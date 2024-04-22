using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;

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

            //var content = new ByteArrayContent(data);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //var response = await HttpClient.PostAsync(
            //    $"https://{MauiProgram.ServerAddress}/BinaryService?operation=counter", content);

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://{MauiProgram.ServerAddress}/BinaryService?operation=counter")
            {
                Content = new ByteArrayContent(data)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = await HttpClient.SendAsync(request);

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
