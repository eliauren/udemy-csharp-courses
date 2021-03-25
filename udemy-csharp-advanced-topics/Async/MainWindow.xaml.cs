using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //DownloadHtml("http://msdn.microsoft.com");
            var getHtmlTask = GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show("Waiting for the task to complete");

            var html = await getHtmlTask;
            MessageBox.Show(html.Substring(0, 10));
        }

        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "result.html"))
            {
                streamWriter.Write(html);
            }
        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public string GetHtml(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }
    }
}