namespace AndroidBinaryPost
{
    public partial class MainPage : ContentPage
    {
        private HttpClient HttpClient;

        public MainPage(HttpClient httpClient)
        {
            InitializeComponent();
            HttpClient = httpClient;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var data = new byte[1024];
            new Random().NextBytes(data);
            var content = new ByteArrayContent(data);
            var response = await HttpClient.PostAsync(
                $"https://{MauiProgram.ServerAddress}/BinaryService?operation=counter", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResultLabel.Text = responseContent;
            }
            else
            {
                ResultLabel.Text = $"SERVICE CALL FAILURE {response.StatusCode}";
            }
        }
    }

}
