using System.Windows;
using WpfStopwatch.ViewModels;

namespace WpfStopwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStopWatch _stopWatch;

        public MainWindow(IStopWatch stopWatch)
        {
            InitializeComponent();

            _stopWatch = stopWatch;
            DataContext = _stopWatch;
        }
    }
}