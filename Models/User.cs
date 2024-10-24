using System;
using System.Collections.Generic;

public class User
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

    private bool _isAdmin;
    public bool IsAdmin
    {
        get => _isAdmin;
        set => _isAdmin = value;
    }

    // Static extent collection to store all User objects
    public static List<User> Users = new List<User>();

    public static void SaveUsers()
    {
        PersistenceManager.SaveExtent(Users, "Users.xml");
    }

    public static void LoadUsers()
    {
        Users = PersistenceManager.LoadExtent<User>("Users.xml");
    }
}
