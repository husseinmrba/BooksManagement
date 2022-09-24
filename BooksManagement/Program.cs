using BooksManagement_DataAccess;
using BooksManagement_DataAccess.DatabaseControl;
using BooksManagement_DataAccess.DefaultInfo;
using BooksManagement_Domain;

namespace BooksManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!UserControl.IsAddedDefaultUsers())
            {
                DefaultInfo.AddDefaultUsers();
            }




        }
    }
}