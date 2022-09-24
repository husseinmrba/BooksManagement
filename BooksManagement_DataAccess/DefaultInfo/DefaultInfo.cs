using BooksManagement_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksManagement_DataAccess.DefaultInfo
{
    public static class DefaultInfo
    {
        

        public static void AddDefaultUsers()
        {
            string contents = File.ReadAllText("DefaultUsers.json");
            var defaultUsers = JsonSerializer.Deserialize<List<User>>(contents);

        }
    }
}
