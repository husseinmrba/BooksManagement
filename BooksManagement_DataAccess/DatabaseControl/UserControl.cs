using BooksManagement_Domain;

namespace BooksManagement_DataAccess.DatabaseControl
{
    public static class UserControl
    {

        
        public static bool IsUserExist(string username , string password)
        {
            using (var context = new BooksMDBContext())
            {
                var user = context.Users
                    .Where(u => u.UserName.Contains(username) &&
                                u.Password.Contains(password))
                    .ToList();
                if (user.Any())
                    return true;
                else
                    return false;
            }
        }
        public static bool IsAddedDefaultUsers()
        {
            using (var context = new BooksMDBContext())
            {
                var user = context
                            .Users
                            .Where(u => u.FullName == "Hussein Issa")
                            .ToList();
                if (user.Any())
                    return true;
                else
                    return false; 
            }
        }
        public static void AddUser(User user)
        {
            using (var context = new BooksMDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

    }
}
