using System.Windows;

namespace bookSystem {
    public partial class bookView : Window {
        data.Book book;
        data.UsersBooks checkBook;

        public bookView(data.Book book) {
            InitializeComponent();

            this.book = book;

            bookName.Text = book.Book_Name;
            bookAuthorName.Text = book.Author.Author_Name;

            bookId.Text = book.Book_Id.ToString();
            bookGenreName.Text = book.Genre.Genre_Name;
            bookPublisherName.Text = book.Publisher.Publisher_Name;
            bookSeriesName.Text = book.Series.Series_Name;

            bookDescription.Text = book.Book_Description;
            bookPublishYear.Text = book.Book_Publish_Year.ToString();
            bookPages.Text = book.Book_Pages.ToString();

            if (data.currentUser.User_Login != null) {
                buttonAddBook.IsEnabled = true;

                checkBook = data.usersBooks.Find(ub => ub.UB_User_Id == data.currentUser.User_Id && ub.UB_Book_Id == book.Book_Id);

                if (checkBook.UB_Book_Id != 0) {
                    buttonAddBook.Content = "Удалить книгу";
                }
                else {
                    buttonAddBook.Content = "Добавить книгу";
                }
            }
            else {
                buttonAddBook.IsEnabled = false;
            }
        }

        private void buttonAddBook_Click(object sender, RoutedEventArgs e) {
            if (checkBook.UB_Book_Id != 0) {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.userBookDelete(checkBook);

                    db.loadUserBooks();
                }
            }
            else {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.userBookAdd(data.currentUser.User_Id, book.Book_Id);

                    db.loadUserBooks();
                }
            }

            this.Close();
        }
    }
}
