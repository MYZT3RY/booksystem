using System.Windows;

namespace bookSystem {
    public partial class userAdd : Window {
        public userAdd() {
            InitializeComponent();

            addRole.ItemsSource = data.roles; 
            addRole.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (addLogin.Text != string.Empty && addPassword.Text != string.Empty && addPasswordRepeat.Text != string.Empty) {
                bool exists = false;

                foreach (data.Users user in data.users) {
                    if (addLogin.Text == user.User_Login) {
                        exists = true;

                        break;
                    }
                }

                if (exists) {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                }
                else {
                    if (addPassword.Text == addPasswordRepeat.Text) {
                        data.Users user = new data.Users {
                            User_Login = addLogin.Text
                            , User_Password = addPassword.Text
                            , Role = data.roles.Find(r => r.Role_Name.Contains(addRole.Text))
                        };

                        database db = new database();

                        if (db.openConnection(db.connectionString)) {
                            db.userAdd(user);

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
            }
            else {
                MessageBox.Show("Поля \"Логин\", \"Пароль\", \"Повторите пароль\" не должны быть пустыми!");
            }
        }
    }
}
