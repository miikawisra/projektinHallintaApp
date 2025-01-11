using projektinHallintaApp.Views;

namespace projektinHallintaApp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();  // T�m� kutsuu XAML-tiedoston komponenteja
        }
    

private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Tarkista, ett� EmailEntry ei ole null
            if (EmailEntry == null)
            {
                await DisplayAlert("Error", "Email entry is not initialized.", "OK");
                return;
            }

            // Hae s�hk�postin sis�lt�
            string email = EmailEntry.Text;

            // Tarkista, ett� s�hk�posti ei ole tyhj�
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Please enter your email.", "OK");
                return;
            }

            // Simuloidaan kirjautumisen tarkistusta
            bool isAuthenticated = await AuthenticateUser(email);

            if (isAuthenticated)
            {
                // Tyhjennet��n navigointijono ja siirryt��n MainPage-sivulle
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Error", "Invalid login credentials.", "OK");
            }
        }

        private Task<bool> AuthenticateUser(string email)
        {
            if (email == "Miika")
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
