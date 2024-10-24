using System;
using System.Collections.Generic;

public class Moderator
{
    private int _accountID;
    public int AccountID
    {
        get => _accountID;
        set
        {
            if (value <= 0) throw new ArgumentException("AccountID must be positive.");
            _accountID = value;
        }
    }

    private DateTime _dateOfAssignment;
    public DateTime DateOfAssignment
    {
        get => _dateOfAssignment;
        set
        {
            if (value > DateTime.Now) throw new ArgumentException("Date of assignment cannot be in the future.");
            _dateOfAssignment = value;
        }
    }

    public List<string> Rights { get; set; } = new List<string>();

    // Static extent collection to store all Moderator objects
    public static List<Moderator> Moderators = new List<Moderator>();

    public static void SaveModerators()
    {
        PersistenceManager.SaveExtent(Moderators, "Moderators.xml");
    }

    public static void LoadModerators()
    {
        Moderators = PersistenceManager.LoadExtent<Moderator>("Moderators.xml");
    }
}
