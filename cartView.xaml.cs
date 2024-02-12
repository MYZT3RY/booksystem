using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Documents;

namespace bookSystem {
    public partial class cartView : Window {
        List<data.Book> cartBooks = new List<data.Book>();

        string cheque;

        public cartView() {
            InitializeComponent();

            refreshLists();
        }

        private void getUserBooks() {
            List<data.Carts> __cartBooks = data.carts.FindAll(c => c.User_Id == data.currentUser.User_Id);

            cartBooks.Clear();

            foreach (data.Carts cart in __cartBooks) {
                cartBooks.Add(data.books.Find(b => b.Book_Id == cart.Book_Id));
            }
        }

        public void dataGridSetItemSource(List<data.Book> book) {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = book;
        }

        private void dataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                bookView bookView = new bookView((data.Book)dataGrid.SelectedItem);

                bookView.Owner = this;
                bookView.ShowDialog();
            }
        }

        private void Window_Activated(object sender, System.EventArgs e) {
            refreshLists();
        }

        private void placeOrderButton_Click(object sender, RoutedEventArgs e) {
            if (cartBooks.Count > 0) {
                cheque = generateCheque();

                if (printChequeCheckBox.IsChecked == true) {
                    printCheque();
                }

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    List<data.Carts> __cartBooks = data.carts.FindAll(c => c.User_Id == data.currentUser.User_Id);

                    foreach (data.Carts c in __cartBooks) {
                        db.userBookAdd(data.currentUser.User_Id, c.Book_Id);
                    }

                    db.loadUserBooks();

                    db.closeConnection();

                    clearCart();
                }
            }
        }

        private void cleanCartButton_Click(object sender, RoutedEventArgs e) {
            if (cartBooks.Count > 0) {
                clearCart();
            }
        }

        private void refreshLists() {
            getUserBooks();

            dataGridSetItemSource(cartBooks);
        }

        private string generateCheque() {
            string __cheque = $"Чек: {Guid.NewGuid()}\n" +
                              $"Дата: {DateTime.Now.ToString("G")}\n" +
                               "*************************************\n" +
                              $"Товар\n";

            foreach (var item in cartBooks) {
                __cheque += $"{item.Book_Name}\n";
            }

            __cheque += "*************************************";

            return __cheque;
        }

        private void printCheque() {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true) {
                FlowDocument flowDocument = new FlowDocument();

                foreach (string line in cheque.Split('\n')) {
                    Paragraph paragraph = new Paragraph();

                    paragraph.Margin = new Thickness(0);
                    paragraph.Inlines.Add(new Run(line));
                    paragraph.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");

                    flowDocument.Blocks.Add(paragraph);
                }

                DocumentPaginator paginator = ((IDocumentPaginatorSource)flowDocument).DocumentPaginator;

                printDialog.PrintDocument(paginator, this.Title);
            }
        }

        private void clearCart() {
            database db = new database();

            if (db.openConnection(db.connectionString)) {
                List<data.Carts> __cartBooks = data.carts.FindAll(c => c.User_Id == data.currentUser.User_Id);

                foreach (data.Carts c in __cartBooks) {
                    db.cartRemove(c);
                }

                db.loadCart();

                refreshLists();

                db.closeConnection();
            }
        }
    }
}
