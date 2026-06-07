namespace MonadsJune26;

public struct Error;

public readonly record struct Result<T> where T: notnull
{
    private readonly T _value;
    private readonly Error _error;
    private readonly bool _hasValue;
    
    public Result(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        _hasValue = true;
        _value = value;
    }

    public Result(Error error)
    {
        _hasValue = false;
        _error = error;
        _value = default!;
    }

    public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<Error, TOut> onFailure) 
        => _hasValue ? onSuccess(_value) : onFailure(_error);
}