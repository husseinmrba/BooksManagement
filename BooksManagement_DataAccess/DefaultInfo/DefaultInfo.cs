using BooksManagement_DataAccess.DatabaseControl;
using BooksManagement_Domain;
using System.Text.Json;


namespace BooksManagement_DataAccess.DefaultInfo
{
    public static class DefaultInfo
    {
        

        public static void AddDefaultUsers()
        {
            string contents = File.ReadAllText("DefaultInfo//DefaultUsers.json");
            var defaultUsers = JsonSerializer.Deserialize<List<User>>(contents);
            foreach (var user in defaultUsers)
            {
                UserControl.AddUser(user);
            }
        }
    }
}
