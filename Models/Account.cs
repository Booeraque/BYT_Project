using System;
using System.Collections.Generic;

public class Account
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

    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Username can't be empty.");
            _username = value;
        }
    }

    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Email can't be empty.");
            _email = value;
        }
    }

    private DateTime _birthDate;
    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (value > DateTime.Now) throw new ArgumentException("Birth date cannot be in the future.");
            _birthDate = value;
        }
    }

    private string _phone;
    public string Phone
    {
        get => _phone;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Phone number can't be empty.");
            _phone = value;
        }
    }

    private string _address;
    public string Address
    {
        get => _address;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Address can't be empty.");
            _address = value;
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Password can't be empty.");
            _password = value;
        }
    }

    // Static extent collection to store all Account objects
    public static List<Account> Accounts = new List<Account>();

    public static void SaveAccounts()
    {
        PersistenceManager.SaveExtent(Accounts, "Accounts.xml");
    }

    public static void LoadAccounts()
    {
        Accounts = PersistenceManager.LoadExtent<Account>("Accounts.xml");
    }
}
