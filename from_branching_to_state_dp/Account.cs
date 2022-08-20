using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_branching_to_state_dp
{
    public class Account
    {
        public double Balance { get; private set; }
        private bool _IsVerified { get; set; }

        public Account()
        {
            Balance = 0;
        }

        public Account(double balance)
        {
            Balance = balance;
        }

        public void Verify()
        {
            _IsVerified = true;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (!_IsVerified)
                return;

            Balance -= amount;
        }
    }
}
