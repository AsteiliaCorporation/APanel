using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.ViewModels
{
    public class ConsoleViewModel : BaseViewModel
    {
        public ConsoleViewModel()
        {
            var values = new int[100];
            var r = new Random();
            var t = 0;

            for (var i = 0; i < 100; i++)
            {
                t += r.Next(-90, 100);
                values[i] = t;
            }

            SeriesCollection = new ISeries[] { new LineSeries<int> { Values = values } };
        }

        public ISeries[] SeriesCollection { get; set; }
    }
}
