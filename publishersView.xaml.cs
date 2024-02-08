using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class publishersView : Window {
        public publishersView() {
            InitializeComponent();

            dataGrid.ItemsSource = data.publishers;
        }

        public void dataGridSetItemSource() {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = data.publishers;
        }

        private void dataGridPublisherAdd_Click(object sender, RoutedEventArgs e) {
            publisherAdd publisherAdd = new publisherAdd();

            publisherAdd.Owner = this;
            publisherAdd.ShowDialog();
        }

        private void dataGridPublisherEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                publisherEdit publisherEdit = new publisherEdit((data.Publisher)dataGrid.SelectedItem);

                publisherEdit.Owner = this;
                publisherEdit.ShowDialog();
            }
        }

        private void dataGridPublisherDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Publisher publisher = (data.Publisher)dataGrid.SelectedItem;

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.publisherDelete(publisher.Publisher_Id);

                    db.loadPublishers();
                    db.loadBooks();

                    dataGridSetItemSource();

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.dataGridSetItemSource(data.books);
                }
            }
        }
    }
}
