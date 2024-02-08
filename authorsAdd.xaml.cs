using System.Windows;

namespace bookSystem {
    public partial class authorsAdd : Window {
        public authorsAdd() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            if (authorName.Text != null) {
                data.Author author = data.authors.Find(a => a.Author_Name == authorName.Text);

                if (author.Author_Name != null) {
                    MessageBox.Show("Автор уже существует в базе данных!");
                }
                else {
                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.authorAdd(authorName.Text);

                        db.loadAuthors();

                        db.closeConnection();

                        authorsView authorsView = (authorsView)this.Owner;
                        authorsView.dataGridSetItemSource();

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
