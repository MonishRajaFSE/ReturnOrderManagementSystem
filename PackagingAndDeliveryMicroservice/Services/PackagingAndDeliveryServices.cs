using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDeliveryMicroservice.Services
{
    public class PackagingAndDeliveryServices
    {
        public float GetPackagingDeliveryCharge(string ComponentType, int Count)
        {
            try
            {
                float result = 0;
                if (ComponentType.Equals("Integral"))
                {
                    result = Count * 300;
                }
                else if (ComponentType.Equals("Accessory"))
                {
                    result = Count * 150;
                }
                else if (ComponentType.Equals("Protective sheath"))
                {
                    result = Count * 50;
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
