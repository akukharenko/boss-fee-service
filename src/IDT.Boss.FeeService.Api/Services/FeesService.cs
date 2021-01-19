using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IFeesService
    {
        Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel);
        
        Task<List<DistributorFeeModel>> GetAllByDistributorAsync(int distributorId);
        Task<List<RetailerFeeModel>> GetAllByRetailerAsync(int retailerId);
        
        Task<FeeModel> UpdateDefaultLoadFeeAsync(Channel channel, UpdateLoadFeeModel request);

        Task<DistributorFeeModel> UpdateDistributorIncentiveAsync(int distributorId, UpdateDistributorIncentiveModel model);
        Task<RetailerFeeModel> UpdateRetailerIncentiveAsync(int retailerId, UpdateRetailerIncentiveModel model);

        Task DeleteDistributorIncentiveAsync(int distributorId, DeleteDistributorIncentiveModel model);
        Task DeleteRetailerIncentiveAsync(int retailerId, DeleteRetailerIncentiveModel model);
        
        Task<Fee> GetDistributorFeeAsync(GetDistributorFeeQuery query);
        Task<Fee> GetRetailerFeeAsync(GetRetailerFeeQuery query);
        Task<Fee> GetFeeAsync(GetFeeQuery query);
    }

    // TODO: service can be divided on the 2 separate - for retailers and distributors

    /// <summary>
    /// Simple service to work with fees (default load fees, retailers and distributors incentives).
    /// </summary>
    public sealed class FeesService : IFeesService
    {
        private readonly ILogger<FeesService> _logger;
        private readonly IExceptionStatesService _exceptionStatesService;

        public FeesService(ILogger<FeesService> logger, IExceptionStatesService exceptionStatesService)
        {
            _logger = logger;
            _exceptionStatesService = exceptionStatesService;
        }
        
        public Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel)
        {
            var data = FeeData.Fees.Where(x => x.Channel == channel).ToList();
            return Task.FromResult(data);
        }

        public Task<List<DistributorFeeModel>> GetAllByDistributorAsync(int distributorId)
        {
            var data = FeeData.DistributorFees.Where(x => x.DistributorId == distributorId).ToList();
            return Task.FromResult(data);
        }

        public Task<List<RetailerFeeModel>> GetAllByRetailerAsync(int retailerId)
        {
            var data = FeeData.RetailerFees.Where(x => x.RetailerId == retailerId).ToList();
            return Task.FromResult(data);
        }

        public Task<FeeModel> UpdateDefaultLoadFeeAsync(Channel channel, UpdateLoadFeeModel request)
        {
            // do processing with updates...

            // prepare sample result from request
            var result = new FeeModel
            {
                PaymentType = request.PaymentType,
                CardPaymentNetwork = request.CardPaymentNetwork,
                LoadFee = request.LoadFee
            };

            return Task.FromResult(result);
        }

        public Task<DistributorFeeModel> UpdateDistributorIncentiveAsync(int distributorId, UpdateDistributorIncentiveModel model)
        {
            // do some stuff here...

            var result =  new DistributorFeeModel
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

        public Task DeleteDistributorIncentiveAsync(int distributorId, DeleteDistributorIncentiveModel model)
        {
            // TODO: add some logic here
            return Task.CompletedTask;
        }

        public Task DeleteRetailerIncentiveAsync(int retailerId, DeleteRetailerIncentiveModel model)
        {
            // TODO: add some logic here
            return Task.CompletedTask;
        }

        public Task<Fee> GetDistributorFeeAsync(GetDistributorFeeQuery query)
        {
            // do some stuff to extract proper value for Fees for Distributor

            var result = new Fee
            {
                LoadFee = new LoadFee
                {
                    Value = 3.0
                },
                SalesIncentive = new SalesIncentive
                {
                    Value = -0.5
                }
            };

            return Task.FromResult(result);
        }

        public Task<Fee> GetRetailerFeeAsync(GetRetailerFeeQuery query)
        {
            // do some stuff to extract proper value for Fees for Retailer

            var result = new Fee
            {
                LoadFee = new LoadFee
                {
                    Value = 2.0
                },
                SalesIncentive = new SalesIncentive
                {
                    Value = -0.2
                }
            };

            return Task.FromResult(result);
        }

        public Task<Fee> GetFeeAsync(GetFeeQuery query)
        {
            Fee result = null;
            if (query.UserType == UserType.Distributor)
            {
                result = new Fee
                {
                    LoadFee = new LoadFee
                    {
                        Value = 3.0
                    },
                    SalesIncentive = new SalesIncentive
                    {
                        Value = -0.5
                    }
                };
            }
            else if (query.UserType == UserType.Retailer)
            {
                result = new Fee
                {
                    LoadFee = new LoadFee
                    {
                        Value = 2.0
                    },
                    SalesIncentive = new SalesIncentive
                    {
                        Value = -0.2
                    }
                };
            }

            return Task.FromResult(result);
        }
    }
}