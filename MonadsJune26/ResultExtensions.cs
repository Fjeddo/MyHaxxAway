namespace MonadsJune26;

public static class ResultExtensions
{
    extension<T>(Result<T> result) where T : notnull
    {
        public Result<TOut> Map<TOut>(Func<T, TOut> func) where TOut : notnull 
            => result.Match(
                onSuccess: value => new Result<TOut>(func(value)),
                onFailure: error => new Result<TOut>(error));

        public Result<TOut> Bind<TOut>(Func<T, Result<TOut>> func) where TOut : notnull 
            => result.Match(
                onSuccess: func,
                onFailure: error => new Result<TOut>(error));
    }
}