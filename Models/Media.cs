using System;
using System.Collections.Generic;

public class Media
{
    // Mandatory attribute: MediaID
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

    // Mandatory attribute: MediaType
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

    // Private static extent collection to store all Media objects
    private static List<Media> mediaExtent = new List<Media>();

    // Private static method to add a Media object to the extent, with validation
    private static void AddMedia(Media media)
    {
        if (media == null)
        {
            throw new ArgumentException("Media cannot be null.");
        }
        mediaExtent.Add(media);
    }

    // Public static method to get a read-only copy of the extent
    public static IReadOnlyList<Media> GetMediaList()
    {
        return mediaExtent.AsReadOnly();
    }

    // Constructor to initialize Media object with mandatory attributes and automatically add to extent
    public Media(int mediaID, string mediaType)
    {
        MediaID = mediaID;
        MediaType = mediaType;

        // Automatically add to extent
        AddMedia(this);
    }

    // Method to save all media to XML (for persistence)
    public static void SaveMedia()
    {
        PersistenceManager.SaveExtent(mediaExtent, "Media.xml");
    }

    // Method to load all media from XML (for persistence)
    public static void LoadMedia()
    {
        mediaExtent = PersistenceManager.LoadExtent<Media>("Media.xml");
    }
}
