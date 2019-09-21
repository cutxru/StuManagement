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
using WpfApplication7.ViewModel;

namespace WpfApplication7
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MainViewModel mainViewModel = new ViewModel.MainViewModel();

        //    var selectList = mainViewModel.list.Where(a => a.Stu_class == comboBox.Text).ToList();
        //    mainViewModel.list.Clear();
        //    foreach (var item in selectList)
        //    {
        //        mainViewModel.list.Add(new StudentEntity()
        //        {
        //            Stu_age = item.Stu_age,
        //            Stu_class = item.Stu_class,
        //            Stu_gender = item.Stu_gender,
        //            Stu_id = item.Stu_id,
        //            Stu_name = item.Stu_name
        //        });
        //    }
        //}
    }
}
