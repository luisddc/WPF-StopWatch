namespace WpfStopwatch.Models
{
    public class StopWatchModel : ModelBase
    {
        private TimeSpan _elapsedTime;
        public DateTime StartTime { get; set; }
        public bool IsRunning { get; set; }
        public TimeSpan ElapsedTime {
            get
            {
                return _elapsedTime;
            } 
            set 
            {
                _elapsedTime = value;
                NotifyPropertyChanged("ElapsedTime");
            } 
        }
    }
}
