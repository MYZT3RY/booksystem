using System.Windows;

namespace bookSystem {
    public partial class genresAdd : Window {
        public genresAdd() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            if (genreName.Text != null) {
                data.Genre genre = data.genres.Find(a => a.Genre_Name == genreName.Text);

                if (genre.Genre_Name != null) {
                    MessageBox.Show("Жанр уже существует в базе данных!");
                }
                else {
                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.genreAdd(genreName.Text);

                        db.loadGenres();

                        db.closeConnection();

                        genresView genresView = (genresView)this.Owner;
                        genresView.dataGridSetItemSource();

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
