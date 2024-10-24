using System;
using System.Collections.Generic;
using Xunit;

public class UserTests
{
    [Fact]
    public void AccountID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var user = new User();
        Assert.Throws<ArgumentException>(() => user.AccountID = 0);
    }

    [Fact]
    public void SaveAndLoadUsers_ShouldPersistDataCorrectly()
    {
        // Arrange
        var user1 = new User { AccountID = 1, IsAdmin = true };
        var user2 = new User { AccountID = 2, IsAdmin = false };
        User.Users.Add(user1);
        User.Users.Add(user2);

        // Act
        User.SaveUsers();
        User.Users.Clear();
        User.LoadUsers();

        // Assert
        Assert.Equal(2, User.Users.Count);
        Assert.Equal(1, User.Users[0].AccountID);
        Assert.True(User.Users[0].IsAdmin);
        Assert.Equal(2, User.Users[1].AccountID);
        Assert.False(User.Users[1].IsAdmin);
    }
}