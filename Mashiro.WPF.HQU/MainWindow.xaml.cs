using Mashiro.Capture.HQU;
using Mashiro.Common;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mashiro.WPF.HQU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Browser.CoreWebView2InitializationCompleted += Browser_CoreWebView2InitializationCompleted;

        }

        private void Browser_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Browser.SourceChanged += HQUFilter.OnSourceChanged;
            Browser.CoreWebView2.WebResourceResponseReceived += HQUFilter.OnWebResourceResponseReceived;
        }

    }
}