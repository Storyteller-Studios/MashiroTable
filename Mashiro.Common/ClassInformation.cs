namespace Mashiro.Common
{
    public class ClassInformation
    {
        /// <summary>
        /// 学生数
        /// </summary>
        public string StudentCount { get; set; } = string.Empty;
        /// <summary>
        /// 学分
        /// </summary>
        public double Credit { get; set; } = 0;
        /// <summary>
        /// 教师名
        /// </summary>
        public string TeacherName { get; set; } = string.Empty;
        /// <summary>
        /// 学院名
        /// </summary>
        public string CollegeName {  get; set; } = string.Empty;
        /// <summary>
        /// 考察方法
        /// </summary>
        public string TestMethod {  get; set; } = string.Empty;
        /// <summary>
        /// 课程代码
        /// </summary>
        public string SubjectId { get; set; } = string.Empty;
        /// <summary>
        /// 班级名
        /// </summary>
        public string ClassName { get; set; } = string.Empty;
        /// <summary>
        /// 出席班级
        /// </summary>
        public string AttendClasses {  get; set; } = string.Empty;
        /// <summary>
        /// 上课时间表
        /// </summary>
        public string TimeTable { get; set; } = string.Empty;
        /// <summary>
        /// 课程开始节次
        /// </summary>
        public int StartIndex { get; set; } = -1;
        /// <summary>
        /// 课程开始时间
        /// </summary>
        public TimeTableInformation? StartTime {  get; set; }
        /// <summary>
        /// 课程结束节次
        /// </summary>
        public int EndIndex { get; set; } = -1;
        /// <summary>
        /// 课程结束时间
        /// </summary>
        public TimeTableInformation? EndTime { get; set; }
        /// <summary>
        /// 开课周数
        /// </summary>
        public List<bool> AvailableWeeks { get; set; } = [];
    }
}
