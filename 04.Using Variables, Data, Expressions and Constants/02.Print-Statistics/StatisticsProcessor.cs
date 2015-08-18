namespace TelerikAcademy.Homeworks
{
    using System;

    public class StatisticsProcessor
    {
        public void PrintStatistics(double[] statisticsData, int itemsToSummarize)
        {
            double maximalValue = double.MinValue;
            for (int currentIndex = 0; currentIndex < itemsToSummarize; currentIndex++)
            {
                if (statisticsData[currentIndex] > maximalValue)
                {
                    maximalValue = statisticsData[currentIndex];
                }
            }

            PrintMax(maximalValue);

            double minimalValue = double.MaxValue;
            for (int currentIndex = 0; currentIndex < itemsToSummarize; currentIndex++)
            {
                if (statisticsData[currentIndex] < minimalValue)
                {
                    minimalValue = statisticsData[currentIndex];
                }
            }

            PrintMin(minimalValue);

            double averageValue = 0;
            for (int currentIndex = 0; currentIndex < itemsToSummarize; currentIndex++)
            {
                averageValue += statisticsData[currentIndex];
            }

            PrintAvg(averageValue / itemsToSummarize);
        }
    }
}
