public class Post
{
    public int PostID { get; set; }
    public string Caption { get; set; }
    public string Option { get; set; }

    // Static extent collection to store all Post objects
    public static List<Post> Posts = new List<Post>();

    // Save all posts using PersistenceManager
    public static void SavePosts()
    {
        PersistenceManager.SaveExtent(Posts, "Posts.xml");
    }

    // Load all posts using PersistenceManager
    public static void LoadPosts()
    {
        Posts = PersistenceManager.LoadExtent<Post>("Posts.xml");
    }
}
