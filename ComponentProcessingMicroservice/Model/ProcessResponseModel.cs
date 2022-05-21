using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Model
{
    public class ProcessResponseModel
    {
        public int RequestId { get; set; }
        public float ProcessingCharge { get; set; }
        public float PackagingAndDeliveryCharge { get; set; }
        public DateTime DateOfDelivery { get; set; }
    }
}
