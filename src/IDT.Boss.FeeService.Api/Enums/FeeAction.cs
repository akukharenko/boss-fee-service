namespace IDT.Boss.FeeService.Api.Enums
{
    /// <summary>
    /// Represents 'productized' fee operation.
    /// Based on action type, exception states checks are either used from provided information or from billing address when action was triggered by external job.
    /// </summary>
    public enum FeeAction
    {
        Recharge,
        Autorecharge
    }
}