using System;
using System.Collections.Generic;

public class Music
{
    public int MusicID { get; set; }
    public string Description { get; set; }

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
