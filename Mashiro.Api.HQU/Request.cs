using Mashiro.Common;
using Mashiro.Raw.HQU;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClassInformation = Mashiro.Raw.HQU.ClassInformation;
using CommonClassInformation = Mashiro.Common.ClassInformation;

namespace Mashiro.Api.HQU
{
    public static class Request
    {
        private static readonly Uri classEndpoint = new Uri("https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/modules/xskcb/cxxszhxqkb.do");
        private static readonly Uri semesterEndpoint = new Uri("https://jwapp.hqu.edu.cn/jwapp/sys/wdkb/modules/xskcb/xtcscx.do");
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="httpClient">需要使用的HttpClient</param>
        /// <param name="cookies">认证Cookies</param>
        /// <param name="userAgent">模拟User-Agent</param>
        /// <param name="semester">学期代码</param>
        /// <returns></returns>
        private static async Task<List<ClassInformation>?> GetClassRawInformation(
            HttpClient httpClient, 
            Dictionary<string,string> cookies, 
            string userAgent,
            string semester)
        {
            using var request = new HttpRequestMessage()
            {
                RequestUri = classEndpoint,
                Method = HttpMethod.Post,
            };
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Cookie", string.Join("; ", cookies.Select(c => $"{c.Key}={c.Value}")));
            var query = new Dictionary<string, string>
            {
                 { "XNXQDM", semester },
                 { "XNXQDM2", semester },
                 { "XNXQDM3", semester }
            };
            var content = new FormUrlEncodedContent(query);
            request.Content = content;
            using var response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ClassResponseMessage>(responseString);
            return data?.Contents?.SemesterScheduleResponse?.Rows;
        }

        private static async Task<string?> GetSemesterCode(
            HttpClient httpClient,
            Dictionary<string, string> cookies,
            string userAgent)
        {
            using var request = new HttpRequestMessage()
            {
                RequestUri = semesterEndpoint,
                Method = HttpMethod.Post,
            };
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Cookie", string.Join("; ", cookies.Select(c => $"{c.Key}={c.Value}")));
            var query = new Dictionary<string, string>()
            {
                 { "querySetting", "[{\"name\":\"CSDM\",\"linkOpt\":\"AND\",\"builderList\":\"cbl_String\",\"builder\":\"equal\",\"value\":\"PK\"},{\"name\":\"ZCSDM\",\"linkOpt\":\"AND\",\"builderList\":\"cbl_String\",\"builder\":\"equal\",\"value\":\"XSDXNXQDM\"}]" }
            };
            
            var content = new FormUrlEncodedContent(query);
            request.Content = content;
            using var response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<SemesterResponseMessage>(responseString);
            return data?.Contents?.SemesterIdResponse?.SemesterId;
        }
        public static async Task<List<CommonClassInformation>?> GetClassInformation(
            HttpClient httpClient,
            Dictionary<string, string> cookies,
            string userAgent)
        {
            var semester = await GetSemesterCode(httpClient, cookies, userAgent);
            if(semester != null)
            {
                var rawInformation = await GetClassRawInformation(httpClient, cookies, userAgent, semester);
                if(rawInformation != null)
                {
                    return rawInformation.Select(t=>t.RawToCommon())?.ToList();
                }
            }
            return null;
        }
    }
}
