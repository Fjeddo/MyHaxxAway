namespace MonadsJune26;

public abstract record Either2<TLeft, TRight>
{
    public abstract TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight);

    public static Either2<TLeft, TRight> Left(TLeft left) => new Left2Impl(left);
    public static Either2<TLeft, TRight> Right(TRight right) => new Right2Impl(right);
    
    private sealed record Left2Impl(TLeft Value) : Either2<TLeft, TRight>
    {
        public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight) => onLeft(Value);
    }

    private sealed record Right2Impl(TRight Value) : Either2<TLeft, TRight>
    {
        public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight) => onRight(Value);
    }
}