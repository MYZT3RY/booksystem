using System.Windows;

namespace bookSystem {
    public partial class publisherEdit : Window {
        data.Publisher __publisher;

        public publisherEdit(data.Publisher publisher) {
            InitializeComponent();

            this.__publisher = publisher;

            publisherName.Text = __publisher.Publisher_Name;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            if (publisherName.Text != null) {
                data.Publisher publisher = data.publishers.Find(a => a.Publisher_Name == publisherName.Text);

                if (publisher.Publisher_Name != null) {
                    MessageBox.Show("Издатель уже существует в базе данных!");
                }
                else {
                    __publisher.Publisher_Name = publisherName.Text;

                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.publisherEdit(__publisher);

                        db.loadPublishers();
                        db.loadBooks();

                        db.closeConnection();

                        publishersView publishersView = (publishersView)this.Owner;
                        publishersView.dataGridSetItemSource();

                        MainWindow mainWindow = (MainWindow)publishersView.Owner;
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
