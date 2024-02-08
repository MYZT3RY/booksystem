using System.Windows;

namespace bookSystem {
    public partial class userEdit : Window {
        data.Users __user;

        public userEdit(data.Users user) {
            InitializeComponent();

            editRole.ItemsSource = data.roles;

            this.__user = user;

            editLogin.Text = __user.User_Login;
            editRole.Text = __user.Role.Role_Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (editLogin.Text != string.Empty && editPassword.Text != string.Empty && editPasswordRepeat.Text != string.Empty) {
                data.Users user = data.users.Find(u => u.User_Login == editLogin.Text);

                if (editPassword.Text == editPasswordRepeat.Text) {
                    __user.User_Password = editPassword.Text;
                    __user.Role = data.roles.Find(r => r.Role_Name.Contains(editRole.Text!));

                    database db = new database();

                    if (db.openConnection(db.connectionString)) {
                        db.userEdit(__user);

                        db.loadUsers();

                        db.closeConnection();

                        usersView usersView = (usersView)this.Owner;
                        usersView.dataGridSetItemSource();

                        this.Close();
                    }
                    else {
                        MessageBox.Show("Подключение к базе данных неактивно!");
                    }
                }
                else {
                    MessageBox.Show("Введённые пароли не совпадают!");
                }
            }
            else {
                MessageBox.Show("Поля \"Пароль\", \"Повторите пароль\" не должны быть пустыми!");
            }
        }
    }
}
