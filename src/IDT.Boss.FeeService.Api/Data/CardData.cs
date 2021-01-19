using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;

namespace IDT.Boss.FeeService.Api.Data
{
    /// <summary>
    /// Sample data for cards.
    /// </summary>
    public static class CardData
    {
        /// <summary>
        /// All possible combinations for the Card Type - Network supported by the application.
        /// </summary>
        public static readonly IReadOnlyList<CardLookup> CardsLookups = new List<CardLookup>
        {
            new CardLookup
            {
                PaymentType = PaymentType.CreditCard,
                PaymentNetwork = CardPaymentNetwork.AmEx
            },
            new CardLookup
            {
                PaymentType = PaymentType.DebitCard,
                PaymentNetwork = CardPaymentNetwork.AmEx
            },
            new CardLookup
            {
                PaymentType = PaymentType.CreditCard,
                PaymentNetwork = CardPaymentNetwork.Mastercard
            },
            new CardLookup
            {
                PaymentType = PaymentType.DebitCard,
                PaymentNetwork = CardPaymentNetwork.Mastercard
            },
            new CardLookup
            {
                PaymentType = PaymentType.CreditCard,
                PaymentNetwork = CardPaymentNetwork.Discover
            },
            new CardLookup
            {
                PaymentType = PaymentType.DebitCard,
                PaymentNetwork = CardPaymentNetwork.Discover
            },
            new CardLookup
            {
                PaymentType = PaymentType.CreditCard,
                PaymentNetwork = CardPaymentNetwork.Visa
            },
            new CardLookup
            {
                PaymentType = PaymentType.DebitCard,
                PaymentNetwork = CardPaymentNetwork.Visa
            }
        };
    }
}
