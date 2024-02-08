using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class usersView : Window {
        public usersView() {
            InitializeComponent();

            dataGrid.ItemsSource = data.users;
        }

        public void dataGridSetItemSource() {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = data.users;
        }

        private void dataGridUserAdd_Click(object sender, RoutedEventArgs e) {
            userAdd userAdd = new userAdd();

            userAdd.Owner = this;
            userAdd.ShowDialog();
        }

        private void dataGridUserEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                userEdit userEdit = new userEdit((data.Users)dataGrid.SelectedItem);

                userEdit.Owner = this;
                userEdit.ShowDialog();
            }
        }

        private void dataGridUserDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.userDelete(((data.Users)dataGrid.SelectedItem).User_Id);

                    dataGridSetItemSource();

                    db.closeConnection();
                }
            }
        }
    }
}
