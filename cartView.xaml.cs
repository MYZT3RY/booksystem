using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Documents;

namespace bookSystem {
    public partial class cartView : Window {
        List<data.Carts> cart = new List<data.Carts>();

        string cheque;

        public cartView() {
            InitializeComponent();

            refreshLists();
            refreshTextBlocks();
        }

        private void getUserBooks() {
            cart.Clear();

            cart = data.carts.FindAll(c => c.User_Id == data.currentUser.User_Id);
        }

        public void dataGridSetItemSource(List<data.Carts> cart) {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = cart;
        }

        private void dataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Carts carts = (data.Carts)dataGrid.SelectedItem;
                bookView bookView = new bookView(carts.Book);

                bookView.Owner = this;
                bookView.ShowDialog();
            }
        }

        private void Window_Activated(object sender, System.EventArgs e) {
            refreshLists();
            refreshTextBlocks();
        }

        private void placeOrderButton_Click(object sender, RoutedEventArgs e) {
            if (cart.Count > 0) {
                cheque = generateCheque();

                if (printChequeCheckBox.IsChecked == true) {
                    printCheque();
                }

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    foreach (data.Carts c in cart) {
                        db.userBookAdd(data.currentUser.User_Id, c.Book_Id);
                    }

                    db.loadUserBooks();

                    db.closeConnection();

                    clearCart();
                }
            }
        }

        private void cleanCartButton_Click(object sender, RoutedEventArgs e) {
            if (cart.Count > 0) {
                clearCart();
            }
        }

        private void refreshLists() {
            getUserBooks();

            dataGridSetItemSource(cart);
        }

        private string generateCheque() {
            int __count = 1;

            int __totalBooks = 0;
            int __totalPrice = 0;

            string __cheque = $"Чек: {Guid.NewGuid()}\n" +
                              $"Дата: {DateTime.Now.ToString("G")}\n" +
                              $"Покупатель: {data.currentUser.User_Login}\n" +
                               "*************************************\n" +
                              $"Товар Количество Цена\n";

            foreach (var item in cart) {
                __cheque += $"{__count}. {item.Book.Book_Name} - {item.Cart_Values} шт. - {item.Book.Book_Price} руб.\n";

                __totalBooks += item.Cart_Values;
                __totalPrice += item.Book.Book_Price * item.Cart_Values;

                __count++;
            }

            __cheque += $"Количество товаров: {__totalBooks} шт.\n";
            __cheque += $"Общая сумма: {__totalPrice} руб.\n";

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
                foreach (data.Carts c in cart) {
                    db.cartRemove(c);
                }

                db.loadCart();

                refreshLists();
                refreshTextBlocks();

                db.closeConnection();
            }
        }

        private void plusValueButton_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.cartAddValue((data.Carts)dataGrid.SelectedItem);

                    db.loadCart();

                    refreshLists();
                    refreshTextBlocks();

                    db.closeConnection();
                }
            }
        }

        private void minusValueButton_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.cartRemoveValue((data.Carts)dataGrid.SelectedItem);

                    db.loadCart();

                    refreshLists();
                    refreshTextBlocks();

                    db.closeConnection();
                }
            }
        }

        private void refreshTextBlocks() {
            int totalBooks = 0;
            int totalPrice = 0;

            foreach (data.Carts c in cart) {
                totalBooks += c.Cart_Values;
                totalPrice += c.Book.Book_Price * c.Cart_Values;
            }

            totalBooksTextBlock.Text = $"Кол-во товаров: {totalBooks}";
            totalPriceTextBlock.Text = $"Сумма чека: {totalPrice}";
        }
    }
}
