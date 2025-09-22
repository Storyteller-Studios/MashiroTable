using Mashiro.Api.HQU;
using System.Text.Json;

var option = new JsonSerializerOptions(JsonSerializerDefaults.Web)
{
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};
init:
Console.WriteLine("请输入统一认证Cookie");
var cookieString = Console.ReadLine();
if (string.IsNullOrWhiteSpace(cookieString))
{
    goto init;
}
var httpClient = new HttpClient();
var cookies = GetCookieDictionary(cookieString);
var result = await Request.GetClassInformation(httpClient, cookies, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
Console.WriteLine(JsonSerializer.Serialize(result, option));
static Dictionary<string,string> GetCookieDictionary(string cookieStrings)
{
    var result = new Dictionary<string,string>();
    var cookieStringArray = cookieStrings.Split("; ");
    foreach(var cookieString in cookieStringArray)
    {
        var index = cookieString.IndexOf('=');
        var key = cookieString[..index];
        var value = cookieString[(index+1)..];
        result[key] = value;
    }
    return result;
}