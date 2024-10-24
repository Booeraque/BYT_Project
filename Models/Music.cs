public class Music
{
    private int _musicID;
    public int MusicID
    {
        get => _musicID;
        set
        {
            if (value <= 0) throw new ArgumentException("MusicID must be positive.");
            _musicID = value;
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Description can't be empty.");
            _description = value;
        }
    }

    // Static extent collection to store all Music objects
    public static List<Music> MusicList = new List<Music>();

    // Save all music using PersistenceManager
    public static void SaveMusic()
    {
        PersistenceManager.SaveExtent(MusicList, "Music.xml");
    }

    // Load all music using PersistenceManager
    public static void LoadMusic()
    {
        MusicList = PersistenceManager.LoadExtent<Music>("Music.xml");
    }
}