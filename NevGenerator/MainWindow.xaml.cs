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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace NevGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<String> csaladiNevek = new ObservableCollection<string>();
        private ObservableCollection<String> utoNevek = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadCsaladNevek(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                foreach(var nev in File.ReadAllLines(ofd.FileName).ToList())
                {
                    csaladiNevek.Add(nev);
                }
                lbCsaladNevek.ItemsSource= csaladiNevek;
            }
        }

        private void loadUtoNevek(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                foreach (var nev in File.ReadAllLines(ofd.FileName).ToList())
                {
                    utoNevek.Add(nev);
                }
                lbUtoNevek.ItemsSource = utoNevek;
            }
        }

        private void neveketGeneral(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int nevekSzama = (int)sliderLetrehozandoSzam.Value;
            for (int i =0; i < nevekSzama; i++)
            {
                try
                {
                    if (EgyUtoNev.IsChecked.Value)
                    {
                        String csaladnev = csaladiNevek[r.Next(0,csaladiNevek.Count)];
                        String utonev1 = utoNevek[r.Next(0, utoNevek.Count)];
                        utoNevek.Remove(utonev1);
                        csaladiNevek.Remove(csaladnev);
                        lbGeneraltNevek.Items.Add($"{csaladnev} {utonev1}");
                    }
                    else
                    {
                        String csaladnev = csaladiNevek[r.Next(0, csaladiNevek.Count)];
                        String utonev1 = utoNevek[r.Next(0, utoNevek.Count)];
                        utoNevek.Remove(utonev1);
                        csaladiNevek.Remove(csaladnev);
                        String utonev2 = utoNevek[r.Next(0, utoNevek.Count)];
                        utoNevek.Remove(utonev2);
                        lbGeneraltNevek.Items.Add($"{csaladnev} {utonev1} {utonev2}");
                    }
                }catch(Exception ex)
                {

                }
            }
            stbRendezes.Content = "";
        }

        private void generaltTorlese(object sender, RoutedEventArgs e)
        {
            while(lbGeneraltNevek.Items.Count > 0)
            {
                String[] jelenlegi = lbGeneraltNevek.Items[0].ToString().Split(' ');
                csaladiNevek.Add(jelenlegi[0]);
                utoNevek.Add((jelenlegi[1]));
                if(jelenlegi.Length > 2)
                {
                    utoNevek.Add(jelenlegi[2]);
                }
                lbGeneraltNevek.Items.RemoveAt(0);
            }
            stbRendezes.Content = "";
        }

        private void nevekRendezese(object sender, RoutedEventArgs e)
        {
            lbGeneraltNevek.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
            stbRendezes.Content = "Rendezett névsor";
        }

        private void nevekMentese(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension= true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Szöveges fájl (*.txt) | *.txt| CSV fájl (*.csv) | *.csv| Összes fájl (*.*) | *.*";
            sfd.Title = "Adja meg a névsor nevét!";
            if(sfd.ShowDialog() == true)
            {
                try
                {
                    var fileName = sfd.FileName;
                    StreamWriter sw = new StreamWriter(fileName);
                    switch (System.IO.Path.GetExtension(fileName).ToLower()) {
                        case ".txt":
                            foreach(var nev in lbGeneraltNevek.Items)
                            {
                                sw.WriteLine(nev.ToString);
                            }
                            break;
                        case ".csv":
                            foreach (var nev in lbGeneraltNevek.Items)
                            {
                               sw.WriteLine(nev.ToString().Replace(' ',';'));
                            }
                            break;
                        default:
                            foreach (var nev in lbGeneraltNevek.Items)
                            {
                                sw.WriteLine(nev.ToString());
                            }
                            break;
                    }
                    
                    sw.Close();
                    MessageBox.Show("Sikeres mentés!", "", MessageBoxButton.OK);
                }
                catch (Exception ex) {
                    MessageBox.Show("Sikertelen mentés!", ex.Message, MessageBoxButton.OK);
                }
            }
        }

        private void lbGeneraltNevek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lbGeneraltNevek.SelectedIndex != -1)
            {
                String[] jelenlegi = lbGeneraltNevek.Items[lbGeneraltNevek.SelectedIndex].ToString().Split(' ');
                csaladiNevek.Add(jelenlegi[0]);
                utoNevek.Add((jelenlegi[1]));
                if (jelenlegi.Length > 2)
                {
                    utoNevek.Add(jelenlegi[2]);
                }
                lbGeneraltNevek.Items.RemoveAt(lbGeneraltNevek.SelectedIndex);
            }
        }
    }
}
