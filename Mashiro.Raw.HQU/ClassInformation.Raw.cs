using System.Text.Json.Serialization;

namespace Mashiro.Raw.HQU
{
    public class ClassInformation
    {
        /// <summary>
        /// 专业
        /// </summary>
        public string ZYDM { get; set; } = string.Empty;

        /// <summary>
        /// 开始时间
        /// </summary>
        public string KSSJ { get; set; } = string.Empty;

        /// <summary>
        /// 开课单位 (字符串)
        /// </summary>
        public string KKDWDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 开始节次
        /// </summary>
        public int KSJC { get; set; } = -1;

        /// <summary>
        /// 上课周次
        /// </summary>
        public string SKZC { get; set; } = string.Empty;

        /// <summary>
        /// 单位
        /// </summary>
        public string DWDM { get; set; } = string.Empty;

        /// <summary>
        /// 上课教师
        /// </summary>
        public string SKJS { get; set; } = string.Empty;

        /// <summary>
        /// 结束节次 (字符串)
        /// </summary>
        public string JSJC_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 考试类型 (字符串)
        /// </summary>
        public string KSLXDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 年级
        /// </summary>
        public string NJDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 学年学期
        /// </summary>
        public string XNXQDM { get; set; } = string.Empty;

        /// <summary>
        /// 课表ID
        /// </summary>
        public string KBID { get; set; } = string.Empty;

        /// <summary>
        /// 是否已提交
        /// </summary>
        public string SFYTJ { get; set; } = string.Empty;

        /// <summary>
        /// 上课班级
        /// </summary>
        public string SKBJ { get; set; } = string.Empty;

        /// <summary>
        /// 开课单位
        /// </summary>
        public string KKDWDM { get; set; } = string.Empty;

        /// <summary>
        /// 开始节次 (字符串)
        /// </summary>
        public string KSJC_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 考试类型
        /// </summary>
        public string KSLXDM { get; set; } = string.Empty;

        /// <summary>
        /// 专业 (字符串)
        /// </summary>
        public string ZYDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 课程分类
        /// </summary>
        public string KCFL_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 校公选课类别
        /// </summary>
        public string XGXKLBDM { get; set; } = string.Empty;

        /// <summary>
        /// 课程名
        /// </summary>
        public string KCM { get; set; } = string.Empty;

        /// <summary>
        /// 教室
        /// </summary>
        public string JASDM { get; set; } = string.Empty;

        /// <summary>
        /// 课表类别
        /// </summary>
        public string KBLB { get; set; } = string.Empty;

        /// <summary>
        /// 年级
        /// </summary>
        public string NJDM { get; set; } = string.Empty;

        /// <summary>
        /// 教学楼 (字符串)
        /// </summary>
        public string JXLDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 课程号
        /// </summary>
        public string KCH { get; set; } = string.Empty;

        /// <summary>
        /// 是否调课 (字符串)
        /// </summary>
        public string ISTK_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 学时
        /// </summary>
        public double XS { get; set; } = 0;

        /// <summary>
        /// 课程性质
        /// </summary>
        public string KCXZDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 教室名称
        /// </summary>
        public string JASMC { get; set; } = string.Empty;

        /// <summary>
        /// 数据唯一标识
        /// </summary>
        public string WID { get; set; } = string.Empty;

        /// <summary>
        /// 结束节次
        /// </summary>
        public int JSJC { get; set; } = 0; 

        /// <summary>
        /// 学校校区
        /// </summary>
        public string XXXQDM { get; set; } = string.Empty;

        /// <summary>
        /// 校公选课类别 (字符串)
        /// </summary>
        public string XGXKLBDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 学号
        /// </summary>
        public string XH { get; set; } = string.Empty;

        /// <summary>
        /// 班级 (字符串)
        /// </summary>
        public string BJDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 选课总人数
        /// </summary>
        public string XKZRS { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string XM { get; set; } = string.Empty;

        /// <summary>
        /// 是否调课
        /// </summary>
        public int ISTK { get; set; } = 0;

        /// <summary>
        /// 已排时间地点
        /// </summary>
        public string YPSJDD { get; set; } = string.Empty;

        /// <summary>
        /// 学分
        /// </summary>
        public double XF { get; set; } = 0;

        /// <summary>
        /// 上课星期
        /// </summary>
        public int SKXQ { get; set; } = 0;

        /// <summary>
        /// 课程性质
        /// </summary>
        public string KCXZDM { get; set; } = string.Empty;


        /// <summary>
        /// 授课形式
        /// </summary>
        public string SKXSDM { get; set; } = string.Empty;

        public string KCXZMC { get; set; } = string.Empty;

        /// <summary>
        /// 教学班ID
        /// </summary>
        public string JXBID { get; set; } = string.Empty;

        /// <summary>
        /// 体育项目 (字符串)
        /// </summary>
        public string TYXMDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 学年学期 (字符串)
        /// </summary>
        public string XNXQDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 学校校区 (字符串)
        /// </summary>
        public string XXXQDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 课程类别 (字符串)
        /// </summary>
        public string KCLBDM_DISPLAY { get; set; } = string.Empty;
        public string SKXSMC { get; set; } = string.Empty;

        /// <summary>
        /// 授课形式 (字符串)
        /// </summary>
        public string SKXSDM_DISPLAY { get; set; } = string.Empty;


        /// <summary>
        /// 课序号
        /// </summary>
        public string KXH { get; set; } = string.Empty;

        /// <summary>
        /// 班级
        /// </summary>
        public string BJDM { get; set; } = string.Empty;

        /// <summary>
        /// 是否主辅修班
        /// </summary>
        public string SFZFXB { get; set; } = string.Empty;

        /// <summary>
        /// 课程类别
        /// </summary>
        public string KCLBDM { get; set; } = string.Empty;

        public string KCFL { get; set; } = string.Empty;

        /// <summary>
        /// 上课周次
        /// </summary>
        public string ZCMC { get; set; } = string.Empty;

        /// <summary>
        /// 教师名
        /// </summary>
        public string JSM { get; set; } = string.Empty;

        /// <summary>
        /// 单位 (字符串)
        /// </summary>
        public string DWDM_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 结束时间
        /// </summary>
        public string JSSJ { get; set; } = string.Empty;

        /// <summary>
        /// 上课星期 (字符串)
        /// </summary>
        public string SKXQ_DISPLAY { get; set; } = string.Empty;

        /// <summary>
        /// 教学楼代码
        /// </summary>
        public string JXLDM { get; set; } = string.Empty;

        /// <summary>
        /// 实践起讫周
        /// </summary>
        public string SJZCMC { get; set; } = string.Empty;

        /// <summary>
        /// 体育项目代码
        /// </summary>
        public string TYXMDM { get; set; } = string.Empty;

        public string SJLY { get; set; } = string.Empty;
    }
}
