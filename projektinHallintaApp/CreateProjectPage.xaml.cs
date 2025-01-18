using System;
using System.Collections.ObjectModel;
using projektinHallintaApp.Views; // K‰yt‰ t‰t‰ viittaamaan Project-luokkaan

namespace projektinHallintaApp.Views
{
    public partial class CreateProjectPage : ContentPage
    {
        private DatabaseService _databaseService;

        // Oletuskonstruktori, joka viittaa globaalisti App.Projects
        public CreateProjectPage() : this(App.Projects) // K‰ytet‰‰n globaalisti m‰‰ritelty‰ projektikokoelmaa
        {
        }

        // Konstruktori, jossa on ObservableCollection
        public CreateProjectPage(ObservableCollection<Project> projects)
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnSaveProjectClicked(object sender, EventArgs e)
        {
            string projectName = ProjectNameEntry.Text;
            DateTime deadline = DeadlinePicker.Date;

            if (string.IsNullOrEmpty(projectName))
            {
                await DisplayAlert("Error", "Please enter a project name.", "OK");
                return;
            }

            // Luo uusi projekti ja tallenna tietokantaan
            var newProject = new Project
            {
                Name = projectName,
                Deadline = deadline,
                
            };

            _databaseService.SaveProject(newProject);

            // Navigoidaan takaisin MainPage-sivulle
            await Shell.Current.GoToAsync("//MainPage");

        }
        private async void ReturnToMainPage(object sender, EventArgs e) 
        {
            await Shell.Current.GoToAsync("//MainPage");

        }
    }
}
    
