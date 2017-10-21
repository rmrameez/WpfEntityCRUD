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

namespace WpfEntityCRUD
{
    /// <summary>
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCrudEntities _db = new wpfCrudEntities();
        int Id;

        public UpdatePage(int memberId)
        {
            InitializeComponent();
            Id = memberId;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            member updateMember = (from m in _db.members
                                  where m.id == Id
                                  select m).Single();
            updateMember.name = nametextBox.Text;
            updateMember.gender = gendercomboBox.Text;
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.members.ToList();
            this.Hide();
        }
    }
}
