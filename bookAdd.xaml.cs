using System;
using System.Windows;

namespace bookSystem {
    public partial class bookAdd : Window {
        public bookAdd() {
            InitializeComponent();

            bookAuthor.ItemsSource = data.authors;
            bookGenre.ItemsSource = data.genres;
            bookPublisher.ItemsSource = data.publishers;
            bookSeries.ItemsSource = data.series;
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
                                                    db.bookAdd(new data.Book {
                                                        Book_Name = bookName.Text
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
                                            else {

                                            }
                                        }
                                        else {
                                            MessageBox.Show("Необходимо указать издателя для книги!");
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
                                MessageBox.Show("Необходимо указать серию для книги!");
                            }
                        }
                        else {
                            MessageBox.Show("Необходимо указать описание для книги!");
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
