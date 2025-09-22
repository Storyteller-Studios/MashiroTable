using System.Text.Json.Serialization;

namespace Mashiro.Raw.HQU
{
    public class TimeTableInformation
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string KSSJ { get; set; } = string.Empty;
        /// <summary>
        /// 结束时间
        /// </summary>
        public string JSSJ { get; set; } = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string MC { get; set; } = string.Empty;
        /// <summary>
        /// 排序
        /// </summary>
        public int PX { get; set; } = -1;
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string WID { get; set; } = string.Empty;
    }
}
