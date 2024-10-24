using System;
using System.Collections.Generic;
using Xunit;

public class PostTests
{
    [Fact]
    public void PostID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var post = new Post();
        Assert.Throws<ArgumentException>(() => post.PostID = 0);
    }

    [Fact]
    public void Caption_ShouldThrowException_WhenValueIsEmpty()
    {
        var post = new Post();
        Assert.Throws<ArgumentException>(() => post.Caption = "");
    }

    [Fact]
    public void SaveAndLoadPosts_ShouldPersistDataCorrectly()
    {
        // Arrange
        var post1 = new Post { PostID = 1, Caption = "Post 1" };
        var post2 = new Post { PostID = 2, Caption = "Post 2" };
        Post.Posts.Add(post1);
        Post.Posts.Add(post2);

        // Act
        Post.SavePosts();
        Post.Posts.Clear();
        Post.LoadPosts();

        // Assert
        Assert.Equal(2, Post.Posts.Count);
        Assert.Equal(1, Post.Posts[0].PostID);
        Assert.Equal("Post 1", Post.Posts[0].Caption);
        Assert.Equal(2, Post.Posts[1].PostID);
        Assert.Equal("Post 2", Post.Posts[1].Caption);
    }
}