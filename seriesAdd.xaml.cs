using System.Windows;

namespace bookSystem {
    public partial class seriesAdd : Window {
        public seriesAdd() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            if (seriesName.Text != null) {
                data.Series series = data.series.Find(a => a.Series_Name == seriesName.Text);

                if (series.Series_Name != null) {
                    MessageBox.Show("Серия уже существует в базе данных!");
                }
                else {
                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.seriesAdd(seriesName.Text);

                        db.loadSeries();

                        db.closeConnection();

                        seriesView seriesView = (seriesView)this.Owner;
                        seriesView.dataGridSetItemSource();

                        this.Close();
                    }
                    else {
                        MessageBox.Show("Подключение к базе данных неактивно!");
                    }
                }
            }
            else {
                MessageBox.Show("Необходимо указать серию!");
            }
        }
    }
}
