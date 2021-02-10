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
using System.Windows.Shapes;
using WpfApp2;

namespace WpfProject
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private bool isInputCorrect = true;
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            InitForm();
            CheskCorrectInput();

            if (isInputCorrect)
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == TextBox_Login.Text && 
                                              b.Pass == PassBox.Password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Пользователя с такими данными не существет.");
            }
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void CheskCorrectInput()
        {
            string login = TextBox_Login.Text.Trim();
            string pass  = PassBox.Password.Trim();
            int fieldLength = 5;

            if (login.Length < fieldLength)
                SetControlNotCorrect(TextBox_Login);

            if (pass.Length < fieldLength)
                SetControlNotCorrect(PassBox);

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

            Control[] controls = { TextBox_Login, PassBox };
            foreach (var control in controls)
            {
                control.ToolTip = "";
                control.Background = Brushes.White;
            }
        }
    }     
}
