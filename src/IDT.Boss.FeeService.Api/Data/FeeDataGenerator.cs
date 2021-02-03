using System;
using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;

namespace IDT.Boss.FeeService.Api.Data
{
    /// <summary>
    /// Simple generators to the fake data to show as sample in the API.
    /// </summary>
    public static class FeeDataGenerator
    {
        private static readonly Random Rand = new Random();

        public static List<LoadFeeModel> GenerateLoadFees(Channel channel)
        {
            var cardCombinations = CardData.CardsLookups;

            var result = new List<LoadFeeModel>();
            int index = 1;
            foreach (var cardCombination in cardCombinations)
            {
                result.Add(new LoadFeeModel
                {
                    Id = index,
                    PaymentType = cardCombination.PaymentType,
                    CardPaymentNetwork = cardCombination.PaymentNetwork,
                    Channel = channel,
                    LoadFee = GetRandomValue(false)
                });

                index++;
            }

            return result;
        }

        public static List<FeeModel> GenerateFees(Channel channel)
        {
            var cardCombinations = CardData.CardsLookups;

            var result = new List<FeeModel>();
            int index = 1;
            foreach (var cardCombination in cardCombinations)
            {
                result.Add(new FeeModel
                {
                    Id = index,
                    PaymentType = cardCombination.PaymentType,
                    CardPaymentNetwork = cardCombination.PaymentNetwork,
                    Channel = channel,
                    LoadFee = GetRandomValue(false),
                    DistributorIncentive = GetRandomValue(true),
                    RetailerLoadIncentives = new RetailerLoadIncentive
                    {
                        PlatinumIncentive = GetRandomValue(true),
                        GoldIncentive = GetRandomValue(true),
                        SilverIncentive = GetRandomValue(true),
                        BronzeIncentive = GetRandomValue(true),
                        NoLevelIncentive = GetRandomValue(true)
                    }
                });

                index++;
            }

            return result;
        }

        public static List<DistributorFeeModel> GenerateDistributorFees(int distributorId, Channel channel)
        {
            var cardCombinations = CardData.CardsLookups;

            var result = new List<DistributorFeeModel>();
            int index = 1;
            foreach (var cardCombination in cardCombinations)
            {
                result.Add(new DistributorFeeModel
                {
                    DistributorId = distributorId,
                    PaymentType = cardCombination.PaymentType,
                    CardPaymentNetwork = cardCombination.PaymentNetwork,
                    Channel = channel,
                    LoadFee = GetRandomValue(false),
                    DefaultIncentive = GetRandomValue(true),
                    OverrideIncentive = GetRandomValue(true),
                    IsIncentiveOverridden = true
                });

                index++;
            }

            return result;
        }

        public static List<RetailerFeeModel> GenerateRetailerFees(int retailerId, Channel channel)
        {
            var cardCombinations = CardData.CardsLookups;

            var result = new List<RetailerFeeModel>();
            int index = 1;
            foreach (var cardCombination in cardCombinations)
            {
                result.Add(new RetailerFeeModel
                {
                    RetailerId = retailerId,
                    PaymentType = cardCombination.PaymentType,
                    CardPaymentNetwork = cardCombination.PaymentNetwork,
                    Channel = channel,
                    LoadFee = GetRandomValue(false),
                    RetailerDefaultIncentives = new RetailerLoadIncentive
                    {
                        PlatinumIncentive = GetRandomValue(true),
                        GoldIncentive = GetRandomValue(true),
                        SilverIncentive = GetRandomValue(true),
                        BronzeIncentive = GetRandomValue(true),
                        NoLevelIncentive = GetRandomValue(true)
                    },
                    RetailerIncentiveOverride = new RetailerLoadIncentive
                    {
                        PlatinumIncentive = GetRandomValue(true),
                        GoldIncentive = GetRandomValue(true),
                        SilverIncentive = GetRandomValue(true),
                        BronzeIncentive = GetRandomValue(true),
                        NoLevelIncentive = GetRandomValue(true)
                    },
                    IsIncentiveOverridden = true
                });

                index++;
            }

            return result;
        }

        public static Fee GenerateFee(int inAmount)
        {
            // TODO: update calculation depends on the values how we store it (fee as positive and incentive as negative)
            var fee = GetRandomValue(false);
            var incentive = GetRandomValue(true);

            var feeAmount = inAmount/100.0m * fee;
            var incentiveAmount = inAmount/100.0m * incentive;
            var amount = inAmount/100.0m + (feeAmount + incentiveAmount);

            return new Fee
            {
                Amount = amount,
                LoadFee = new LoadFee
                {
                    Amount = feeAmount,
                    Percentage = fee
                },
                LoadIncentive = new LoadIncentive
                {
                    Amount = incentiveAmount,
                    Percentage = incentive
                }
            };
        }

        private static decimal GetRandomValue(bool isNegative)
        {
            var value = Rand.Next(1, 10);
            var tmp = (decimal) value / 100;
            if (isNegative) return -tmp;
            return tmp;
        }

        public static DistributorReportModel GenerateDistributorReport(Channel channel, int rowCount = 10)
        {
            var result = new DistributorReportModel
            {
                Items = new List<DistributorReportRow>()
            };
            for (var i = 0; i < rowCount; i++)
            {
                result.Items.Add(new DistributorReportRow
                {
                    DistributorId = i + 1,
                    PaymentType = PaymentType.DebitCard,
                    CardPaymentNetwork = CardPaymentNetwork.Mastercard,
                    LoadFee = GetRandomValue(false),
                    DefaultIncentive = GetRandomValue(true),
                    IncentiveOverride = GetRandomValue(true),
                    UpdatedAt = DateTime.Today.AddDays(-10)
                });
            }

            return result;
        }

        public static RetailerReportModel GenerateRetailerReport(Channel channel, int rowCount = 10)
        {
            var result = new RetailerReportModel
            {
                Items = new List<RetailerReportRow>()
            };
            for (var i = 0; i < rowCount; i++)
            {
                result.Items.Add(new RetailerReportRow
                {
                    RetailerId = i + 1,
                    PaymentType = PaymentType.DebitCard,
                    CardPaymentNetwork = CardPaymentNetwork.Mastercard,
                    LoadFee = GetRandomValue(false),
                    DefaultIncentive = GetRandomValue(true),
                    IncentiveOverride = GetRandomValue(true),
                    RewardLevel = RewardLevel.Silver,
                    UpdatedAt = DateTime.Today.AddDays(-10)
                });
            }

            return result;
        }
    }
}