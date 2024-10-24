using System;
using System.Collections.Generic;

public class Group
{
    private int _groupID;
    public int GroupID
    {
        get => _groupID;
        set
        {
            if (value <= 0) throw new ArgumentException("GroupID must be positive.");
            _groupID = value;
        }
    }

    private string _groupName;
    public string GroupName
    {
        get => _groupName;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Group name can't be empty.");
            _groupName = value;
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

    // Static extent collection to store all Group objects
    public static List<Group> Groups = new List<Group>();

    public static void SaveGroups()
    {
        PersistenceManager.SaveExtent(Groups, "Groups.xml");
    }

    public static void LoadGroups()
    {
        Groups = PersistenceManager.LoadExtent<Group>("Groups.xml");
    }
}
