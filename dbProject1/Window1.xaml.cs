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

namespace dbProject1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<User> users = new List<User>();
        int? id;
        public Window1(int? ID)
        {
            InitializeComponent();
            id = ID;
            cb_type.ItemsSource = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();
            cb_type.SelectedIndex = 0;
            cb_status.ItemsSource = Enum.GetValues(typeof(RequestStatus)).Cast<RequestStatus>();
            cb_status.SelectedIndex = 0;
            User user = new User("Виктор Юрьевич Абоба");
            users.Add(user);
            user = new User("Савелий Андреевич Юрьевич");
            users.Add(user);
            user = new User("Никита Абоба Амонг Ас");
            users.Add(user);
            foreach (User userrrrr in users)
            {
                cb_addResp.Items.Add(userrrrr.Name);
            }
            cb_addResp.SelectedIndex = 0;
            //tb_ID.Text = new Random().Next().ToString();
            if(id != null)
            {
                ApplicationContext ac = new ApplicationContext();
                var item = ac.Requests.FirstOrDefault(q => q.ID == id);
                tb_date.Text = item.creationDate;
                cb_type.SelectedItem = item.type;
                tb_mod.Text = item.model;
                tb_desc.Text = item.description;
                tb_name.Text = item.name;
                tb_telephone.Text = item.telephoneNumber;
                cb_status.SelectedItem = item.status;
                cb_addResp.Text = item.responsiveMan;
            }
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                if (id == null)
                {
                    Request newRequest = new Request(
                        new Random().Next(),
                        tb_date.Text,
                        (DeviceType)cb_type.SelectedItem,
                        tb_mod.Text,
                        tb_desc.Text,
                        tb_name.Text,
                        tb_telephone.Text,
                        (RequestStatus)cb_status.SelectedItem);
                    newRequest.responsiveMan = cb_addResp.SelectedValue.ToString();
                    var list = ac.Requests.Append(newRequest);
                    list.Append(newRequest);
                    ac.Requests = list;

                    var liskt = list;
                }
                else
                {
                    var item = ac.Requests.FirstOrDefault(q => q.ID == id);
                    item.creationDate = tb_date.Text;
                    item.type = (DeviceType)cb_type.SelectedItem;
                    item.model = tb_mod.Text;
                    item.description = tb_desc.Text;
                    item.name = tb_desc.Text;
                    item.telephoneNumber = tb_telephone.Text;
                    item.status = (RequestStatus)cb_status.SelectedItem;
                    item.responsiveMan = cb_addResp.Text;
                }
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
