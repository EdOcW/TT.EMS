namespace TT.EMS.Domain.Shared
{
    public sealed record Error(string Code, string Message)
    {
        public static readonly Error None = new (string.Empty, string.Empty);

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;
    }
}