using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class genresView : Window {
        public genresView() {
            InitializeComponent();

            dataGrid.ItemsSource = data.genres;
        }

        public void dataGridSetItemSource() {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = data.genres;
        }

        private void dataGridGenreAdd_Click(object sender, RoutedEventArgs e) {
            genresAdd genresAdd = new genresAdd();

            genresAdd.Owner = this;
            genresAdd.ShowDialog();
        }

        private void dataGridGenreEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                genresEdit genresEdit = new genresEdit((data.Genre)dataGrid.SelectedItem);

                genresEdit.Owner = this;
                genresEdit.ShowDialog();
            }
        }

        private void dataGridGenreDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Genre genre = (data.Genre)dataGrid.SelectedItem;

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.genreDelete(genre.Genre_Id);

                    db.loadGenres();
                    db.loadBooks();

                    dataGridSetItemSource();

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.dataGridSetItemSource(data.books);
                }
            }
        }
    }
}
