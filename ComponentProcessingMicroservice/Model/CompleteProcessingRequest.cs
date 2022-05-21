using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Model
{
    public class CompleteProcessingRequest
    {
        public int RequestId { get; set; }
        public string CreditCardNumber { get; set; }
        public float CreditLimit { get; set; }
        public float ProcessingCharge { get; set; }
    }
}
