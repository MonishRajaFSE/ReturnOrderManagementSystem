using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PackagingAndDeliveryMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDeliveryMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackagingAndDeliveryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private PackagingAndDeliveryServices _packagingAndDeliveryServices = new PackagingAndDeliveryServices();
        public PackagingAndDeliveryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetPackagingDeliveryCharge")]
        public float GetPackagingDeliveryCharge(string ComponentType,int Count)
        {
            try
            {
                return _packagingAndDeliveryServices.GetPackagingDeliveryCharge(ComponentType, Count);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
