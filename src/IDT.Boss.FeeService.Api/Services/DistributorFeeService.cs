using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IDistributorFeeService
    {
        Task<List<DistributorFeeModel>> GetAllByDistributorAsync(int distributorId);
        Task<DistributorFeeModel> UpdateDistributorIncentiveAsync(int distributorId, UpdateDistributorIncentiveModel model);
        Task DeleteDistributorIncentiveAsync(int distributorId, DeleteDistributorIncentiveModel model);
        Task<Fee> GetDistributorFeeAsync(GetDistributorFeeQuery query);
    }

    public sealed class DistributorFeeService : IDistributorFeeService
    {
        private readonly ILogger<DistributorFeeService> _logger;
        private readonly IExceptionStatesService _exceptionStatesService;

        public DistributorFeeService(ILogger<DistributorFeeService> logger, IExceptionStatesService exceptionStatesService)
        {
            _logger = logger;
            _exceptionStatesService = exceptionStatesService;
        }

        public Task<List<DistributorFeeModel>> GetAllByDistributorAsync(int distributorId)
        {
            //var data = FeeData.DistributorFees.Where(x => x.DistributorId == distributorId).ToList();
            var data = FeeDataGenerator.GenerateDistributorFees(distributorId, Channel.US);
            return Task.FromResult(data);
        }

        public Task<DistributorFeeModel> UpdateDistributorIncentiveAsync(int distributorId, UpdateDistributorIncentiveModel model)
        {
            // do some stuff here...

            var result = new DistributorFeeModel
            {
                DistributorId = distributorId,
                Channel = model.Channel,
                PaymentType = model.PaymentType,
                CardPaymentNetwork = model.CardPaymentNetwork,
                OverrideIncentive = model.Incentive,
                IsIncentiveOverridden = true
            };

            return Task.FromResult(result);
        }

        public Task DeleteDistributorIncentiveAsync(int distributorId, DeleteDistributorIncentiveModel model)
        {
            // TODO: add some logic here
            return Task.CompletedTask;
        }

        public Task<Fee> GetDistributorFeeAsync(GetDistributorFeeQuery query)
        {
            // do some stuff to extract proper value for Fees for Distributor

            var result = FeeDataGenerator.GenerateFee();

            return Task.FromResult(result);
        }
    }
}