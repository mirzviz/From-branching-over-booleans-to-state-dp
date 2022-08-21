using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp;

public class Unverified : IAccountState
{
    private Action _OnUnfreeze;

    public Unverified(Action onUnfreeze)
    {
        _OnUnfreeze = onUnfreeze;
    }

    public IAccountState Close() => new Closed();

    public IAccountState Deposit(Action action)
    {
        action();

        return this;
    }

    public IAccountState Withdraw(Action action) => this;

    public IAccountState Freeze() => this;

    public IAccountState Verify() => new Active(_OnUnfreeze);   

}
