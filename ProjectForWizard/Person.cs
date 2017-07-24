using System.Collections.Generic;

namespace ProjectForWizard
{
    public class Person
    {
        public string Name { get; set; }
        public bool StateOfMind { get; set; }
        public List<int> BeforeEstimationArrayOfMarks { get; set; }
        public List<int> AfterEstimationArrayOfMarks { get; set; }
        public double BeforeSumOfTheAverageMark { get; set; }
        public double AfterSumOfTheAverageMark { get; set; }
    }
}