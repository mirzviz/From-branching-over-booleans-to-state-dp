using from_branching_to_state_dp;
using Xunit;

namespace from_branching_to_state_dp_tests
{
    public class AccountUT
    {
        [Fact]
        public void Account_One_Deposit()
        {
            //Arrange
            var account = new Account();
            //Act
            account.Deposit(10);
            //Assert
            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void Account_Two_Deposits()
        {
            //Arrange
            var account = new Account();
            //Act
            account.Deposit(10);
            account.Deposit(2);
            //Assert
            Assert.Equal(12, account.Balance);
        }

        [Fact]
        public void Account_Withdraw_Without_Verification_Wont_Work()
        {
            //Arrange
            var account = new Account();
            //Act
            account.Deposit(5);
            account.Withdraw(4);
            //Assert
            Assert.Equal(5, account.Balance);
        }

        [Fact]
        public void Account_Withdraw_With_Verification_Works()
        {
            //Arrange
            var account = new Account();
            //Act
            account.Deposit(5);
            account.Verify();
            account.Withdraw(4);
            //Assert
            Assert.Equal(1, account.Balance);
        }
    }
}