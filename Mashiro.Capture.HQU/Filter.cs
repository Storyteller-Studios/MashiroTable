using Microsoft.Web.WebView2.Wpf;
using System.Text.Json;

namespace Mashiro.Capture.HQU
{
    public class HQUFilter
    {
        public bool UseVPN { get; set; } = false;
        public delegate void ClassResponseMessageReceivedDelegate(ClassResponseMessage message);
        public delegate void TimeTableResponseMessageReceivedDelegate(TimeTableResponseMessage message);
        public event ClassResponseMessageReceivedDelegate? OnClassResponseMessageReceived;
        public event TimeTableResponseMessageReceivedDelegate? OnTimeTableResponseMessageReceived;
        public async void OnWebResourceResponseReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponseReceivedEventArgs e)
        {
            if (e.Request.Uri.Contains("/jwapp/sys/wdkb/modules/xskcb/cxxszhxqkb.do"))
            {
                var content = await e.Response.GetContentAsync();
                var table = JsonSerializer.Deserialize<ClassResponseMessage>(content);
                if(table != null)
                {
                    OnClassResponseMessageReceived?.Invoke(table);
                }
                return;
            }
            if(e.Request.Uri.Contains("/jwapp/sys/wdkb/modules/jshkcb/jc.do"))
            {
                var content = await e.Response.GetContentAsync();
                var table = JsonSerializer.Deserialize<TimeTableResponseMessage>(content);
                if (table != null)
                {
                    OnTimeTableResponseMessageReceived?.Invoke(table);
                }
                return;
            }
        }

        public void OnSourceChanged(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            var browser = (WebView2)sender!;
            if (browser!.Source.AbsolutePath.Contains("/jwapp/sys/emaphome/portal/index.do"))
            {
                if (UseVPN)
                {

                    browser!.Source = new Uri("https://jwapp-hqu-edu-cn-s.atrust.hqu.edu.cn:9443/jwapp/sys/wdkb/*default/index.do?EMAP_LANG=zh#/xskcb");
                }
                else
                {
                    browser!.Source = new Uri("https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/*default/index.do?EMAP_LANG=zh#/xskcb");
                }
            }
        }
    }
}
