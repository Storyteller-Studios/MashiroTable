using Mashiro.Raw.HQU;
using System.Text.Json.Serialization;

namespace Mashiro.Api.HQU
{
    public class ClassResponseMessage
    {
        [JsonPropertyName("datas")]
        public Datas? Contents { get; set; }
        public class Datas
        {
            [JsonPropertyName("cxxszhxqkb")]
            public SemesterScheduleResponse? SemesterScheduleResponse { get; set; }
        }
        public class SemesterScheduleResponse
        {
            [JsonPropertyName("rows")]
            public List<ClassInformation> Rows { get; set; } = [];
        }
    }
    public class SemesterResponseMessage
    {
        [JsonPropertyName("datas")]
        public Datas? Contents { get; set; }
        public class Datas
        {
            [JsonPropertyName("xtcscx")]
            public SemesterIdResponse? SemesterIdResponse { get; set; }
        }
        public class SemesterIdResponse
        {
            [JsonPropertyName("CSZA")]
            public string SemesterId { get; set; } = string.Empty;
        }
    }
}
