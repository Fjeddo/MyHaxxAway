namespace MonadsJune26;

public abstract record Either2<TLeft, TRight>
{
    public abstract T Match<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight);

    public static Either2<TLeft, TRight> Left(TLeft left) => new Left2Impl(left);
    public static Either2<TLeft, TRight> Right(TRight right) => new Right2Impl(right);
    
    private record Left2Impl(TLeft Value) : Either2<TLeft, TRight>
    {
        public override T Match<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight) => onLeft(Value);
    }

    private record Right2Impl(TRight Value) : Either2<TLeft, TRight>
    {
        public override T Match<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight) => onRight(Value);
    }
}