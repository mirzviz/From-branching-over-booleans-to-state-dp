using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp;

public class AccountWithState
{
    public double Balance { get; private set; }

    public IAccountState State;

    public AccountWithState(Action onUnfreeze)
    {
        Balance = 0;
        State = new Unverified(onUnfreeze);
    }

    public void Verify()
    {
        State = State.Verify();
    }

    public void Deposit(double amount)
    {
        State = State.Deposit(() => Balance += amount);
    }

    public void Withdraw(double amount)
    {
        State = State.Withdraw(() => Balance -= amount);
    }

    public void Close()
    {
        State = State.Close();
    }

    public void Freeze()
    {
        State = State.Freeze();
    }

}
