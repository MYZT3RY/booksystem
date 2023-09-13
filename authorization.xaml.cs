using System.Windows;

namespace bookSystem {
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Window {
        private string __password = "1234";

        public authorization() {
            InitializeComponent();
        }

        private void logIn_Click(object sender, RoutedEventArgs e) {
            if (password.Password != string.Empty) {
                if (password.Password == __password) {
                    this.Close();

                    MainWindow mainWindow = (MainWindow)this.Owner;
                    mainWindow.enableDataGridContextMenu();
                }
                else {
                    MessageBox.Show("Неправильный пароль!");
                }
            }
        }
    }
}
