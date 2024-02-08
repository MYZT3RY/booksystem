using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class userProfile : Window {
        List<data.Book> usersBooks = new List<data.Book>();

        public userProfile() {
            InitializeComponent();

            profileId.Text = data.currentUser.User_Id.ToString();
            profileLogin.Text = data.currentUser.User_Login;
            profileRegisterDate.Text = data.currentUser.User_Register_Date.ToString("dd.MM.yyyy HH:mm:ss");
            profileRole.Text = data.currentUser.Role.Role_Name;

            getUserBooks();

            dataGridSetItemSource(usersBooks);
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

        private void getUserBooks() {
            List<data.UsersBooks> __usersBooks = data.usersBooks.FindAll(ub => ub.UB_User_Id == data.currentUser.User_Id);

            usersBooks.Clear();

            foreach (data.UsersBooks ub in __usersBooks) {
                usersBooks.Add(data.books.Find(b => b.Book_Id == ub.UB_Book_Id));
            }
        }

        private void Window_Activated(object sender, System.EventArgs e) {
            getUserBooks();

            dataGridSetItemSource(usersBooks);
        }
    }
}
