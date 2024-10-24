using System;
using System.Collections.Generic;
using Xunit;

public class GroupTests
{
    [Fact]
    public void GroupID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var group = new Group();
        Assert.Throws<ArgumentException>(() => group.GroupID = 0);
    }

    [Fact]
    public void GroupName_ShouldThrowException_WhenValueIsEmpty()
    {
        var group = new Group();
        Assert.Throws<ArgumentException>(() => group.GroupName = "");
    }

    [Fact]
    public void SaveAndLoadGroups_ShouldPersistDataCorrectly()
    {
        // Arrange
        var group1 = new Group { GroupID = 1, GroupName = "Group 1" };
        var group2 = new Group { GroupID = 2, GroupName = "Group 2" };
        Group.Groups.Add(group1);
        Group.Groups.Add(group2);

        // Act
        Group.SaveGroups();
        Group.Groups.Clear();
        Group.LoadGroups();

        // Assert
        Assert.Equal(2, Group.Groups.Count);
        Assert.Equal(1, Group.Groups[0].GroupID);
        Assert.Equal("Group 1", Group.Groups[0].GroupName);
        Assert.Equal(2, Group.Groups[1].GroupID);
        Assert.Equal("Group 2", Group.Groups[1].GroupName);
    }
}