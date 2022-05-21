using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Model
{
    public class ProcessRequestModel
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ComponentType { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
        public ProcessRequestModel(string Name, string ContactNumber, string ComponentType, string ComponentName, int Quantity)
        {
            this.Name = Name;
            this.ContactNumber = ContactNumber;
            this.ComponentType = ComponentType;
            this.ComponentName = ComponentName;
            this.Quantity = Quantity;
        }
    }
}
