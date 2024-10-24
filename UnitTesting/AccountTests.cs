using System;
using System.Collections.Generic;
using Xunit;

public class AccountTests
{
    [Fact]
    public void AccountID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var account = new Account();
        Assert.Throws<ArgumentException>(() => account.AccountID = 0);
    }

    [Fact]
    public void Username_ShouldThrowException_WhenValueIsEmpty()
    {
        var account = new Account();
        Assert.Throws<ArgumentException>(() => account.Username = "");
    }

    [Fact]
    public void SaveAndLoadAccounts_ShouldPersistDataCorrectly()
    {
        // Arrange
        var account1 = new Account { AccountID = 1, Username = "User1" };
        var account2 = new Account { AccountID = 2, Username = "User2" };
        Account.Accounts.Add(account1);
        Account.Accounts.Add(account2);

        // Act
        Account.SaveAccounts();
        Account.Accounts.Clear();
        Account.LoadAccounts();

        // Assert
        Assert.Equal(2, Account.Accounts.Count);
        Assert.Equal(1, Account.Accounts[0].AccountID);
        Assert.Equal("User1", Account.Accounts[0].Username);
        Assert.Equal(2, Account.Accounts[1].AccountID);
        Assert.Equal("User2", Account.Accounts[1].Username);
    }
}