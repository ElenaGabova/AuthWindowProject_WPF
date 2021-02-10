using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isInputCorrect = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {   
            InitForm();
            CheskCorrectInput();
  
            if (isInputCorrect)
            {
                string login = TextBox_Login.Text.Trim();
                string pass  = PassBox.Password.Trim();
                string email = TextBox_Email.Text;

                var user = new User(login, pass, email);
                var db = new ApplicationContext();
                db.Users.Add(user);
                db.SaveChanges();

                UserPageWindow userPageWindow = new UserPageWindow();
                userPageWindow.Show();
                this.Hide();
            }   
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void CheskCorrectInput()
        {
            string login  = TextBox_Login.Text.Trim();
            string pass   = PassBox.Password.Trim();
            string pass_2 = PassBox_2.Password.Trim();
            string email  = TextBox_Email.Text.ToLower();

            int fieldLength = 5;

            if (login.Length < fieldLength)
                SetControlNotCorrect(TextBox_Login);

            if (pass.Length < fieldLength)
                SetControlNotCorrect(PassBox);

            if (pass_2.Length < fieldLength || !pass.Equals(pass_2))
                SetControlNotCorrect(PassBox_2);

            if (!email.Contains("@"))
                SetControlNotCorrect(TextBox_Email);

            void SetControlNotCorrect(Control box)
            {
                box.ToolTip = "Это поле было введено некоректно";
                box.Background = Brushes.LightGray;
                isInputCorrect = false;
            }
        }

        private void InitForm()
        {
            isInputCorrect = true;

            Control[] controls = { TextBox_Login, PassBox, PassBox_2, TextBox_Email };

            foreach (var control in controls)
                control.Background = Brushes.White;
        }
    }
}
