namespace MonadsJune26;

public static class Either2Extensions
{
    extension<TLeft, TRight>(Either2<TLeft, TRight> either)
    {
        public Either2<TLeft, T> Map<T>(Func<TRight, T> map)
            => either.Match(
                onLeft: Either2<TLeft, T>.Left,
                onRight: right => Either2<TLeft, T>.Right(map(right)));

        public Either2<TLeft, T> Bind<T>(Func<TRight, Either2<TLeft, T>> bind)
            => either.Match(
                onLeft: Either2<TLeft, T>.Left,
                onRight: bind);
    }
}