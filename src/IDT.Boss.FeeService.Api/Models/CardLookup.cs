using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Full card description (type and network).
    /// </summary>
    public sealed class CardLookup
    {
        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card network (MasterCard, Visa, etc.).
        /// </summary>
        public CardPaymentNetwork PaymentNetwork { get; set; }
    }
}