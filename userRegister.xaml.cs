using System.Windows;

namespace bookSystem {
    public partial class userRegister : Window {
        public userRegister() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (registerLogin.Text != string.Empty && registerPassword.Text != string.Empty && registerPasswordRepeat.Text != string.Empty) {
                bool exists = false;

                foreach (data.Users user in data.users) {
                    if (registerLogin.Text == user.User_Login) {
                        exists = true;

                        break;
                    }
                }

                if (exists) {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                }
                else {
                    if (registerPassword.Text == registerPasswordRepeat.Text) {
                        data.Users user = new data.Users {
                            User_Login = registerLogin.Text
                            , User_Password = registerPassword.Text
                            , Role = data.roles.Find(r => r.Role_Name.Contains("Пользователь") && r.Role_Is_Admin == false)
                        };

                        database db = new database();

                        if (db.openConnection(db.connectionString)) {
                            db.userAdd(user);

                            db.loadUsers();

                            db.closeConnection();

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
            }
            else {
                MessageBox.Show("Поля \"Логин\", \"Пароль\", \"Повторите пароль\" не должны быть пустыми!");
            }
        }
    }
}
