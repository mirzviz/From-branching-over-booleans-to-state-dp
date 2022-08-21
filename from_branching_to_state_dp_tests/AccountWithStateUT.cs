using from_branching_to_state_dp;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace from_branching_to_state_dp_tests;

public class AccountWithStateUT
{
    [Fact]
    public void Account_One_Deposit()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Deposit(10);
        //Assert
        Assert.Equal(10, account.Balance);
    }

    [Fact]
    public void Account_Two_Deposits()
    {
        //Arrange
        var account = new AccountWithState(() => { });
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
        var account = new AccountWithState(() => { });
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
        var account = new AccountWithState(() => { });
        //Act
        account.Deposit(5);
        account.Verify();
        account.Withdraw(4);
        //Assert
        Assert.Equal(1, account.Balance);
    }

    [Fact]
    public void Account_Closed_Withdraw_Wont_Work()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Deposit(5);
        account.Close();
        account.Withdraw(4);
        //Assert
        Assert.Equal(5, account.Balance);
    }

    [Fact]
    public void Freezing_Account_Works()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Verify();
        account.Freeze();
        //Assert
        Assert.True(account.IsFrozen);
    }

    [Fact]
    public void Unverified_Account_Cant_Be_Frozen()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Freeze();
        //Assert
        Assert.False(account.IsFrozen);
    }

    [Fact]
    public void Closed_Account_Cant_Be_Frozen()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Verify();
        account.Close();
        account.Freeze();
        //Assert
        Assert.False(account.IsFrozen);
    }

    [Fact]
    public void Frozen_Account_Deposit_Will_Be_Unfrozen()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Verify();
        account.Freeze();
        account.Deposit(5);
        //Assert
        Assert.False(account.IsFrozen);
    }

    [Fact]
    public void Frozen_Account_Withdraw_Will_Be_Unfrozen()
    {
        //Arrange
        var account = new AccountWithState(() => { });
        //Act
        account.Verify();
        account.Freeze();
        account.Withdraw(5);
        //Assert
        Assert.False(account.IsFrozen);
    }

    [Fact]
    public void Unfreezing_Account_By_Withdraw_Will_Call_Callback()
    {
        //Arrange
        var mock = new Mock<Action>();
        var account = new AccountWithState(mock.Object);
        //Act
        account.Verify();
        account.Freeze();
        account.Withdraw(5);
        //Assert
        mock.Verify(a => a(), Times.Once());
    }

    [Fact]
    public void Unfreezing_Account_By_Deposit_Will_Call_Callback()
    {
        //Arrange
        var mock = new Mock<Action>();
        var account = new AccountWithState(mock.Object);
        //Act
        account.Verify();
        account.Freeze();
        account.Deposit(5);
        //Assert
        mock.Verify(a => a(), Times.Once());
    }

    [Fact]
    public void Unfreezen_Account_Deposit_Will_Not_Call_Callback()
    {
        //Arrange
        var mock = new Mock<Action>();
        var account = new AccountWithState(mock.Object);
        //Act
        account.Verify();
        account.Deposit(5);
        //Assert
        mock.Verify(a => a(), Times.Never);
    }
}
