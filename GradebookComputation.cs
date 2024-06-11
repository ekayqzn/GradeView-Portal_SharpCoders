using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradesBookApp
{
    public class GradebookComputation
    {
        public decimal ScoreStandardization (int score, int totalScore)
        {
            decimal result = (score / totalScore) * 50 + 50;

            return result;
        }

        public decimal Percentile (int percentage, decimal summation)
        {
            decimal result = summation * (percentage / 100);

            return result;
        }

        public decimal PercentileRdo (int score, int totalScore)
        {
            decimal standardize = ScoreStandardization(score, totalScore);
            return (standardize * (30/100));
        }
    }
}
