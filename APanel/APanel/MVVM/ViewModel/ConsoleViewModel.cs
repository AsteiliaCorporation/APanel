using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LiveChartsCore.SkiaSharpView;

namespace APanel.MVVM.ViewModel
{
    internal class ConsoleViewModel
    {
        private int index;

        private Random random;

        private ObservableCollection<ObservablePoint> observableValues;

        public ConsoleViewModel()
        {
            index = 0;
            random = new Random();
            observableValues = new ObservableCollection<ObservablePoint>();

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservablePoint>
                {
                    Values = observableValues
                }
            };
        }

        private static int RamUsage()
        {
            PerformanceCounter performanceCounter = new PerformanceCounter();
            performanceCounter.CategoryName = "Process";
            performanceCounter.CounterName = "Working Set - Private";
            performanceCounter.InstanceName = "APanel";

            int memorySize = Convert.ToInt32(performanceCounter.NextValue()) / 1024;
            performanceCounter.Close();
            performanceCounter.Dispose();
            return memorySize;
        }

        public ObservableCollection<ISeries> Series { get; set; }

        public void AddItem()
        {
            observableValues.Add(new ObservablePoint(index++, random.NextDouble()));
        }

        public void RemoveFirstItem()
        {
            observableValues.RemoveAt(0);
        }

        public Axis[] XAxes { get; set; }
            = new Axis[]
            {
                new Axis
                {
                    Name = "X Axis",
                    NamePaint = new SolidColorPaint(SKColors.White),
                    LabelsPaint = new SolidColorPaint(SKColors.Gray),
                    TextSize = 16,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 2
                    }
                }
            };

        public Axis[] YAxes { get; set; }
            = new Axis[]
            {
                new Axis
                {
                    Name = "Y Axis",
                    NamePaint = new SolidColorPaint(SKColors.White),
                    LabelsPaint = new SolidColorPaint(SKColors.Gray),
                    TextSize = 16,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 2,
                        PathEffect = new DashEffect(new float[] { 3, 3 })
                    }
                }
            };
    }
}
