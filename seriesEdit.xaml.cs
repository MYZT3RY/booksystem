using System.Windows;

namespace bookSystem {
    public partial class seriesEdit : Window {
        data.Series __series;

        public seriesEdit(data.Series series) {
            InitializeComponent();

            this.__series = series;

            seriesName.Text = __series.Series_Name;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            if (seriesName.Text != null) {
                data.Series series = data.series.Find(a => a.Series_Name == seriesName.Text);

                if (series.Series_Name != null) {
                    MessageBox.Show("Издатель уже существует в базе данных!");
                }
                else {
                    __series.Series_Name = seriesName.Text;

                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.seriesEdit(__series);

                        db.loadSeries();
                        db.loadBooks();

                        db.closeConnection();

                        seriesView seriesView = (seriesView)this.Owner;
                        seriesView.dataGridSetItemSource();

                        MainWindow mainWindow = (MainWindow)seriesView.Owner;
                        mainWindow.dataGridSetItemSource(data.books);

                        this.Close();
                    }
                    else {
                        MessageBox.Show("Подключение к базе данных неактивно!");
                    }
                }
            }
            else {
                MessageBox.Show("Необходимо указать издателя!");
            }
        }
    }
}
