using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class authorsView : Window {
        public authorsView() {
            InitializeComponent();

            dataGrid.ItemsSource = data.authors;
        }

        private void dataGridAuthorAdd_Click(object sender, RoutedEventArgs e) {
            authorsAdd authorsAdd = new authorsAdd();

            authorsAdd.Owner = this;
            authorsAdd.ShowDialog();
        }

        public void dataGridSetItemSource() {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = data.authors;
        }

        private void dataGridAuthorEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                authorsEdit authorsEdit = new authorsEdit((data.Author)dataGrid.SelectedItem);

                authorsEdit.Owner = this;
                authorsEdit.ShowDialog();
            }
        }

        private void dataGridAuthorDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Author author = (data.Author)dataGrid.SelectedItem;

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.authorDelete(author.Author_Id);

                    db.loadAuthors();
                    db.loadBooks();

                    dataGridSetItemSource();

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.dataGridSetItemSource(data.books);
                }
            }
        }
    }
}
