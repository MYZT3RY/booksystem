using System.Windows;

namespace bookSystem {
    public partial class bookView : Window {
        data.Book book;
        data.Carts checkCart;

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

            bookPrice.Text = book.Book_Price.ToString();

            if (data.currentUser.User_Login != null) {
                buttonAddBook.IsEnabled = true;

                checkCart = data.carts.Find(c => c.User_Id == data.currentUser.User_Id && c.Book_Id == book.Book_Id);

                if (checkCart.Primary_Id != 0) {
                    buttonAddBook.Content = "Убрать из корзины";
                }
                else {
                    buttonAddBook.Content = "Добавить в корзину";
                }
            }
            else {
                buttonAddBook.IsEnabled = false;
            }
        }

        private void buttonAddBook_Click(object sender, RoutedEventArgs e) {
            if (checkCart.Primary_Id != 0) {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.cartRemove(checkCart);
                    db.loadCart();
                }
            }
            else {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.cartAdd(data.currentUser.User_Id, book.Book_Id);
                    db.loadCart();
                }
            }

            this.Close();
        }
    }
}
