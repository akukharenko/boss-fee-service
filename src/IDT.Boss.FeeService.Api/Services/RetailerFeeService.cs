using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IRetailerFeeService
    {
        Task<List<RetailerFeeModel>> GetAllByRetailerAsync(int retailerId);
        Task<RetailerFeeModel> UpdateRetailerIncentiveAsync(int retailerId, UpdateRetailerIncentiveModel model);
        Task DeleteRetailerIncentiveAsync(int retailerId, DeleteRetailerIncentiveModel model);
        Task<Fee> GetRetailerFeeAsync(GetRetailerFeeQuery query);
    }

    public sealed class RetailerFeeService : IRetailerFeeService
    {
        private readonly ILogger<RetailerFeeService> _logger;
        private readonly IExceptionStatesService _exceptionStatesService;

        public RetailerFeeService(ILogger<RetailerFeeService> logger, IExceptionStatesService exceptionStatesService)
        {
            _logger = logger;
            _exceptionStatesService = exceptionStatesService;
        }

        public Task<List<RetailerFeeModel>> GetAllByRetailerAsync(int retailerId)
        {
            //var data = FeeData.RetailerFees.Where(x => x.RetailerId == retailerId).ToList();
            var data = FeeDataGenerator.GenerateRetailerFees(retailerId, Channel.US);
            return Task.FromResult(data);
        }

        public Task<RetailerFeeModel> UpdateRetailerIncentiveAsync(int retailerId, UpdateRetailerIncentiveModel model)
        {
            // do some stuff here...

            var result = new RetailerFeeModel
            {
                RetailerId = retailerId,
                Channel = model.Channel,
                PaymentType = model.PaymentType,
                CardPaymentNetwork = model.CardPaymentNetwork,
                RetailerIncentiveOverride = model.Incentives,
                IsIncentiveOverridden = true
            };

            return Task.FromResult(result);
        }

        public Task DeleteRetailerIncentiveAsync(int retailerId, DeleteRetailerIncentiveModel model)
        {
            // TODO: add some logic here
            return Task.CompletedTask;
        }

        public Task<Fee> GetRetailerFeeAsync(GetRetailerFeeQuery query)
        {
            // do some stuff to extract proper value for Fees for Retailer

            var result = FeeDataGenerator.GenerateFee(query.Amount);

            return Task.FromResult(result);
        }
    }
}
