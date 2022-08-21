using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp;
public class Frozen : IAccountState
{
    private readonly Action _onUnfreeze;

    public Frozen(Action onUnfreeze)
    {
        _onUnfreeze = onUnfreeze;
    }

    public IAccountState Deposit(Action action)
    {
        _onUnfreeze();

        return new Active(_onUnfreeze);
    }

    public IAccountState Withdraw(Action action)
    {
        _onUnfreeze();

        return new Active(_onUnfreeze);
    
    }
    public IAccountState Freeze() => this;

    public IAccountState Close() => new Closed();

    public IAccountState Verify() => this;  
}
