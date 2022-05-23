using ComponentProcessingMicroservice.Data;
using ComponentProcessingMicroservice.Interface;
using ComponentProcessingMicroservice.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Services
{
    public class ComponentProcessingServices
    {
        private readonly Func<ServiceEnum, IComponentProcessing> _icomponentProcessing;
        public DBHelper dbHelper;
        public ComponentProcessingServices(Func<ServiceEnum, IComponentProcessing> icomponentProcessing)
        {
            this._icomponentProcessing = icomponentProcessing;
            dbHelper = new DBHelper();
        }
        public delegate IComponentProcessing ServiceResolver(ServiceType serviceType);
        public ProcessResponseModel Calculate(ProcessRequestModel request,HttpRequest httpRequest)
        {
            try
            {
                int requestID = dbHelper.SaveRequest(request);
                var accessToken = httpRequest.Headers[HeaderNames.Authorization];
                var response = new ProcessResponseModel();
                var servicingModel = new ServicingModel();
                if (request.ComponentType.Equals("Integral"))
                {
                    servicingModel = this._icomponentProcessing(ServiceEnum.Integral).CalculateChargeAndDuration(request.Quantity);
                }
                else if (request.ComponentType.Equals("Accessory"))
                {
                    servicingModel = this._icomponentProcessing(ServiceEnum.Accessory).CalculateChargeAndDuration(request.Quantity);
                }
                response.RequestId = requestID;
                response.ProcessingCharge = servicingModel.ProcessingCharge;
                response.PackagingAndDeliveryCharge = GetPackaginAndDeliveryCharge(request.ComponentType, request.Quantity, accessToken).Result;
                response.DateOfDelivery = servicingModel.DateOfDelivery;
                dbHelper.SaveResponse(response);
                return response;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<float> GetPackaginAndDeliveryCharge(string ComponentType, int Quantity,string token)
        {
            try
            {
                string res = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://20.232.51.195/api/PackagingAndDelivery/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    //GET Method
                    string route = "GetPackagingDeliveryCharge?ComponentType=" + ComponentType + "&Count=" + Quantity;
                    HttpResponseMessage response = await client.GetAsync(route);
                    if (response.IsSuccessStatusCode)
                    {
                        res = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
                return float.Parse(res);
            }
            catch (Exception ex) { throw ex; }
        }
        public bool CompleteProcessing(CompleteProcessingRequest request)
        {
            try
            {
                return dbHelper.SaveCompleteProcessingRequest(request);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
