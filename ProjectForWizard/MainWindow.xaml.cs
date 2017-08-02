using System;
using System.Collections;
using System.Windows;

namespace ProjectForWizard
{
    public partial class MainWindow : Window
    {
        private ResearchBeforeConsumingPotions researchBeforeConsumingPotions;
        private ResearchAfterConsumingPotions researchAfterConsumingPotions;

        private ErrorHelper errorHelper;
        private int researshNumber;

        public MainWindow()
        {
            InitializeComponent();

            researshNumber = 0;

            //  for errors  
            errorHelper = new ErrorHelper();
            DataContext = errorHelper;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.DataValidator(txtNumberOfParticipent, txtNumberOfTest, breakRestTime, TimeForOneTest, workTimeFrom, dinnerTime, workTimeTo, optimizationCheckBox))
            {
                researchBeforeConsumingPotions = new ResearchBeforeConsumingPotions(txtNumberOfParticipent, txtNumberOfTest, breakRestTime, TimeForOneTest, workTimeFrom, dinnerTime, workTimeTo, optimizationCheckBox);

                researchAfterConsumingPotions = new ResearchAfterConsumingPotions(txtNumberOfParticipent, txtNumberOfTest, breakRestTime, TimeForOneTest, workTimeFrom, dinnerTime, workTimeTo, optimizationCheckBox);
                


                //  print Results
                Text_BeforeResearch.Content = researchBeforeConsumingPotions.ResearchMethod();

                Text_AfterResearch.Content = researchAfterConsumingPotions.ResearchMethod()
                    + $"\n\nTime for Research:\n" +
                    $"Days: {AbstractResearch.DateTime.Day}; " +
                    $"Month: {AbstractResearch.DateTime.Month}; " +
                    $"Years: {AbstractResearch.DateTime.Year}.";


                for (int i = 0; i <  AbstractResearch.ListOfPersons.Count && i < AbstractResearch.ListOfPersons.Count; i++)
                {
                    AbstractResearch.ListOfPersons[i].AfterSumOfTheAverageMark = AbstractResearch.ListOfPersons[i].AfterSumOfTheAverageMark;
                }


                ////  Print Collections 'ListOfPersons' in the 'ListView'
                //  Tilte
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView() { Name = "Test №" + ++researshNumber });

                //  List
                foreach (var i in AbstractResearch.ListOfPersons)
                {
                    ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView()
                    {
                        Name = i.Name,
                        StateOfMind = (i.StateOfMind == true ? "Normal" : "Not Normal"),
                        BeforeSumOfTheAverageMark = i.BeforeSumOfTheAverageMark,
                        AfterSumOfTheAverageMark = i.AfterSumOfTheAverageMark
                    });
                }

                //  Short report of the research
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView()
                {
                    Name = "Average mark",
                    BeforeSumOfTheAverageMark = researchBeforeConsumingPotions.MaxAverageMark().BeforeSumOfTheAverageMark,
                    AfterSumOfTheAverageMark = researchAfterConsumingPotions.MaxAverageMark().AfterSumOfTheAverageMark
                });
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView()
                {
                    Name = "Time:",
                    StateOfMind = AbstractResearch.DateTime.ToString("dd.MM.yyyy")
                });
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView() { });

                resultList.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

    }
}