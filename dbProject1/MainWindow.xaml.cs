using System.Collections.Frozen;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace dbProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1(null);
            bool? dialog = win.ShowDialog();
            if(dialog == true)
            {
                lw_Requests.Items.Clear();
                ApplicationContext ac = new ApplicationContext();
                List<Request> newList = new List<Request>();
                newList = ac.Requests.ToList();
                foreach(Request reqt in newList)
                {
                    lw_Requests.Items.Add(reqt.ToString());
                }
            }
        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {
            int? selectedID = int.Parse((string)lw_Requests.SelectedItem);
            if (selectedID == null) { return; }
            Window1 win = new Window1(selectedID);
            bool? dialog = win.ShowDialog();
            if (dialog == true)
            {
                lw_Requests.Items.Clear();
                ApplicationContext ac = new ApplicationContext();
                List<Request> newList = new List<Request>();
                newList = ac.Requests.ToList();
                foreach (Request reqt in newList)
                {
                    lw_Requests.Items.Add(reqt.ToString());
                }
            }
        }
    }
}