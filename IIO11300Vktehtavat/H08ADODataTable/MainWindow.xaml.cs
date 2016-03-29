using System;
using System.Data;
using System.Data.SqlClient;
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

namespace H08ADODataTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        DataView dv;
        List<string> cities;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IniMyStuff()
        {
            //kaupunkien nimet ComboBoxiin
            cities = new List<string>();
            //v1
            //cities.Add("Jyväskylä");
            //cities.Add("Helsinki");
            //cities.Add("New York");
            //v2
            string kaupunki = "";
            foreach (DataRow item in dt.Rows)
            {
                kaupunki = item[3].ToString();
                //tai
                kaupunki = item["City"].ToString();
                if (!cities.Contains(kaupunki))
                    cities.Add(kaupunki);
            }
            //v3
            //var result = (from c in dt select c.City).Distinct();
            //databindaus
            cbCities.ItemsSource = cities;
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            //haetaan viiniasiakkaat palvelimelta ja näytetään listboxissa
            try
            {
                GetData();
                //versio 1 dataview filtteroi tai sorttaa
                dv = dt.DefaultView;               
                //datan sitominen UI-kontrolliin, kelpaa DataTable, DataView, DataReader, oliokokoelma
                lbCustomers.DataContext = dv;
                //huom DataTable sarake on case-sensitive
                lbCustomers.DisplayMemberPath = "Lastname";
                IniMyStuff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region METHODS
        private void GetData()
        {
            //luodaan yhteys tietokantaan connection stringin avulla
            try
            {
                using (SqlConnection conn = new SqlConnection(H08ADODataTable.Properties.Settings.Default.Tietokanta))
                {
                    dt = new DataTable();
                    string sql = "SELECT * FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    //pistetään data-adapteri hakemaan tiedot muistiin=Datatableen
                    da.Fill(dt);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vaihdetaan stackpanelin datacontext viittaamaan valittuun asiakkaaseen
            spCustomer.DataContext = lbCustomers.SelectedItem;
        }

        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //asetetaan DataView:lle filtteri
            dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
        }
    }
}
