using Npgsql;
using System;
using System.Windows;

namespace bookSystem {
    internal class database {
        public NpgsqlConnection Connection { get; set; }
        public NpgsqlCommand Command { get; set; }
        public NpgsqlDataReader Reader { get; set; }
        public string connectionString { get; set; } = "Server=localhost;Port=5432;User Id=postgres;Password=;Database=booksystem";

        public bool openConnection(string connectionString) {
            Connection = new NpgsqlConnection(connectionString);

            try {
                Connection.Open();

                return true;
            }
            catch { 
                return false; 
            }
        }

        public bool closeConnection() {
            try {
                Connection.Close();

                return true;
            }
            catch { 
                return false;
            }
        }

        public bool executeQuery(string query) {
            try {
                Command = new NpgsqlCommand(query, Connection);
                Command.ExecuteNonQuery();

                return true;
            }
            catch (NpgsqlException e) {
                MessageBox.Show($"[E] Ошибка при выполнении запроса в базу данных!\n\n\n{e.Message}");

                return false;
            }
        }

        public bool executeReader(string query) {
            try {
                Command = new NpgsqlCommand(query, Connection);
                Reader = Command.ExecuteReader();

                return true;
            }
            catch (NpgsqlException e) {
                MessageBox.Show($"[R] Ошибка при выполнении запроса в базу данных!\n\n\n{e.Message}");

                return false;
            }
        }

        public void loadGenres() {
            data.genres.Clear();

            string sql_query = "select * from public.genres";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.genres.Add(new data.Genre { 
                        Genre_Id = (int)Reader["genre_id"]
                        , Genre_Name = (string)Reader["genre_name"] 
                    });
                }
            }

