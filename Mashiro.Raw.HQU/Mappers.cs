using CommonClassInformation = Mashiro.Common.ClassInformation;
using CommonTimeTableInformation = Mashiro.Common.TimeTableInformation;


namespace Mashiro.Raw.HQU
{
    public static class Mapper
    {
        public static CommonClassInformation RawClassInformationToCommon(this ClassInformation classInfo)
        {
            var result = new CommonClassInformation()
            {
                StudentCount = classInfo.XKZRS,
                SubjectId = classInfo.KCH,
                ClassName = classInfo.BJDM_DISPLAY,
                CollegeName = classInfo.KKDWDM,
                AttendClasses = classInfo.SKBJ,
                Credit = classInfo.XF,
                TeacherName = classInfo.JSM,
                TestMethod = classInfo.KSLXDM_DISPLAY,
                TimeTable = classInfo.YPSJDD,
                StartIndex = classInfo.KSJC,
                EndIndex = classInfo.JSJC,
                AvailableWeeks = [.. classInfo.SKZC.Select(t => t == '1')]
            };
            return result;
        }
        public static CommonTimeTableInformation RawTimeTableToCommon(this TimeTableInformation timeInfo)
        {

            var result = new CommonTimeTableInformation()
            {
                StartTime = timeInfo.KSSJ,
                EndTime = timeInfo.JSSJ,
                Index = timeInfo.MC switch
                {
                    "第1节" => 1,
                    "第2节" => 2,
                    "第3节" => 3,
                    "第4节" => 4,
                    "第5节" => 5,
                    "第6节" => 6,
                    "第7节" => 7,
                    "第8节" => 8,
                    "第9节" => 9,
                    "第10节" => 10,
                    "第11节" => 11,
                    "第12节" => 12,
                    "第13节" => 13,
                    "中午" => 0,
                    _ => throw new ArgumentOutOfRangeException(nameof(timeInfo),"TimeTableInformation MC Out Of Range. Module:HQU")
                },
                Name = timeInfo.MC
            };
            return result;
        }
        public static CommonClassInformation RawClassInformationToCommon(this ClassInformation classInfo, IEnumerable<TimeTableInformation> timeInfos)
        {
            var startTime = timeInfos.FirstOrDefault(t => t.MC == classInfo.KSJC_DISPLAY)?.RawTimeTableToCommon();
            var endTime = timeInfos.FirstOrDefault(t=>t.MC == classInfo.JSJC_DISPLAY)?.RawTimeTableToCommon();
            
            var result = new CommonClassInformation()
            {
                StudentCount = classInfo.XKZRS,
                SubjectId = classInfo.KCH,
                ClassName = classInfo.BJDM_DISPLAY,
                CollegeName = classInfo.KKDWDM,
                AttendClasses = classInfo.SKBJ,
                Credit = classInfo.XF,
                TeacherName = classInfo.JSM,
                TestMethod = classInfo.KSLXDM_DISPLAY,
                TimeTable = classInfo.YPSJDD,
                StartIndex = classInfo.KSJC,
                EndIndex = classInfo.JSJC,
                StartTime = startTime,
                EndTime = endTime,
                AvailableWeeks = [.. classInfo.SKZC.Select(t => t == '1')]
            };
            return result;
        }
    }
}
