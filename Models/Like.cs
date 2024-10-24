using System;
using System.Collections.Generic;

public class Like
{
    public int LikeID { get; set; }
    public DateTime CreatedAt { get; set; }

    // Static extent collection to store all Like objects
    public static List<Like> Likes = new List<Like>();

    // Save all likes using PersistenceManager
    public static void SaveLikes()
    {
        PersistenceManager.SaveExtent(Likes, "Likes.xml");
    }

    // Load all likes using PersistenceManager
    public static void LoadLikes()
    {
        Likes = PersistenceManager.LoadExtent<Like>("Likes.xml");
    }
}
