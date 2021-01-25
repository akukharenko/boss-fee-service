using System.ComponentModel;

namespace IDT.Boss.FeeService.Api.Enums
{
    // TODO: add hee static list of channels to verify also and use as strong type
    // TODO: think to rename to the country

    public enum Channel
    {
        [Description("Unites States")]
        US,
        [Description("Canada")]
        CA
    }
}
