using System;
using System.Collections.Generic;

public class Like
{
    private int _likeID;
    public int LikeID
    {
        get => _likeID;
        set
        {
            if (value <= 0) throw new ArgumentException("LikeID must be positive.");
            _likeID = value;
        }
    }

    private DateTime _createdAt;
    public DateTime CreatedAt
    {
        get => _createdAt;
        set
        {
            if (value > DateTime.Now) throw new ArgumentException("Creation date cannot be in the future.");
            _createdAt = value;
        }
    }

    // Static extent collection to store all Like objects
    public static List<Like> Likes = new List<Like>();

    public static void SaveLikes()
    {
        PersistenceManager.SaveExtent(Likes, "Likes.xml");
    }

    public static void LoadLikes()
    {
        Likes = PersistenceManager.LoadExtent<Like>("Likes.xml");
    }
}
