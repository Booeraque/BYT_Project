using System;
using System.Collections.Generic;

public class Comment
{
    public int CommentID { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }

    // Static extent collection to store all Comment objects
    public static List<Comment> Comments = new List<Comment>();

    // Save all comments using PersistenceManager
    public static void SaveComments()
    {
        PersistenceManager.SaveExtent(Comments, "Comments.xml");
    }

    // Load all comments using PersistenceManager
    public static void LoadComments()
    {
        Comments = PersistenceManager.LoadExtent<Comment>("Comments.xml");
    }
}
