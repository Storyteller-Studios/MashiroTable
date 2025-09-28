using Microsoft.Web.WebView2.Wpf;
using System.Text.Json;

namespace Mashiro.Capture.HQU
{
    public static class HQUFilter
    {

        public static async void OnWebResourceResponseReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponseReceivedEventArgs e)
        {
            if (e.Request.Uri == "https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/modules/xskcb/cxxszhxqkb.do")
            {
                var content = await e.Response.GetContentAsync();
                var table = JsonSerializer.Deserialize<ClassResponseMessage>(content);
                return;
            }
            if(e.Request.Uri == "https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/modules/jshkcb/jc.do")
            {
                var content = await e.Response.GetContentAsync();
                var table = JsonSerializer.Deserialize<TimeTableResponseMessage>(content);
                return;
            }


        }

        public static void OnSourceChanged(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            var browser = (WebView2)sender!;
            if (browser?.Source?.ToString() == "https://jwapp.hqu.edu.cn/jwapp/sys/emaphome/portal/index.do?forceCas=1")
            {
                browser!.Source = new Uri("https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/*default/index.do?EMAP_LANG=zh#/xskcb");
            }
        }
    }
}
