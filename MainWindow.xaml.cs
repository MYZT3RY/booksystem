using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class MainWindow : Window {

        database db = new database();

        public MainWindow() {
            InitializeComponent();

            if (db.openConnection(db.connectionString)) {
                db.loadAuthors();
                db.loadGenres();
                db.loadPublishers();
                db.loadSeries();
                db.loadBooks();
                db.loadRoles();
                db.loadUsers();
                db.loadUserBooks();
                db.loadCart();

                dataGridSetItemSource(data.books);

                db.closeConnection();
            }
            else {
                MessageBox.Show("Невозможно подключиться к базе данных!");

                this.Close();
            }
        }

        private void authorizationMenuItem_Click(object sender, RoutedEventArgs e) {
            authorization authorization = new authorization();

            authorization.Owner = this;
            authorization.ShowDialog();
        }

        private void dataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                bookView bookView = new bookView((data.Book)dataGrid.SelectedItem);

                bookView.Owner = this;
                bookView.ShowDialog();
            }
        }

        public void enableUserActivity() {
            registerMenuItem.IsEnabled = false;
            authorizationMenuItem.IsEnabled = false;
            userMenuItem.Visibility = Visibility.Visible;

            if (data.currentUser.Role.Role_Is_Admin) {
                dataGridContextMenu.Visibility = Visibility.Visible;
                dataMenuItem.Visibility = Visibility.Visible;
            }
        }

        private void dataGridBookAdd_Click(object sender, RoutedEventArgs e) {
            bookAdd bookAdd = new bookAdd();

            bookAdd.Owner = this;
            bookAdd.ShowDialog();
        }

        public void dataGridSetItemSource(List<data.Book> book) {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = book;
        }

        private void dataGridBookEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                bookEdit bookEdit = new bookEdit((data.Book)dataGrid.SelectedItem);

                bookEdit.Owner = this;
                bookEdit.ShowDialog();
            }
        }

        private void dataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                dataGridBookEdit.IsEnabled = true;
                dataGridBookDelete.IsEnabled = true;
            }
            else {
                dataGridBookEdit.IsEnabled = false;
                dataGridBookDelete.IsEnabled = false;
            }
        }

        private void dataGridBookDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Book book = (data.Book)dataGrid.SelectedItem;

                db.bookDelete(book.Book_Id);

                db.loadBooks();
                dataGridSetItemSource(data.books);
            }
        }

        private void authorsViewMenuItem_Click(object sender, RoutedEventArgs e) {
            authorsView authorsView = new authorsView();

            authorsView.Owner = this;
            authorsView.ShowDialog();
        }

        private void genresView_Click(object sender, RoutedEventArgs e) {
            genresView genresView = new genresView();

            genresView.Owner = this;
            genresView.ShowDialog();
        }

        private void publishersView_Click(object sender, RoutedEventArgs e) {
            publishersView publishersView = new publishersView();

            publishersView.Owner = this;
            publishersView.ShowDialog();
        }

        private void seriesView_Click(object sender, RoutedEventArgs e) {
            seriesView seriesView = new seriesView();

            seriesView.Owner = this;
            seriesView.ShowDialog();
        }

        private void registerMenuItem_Click(object sender, RoutedEventArgs e) {
            userRegister userRegister = new userRegister();

            userRegister.Owner = this;
            userRegister.ShowDialog();
        }

        private void usersView_Click(object sender, RoutedEventArgs e) {
            usersView usersView = new usersView();

            usersView.Owner = this;
            usersView.ShowDialog();
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void profileMenuItem_Click(object sender, RoutedEventArgs e) {
            userProfile userProfile = new userProfile();

            userProfile.Owner = this;
            userProfile.ShowDialog();
        }

        private void cartMenuItem_Click(object sender, RoutedEventArgs e) {
            cartView cartView = new cartView();

            cartView.Owner = this;
            cartView.ShowDialog();
        }
    }
}