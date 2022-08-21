using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp;

public class Closed : IAccountState
{
    public IAccountState Close() => this;

    public IAccountState Deposit(Action action) => this;

    public IAccountState Withdraw(Action action) => this;

    public IAccountState Freeze() => this;

    public IAccountState Verify() => this;

}
