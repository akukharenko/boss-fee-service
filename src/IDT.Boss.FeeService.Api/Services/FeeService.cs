using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IFeeService
    {
        Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel);

        Task<FeeModel> UpdateDefaultLoadFeeAsync(Channel channel, UpdateLoadFeeModel request);
        
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

        public Task<List<FeeModel>> GetAllDefaultFeesByChannelAsync(Channel channel)
        {
            //var data = FeeData.Fees.Where(x => x.Channel == channel).ToList();
            var data = FeeDataGenerator.GenerateFees(channel);
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

        public Task<Fee> GetFeeAsync(GetFeeQuery query)
        {
            var result = FeeDataGenerator.GenerateFee();

            return Task.FromResult(result);
        }
    }
}
