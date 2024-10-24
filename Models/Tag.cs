using System;
using System.Collections.Generic;

public class Tag
{
    private int _tagID;
    public int TagID
    {
        get => _tagID;
        set
        {
            if (value <= 0) throw new ArgumentException("TagID must be positive.");
            _tagID = value;
        }
    }

    private string _category;
    public string Category
    {
        get => _category;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Category can't be empty.");
            _category = value;
        }
    }

    // Static extent collection to store all Tag objects
    public static List<Tag> Tags = new List<Tag>();

    public static void SaveTags()
    {
        PersistenceManager.SaveExtent(Tags, "Tags.xml");
    }

    public static void LoadTags()
    {
        Tags = PersistenceManager.LoadExtent<Tag>("Tags.xml");
    }
}
