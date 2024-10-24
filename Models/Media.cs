public class Media
{
    private int _mediaID;
    public int MediaID
    {
        get => _mediaID;
        set
        {
            if (value <= 0) throw new ArgumentException("MediaID must be positive.");
            _mediaID = value;
        }
    }

    private string _mediaType;
    public string MediaType
    {
        get => _mediaType;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("MediaType can't be empty.");
            _mediaType = value;
        }
    }

    // Static extent collection to store all Media objects
    public static List<Media> MediaList = new List<Media>();

    // Save all media using PersistenceManager
    public static void SaveMedia()
    {
        PersistenceManager.SaveExtent(MediaList, "Media.xml");
    }

    // Load all media using PersistenceManager
    public static void LoadMedia()
    {
        MediaList = PersistenceManager.LoadExtent<Media>("Media.xml");
    }
}