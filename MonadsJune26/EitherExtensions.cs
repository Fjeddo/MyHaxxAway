namespace MonadsJune26;

public static class EitherExtensions
{
    extension<TLeft, TRight>(Either<TLeft, TRight> either)
    {
        public Either<TLeft, T> Map<T>(Func<TRight, T> map)
            => either.Match(
                onLeft: left => new Either<TLeft, T>(left: left),
                onRight: right => new Either<TLeft, T>(right: map(right)));

        public Either<TLeft, T> Bind<T>(Func<TRight, Either<TLeft, T>> bind)
            => either.Match(
                onLeft: left => new Either<TLeft, T>(left: left),
                onRight: bind);
    }
}