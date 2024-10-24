using System;
using System.Collections.Generic;
using Xunit;

public class LikeTests
{
    [Fact]
    public void LikeID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var like = new Like();
        Assert.Throws<ArgumentException>(() => like.LikeID = 0);
    }

    [Fact]
    public void SaveAndLoadLikes_ShouldPersistDataCorrectly()
    {
        // Arrange
        var like1 = new Like { LikeID = 1, CreatedAt = DateTime.Now };
        var like2 = new Like { LikeID = 2, CreatedAt = DateTime.Now };
        Like.Likes.Add(like1);
        Like.Likes.Add(like2);

        // Act
        Like.SaveLikes();
        Like.Likes.Clear();
        Like.LoadLikes();

        // Assert
        Assert.Equal(2, Like.Likes.Count);
        Assert.Equal(1, Like.Likes[0].LikeID);
        Assert.Equal(2, Like.Likes[1].LikeID);
    }
}