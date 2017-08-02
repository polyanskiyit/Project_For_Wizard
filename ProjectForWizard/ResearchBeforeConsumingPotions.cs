using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjectForWizard
{
    public class ResearchBeforeConsumingPotions : AbstractResearch
    {
        private int third;

        public ResearchBeforeConsumingPotions(TextBox txtNumberOfParticipent, TextBox txtNumberOfTest, TextBox breakRestTime, TextBox TimeForOneTest, TextBox workTimeFrom, TextBox dinnerTime, TextBox workTimeTo, CheckBox optimizationCheckBox) : base(txtNumberOfParticipent, txtNumberOfTest, breakRestTime, TimeForOneTest, workTimeFrom, dinnerTime, workTimeTo, optimizationCheckBox)
        {
            Init();//  Initialization
            InputParameters();
            third = 3;

            //  create a list of persons
            SetOfParticipents setOfParticipents = new SetOfParticipents(r, numberOfParticipent);
            //Generation of the Participents
            ListOfPersons = setOfParticipents.GetListOfParticipents();
        }

        protected override void Init()
        {
            DateTime = new DateTime();
            r = new Random();
        }
        protected override void InputParameters()
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

        protected override void ResearchTest()
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
                        DateTime.Hour <= timeTo - third &&
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
        protected override void AverageMark()
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
        public override Person MaxAverageMark()
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

        public override string ResearchMethod()
        {
            ResearchTest();
            AverageMark();
            return string.Format($"Result before experiment: \nThe Best Participent: \n{MaxAverageMark().Name};\nEstimation: {MaxAverageMark().BeforeSumOfTheAverageMark};\nMax estimation is 5.");
        }
    }
}
