using ComponentProcessingMicroservice.DBContexts;
using ComponentProcessingMicroservice.Entities;
using ComponentProcessingMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Data
{
    public class DBHelper
    {
        public DBContext _userContext;
        public DBHelper()
        {
            _userContext = new DBContext();
        }
        public void SaveResponse(ProcessResponseModel response)
        {
            try
            {
                var entity = _userContext.MasterTable.FirstOrDefault(item => item.RequestId == response.RequestId);
                if (entity != null)
                {
                    entity.ProcessingCharge = response.ProcessingCharge;
                    entity.PackagingAndDeliveryCharge = response.PackagingAndDeliveryCharge;
                    entity.DateOfDelivery = response.DateOfDelivery;
                    _userContext.MasterTable.Update(entity);
                    _userContext.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public bool SaveCompleteProcessingRequest(CompleteProcessingRequest request)
        {
            try
            {
                var entity = _userContext.MasterTable.FirstOrDefault(item => item.RequestId == request.RequestId);
                if (entity != null)
                {
                    entity.CreditCardNumber = request.CreditCardNumber;
                    entity.CreditLimit = request.CreditLimit;
                    entity.ProcessingCharge = request.ProcessingCharge;
                    _userContext.MasterTable.Update(entity);
                    _userContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public int SaveRequest(ProcessRequestModel request)
        {
            try
            {
                var masterTable = new MasterTable();
                masterTable.Name = request.Name;
                masterTable.ContactNumber = request.ContactNumber;
                masterTable.ComponentType = request.ComponentType;
                masterTable.ComponentName = request.ComponentName;
                masterTable.Quantity = request.Quantity;
                _userContext.MasterTable.Add(masterTable);
                _userContext.SaveChanges();
                return masterTable.RequestId;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
