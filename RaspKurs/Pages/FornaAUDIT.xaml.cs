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
    /// Логика взаимодействия для FornaAUDIT.xaml
    /// </summary>
    public partial class FornaAUDIT : Page
    {
        public FornaAUDIT()
        {
            InitializeComponent();
            DtGridAudit.ItemsSource = RaspEntities2.GetContext().Auditorii.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDobav_Click(object sender, RoutedEventArgs e)
        {
            Manager.FormFrame.Navigate(new DobavAUDIT());
        }
    }
}
