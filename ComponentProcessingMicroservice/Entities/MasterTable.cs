using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Entities
{
    public class MasterTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ComponentType { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
        public float ProcessingCharge { get; set; }
        public float PackagingAndDeliveryCharge { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string CreditCardNumber { get; set; }
        public float CreditLimit { get; set; }
    }
}
