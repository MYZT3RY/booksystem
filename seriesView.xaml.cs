using System.Windows;
using System.Windows.Controls;

namespace bookSystem {
    public partial class seriesView : Window {
        public seriesView() {
            InitializeComponent();

            dataGrid.ItemsSource = data.series;
        }

        public void dataGridSetItemSource() {
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            dataGrid.ItemsSource = data.series;
        }

        private void dataGridSeriesAdd_Click(object sender, RoutedEventArgs e) {
            seriesAdd seriesAdd = new seriesAdd();

            seriesAdd.Owner = this;
            seriesAdd.ShowDialog();
        }

        private void dataGridSeriesEdit_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                seriesEdit seriesEdit = new seriesEdit((data.Series)dataGrid.SelectedItem);

                seriesEdit.Owner = this;
                seriesEdit.ShowDialog();
            }
        }

        private void dataGridSeriesDelete_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedItem != null) {
                data.Series series = (data.Series)dataGrid.SelectedItem;

                database db = new database();

                if (db.openConnection(db.connectionString)) {
                    db.seriesDelete(series.Series_Id);

                    db.loadSeries();
                    db.loadBooks();

                    dataGridSetItemSource();

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.dataGridSetItemSource(data.books);
                }
            }
        }
    }
}
