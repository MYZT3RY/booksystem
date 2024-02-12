using System;
using System.Collections.Generic;

namespace bookSystem {
    public class data {
        public struct Book {
            public int Book_Id { get; set; }
            public Genre Genre { get; set; }
            public Author Author { get; set; }
            public Publisher Publisher { get; set; }
            public Series Series { get; set; }
            public string Book_Name { get; set; }
            public string Book_Description { get; set; }
            public int Book_Publish_Year { get; set; }
            public int Book_Pages { get; set; }
            public int Book_Price { get; set; }
        }

        public struct Genre {
            public int Genre_Id { get; set; }
            public string Genre_Name { get; set; }
        }

        public struct Author {
            public int Author_Id { get; set; }
            public string Author_Name { get; set; }
        }

        public struct Publisher {
            public int Publisher_Id { get; set; }
            public string Publisher_Name { get; set; }
        }

        public struct Series {
            public int Series_Id { get; set; }
            public string Series_Name { get; set;}
        }

        public struct Users {
            public int User_Id { get; set; }
            public string User_Login { get; set; }
            public string User_Password { get; set; }
            public DateTime User_Register_Date { get; set; }
            public Roles Role { get; set; }
        }

        public struct Roles { 
            public int Role_Id { get; set; }
            public string Role_Name { get; set; }
            public bool Role_Is_Admin { get; set; }
        }

        public struct UsersBooks {
            public int UB_Id { get; set; }
            public int UB_User_Id { get; set; }
            public int UB_Book_Id {  get; set; }
            public DateTime UB_Add_Date { get; set; }
        }

        public struct Carts {
            public int Primary_Id { get; set; }
            public int User_Id { get; set; }
            public int Book_Id { get; set; }
            public int Cart_Values { get; set; }
            public Book Book { get; set; }
        }

        public static List<Book> books = new List<Book>();
        public static List<Genre> genres = new List<Genre>();
        public static List<Author> authors = new List<Author>();
        public static List<Publisher> publishers = new List<Publisher>();
        public static List<Series> series = new List<Series>();
        public static List<Users> users = new List<Users>();
        public static List<Roles> roles = new List<Roles>();
        public static List<UsersBooks> usersBooks = new List<UsersBooks>();
        public static List<Carts> carts = new List<Carts>();
        public static Users currentUser;
    }
}
