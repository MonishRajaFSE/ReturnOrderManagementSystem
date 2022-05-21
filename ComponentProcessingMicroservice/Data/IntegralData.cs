using ComponentProcessingMicroservice.Interface;
using ComponentProcessingMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Data
{
    public class IntegralData : IComponentProcessing
    {
        public ServicingModel CalculateChargeAndDuration(int Quantity)
        {
            try
            {
                var servicingModel = new ServicingModel();
                servicingModel.ProcessingCharge = Quantity * 500;
                servicingModel.DateOfDelivery = DateTime.Now.AddDays(5);
                return servicingModel;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
