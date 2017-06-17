using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void listViewCargoUnits_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            CargoVM item = e.Row.DataContext as CargoVM;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if(item.Weight != 0)
                {
                    item.BtnText = "Удалить (Del)";
                    this.CalcBtn.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Для расчета необходимо указать вес.",string.Empty,MessageBoxButton.OK, MessageBoxImage.Warning);
                    e.Cancel = true;
                }
                    
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = (this.DataContext as CalcModel).RecCalc.CargoUnits;
            string content = (e.Source as Button).Content.ToString();
            if (content == "Удалить (Del)")
                data.Remove((sender as Control).DataContext as CargoVM);
            else if (content == "Отменить(Esc)")
            {
                ((e.Source as Button).CommandTarget as DataGrid).CancelEdit();
            }
            if (data.Count == 0)
            {
                this.CalcBtn.IsEnabled = false;
            }
        }


            //foreach (ServiceInfo service in (DataContext as CalcModel).InputParams.Services)
            //{
            //    if (service != null && service.Name != null)
            //    {
            //        LineSeries line = new LineSeries();
            //        line.IndependentValueBinding = new Binding("Key");
            //        line.DependentValueBinding = new Binding("Value");
            //        line.Title = service.Name;
            //        line.ItemsSource = (DataContext as CalcModel).Chart.Series.Where(item => item.Title == service.Name).Select(item => item.Series).FirstOrDefault();
            //        lnChart.Series.Add(line);
            //    }
            //}
    }
}
