using System.Windows.Input;

namespace WpfStopwatch.ViewModels
{
    public interface IStopWatch
    {
        ICommand StartCommand { get; }
        ICommand StopCommand { get; }
        ICommand ResetCommand { get; }
    }
}
