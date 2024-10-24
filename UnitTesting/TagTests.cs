using System;
using System.Collections.Generic;
using Xunit;

public class TagTests
{
    [Fact]
    public void TagID_ShouldThrowException_WhenValueIsNonPositive()
    {
        var tag = new Tag();
        Assert.Throws<ArgumentException>(() => tag.TagID = 0);
    }

    [Fact]
    public void Category_ShouldThrowException_WhenValueIsEmpty()
    {
        var tag = new Tag();
        Assert.Throws<ArgumentException>(() => tag.Category = "");
    }

    [Fact]
    public void SaveAndLoadTags_ShouldPersistDataCorrectly()
    {
        // Arrange
        var tag1 = new Tag { TagID = 1, Category = "Category 1" };
        var tag2 = new Tag { TagID = 2, Category = "Category 2" };
        Tag.Tags.Add(tag1);
        Tag.Tags.Add(tag2);

        // Act
        Tag.SaveTags();
        Tag.Tags.Clear();
        Tag.LoadTags();

        // Assert
        Assert.Equal(2, Tag.Tags.Count);
        Assert.Equal(1, Tag.Tags[0].TagID);
        Assert.Equal("Category 1", Tag.Tags[0].Category);
        Assert.Equal(2, Tag.Tags[1].TagID);
        Assert.Equal("Category 2", Tag.Tags[1].Category);
    }
}