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
            TextBox_Login.Background = Brushes.White;
            PassBox.Background       = Brushes.White;
            PassBox_2.Background     = Brushes.White;
            TextBox_Email.Background = Brushes.White;

            CheskCorrectInput(sender, e);
        }

        public void CheskCorrectInput(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass_2 = PassBox_2.Password.Trim();
            string email = TextBox_Email.Text.ToLower();
            int fieldLength = 5;

            if (login.Length < fieldLength)
                SetFieldNotCorrect(TextBox_Login);

            if (pass.Length < fieldLength)
                SetFieldNotCorrect(PassBox);

            if (pass_2.Length < fieldLength)
                SetFieldNotCorrect(PassBox_2);

            if (!pass.Equals(pass_2))
                SetFieldNotCorrect(PassBox_2);

            if (!email.Contains("@"))
                SetFieldNotCorrect(TextBox_Email);

            if (isInputCorrect)
            {
                var user = new User(login, pass, email);
                var db   = new ApplicationContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void SetFieldNotCorrect(Control box)
        {
            box.ToolTip = "Это поле было введено некоректно";
            box.Background =  Brushes.LightGray;
            isInputCorrect = false;
        }
    }
}
