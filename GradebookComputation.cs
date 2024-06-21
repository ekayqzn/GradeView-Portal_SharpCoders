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
            // Ensure totalScore is not zero to avoid division by zero
            if (totalScore == 0) throw new ArgumentException("Total score must be greater than zero.");

            // Convert to decimal for precise division and correct the formula
            decimal result = ((decimal)score / totalScore) * 50 + 50;

            return result;
        }

        public decimal Percentile (int percentage, decimal summation)
        {
            // Ensure percentage is between 0 and 100
            if (percentage < 0 || percentage > 100) throw new ArgumentException("Percentage must be between 0 and 100.");

            decimal result = summation * (percentage / 100m);

            return result;
        }

        public decimal PercentileRdo (int score, int totalScore)
        {
            // Standardize the score first
            decimal standardize = ScoreStandardization(score, totalScore);

            // Calculate 30% of the standardized score
            return standardize * 0.30m;
        }

        public decimal GradePoints (decimal percentage)
        {
            decimal result = 0;

            if (percentage < 0 || percentage > 100)
            {
                return 0.00m;
            }

            if (percentage >= 97)
            {
                result = 1.0m;
            }
            else if (percentage >= 94)
            {
                result = 1.25m;
            }
            else if (percentage >= 91)
            {
                result = 1.5m;
            }
            else if (percentage >= 88)
            {
                result = 1.75m;
            }
            else if (percentage >= 85)
            {
                result = 2.0m;
            }
            else if (percentage >= 82)
            {
                result = 2.25m;
            }
            else if (percentage >= 79)
            {
                result = 2.5m;
            }
            else if (percentage >= 76)
            {
                result = 2.75m;
            }
            else if (percentage >= 75)
            {
                result = 3.0m;
            }
            else
            {
                result = 5.0m;
            }

            return result;
        }
    }
    
}
