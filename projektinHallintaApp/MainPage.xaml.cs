using System;
using System.Collections.ObjectModel;
using projektinHallintaApp.Views;




namespace projektinHallintaApp.Views
{
    public partial class MainPage : ContentPage
    {
        // Määritellään lista projekteista
        public ObservableCollection<Project> Projects { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Käytetään globaalisti määriteltyä projektikokoelmaa
            Projects = App.Projects; // Nyt tämä lista on saatavilla myös MainPage:ssa
            BindingContext = this; // Määritellään binding context
        }

        private void OnDeleteProjectClicked(object sender, EventArgs e)
        {
            // Haetaan poistettava projekti CommandParameter:sta
            var button = (Button)sender;
            var projectToDelete = (Project)button.CommandParameter;

            if (projectToDelete != null)
            {
                
                    // Poistetaan projekti
                    App.Projects.Remove(projectToDelete);
                
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RemoveExpiredProjects();
        }

        private void RemoveExpiredProjects()
        {
            // Luo kopio projekteista, jotka pitää poistaa
            var expiredProjects = Projects.Where(p => p.Deadline < DateTime.Now).ToList();

            foreach (var project in expiredProjects)
            {
                Projects.Remove(project);
            }
        }







        // Tapahtuma, joka käynnistyy kun "Add Project" -nappia painetaan
        private async void OnAddProjectClicked(object sender, EventArgs e)
        {
            // Navigoi AddProjectPage-sivulle
            await Shell.Current.GoToAsync("///CreateProjectPage");
        }

        // Tapahtuma, joka käynnistyy kun projektia valitaan ListView:ssä
        private async void OnProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Tarkistetaan, että valinta ei ole tyhjä
            if (e.SelectedItem != null)
            {
                var selectedProject = (Project)e.SelectedItem;

                // Voit tehdä jotain valitun projektin kanssa, esim. näyttää sen tiedot
                await DisplayAlert("Project Selected", $"Project: {selectedProject.Name}", "OK");

                // Poistetaan valinta
                ((ListView)sender).SelectedItem = null;
            }
        }
    }

    
}
