using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;

namespace IDT.Boss.FeeService.Api.Data
{
    /// <summary>
    /// Simple static data for different Fees.
    /// </summary>
    public static class FeeData
    {
        /// <summary>
        /// Data for Default fees.
        /// </summary>
        public static readonly IReadOnlyList<FeeModel> Fees = new List<FeeModel>
        {
            new FeeModel
            {
                Id = 1,
                LoadFee = 0.7m,
                DistributorIncentive = -0.1m,
                RetailerIncentive = new RetailerSalesIncentive {
                    PlatinumIncentive = -0.5m,
                    GoldIncentive = -0.4m,
                    SilverIncentive = -0.3m,
                    BronzeIncentive = -0.1m,
                    NoLevelIncentive = 0.0m
                },
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.AmEx,
                Channel = Channel.US
            },
            new FeeModel
            {
                Id = 2,
                LoadFee = 3.0m,
                DistributorIncentive = 2.0m,
                RetailerIncentive = new RetailerSalesIncentive {
                    PlatinumIncentive = -0.9m,
                    GoldIncentive = -0.5m,
                    SilverIncentive = -0.3m,
                    BronzeIncentive = -0.1m,
                    NoLevelIncentive = 0.0m
                },
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.Mastercard,
                Channel = Channel.US
            }
        };

        /// <summary>
        /// Data for distributors fees.
        /// </summary>
        public static readonly IReadOnlyList<DistributorFeeModel> DistributorFees = new List<DistributorFeeModel>
        {
            new DistributorFeeModel
            {
                DistributorId = 1,
                LoadFee = 0.7m,
                DefaultIncentive = -0.1m,
                OverrideIncentive = 0.0m,
                IsIncentiveOverridden = false,
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.AmEx,
                Channel = Channel.US
            },
            new DistributorFeeModel
            {
                DistributorId = 2,
                LoadFee = 0.6m,
                DefaultIncentive = -0.1m,
                OverrideIncentive = -0.5m,
                IsIncentiveOverridden = true,
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.Mastercard,
                Channel = Channel.US
            }
        };

        /// <summary>
        /// Data for retailers fees.
        /// </summary>
        public static readonly IReadOnlyList<RetailerFeeModel> RetailerFees = new List<RetailerFeeModel>
        {
            new RetailerFeeModel
            {
                RetailerId = 1,
                LoadFeeValue = 0.7m,
                RetailerDefaultIncentive = new RetailerSalesIncentive
                {
                    PlatinumIncentive = -0.5m,
                    GoldIncentive = -0.4m,
                    SilverIncentive = -0.3m,
                    BronzeIncentive = -0.1m,
                    NoLevelIncentive = 0.0m
                },
                RetailerIncentiveOverride = new RetailerSalesIncentive
                {
                    PlatinumIncentive = -0.5m,
                    GoldIncentive = -0.4m,
                    SilverIncentive = -0.3m,
                    BronzeIncentive = -0.1m,
                    NoLevelIncentive = 0.0m
                },
                IsIncentiveOverridden = false,
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.AmEx,
                Channel = Channel.US
            },
            new RetailerFeeModel
            {
                RetailerId = 2,
                LoadFeeValue = 0.7m,
                RetailerDefaultIncentive = new RetailerSalesIncentive
                {
                    PlatinumIncentive = -0.5m,
                    GoldIncentive = -0.4m,
                    SilverIncentive = -0.3m,
                    BronzeIncentive = -0.1m,
                    NoLevelIncentive = 0.0m
                },
                RetailerIncentiveOverride = new RetailerSalesIncentive
                {
                    PlatinumIncentive = -0.8m,
                    GoldIncentive = -0.6m,
                    SilverIncentive = -0.4m,
                    BronzeIncentive = -0.2m,
                    NoLevelIncentive = -0.1m
                },
                IsIncentiveOverridden = true,
                PaymentType = PaymentType.CreditCard,
                CardPaymentNetwork = CardPaymentNetwork.AmEx,
                Channel = Channel.US
            }
        };
    }
}
