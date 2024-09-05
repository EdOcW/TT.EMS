namespace TT.EMS.Domain.Shared;

public sealed class Result<TValue> : Result
{
    private readonly TValue _value;

    internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error) =>
        _value = value;

    public TValue Value =>
        IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}