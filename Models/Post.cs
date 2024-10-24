using System;
using System.Collections.Generic;

public class Post
{
    private int _postID;
    public int PostID
    {
        get => _postID;
        set
        {
            if (value <= 0) throw new ArgumentException("PostID must be positive.");
            _postID = value;
        }
    }

    private string _caption;
    public string Caption
    {
        get => _caption;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Caption can't be empty.");
            _caption = value;
        }
    }

    private string _option;
    public string Option
    {
        get => _option;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Option can't be empty.");
            _option = value;
        }
    }

    // Static extent collection to store all Post objects
    public static List<Post> Posts = new List<Post>();

    public static void SavePosts()
    {
        PersistenceManager.SaveExtent(Posts, "Posts.xml");
    }

    public static void LoadPosts()
    {
        Posts = PersistenceManager.LoadExtent<Post>("Posts.xml");
    }
}
