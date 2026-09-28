using System.Collections.ObjectModel;
using Vehicles.Core;
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

namespace Vehicles.WpfApp;

public partial class MainWindow : Window
{
    private ObservableCollection<Vehicle> vehicles =
        new ObservableCollection<Vehicle>();

    public MainWindow()
    {
        InitializeComponent();

        VehiclesListBox.ItemsSource = vehicles;
    }

    private void AddCarButton_Click(object sender, RoutedEventArgs e)
    {
        vehicles.Add(new Car("BMW", "M4"));

        LogListBox.Items.Add("Car added.");
    }

    private void AddBoatButton_Click(object sender, RoutedEventArgs e)
    {
        vehicles.Add(new Boat("Bella", "500"));

        LogListBox.Items.Add("Boat added.");
    }

    private void AddAmphibiousButton_Click(object sender, RoutedEventArgs e)
    {
        vehicles.Add(new AmphibiousCar("Amphi", "X"));

        LogListBox.Items.Add("Amphibious vehicle added.");
    }

    private void VehiclesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (VehiclesListBox.SelectedItem is Vehicle vehicle)
        {
            VehicleInfoText.Text =
                $"{vehicle.Make} {vehicle.Model}\nOdometer: {vehicle.Odometer} km";
        }
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (VehiclesListBox.SelectedItem is Vehicle vehicle)
        {
            vehicles.Remove(vehicle);

            LogListBox.Items.Add($"{vehicle.Make} {vehicle.Model} removed.");

            VehicleInfoText.Text = "";
        }
    }
    private void DriveButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (VehiclesListBox.SelectedItem is not IDrivable vehicle)
                throw new Exception("Selected vehicle cannot drive.");

            if (!double.TryParse(DistanceTextBox.Text, out double km))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }

            if (km <= 0)
            {
                MessageBox.Show("Distance must be positive.");
                return;
            }

            string result = vehicle.Drive(km);

            LogListBox.Items.Add(result);

            if (VehiclesListBox.SelectedItem is Vehicle selectedVehicle)
            {
                VehicleInfoText.Text =
                    $"{selectedVehicle.Make} {selectedVehicle.Model}\nOdometer: {selectedVehicle.Odometer} km";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void SwimButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (VehiclesListBox.SelectedItem is not ISwimmable vehicle)
                throw new Exception("Selected vehicle cannot swim.");

            if (!double.TryParse(DistanceTextBox.Text, out double km))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }

            if (km <= 0)
            {
                MessageBox.Show("Distance must be positive.");
                return;
            }

            string result = vehicle.Swim(km);

            LogListBox.Items.Add(result);

            if (VehiclesListBox.SelectedItem is Vehicle selectedVehicle)
            {
                VehicleInfoText.Text =
                    $"{selectedVehicle.Make} {selectedVehicle.Model}\nOdometer: {selectedVehicle.Odometer} km";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}