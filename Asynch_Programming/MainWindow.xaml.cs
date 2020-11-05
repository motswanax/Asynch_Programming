using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Asynch_Programming
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

        // can only use the await operator in an async method.
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadHtml("http://msdn.microsoft.com");
            var html = await GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show(html.Substring(0, 10));
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

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"c:\projects\result.html"))
            {
                streamWriter.Write(html);
            }
        }
    }
}
