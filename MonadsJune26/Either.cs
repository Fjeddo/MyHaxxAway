using System.Diagnostics;

namespace MonadsJune26;

public readonly struct Either<TLeft, TRight>
{
    private readonly TLeft _left = default!;
    private readonly TRight _right = default!;
    private readonly bool _isLeft = false;

    public Either(TLeft left)
    {
        _left = left;
        _isLeft = true;
    }

    public Either(TRight right)
    {
        _right = right;
        _isLeft = false;
    }

    public TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight)
        => _isLeft
            ? onLeft(_left)
            : _right != null
                ? onRight(_right)
                : throw new UnreachableException("Left or Right must be a valid Either");
}