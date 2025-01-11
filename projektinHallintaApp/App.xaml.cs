using System.Collections.ObjectModel;
using projektinHallintaApp.Views; // Lisää tämä
using Microsoft.Maui.Controls;

namespace projektinHallintaApp
{
    public partial class App : Application
    {
        // Globaali projektilista
        public static ObservableCollection<Project> Projects { get; private set; }

        public App()
        {
            InitializeComponent();

            // Alustetaan globaali projektikokoelma
            Projects = new ObservableCollection<Project>();

            // Määritellään pääsivu
            MainPage = new AppShell();
        }
    }
}
