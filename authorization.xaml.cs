using System.Windows;

namespace bookSystem {
    public partial class authorization : Window {
        public authorization() {
            InitializeComponent();
        }

        private void logIn_Click(object sender, RoutedEventArgs e) {
            if (AuthorizationPassword.Password != string.Empty && authorizationLogin.Text != string.Empty) {
                data.Users user = data.users.Find(u => u.User_Login == authorizationLogin.Text && u.User_Password == AuthorizationPassword.Password);

                if (user.User_Login != null) {
                    this.Close();

                    data.currentUser = user;

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.enableUserActivity();
                }
                else {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }
    }
}
