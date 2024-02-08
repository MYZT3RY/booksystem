using System.Windows;

namespace bookSystem {
    public partial class genresEdit : Window {
        data.Genre __genre;

        public genresEdit(data.Genre genre) {
            InitializeComponent();

            this.__genre = genre;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            if (genreName.Text != null) {
                data.Genre genre = data.genres.Find(a => a.Genre_Name == genreName.Text);

                if (genre.Genre_Name != null) {
                    MessageBox.Show("Жанр уже существует в базе данных!");
                }
                else {
                    __genre.Genre_Name = genreName.Text;

                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.genreEdit(__genre);

                        db.loadGenres();
                        db.loadBooks();

                        db.closeConnection();

                        genresView genresView = (genresView)this.Owner;
                        genresView.dataGridSetItemSource();

                        MainWindow mainWindow = (MainWindow)genresView.Owner;
                        mainWindow.dataGridSetItemSource(data.books);

                        this.Close();
                    }
                    else {
                        MessageBox.Show("Подключение к базе данных неактивно!");
                    }
                }
            }
            else {
                MessageBox.Show("Необходимо указать жанр!");
            }
        }
    }
}
