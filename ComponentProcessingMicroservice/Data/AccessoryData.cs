using ComponentProcessingMicroservice.Interface;
using ComponentProcessingMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Data
{
    public class AccessoryData : IComponentProcessing
    {
        public ServicingModel CalculateChargeAndDuration(int Quantity)
        {
            try
            {
                var servicingModel = new ServicingModel();
                servicingModel.ProcessingCharge = Quantity * 300;
                servicingModel.DateOfDelivery = DateTime.Now.AddDays(2).Date;
                return servicingModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
