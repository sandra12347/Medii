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
using VoluntariatModel;
using System.Data.Entity;
using System.Data;

namespace Medii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
       
        ActionState action = ActionState.Nothing;
        VoluntariatEntitiesModel ctx = new VoluntariatEntitiesModel();
        CollectionViewSource officeVSource;
        CollectionViewSource officeEventsVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using System.Data.Entity;
            officeVSource =
           ((System.Windows.Data.CollectionViewSource)(this.FindResource("officeViewSource")));
            officeVSource.Source = ctx.Offices.Local;
            ctx.Offices.Load();


            officeEventsVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("officeEventsViewSource")));

            officeEventsVSource.Source = ctx.Events.Local;
            ctx.Events.Load();
            ctx.Sponsors.Load();
            cmbOffices.ItemsSource = ctx.Offices.Local;
            //cmbOffices.DisplayMemberPath = "StreetName";
            cmbOffices.SelectedValuePath = "OfficeId";
            cmbSponsor.ItemsSource = ctx.Sponsors.Local;
            //cmbSponsor.DisplayMemberPath = "Adress";
            cmbSponsor.SelectedValuePath = "SponsorId";
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            officeVSource.View.MoveCurrentToNext();
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            officeVSource.View.MoveCurrentToPrevious();
        }

        private void btnNew1_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit1_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnDelete1_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }
        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            officeVSource.View.MoveCurrentToNext();
        }
        private void btnPrev1_Click(object sender, RoutedEventArgs e)
        {
            officeVSource.View.MoveCurrentToPrevious();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnCancel1_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlVoluntariat.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Offices":
                    SaveOffices();
                    break;
                case "Sponsor":
                    SaveSponsors();
                    break;
                case "Events":
                    break;
            }
            ReInitialize();
        }
        private void btnSave1_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlVoluntariat.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Offices":
                    SaveOffices();
                    break;
                case "Sponsor":
                    SaveSponsors();
                    break;
                case "Events":
                    break;
            }
            ReInitialize();
        }
        private void SaveOffices()
        {
            Office office = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Office entity
                    office = new Office()
                    {
                        StreetName = streetNameTextBox.Text.Trim(),
                        Caretaker = caretakerTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Offices.Add(office);
                    officeVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    office = (Office)officeDataGrid.SelectedItem;
                    office.StreetName = streetNameTextBox.Text.Trim();
                    office.Caretaker = caretakerTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    office = (Office)officeDataGrid.SelectedItem;
                    ctx.Offices.Remove(office);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                officeVSource.View.Refresh();
            }

        }


        private void SaveSponsors()
        {
            Sponsor sponsor = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    sponsor = new Sponsor()
                    {
                        Adress = adressTextBox.Text.Trim(),
                        Name = nameTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Sponsors.Add(sponsor);
                    sponsorVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sponsor = (Sponsor)sponsorDataGrid.SelectedItem;
                    sponsor.Adress = adressTextBox.Text.Trim();
                    sponsor.Name = nameTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sponsor = (Sponsor)sponsorDataGrid.SelectedItem;
                    ctx.Sponsors.Remove(sponsor);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sponsorVSource.View.Refresh();
            }

        }


        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }


        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }


        



    }



}


