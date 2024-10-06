using WpfStopwatch.Models;
using System.Windows.Input;
using Timer = System.Timers.Timer;

namespace WpfStopwatch.ViewModels
{
    public class StopWatchViewModel : IStopWatch
    {
        private Timer _timer;
        public StopWatchModel CurrentTime {  get; set; }
        private ICommand _startCommand;
        private ICommand _stopCommand;
        private ICommand _resetCommand;

        public StopWatchViewModel()
        {
            CurrentTime = new StopWatchModel();

            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Elapsed += _stopWatch_Elapsed;
        }

        private void _stopWatch_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            CurrentTime.ElapsedTime = DateTime.Now - CurrentTime.StartTime;
        }

        public ICommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                {
                    _startCommand = new RelayCommand(param => this.Start(), (x) => !CurrentTime.IsRunning || (CurrentTime.IsRunning && CurrentTime.ElapsedTime > TimeSpan.Zero));
                }
                return _startCommand;
            }
        }

        public ICommand StopCommand
        {
            get
            {
                if (_stopCommand == null)
                {
                    _stopCommand = new RelayCommand(param => this.Stop(), (x) => CurrentTime.IsRunning);
                }
                return _stopCommand;
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new RelayCommand(param => this.Reset(), (x) => CurrentTime.IsRunning || CurrentTime.ElapsedTime > TimeSpan.Zero);
                }
                return _resetCommand;
            }
        }

        private void Start()
        {
            if (!CurrentTime.IsRunning) 
            {
                CurrentTime.IsRunning = true;
                CurrentTime.StartTime = DateTime.Now;
            }
            else
            {
                CurrentTime.StartTime = DateTime.Now - CurrentTime.ElapsedTime;
            }
            
            _timer.Start();
        }

        private void Stop()
        {
            _timer.Stop();
        }

        private void Reset()
        {
            Stop();
            CurrentTime.IsRunning = false;
            CurrentTime.ElapsedTime = TimeSpan.Zero;
        }
    }
}
