using System.Windows;

namespace bookSystem {
    public partial class publisherAdd : Window {
        public publisherAdd() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            if (publisherName.Text != null) {
                data.Publisher publisher = data.publishers.Find(a => a.Publisher_Name == publisherName.Text);

                if (publisher.Publisher_Name != null) {
                    MessageBox.Show("Издатель уже существует в базе данных!");
                }
                else {
                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.publisherAdd(publisherName.Text);

                        db.loadPublishers();

                        db.closeConnection();

                        publishersView publishersView = (publishersView)this.Owner;
                        publishersView.dataGridSetItemSource();

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
