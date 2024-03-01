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
    /// Логика взаимодействия для DobavAUDIT.xaml
    /// </summary>
    public partial class DobavAUDIT : Page
    {
        private Auditorii _currentAuditorii = new Auditorii();

        public DobavAUDIT()
        {
            InitializeComponent();
            DataContext = _currentAuditorii;
            ComboSpec.ItemsSource = RaspEntities2.GetContext().Spec.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAuditorii.number_auditor))
                errors.AppendLine("Укажите наименование аудитории");
            if (_currentAuditorii.id_spec_auditor == 0)
                errors.AppendLine("Выберите спецификацию аудитории");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            if (_currentAuditorii.id_auditor == null)
                RaspEntities2.GetContext().Auditorii.Add(_currentAuditorii);
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
