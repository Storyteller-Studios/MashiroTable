using CommonClassInformation = Mashiro.Common.ClassInformation;


namespace Mashiro.Raw.HQU
{
    public static class Mapper
    {
        public static CommonClassInformation RawToCommon(this ClassInformation information)
        {
            var result = new CommonClassInformation()
            {
                StudentCount = information.XKZRS,
                SubjectId = information.KCH,
                ClassName = information.BJDM_DISPLAY,
                CollegeName = information.KKDWDM,
                AttendClasses = information.SKBJ,
                Credit = information.XF,
                TeacherName = information.JSM,
                TestMethod = information.KSLXDM_DISPLAY,
                TimeTable = information.YPSJDD
            };
            return result;
        }
    }
}
