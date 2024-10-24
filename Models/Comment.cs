using System;
using System.Collections.Generic;

public class Comment
{
    private int _commentID;
    public int CommentID
    {
        get => _commentID;
        set
        {
            if (value <= 0) throw new ArgumentException("CommentID must be positive.");
            _commentID = value;
        }
    }

    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Text can't be empty.");
            _text = value;
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

    // Static extent collection to store all Comment objects
    public static List<Comment> Comments = new List<Comment>();

    public static void SaveComments()
    {
        PersistenceManager.SaveExtent(Comments, "Comments.xml");
    }

    public static void LoadComments()
    {
        Comments = PersistenceManager.LoadExtent<Comment>("Comments.xml");
    }
}
