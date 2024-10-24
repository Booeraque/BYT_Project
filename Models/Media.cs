using System;
using System.Collections.Generic;

public class Media
{
    public int MediaID { get; set; }
    public string MediaType { get; set; }

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
