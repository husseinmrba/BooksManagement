using BooksManagement_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement_DataAccess.DatabaseControl
{
    public static class UserControl
    {

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
