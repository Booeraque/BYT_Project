public class Account
{
	public int AccountID { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
	public DateTime BirthDate { get; set; }
	public string Phone { get; set; }
	public string Address { get; set; }
	public string Password { get; set; }

	// Static extent collection to store all Account objects
	public static List<Account> Accounts = new List<Account>();

	// Save all accounts using PersistenceManager
	public static void SaveAccounts()
	{
		PersistenceManager.SaveExtent(Accounts, "Accounts.xml");
	}

	// Load all accounts using PersistenceManager
	public static void LoadAccounts()
	{
		Accounts = PersistenceManager.LoadExtent<Account>("Accounts.xml");
	}
}