            Reader.Close();
        }

        public void loadAuthors() {
            data.authors.Clear();

            string sql_query = "select * from public.authors";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.authors.Add(new data.Author {
                        Author_Id = (int)Reader["author_id"]
                        , Author_Name = (string)Reader["author_name"]
                    });
                }
            }

            Reader.Close();
        }

        public void loadPublishers() {
            data.publishers.Clear();

            string sql_query = "select * from public.publishers";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.publishers.Add(new data.Publisher {
                        Publisher_Id = (int)Reader["publisher_id"]
                        , Publisher_Name = (string)Reader["publisher_name"]
                    });
                }
            }

            Reader.Close();
        }

        public void loadSeries() {
            data.series.Clear();

            string sql_query = "select * from public.series";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.series.Add(new data.Series {
                        Series_Id = (int)Reader["series_id"]
                        , Series_Name = (string)Reader["series_name"]
                    });
                }
            }

            Reader.Close();
        }

        public void loadBooks() {
            data.books.Clear();

            string sql_query = "select * from public.books";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.books.Add(new data.Book { 
                        Book_Id = (int)Reader["book_id"] 
                        , Book_Name = (string)Reader["book_name"]
                        , Book_Description = (string)Reader["book_description"]
                        , Genre = data.genres.Find(g => g.Genre_Id == (int)Reader["genre_id"])
                        , Author = data.authors.Find(a => a.Author_Id == (int)Reader["author_id"])
                        , Publisher = data.publishers.Find(p => p.Publisher_Id == (int)Reader["publisher_id"])
                        , Series = data.series.Find(s => s.Series_Id == (int)Reader["series_id"])
                        , Book_Publish_Year = (int)Reader["book_publish_year"]
                        , Book_Pages = (int)Reader["book_pages"]
                    });
                }
            }

            Reader.Close();
        }

        public void loadRoles() {
            data.roles.Clear();

            string sql_query = "select * from public.roles";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.roles.Add(
                        new data.Roles {
                            Role_Id = (int)Reader["role_id"]
                            , Role_Name = (string)Reader["role_name"]
                            , Role_Is_Admin = (bool)Reader["role_is_admin"]
                        }
                    );
                }
            }

            Reader.Close();
        }

        public void loadUsers() {
            data.users.Clear();

            string sql_query = "select * from public.users";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.users.Add( new data.Users {
                        User_Id = (int)Reader["user_id"]
                        , User_Login = (string)Reader["user_login"]
                        , User_Password = (string)Reader["user_password"]
                        , User_Register_Date = (DateTime)Reader["user_register_date"]
                        , Role = data.roles.Find(r => r.Role_Id == (int)Reader["role_id"])
                    } );
                }
            }

            Reader.Close();
        }

        public void loadUserBooks() {
            data.usersBooks.Clear();

            string sql_query = "select * from public.users_books";

            executeReader(sql_query);

            if (Reader.HasRows) {
                while (Reader.Read()) {
                    data.usersBooks.Add(new data.UsersBooks {
                        UB_Id = (int)Reader["ub_id"]
                        , UB_User_Id = (int)Reader["user_id"]
                        , UB_Book_Id = (int)Reader["book_id"]
                        , UB_Add_Date = (DateTime)Reader["ub_add_date"]
                    });
                }
            }

            Reader.Close();
        }

        public void bookAdd(data.Book book) {
            book.Book_Name = checkEscapeChars(book.Book_Name);
            book.Book_Description = checkEscapeChars(book.Book_Description);

            string sql_query = "insert into public.books" +
                                "(book_name, author_id, genre_id, book_description, publisher_id, series_id, book_publish_year, book_pages) values" +
                                $"('{book.Book_Name}', '{book.Author.Author_Id}', '{book.Genre.Genre_Id}', '{book.Book_Description}', '{book.Publisher.Publisher_Id}', '{book.Series.Series_Id}', '{book.Book_Publish_Year}', '{book.Book_Pages}')";

            executeQuery(sql_query);
        }

        public void bookEdit(data.Book book) {
            book.Book_Name = checkEscapeChars(book.Book_Name);
            book.Book_Description = checkEscapeChars(book.Book_Description);

            string sql_query = "update public.books " +
                                $"set genre_id = '{book.Genre.Genre_Id}', author_id = '{book.Author.Author_Id}', book_name = '{book.Book_Name}', book_description = '{book.Book_Description}', publisher_id = '{book.Publisher.Publisher_Id}', series_id = '{book.Series.Series_Id}', book_publish_year = '{book.Book_Publish_Year}', book_pages = '{book.Book_Pages}'" +
                                $"where book_id = '{book.Book_Id}'";

            executeQuery(sql_query);
        }

        public void bookDelete(int bookId) {
            string sql_query = $"delete from public.books where book_id = '{bookId}'";

            executeQuery(sql_query);
        }

        private string checkEscapeChars(string query) {
            return query.Replace("'", "''");
        }

        public void authorAdd(string authorName) {
            authorName = checkEscapeChars(authorName);

            string sql_query = $"insert into public.authors (author_name) values ('{authorName}')";

            executeQuery(sql_query);
        }

        public void authorEdit(data.Author author) {
            author.Author_Name = checkEscapeChars(author.Author_Name);

            string sql_query = $"update public.authors set author_name = '{author.Author_Name}' where author_id = '{author.Author_Id}'";

            executeQuery(sql_query);
        }

        public void authorDelete(int authorId) {
            string sql_query = $"delete from public.authors where author_id = '{authorId}'";

            executeQuery(sql_query);
        }

        public void genreAdd(string genreName) {
            genreName = checkEscapeChars(genreName);

            string sql_query = $"insert into public.genres (genre_name) values ('{genreName}')";

            executeQuery(sql_query);
        }

        public void genreEdit(data.Genre genre) {
            genre.Genre_Name = checkEscapeChars(genre.Genre_Name);

            string sql_query = $"update public.genres set genre_name = '{genre.Genre_Name}' where genre_id = '{genre.Genre_Id}'";

            executeQuery(sql_query);
        }

        public void genreDelete(int genreId) {
            string sql_query = $"delete from public.genres where genre_id = '{genreId}'";

            executeQuery(sql_query);
        }

        public void publisherAdd(string publisherName) {
            publisherName = checkEscapeChars(publisherName);

            string sql_query = $"insert into public.publishers (publisher_name) values ('{publisherName}')";

            executeQuery(sql_query);
        }

        public void publisherEdit(data.Publisher publisher) {
            publisher.Publisher_Name = checkEscapeChars(publisher.Publisher_Name);

            string sql_query = $"update public.publishers set publisher_name = '{publisher.Publisher_Name}' where publisher_id = '{publisher.Publisher_Id}'";

            executeQuery(sql_query);
        }

        public void publisherDelete(int publisherId) {
            string sql_query = $"delete from public.publishers where publisher_id = '{publisherId}'";

            executeQuery(sql_query);
        }

        public void seriesAdd(string seriesName) {
            seriesName = checkEscapeChars(seriesName);

            string sql_query = $"insert into public.series (series_name) values ('{seriesName}')";

            executeQuery(sql_query);
        }

        public void seriesEdit(data.Series series) {
            series.Series_Name = checkEscapeChars(series.Series_Name);

            string sql_query = $"update public.series set series_name = '{series.Series_Name}' where series_id = '{series.Series_Id}'";

            executeQuery(sql_query);
        }

        public void seriesDelete(int seriesId) {
            string sql_query = $"delete from public.series where series_id = '{seriesId}'";

            executeQuery(sql_query);
        }

        public void userAdd(data.Users user) {
            user.User_Login = checkEscapeChars(user.User_Login);
            user.User_Password = checkEscapeChars(user.User_Password);

            string sql_query = $"insert into public.users (user_login, user_password, role_id) values ('{user.User_Login}', '{user.User_Password}', '{user.Role.Role_Id}')";

            executeQuery(sql_query);
        }

        public void userEdit(data.Users user) {
            user.User_Password = checkEscapeChars(user.User_Password);

            string sql_query = $"update public.users set user_password = '{user.User_Password}', role_id = '{user.Role.Role_Id}' where user_id = '{user.User_Id}'";

            executeQuery(sql_query);
        }

        public void userDelete(int userId) {
            string sql_query = $"delete from public.users where user_id = '{userId}'";

            executeQuery(sql_query);
        }

        public void userBookAdd(int userId, int bookId) {
            string sql_query = $"insert into public.users_books (user_id, book_id) values ('{userId}', '{bookId}')";

            executeQuery(sql_query);
        }

        public void userBookDelete(data.UsersBooks userBook) {
            string sql_query = $"delete from public.users_books where ub_id = '{userBook.UB_Id}'";

            executeQuery(sql_query);
        }
    }
}
