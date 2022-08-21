namespace from_branching_to_state_dp;

public interface IAccountState
{
    IAccountState Freeze();
    IAccountState Deposit(Action action);
    IAccountState Withdraw(Action action);
    IAccountState Close();
    IAccountState Verify();
}
