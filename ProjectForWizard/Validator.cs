using System;
using System.Windows.Controls;

namespace ProjectForWizard
{
    public class Validator
    {
        public static bool DataValidator(TextBox txtNumberOfParticipent, TextBox txtNumberOfTest, TextBox breakRestTime, TextBox TimeForOneTest, TextBox workTimeFrom, TextBox dinnerTime, TextBox workTimeTo, CheckBox optimizationCheckBox)
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
