using System;
using System.Windows;

namespace bookSystem {
    public partial class bookEdit : Window {
        private int bookId { get; set; }

        public bookEdit(data.Book book) {
            InitializeComponent();

            bookGenre.ItemsSource = data.genres;
            bookGenre.Text = book.Genre.Genre_Name;

            bookAuthor.ItemsSource = data.authors;
            bookAuthor.Text = book.Author.Author_Name;

            bookName.Text = book.Book_Name;
            bookDescription.Text = book.Book_Description;

            bookPublisher.ItemsSource = data.publishers;
            bookPublisher.Text = book.Publisher.Publisher_Name;

            bookSeries.ItemsSource = data.series;
            bookSeries.Text = book.Series.Series_Name;

            bookPublishYear.Text = book.Book_Publish_Year.ToString();
            bookPages.Text = book.Book_Pages.ToString();
            bookPrice.Text = book.Book_Price.ToString();

            bookId = book.Book_Id;
        }
        
        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            if (bookName.Text.Length > 0) {
                if (bookAuthor.SelectedItem != null) {
                    if (bookGenre.SelectedItem != null) {
                        if (bookPublisher.SelectedItem != null) {
                            if (bookSeries.SelectedItem != null) {
                                if (bookPublishYear.Text.Length > 0) {
                                    if (bookPages.Text.Length > 0) {
                                        if (bookDescription.Text.Length > 0) {
                                            if (Convert.ToInt32(bookPrice.Text) > 0) {
                                                database db = new database();

                                                if (db.openConnection(db.connectionString)) {
                                                    db.bookEdit(new data.Book {
                                                        Book_Id = bookId
                                                        , Book_Name = bookName.Text
                                                        , Book_Description = bookDescription.Text
                                                        , Author = (data.Author)bookAuthor.SelectedItem
                                                        , Genre = (data.Genre)bookGenre.SelectedItem
                                                        , Publisher = (data.Publisher)bookPublisher.SelectedItem
                                                        , Series = (data.Series)bookSeries.SelectedItem
                                                        , Book_Publish_Year = Convert.ToInt32(bookPublishYear.Text)
                                                        , Book_Pages = Convert.ToInt32(bookPages.Text)
                                                        , Book_Price = Convert.ToInt32(bookPrice.Text)
                                                    });

                                                    db.loadBooks();

                                                    db.closeConnection();

                                                    MainWindow mainWindow = (MainWindow)this.Owner;
                                                    mainWindow.dataGridSetItemSource(data.books);
                                                }
                                                else {
                                                    MessageBox.Show("Подключение к базе данных неактивно!");
                                                }
                                            }
                                        }
                                        else {
                                            MessageBox.Show("Необходимо указать описание для книги!");
                                        }
                                    }
                                    else {
                                        MessageBox.Show("Необходимо указать количество страниц для книги!");
                                    }
                                }
                                else {
                                    MessageBox.Show("Необходимо указать год издания для книги!");
                                }
                            }
                            else {
                                MessageBox.Show("Необходимо указать издателя для книги!");
                            }
                        }
                        else {
                            MessageBox.Show("Необходимо указать издателя книги!");
                        }
                    }
                    else {
                        MessageBox.Show("Необходимо указать жанр книги!");
                    }
                }
                else {
                    MessageBox.Show("Необходимо указать автора книги!");
                }
            }
            else {
                MessageBox.Show("Необходимо указать название для книги!");
            }
        }
    }
}
