namespace from_branching_to_state_dp;

public class Active : IAccountState
{
    private Action _onUnfreeze;

    public Active(Action onUnfreeze)
    {
        _onUnfreeze = onUnfreeze;
    }

    public IAccountState Deposit(Action action)
    {
        action();
        return this;
    }

    public IAccountState Withdraw(Action action)
    {
        action();
        return this;
    }

    public IAccountState Freeze() => new Frozen(_onUnfreeze);

    public IAccountState Close() => new Closed();

    public IAccountState Verify() => this;
}
