using ComponentProcessingMicroservice.Interface;
using ComponentProcessingMicroservice.Model;
using ComponentProcessingMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComponentProcessingController : ControllerBase
    {
        private readonly ILogger<ComponentProcessingController> _logger;
        private readonly IConfiguration _configuration;
        private ComponentProcessingServices _componentProcessingServices;
        public ComponentProcessingController(ILogger<ComponentProcessingController> logger,IConfiguration configuration,Func<ServiceEnum, IComponentProcessing> serviceResolver)
        {
            _logger = logger;
            _configuration = configuration;
            _componentProcessingServices = new ComponentProcessingServices(serviceResolver);
        }
        [HttpGet("ProcessDetail")]
        public ProcessResponseModel ProcessDetail(string Name, string ContactNumber, string ComponentType, string ComponentName, int Quantity)
        {
            try
            {
                _logger.LogInformation("ProcessDetail - Calculation");
                ProcessResponseModel response = _componentProcessingServices.Calculate(new ProcessRequestModel(Name, ContactNumber, ComponentType, ComponentName, Quantity), Request);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error - {ex}");
                throw ex;
            }
        }
        [HttpPost("CompleteProcessing")]
        public bool CompleteProcessing([FromBody] CompleteProcessingRequest request)
        {
            try
            {
                _logger.LogInformation("CompleteProcessing - Saving Process details to DB");
                return _componentProcessingServices.CompleteProcessing(request);
            }
            catch (Exception ex) {
                _logger.LogError($"Error - {ex}");
                throw ex;
            }
        }
    }
}
