using System.Windows;

namespace bookSystem {
    public partial class authorsEdit : Window {
        data.Author __author;

        public authorsEdit(data.Author author) {
            InitializeComponent();

            this.__author = author;

            authorName.Text = __author.Author_Name;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            if (authorName.Text != null) {
                data.Author author = data.authors.Find(a => a.Author_Name == authorName.Text);

                if (author.Author_Name != null) {
                    MessageBox.Show("Автор уже существует в базе данных!");
                }
                else {
                    __author.Author_Name = authorName.Text;

                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.authorEdit(__author);

                        db.loadAuthors();
                        db.loadBooks();

                        db.closeConnection();

                        authorsView authorsView = (authorsView)this.Owner;
                        authorsView.dataGridSetItemSource();

                        MainWindow mainWindow = (MainWindow)authorsView.Owner;
                        mainWindow.dataGridSetItemSource(data.books);

                        this.Close();
                    }
                    else {
                        MessageBox.Show("Подключение к базе данных неактивно!");
                    }
                }
            }
            else {
                MessageBox.Show("Необходимо указать автора!");
            }
        }
    }
}
