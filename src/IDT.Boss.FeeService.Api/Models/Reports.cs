using System;
using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    // TODO: need to add support for paging and return data by chunks (to optimize data sending over http)

    /// <summary>
    /// Model with the data for report with distributor fees.
    /// </summary>
    public sealed class DistributorReportModel
    {
        /// <summary>
        /// List of items for the report.
        /// </summary>
        public List<DistributorReportRow> Items { get; set; }
    }

    /// <summary>
    /// Distributor override incentive data for report.
    /// </summary>
    public sealed class DistributorReportRow
    {
        /// <summary>
        /// Distributor id.
        /// </summary>
        public int DistributorId { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Load fee (shared for all the distributors).
        /// </summary>
        public decimal LoadFee { get; set; }

        /// <summary>
        /// Overriden sales incentive.
        /// </summary>
        public decimal IncentiveOverride { get; set; }

        /// <summary>
        /// Default sales incentive.
        /// </summary>
        public decimal DefaultIncentive { get; set; }

        /// <summary>
        /// When record was updated last time.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Model with the data for report with retailer fees.
    /// </summary>
    public sealed class RetailerReportModel
    {
        /// <summary>
        /// List of items for the report.
        /// </summary>
        public List<RetailerReportRow> Items { get; set; }
    }

    /// <summary>
    /// Retailer override incentive data for report.
    /// </summary>
    public sealed class RetailerReportRow
    {
        /// <summary>
        /// Retailer Id.
        /// </summary>
        public int RetailerId { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Load fee (shared for all the retailers).
        /// </summary>
        public decimal LoadFee { get; set; }

        /// <summary>
        /// Reward level for sales incentive.
        /// </summary>
        public RewardLevel RewardLevel { get; set; }

        /// <summary>
        /// Overriden sales incentive.
        /// </summary>
        public decimal IncentiveOverride { get; set; }

        /// <summary>
        /// Default sales incentive.
        /// </summary>
        public decimal DefaultIncentive { get; set; }

        /// <summary>
        /// When record was updated last time.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
