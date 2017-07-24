using System;
using System.Collections;
using System.Windows;

namespace ProjectForWizard
{
    public partial class MainWindow : Window
    {
        private Research research;
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
            //  Values for validation of the input parameters
            int res;
            bool boolNumberOfParticipent = Int32.TryParse(txtNumberOfParticipent.Text, out res);
            bool boolNumberOfTest = Int32.TryParse(txtNumberOfTest.Text, out res);
            bool boolWorkTimeFrom = Int32.TryParse(workTimeFrom.Text, out res);
            bool boolDinnerTime = Int32.TryParse(dinnerTime.Text, out res);
            bool boolWorkTimeTo = Int32.TryParse(workTimeTo.Text, out res);
            bool boolbreakRestTime = Int32.TryParse(breakRestTime.Text, out res);
            bool boolTimeForOneTest = Int32.TryParse(TimeForOneTest.Text, out res);

            if (
                boolNumberOfParticipent == true &&
                boolNumberOfTest == true &&
                boolbreakRestTime == true &&
                boolTimeForOneTest == true &&

                boolWorkTimeFrom == true &&
                boolDinnerTime == true &&
                boolWorkTimeTo == true &&

                Convert.ToInt32(workTimeTo.Text) > Convert.ToInt32(dinnerTime.Text) &&
                Convert.ToInt32(dinnerTime.Text) > Convert.ToInt32(workTimeFrom.Text) &&

                Convert.ToInt32(workTimeTo.Text) < 23 &&
                Convert.ToInt32(txtNumberOfParticipent.Text) > 0 && Convert.ToInt32(txtNumberOfParticipent.Text) < 10000000 &&
                Convert.ToInt32(txtNumberOfTest.Text) > 0 && Convert.ToInt32(txtNumberOfTest.Text) < 10000000 &&
                Convert.ToInt32(workTimeFrom.Text) > 0 && Convert.ToInt32(workTimeFrom.Text) < 1440 &&
                Convert.ToInt32(breakRestTime.Text) > 0 && Convert.ToInt32(breakRestTime.Text) < 1440 &&
                Convert.ToInt32(TimeForOneTest.Text) > 0 && Convert.ToInt32(TimeForOneTest.Text) < 1440 
                )
            {
                research = new Research(txtNumberOfParticipent, txtNumberOfTest, breakRestTime, TimeForOneTest, workTimeFrom, dinnerTime, workTimeTo, optimizationCheckBox);

                Text_BeforeResearch.Content = research.ResearchMethod();
                Text_AfterResearch.Content = research.AfterResearchMethod();

                ////  Print Collections 'ListOfPersons' in the 'ListView'
                //  Tilte
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView() {Name = "Test №" + ++researshNumber });
                
                //  List
                foreach (var i in research.ListOfPersons)
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
                    BeforeSumOfTheAverageMark = research.BeforeMaxAverageMark().BeforeSumOfTheAverageMark,
                    AfterSumOfTheAverageMark = research.AfterMaxAverageMark().AfterSumOfTheAverageMark
                });
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView()
                {
                    Name = "Time:",
                    StateOfMind = research.DateTime.ToString("dd.MM.yyyy")
                    //BeforeSumOfTheAverageMark = research.DateTime.Month,
                    //AfterSumOfTheAverageMark = research.DateTime.Year
                });
                ((ArrayList)resultList.Resources["persons"]).Add(new PersonForResultListView(){});

                resultList.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}