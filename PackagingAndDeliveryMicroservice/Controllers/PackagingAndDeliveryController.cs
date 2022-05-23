using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PackagingAndDeliveryController> _logger;
        private readonly IConfiguration _configuration;
        private PackagingAndDeliveryServices _packagingAndDeliveryServices = new PackagingAndDeliveryServices();
        public PackagingAndDeliveryController(IConfiguration configuration, ILogger<PackagingAndDeliveryController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetPackagingDeliveryCharge")]
        public float GetPackagingDeliveryCharge(string ComponentType,int Count)
        {
            try
            {
                _logger.LogInformation("GetPackagingDeliveryCharge - Getting Packaging and Delivery Charges");
                return _packagingAndDeliveryServices.GetPackagingDeliveryCharge(ComponentType, Count);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error - {ex}");
                throw ex;
            }
        }
    }
}
