using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjectForWizard
{
    public class Research
    {
        /// <summary>
        /// Fields
        /// </summary>  
        private TextBox
            txtNumberOfParticipent,
            txtNumberOfTest,
            breakRestTime,
            TimeForOneTest,
            workTimeFrom,
            dinnerTime,
            workTimeTo;
        private CheckBox
            optimizationCheckBox;

        public DateTime DateTime { get; set; }
        public List<Person> ListOfPersons { get; set; }

        private Random r;

        //  input parameters
        private int numberOfParticipent;
        private int numberOfTest;
        private double pausa;
        private double testTime;
        private int timeFrom;
        private int dinner;
        private int timeTo;

        //  optimization of the Research On / Off
        private bool optimizationValue;

        private double timeForOneParticipent;

        //  Configurations
        private int ForSumnumberOfTest;


        /// <summary>
        /// Methods
        /// </summary>
        public Research()
        {
            throw new NotImplementedException();
        }

        public Research(TextBox txtNumberOfParticipent, TextBox txtNumberOfTest,
            TextBox breakRestTime, TextBox TimeForOneTest,
            TextBox workTimeFrom, TextBox dinnerTime, TextBox workTimeTo, CheckBox optimizationCheckBox)
        {
            this.txtNumberOfParticipent = txtNumberOfParticipent;
            this.txtNumberOfTest = txtNumberOfTest;
            this.breakRestTime = breakRestTime;
            this.TimeForOneTest = TimeForOneTest;
            this.workTimeFrom = workTimeFrom;
            this.dinnerTime = dinnerTime;
            this.workTimeTo = workTimeTo;
            this.optimizationCheckBox = optimizationCheckBox;

            Init();//  Initialization
            InputParameters();
            SetOfParticipents();//  Generation of the Participents
        }

        private void Init()
        {
            DateTime = new DateTime();
            r = new Random();
            ListOfPersons = new List<Person>();
        }

        private void SetOfParticipents()
        {
            int PersonNumber = 1;
            for (int i = 0; i < numberOfParticipent; i++)
            {
                Person p = new Person();
                p.Name = "Participent №" + (PersonNumber++);
                p.BeforeEstimationArrayOfMarks = new List<int>();
                p.AfterEstimationArrayOfMarks = new List<int>();

                if (r.Next(2) == 1)
                {
                    p.StateOfMind = false;
                }
                else
                {
                    p.StateOfMind = true;
                }

                ListOfPersons.Add(p);
            }
        }

        private void InputParameters()
        {
            ////    Input Parameters
            //  Number of Participents and tests
            numberOfParticipent = Convert.ToInt32(txtNumberOfParticipent.Text);
            numberOfTest = Convert.ToInt32(txtNumberOfTest.Text);

            //  The number of minutes for test and interval between tests;
            pausa = Convert.ToInt32(breakRestTime.Text);
            //pausa = r.Next(Convert.ToInt32(breakRestTime.Text));
            testTime = Convert.ToInt32(TimeForOneTest.Text);

            //  Work schedule and lunch time;
            timeFrom = Convert.ToInt32(workTimeFrom.Text);
            dinner = Convert.ToInt32(dinnerTime.Text);
            timeTo = Convert.ToInt32(workTimeTo.Text);

            //  Optimization of the protest process
            optimizationValue = optimizationCheckBox.IsChecked.Value;

            ////  Time for one test and one pause
            timeForOneParticipent = pausa + testTime;
        }



        //  First Test
        private void BeforeResearchTest()
        {
            if (optimizationValue == true)
            {
                ForSumnumberOfTest = numberOfTest / numberOfParticipent;
            }
            else
            {
                ForSumnumberOfTest = numberOfTest;
            }

            int testsIsLeft = numberOfTest;

            foreach (var p in ListOfPersons)
            {
                testsIsLeft = ForSumnumberOfTest;
                while (0 < testsIsLeft)
                {
                    if (DateTime.Hour >= timeFrom &&
                        DateTime.Hour != dinner &&
                        DateTime.Hour <= timeTo &&
                        DateTime.Day != 6 && DateTime.Day != 7)
                    {
                        if (p.StateOfMind == true)
                        {
                            p.BeforeEstimationArrayOfMarks.Add(r.Next(1, 5));
                            testsIsLeft--;
                        }
                        else if (p.StateOfMind == false)
                        {
                            p.BeforeEstimationArrayOfMarks.Add(r.Next(1, 3));
                            testsIsLeft--;
                        }
                    }
                    DateTime = DateTime.AddMinutes(timeForOneParticipent);
                }
            }
        }

        private void BeforeAverageMark()
        {
            foreach (var i in ListOfPersons)
            {
                double value = 0;
                foreach (var s in i.BeforeEstimationArrayOfMarks)
                {
                    value = s;
                    i.BeforeSumOfTheAverageMark += value;
                    value = 0;
                }
                i.BeforeSumOfTheAverageMark = i.BeforeSumOfTheAverageMark / ForSumnumberOfTest;
            }
        }

        public Person BeforeMaxAverageMark()
        {
            double maxAverageMark = 0;
            Person theBestPerson = new Person();

            foreach (var person in ListOfPersons)
            {
                if (maxAverageMark < person.BeforeSumOfTheAverageMark)
                {
                    maxAverageMark = person.BeforeSumOfTheAverageMark;
                    theBestPerson = person;
                }
            }
            return theBestPerson;
        }



        //  Second Test
        private void AfterResearchTest()
        {
            if (optimizationValue == true)
            {
                ForSumnumberOfTest = numberOfTest / numberOfParticipent;

            }
            else
            {
                ForSumnumberOfTest = numberOfTest;
            }

            int testsIsLeft = numberOfTest;

            foreach (var p in ListOfPersons)
            {
                testsIsLeft = ForSumnumberOfTest;
                while (0 < testsIsLeft)
                {
                    if (DateTime.Hour >= timeFrom &&
                        DateTime.Hour != dinner &&
                        DateTime.Hour <= timeTo &&
                        DateTime.Day != 6 && DateTime.Day != 7)
                    {

                        if (p.StateOfMind == true)
                        {
                            p.AfterEstimationArrayOfMarks.Add(r.Next(2, 5));
                            testsIsLeft--;
                        }
                        else if (p.StateOfMind == false)
                        {
                            p.AfterEstimationArrayOfMarks.Add(r.Next(1, 5));
                            testsIsLeft--;
                        }
                    }
                    DateTime = DateTime.AddMinutes(timeForOneParticipent);
                }
            }
        }

        private void AfterAverageMark()
        {
            foreach (var i in ListOfPersons)
            {
                double value = 0;
                foreach (var s in i.AfterEstimationArrayOfMarks)
                {
                    value = s;
                    i.AfterSumOfTheAverageMark += value;
                    value = 0;
                }
                i.AfterSumOfTheAverageMark = i.AfterSumOfTheAverageMark / ForSumnumberOfTest;
            }
        }

        public Person AfterMaxAverageMark()
        {
            double maxAverageMark = 0;
            Person theBestPerson = new Person();

            foreach (var person in ListOfPersons)
            {
                if (maxAverageMark < person.AfterSumOfTheAverageMark)
                {
                    maxAverageMark = person.AfterSumOfTheAverageMark;
                    theBestPerson = person;
                }
            }
            return theBestPerson;
        }



        ////    Result methods
        //  First Research
        public string ResearchMethod()
        {
            BeforeResearchTest();
            BeforeAverageMark();
            return string.Format($"Result before experiment: \nThe Best Participent: \n{BeforeMaxAverageMark().Name};\nEstimation: {BeforeMaxAverageMark().BeforeSumOfTheAverageMark};\nMax estimation is 5.");
        }

        ////  Result method with Data time
        //  Second Research
        public string AfterResearchMethod()
        {
            AfterResearchTest();
            AfterAverageMark();
            return string.Format($"Result after experiment:\nThe Best Participent: \n{AfterMaxAverageMark().Name};\nEstimation: {AfterMaxAverageMark().AfterSumOfTheAverageMark};\nMax estimation is 5.\n\nTime for Research:\nDays: {DateTime.Day}; Month: {DateTime.Month}; Years: {DateTime.Year}.");
        }
    }
}