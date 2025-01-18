using System;
using System.Collections.ObjectModel;
using System.Linq; // Tämän tarvitaan LINQ-toimintoihin
using projektinHallintaApp.Views;

namespace projektinHallintaApp.Views
{
    public partial class MainPage : ContentPage
    {
        private DatabaseService _databaseService;
        public ObservableCollection<Project> Projects { get; set; }

        public MainPage()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();
            Projects = new ObservableCollection<Project>(_databaseService.GetProjects());

            BindingContext = this; // Bindataan MainPage tämän luokan dataan
        }

        private void OnDeleteProjectClicked(object sender, EventArgs e)
        {
            var project = (sender as Button).BindingContext as Project;

            if (project != null)
            {
                _databaseService.DeleteProject(project); // Poista tietokannasta
                Projects.Remove(project); // Päivitä näkymä
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Päivitä projektit tietokannasta
            Projects.Clear();
            var projectsFromDb = _databaseService.GetProjects();
            foreach (var project in projectsFromDb)
            {
                Projects.Add(project);
            }

            // Tarkista ja poista vanhentuneet projektit
            RemoveExpiredProjects();
        }

        private void RemoveExpiredProjects()
        {
            // Etsi vanhentuneet projektit
            var expiredProjects = Projects.Where(p => p.Deadline < DateTime.Now).ToList();

            foreach (var project in expiredProjects)
            {
                Projects.Remove(project); // Poista näkymästä
                _databaseService.DeleteProject(project); // Poista myös tietokannasta
            }
        }

        private async void OnAddProjectClicked(object sender, EventArgs e)
        {
            // Siirrytään CreateProjectPage-sivulle
            await Shell.Current.GoToAsync("///CreateProjectPage");
        }

        private async void OnProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedProject = (Project)e.SelectedItem;

                // Näytä valitun projektin tiedot käyttäjälle
                await DisplayAlert("Project Selected", $"Project: {selectedProject.Name}", "OK");

                // Poistetaan valinta
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
