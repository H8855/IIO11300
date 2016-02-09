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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajat;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            pelaajat = new List<Pelaaja>();
            cmbSeura.Items.Add("Tappara");
            cmbSeura.Items.Add("JYP");
        }

        private void ApplyChanges()
        {
            //päivitetään UI vastaamaan kokoelman tietoja
            lbData.ItemsSource = null;
            lbData.ItemsSource = pelaajat;             
        }

        private void btnLuoPelaaja_Click(object sender, RoutedEventArgs e)
        {
            // pelaajat.Contains(Pelaaja.)
            if (txtEtunimi.Text.Trim().Length > 0 && txtSukunimi.Text.Trim().Length > 0 && txtSiirtohinta.Text.Trim().Length > 0 && cmbSeura.SelectedItem != null &&
                !OnkoPelaajaa(txtEtunimi.Text + " " + txtSukunimi.Text))
            {
                Pelaaja player = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, cmbSeura.SelectedValue.ToString(), int.Parse(txtSiirtohinta.Text));
                player.UpdateNames();
                pelaajat.Add(player);
                ApplyChanges();

            }
            else MessageBox.Show("Tarkista kentät!");
        }

        private bool OnkoPelaajaa(string haettava)
        {
            foreach (var item in pelaajat)
            {
                if (item.Kokonimi == haettava)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnTalletaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            /* Ei toimi, poistamisessa ongelma.
            try
            {
                Pelaaja player = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, cmbSeura.SelectedValue.ToString(), int.Parse(txtSiirtohinta.Text));
                player.UpdateNames();

                int index = lbData.SelectedIndex;
                lbData.Items.RemoveAt(index);
                lbData.Items.Insert(index, player);
                lbData.SelectedIndex = index;

                ApplyChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pelaaja player = (Pelaaja)lbData.SelectedItem;
            txtEtunimi.Text = player.Etunimi;
            txtSukunimi.Text = player.Sukunimi;
            txtSiirtohinta.Text = player.Siirtohinta.ToString();
            cmbSeura.SelectedItem = player.Seura;

        }

        private void btnPoistaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            /* poistamisessa ongelma.
            pelaajat.RemoveAt(lbData.SelectedIndex);
            ApplyChanges();
            */
        }

        private void btnKirjoitaPelaajat_Click(object sender, RoutedEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
