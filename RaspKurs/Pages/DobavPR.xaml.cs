using RaspKurs.AplicationData;
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

namespace RaspKurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для DobavPR.xaml
    /// </summary>
    public partial class DobavPR : Page
    {
        private Prepod _currentPrepod = new Prepod();

        public DobavPR()
        {
            InitializeComponent();
            DataContext = _currentPrepod;
            ComboSpec.ItemsSource = RaspEntities2.GetContext().Spec.ToList();
            ComboRole.ItemsSource = RaspEntities2.GetContext().Role.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPrepod.lname_prepod))
                errors.AppendLine("Укажите наименование фамилия");
            if (string.IsNullOrWhiteSpace(_currentPrepod.name_prepod))
                errors.AppendLine("Укажите наименование имя");
            if (string.IsNullOrWhiteSpace(_currentPrepod.mname_prepod))
                errors.AppendLine("Укажите наименование отчество");
            if (string.IsNullOrWhiteSpace(_currentPrepod.login))
                errors.AppendLine("Укажите логин для преподавателя");
            if (string.IsNullOrWhiteSpace(_currentPrepod.password))
                errors.AppendLine("Укажите пароль для преподавателя");
            if (_currentPrepod.id_spec_prepod == 0)
                errors.AppendLine("Выберите спецификацию преподавателя");
            if (_currentPrepod.id_role_prepod == 0)
                errors.AppendLine("Выберите роль преподавателя");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            if (_currentPrepod.id_prepod == null)
                RaspEntities2.GetContext().Prepod.Add(_currentPrepod);
            try
            {
                RaspEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
