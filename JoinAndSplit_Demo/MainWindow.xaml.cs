using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace JoinAndSplit_Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 初始化数据
            for (int i = 0; i < 20; i++)
            {
                SwitchModels.Add(new SwitchModel() { ID = i, Ckeck = false, SwitchName = $"功能{i}" });
            }
            datagrid.ItemsSource = SwitchModels;

        }

        public ObservableCollection<SwitchModel> SwitchModels { get; set; } = new ObservableCollection<SwitchModel>();

        /// <summary>
        /// 文本转表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lr_Click(object sender, RoutedEventArgs e)
        {
            var vSplit = textbox.Text.Split(',');
            foreach (var itemSwitchModel in SwitchModels)
            {
                bool IsCheck = false;
                foreach (var itemSplit in vSplit)
                {
                    if (itemSwitchModel.ID == int.Parse(itemSplit))
                    {
                        IsCheck = true;
                        break;
                    }
                }
                itemSwitchModel.Ckeck = IsCheck;
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = SwitchModels;
        }

        /// <summary>
        /// 表格转文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rl_Click(object sender, RoutedEventArgs e)
        {
            List<int> list = new List<int>();
            foreach (var itemSwitchModel in SwitchModels)
            {
                if (itemSwitchModel.Ckeck)
                {
                    list.Add(itemSwitchModel.ID);
                }
            }
            textbox.Text = string.Join(",", list);
        }
    }
}
