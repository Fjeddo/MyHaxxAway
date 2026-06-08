namespace MonadsJune26;

public abstract record Maybe<T>
{
    private record Some(T Value) : Maybe<T>
    {
        public override TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) => some(Value);
    }

    private record None() : Maybe<T>
    {
        public override TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) => none();
    }

    public abstract TOut Match<TOut>(Func<T,TOut> some, Func<TOut> none);
}