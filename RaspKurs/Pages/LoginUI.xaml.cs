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
using RaspKurs.AplicationData;

namespace RaspKurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Page
    {
        public LoginUI()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var userObj = AppConnect.model0db.Prepod.FirstOrDefault(x => x.login == txtUser.Text && x.password == txtPass.Password);
                if (userObj == null)
                {
                    MessageBox.Show(" Такого пользователя не существует! ", " Ошибка авторизации! ",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else 
                {
                    switch (userObj.id_role_prepod) 
                    {
                        case 1:
                            MessageBox.Show(" Здравствуйте, Администратор " + userObj.name_prepod + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Content = null;
                            break;
                        case 2:
                            MessageBox.Show(" Здравствуйте, Преподаватель " + userObj.name_prepod + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Content = null;
                            break;
                    }
                
                }
            }
            catch (Exception Ex) 
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения! ",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
