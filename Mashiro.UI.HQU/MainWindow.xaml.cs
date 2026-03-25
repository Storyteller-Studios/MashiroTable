using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Mashiro.Capture.HQU;
using Mashiro.Raw.HQU;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Mashiro.UI.HQU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HQUFilter _filter = new();
        private TimeTableResponseMessage? _timeTableResponse;
        private ClassResponseMessage? _classResponse;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browser_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Browser.SourceChanged += _filter.OnSourceChanged;
            Browser.CoreWebView2.WebResourceResponseReceived += _filter.OnWebResourceResponseReceived;
            _filter.OnClassResponseMessageReceived += OnClassResponseMessageReceived;
            _filter.OnTimeTableResponseMessageReceived += OnTimeTableResponseMessageReceived;
        }

        private void OnTimeTableResponseMessageReceived(TimeTableResponseMessage message)
        {
            _timeTableResponse = message;
            if (_classResponse != null)
            {
                MessageBox.Show("课程信息获取完成, 请点击开始导出以导出课程表", "信息获取完成", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnClassResponseMessageReceived(ClassResponseMessage message)
        {
            _classResponse = message;
            if (_timeTableResponse != null)
            {
                MessageBox.Show("课程信息获取完成, 请点击开始导出以导出课程表", "信息获取完成", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Browser_Unloaded(object sender, RoutedEventArgs e)
        {
            Browser.SourceChanged -= _filter.OnSourceChanged;
            Browser.CoreWebView2.WebResourceResponseReceived -= _filter.OnWebResourceResponseReceived;
            _filter.OnClassResponseMessageReceived -= OnClassResponseMessageReceived;
            _filter.OnTimeTableResponseMessageReceived -= OnTimeTableResponseMessageReceived;
        }
        public void TryParseDataToICSFile()
        {
            if (_classResponse == null || _timeTableResponse == null)
            {
                MessageBox.Show("获取课程数据失败, 请检查是否已经正确登录", "发生预期外的情况", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!SemesterStrtDatePicker.SelectedDate.HasValue || SemesterStrtDatePicker.SelectedDate.Value.DayOfWeek != DayOfWeek.Sunday)
            {
                MessageBox.Show("请选择第一周星期日", "发生预期外的情况", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var calendar = new Calendar();
            var timeTable = _timeTableResponse?.Contents?.TimeTableResponse?.Rows;
            if (timeTable == null)
            {
                MessageBox.Show("获取课程时间数据失败", "发生预期外的情况", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var classData = _classResponse?.Contents?.SemesterScheduleResponse?.Rows?.Select(t => t.RawClassInformationToCommon(timeTable!)).ToList();
            var start = SemesterStrtDatePicker.SelectedDate.Value;
            foreach (var item in classData!)
            {
                for (int i = 0; i < item.AvailableWeeks.Count; i++)
                {
                    if (item.AvailableWeeks[i] == false) continue;
                    var addDays = start.AddDays(i * 7 + item.DayOfWeek);
                    var startTimeSpan = TimeSpan.Parse(item.StartTime!.StartTime);
                    var endTimeSpan = TimeSpan.Parse(item.EndTime!.EndTime);
                    var calendarEvent = new CalendarEvent()
                    {
                        Summary = item.ClassName,
                        Description = item.TimeTable,
                        Location = item.Location,
                        Start = new CalDateTime(addDays + startTimeSpan, "Asia/Shanghai"),
                        End = new CalDateTime(addDays + endTimeSpan, "Asia/Shanghai")
                    };
                    calendar.Events.Add(calendarEvent);
                }
            }
            var serializer = new CalendarSerializer();
            var icsString = serializer.SerializeToString(calendar);
            var dialog = new SaveFileDialog()
            {
                DefaultExt = ".ics",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "日历文件|*.ics",
                FileName = "课程表"
            };
            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                File.WriteAllText(dialog.FileName, icsString);
                MessageBox.Show("ICS文件导出完成", "导出完成", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            TryParseDataToICSFile();
        }

        private void VPNCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Browser.Source = new Uri("https://jwapp-hqu-edu-cn-s.atrust.hqu.edu.cn:9443");
            _filter.UseVPN = true;
        }

        private void VPNCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Browser.Source = new Uri("https://jwapp.hqu.edu.cn");
            _filter.UseVPN = false;
        }

        private void Redirect_Click(object sender, RoutedEventArgs e)
        {
            if (VPNCheckBox.IsChecked == true) 
            {
                Browser.Source = new Uri("https://jwapp-hqu-edu-cn-s.atrust.hqu.edu.cn:9443");
                
            }
            else
            {
                Browser.Source = new Uri("https://jwapp.hqu.edu.cn");
            }
        }
    }
}