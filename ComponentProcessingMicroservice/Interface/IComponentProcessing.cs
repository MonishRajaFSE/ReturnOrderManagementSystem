using ComponentProcessingMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Interface
{
    public interface IComponentProcessing
    {
        public ServicingModel CalculateChargeAndDuration(int Quantity);
    }
}
