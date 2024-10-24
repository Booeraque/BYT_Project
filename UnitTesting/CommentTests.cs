using System;
using System.Collections.Generic;
using Xunit;

public class CommentTests
{
    [Fact]
    public void CommentID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var comment = new Comment();
        Assert.Throws<ArgumentException>(() => comment.CommentID = 0);
    }

    [Fact]
    public void Text_ShouldThrowException_WhenValueIsEmpty()
    {
        var comment = new Comment();
        Assert.Throws<ArgumentException>(() => comment.Text = "");
    }

    [Fact]
    public void SaveAndLoadComments_ShouldPersistDataCorrectly()
    {
        // Arrange
        var comment1 = new Comment { CommentID = 1, Text = "Comment 1" };
        var comment2 = new Comment { CommentID = 2, Text = "Comment 2" };
        Comment.Comments.Add(comment1);
        Comment.Comments.Add(comment2);

        // Act
        Comment.SaveComments();
        Comment.Comments.Clear();
        Comment.LoadComments();

        // Assert
        Assert.Equal(2, Comment.Comments.Count);
        Assert.Equal(1, Comment.Comments[0].CommentID);
        Assert.Equal("Comment 1", Comment.Comments[0].Text);
        Assert.Equal(2, Comment.Comments[1].CommentID);
        Assert.Equal("Comment 2", Comment.Comments[1].Text);
    }
}