using System;
using System.Collections.Generic;

public class Tag
{
    public int TagID { get; set; }
    public string Category { get; set; }

    // Static extent collection to store all Tag objects
    public static List<Tag> Tags = new List<Tag>();

    // Save all tags using PersistenceManager
    public static void SaveTags()
    {
        PersistenceManager.SaveExtent(Tags, "Tags.xml");
    }

    // Load all tags using PersistenceManager
    public static void LoadTags()
    {
        Tags = PersistenceManager.LoadExtent<Tag>("Tags.xml");
    }
}
