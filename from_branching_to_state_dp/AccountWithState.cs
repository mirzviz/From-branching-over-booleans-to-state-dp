using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp;

public class AccountWithState
{
    public double Balance { get; private set; }
    private bool _IsVerified { get; set; }
    private bool _IsClosed { get; set; }

    public bool IsFrozen { get; private set; }
    public Action OnUnfreeze { get; }

    public AccountWithState(Action onUnfreeze)
    {
        Balance = 0;
        OnUnfreeze = onUnfreeze;
    }

    public void Verify()
    {
        _IsVerified = true;
    }

    public void Deposit(double amount)
    {
        if (_IsClosed)
            return;

        if (IsFrozen)
        {
            IsFrozen = false;
            OnUnfreeze();
        }

        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (_IsClosed)
            return;

        if (!_IsVerified)
            return;

        if (IsFrozen)
        {
            IsFrozen = false;
            OnUnfreeze();
        }

        Balance -= amount;
    }

    public void Close()
    {
        _IsClosed = true;
    }

    public void Freeze()
    {
        if (_IsClosed)
            return;
        if (!_IsVerified)
            return;

        IsFrozen = true;
    }

}
