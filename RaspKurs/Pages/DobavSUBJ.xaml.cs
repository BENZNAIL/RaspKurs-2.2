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
    /// Логика взаимодействия для DobavSUBJ.xaml
    /// </summary>
    public partial class DobavSUBJ : Page
    {
        private Subjects _currentSubjects = new Subjects();

        public DobavSUBJ()
        {
            InitializeComponent();
            DataContext = _currentSubjects;
            ComboSpec.ItemsSource = RaspEntities2.GetContext().Spec.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSubjects.name_subject))
                errors.AppendLine("Укажите наименование предмета");
            if (_currentSubjects.id_spec_subject == 0)
                errors.AppendLine("Выберите спецификацию предмета");

            if (errors.Length > 0) 
            {
                MessageBox.Show(errors.ToString());
            }
            if (_currentSubjects.id_subject == null)
                RaspEntities2.GetContext().Subjects.Add(_currentSubjects);
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
