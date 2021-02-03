using System.Collections.Generic;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IFeeService
    {
        /// <summary>
        /// Get all load fees.
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <returns>Returns ths list of all load fees.</returns>
        Task<List<LoadFeeModel>> GetAllLoadFeesByChannelAsync(Channel channel);

        /// <summary>
        /// Get all default fees (load fees and incentives for distributor and retailer).
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <returns>Returns ths list of all default fees.</returns>
        Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel);

        Task<FeeModel> UpdateDefaultLoadFeeAsync(Channel channel, UpdateLoadFeeModel model);
        Task<FeeModel> UpdateDefaultIncentiveAsync(Channel channel, UpdateDefaultIncentiveModel model);

        Task<Fee> GetFeeAsync(GetFeeQuery query);
    }

    public sealed class FeeService: IFeeService
    {
        private readonly ILogger<FeeService> _logger;
        private readonly IExceptionStatesService _exceptionStatesService;

        public FeeService(ILogger<FeeService> logger, IExceptionStatesService exceptionStatesService)
        {
            _logger = logger;
            _exceptionStatesService = exceptionStatesService;
        }

        public Task<List<LoadFeeModel>> GetAllLoadFeesByChannelAsync(Channel channel)
        {
            var data = FeeDataGenerator.GenerateLoadFees(channel);
            return Task.FromResult(data);
        }

        public Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel)
        {
            var data = FeeDataGenerator.GenerateFees(channel);
            return Task.FromResult(data);
        }

        public Task<FeeModel> UpdateDefaultLoadFeeAsync(Channel channel, UpdateLoadFeeModel model)
        {
            // do processing with updates...

            // prepare sample result from request
            var result = new FeeModel
            {
                PaymentType = model.PaymentType,
                CardPaymentNetwork = model.CardPaymentNetwork,
                LoadFee = model.LoadFee
            };

            return Task.FromResult(result);
        }

        public Task<FeeModel> UpdateDefaultIncentiveAsync(Channel channel, UpdateDefaultIncentiveModel model)
        {
            // do processing with updates the records

            var result = new FeeModel
            {
                Channel = channel,
                PaymentType = model.PaymentType,
                CardPaymentNetwork = model.CardPaymentNetwork,
                DistributorIncentive = model.DistributorIncentive,
                RetailerLoadIncentives = model.RetailerIncentives
            };

            return Task.FromResult(result);
        }

        public Task<Fee> GetFeeAsync(GetFeeQuery query)
        {
            var result = FeeDataGenerator.GenerateFee(query.Amount);

            return Task.FromResult(result);
        }
    }
}
