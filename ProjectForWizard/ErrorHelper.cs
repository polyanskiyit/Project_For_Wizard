using System;
using System.ComponentModel;

namespace ProjectForWizard
{
    public class ErrorHelper : IDataErrorInfo
    {
        private string errorText = "Choose a number in the range from 1 to 10000000";

        public int numberOfPForError { get; set; } = 100;
        public int numberOfTForError { get; set; } = 10000;
        public int breakRestTimeForError { get; set; } = 20;
        public int TimeForOneTestForError { get; set; } = 10;
        public int workTimeFromForError { get; set; } = 10;
        public int dinnerTimeForError { get; set; } = 13;
        public int workTimeToForError { get; set; } = 19;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "numberOfPForError":
                        if ((numberOfPForError <= 0) || (numberOfPForError >= 10000000))
                        {
                            error = errorText;
                        }
                        break;
                    case "numberOfTForError":
                        if ((numberOfPForError <= 0) || (numberOfPForError >= 10000000))
                        {
                            error = errorText;
                        }
                        break;
                    case "breakRestTimeForError":
                        if ((breakRestTimeForError <= 0) || (breakRestTimeForError >= 10000000))
                        {
                            error = errorText;
                        }
                        break;
                    case "TimeForOneTestForError":
                        if ((TimeForOneTestForError <= 0) || (TimeForOneTestForError >= 10000000))
                        {
                            error = errorText;
                        }
                        break;
                    case "workTimeFromForError":
                        if ((workTimeFromForError <= 0) || (workTimeFromForError >= 10000000) && (workTimeFromForError > dinnerTimeForError))
                        {
                            error = errorText;
                        }
                        break;
                    case "dinnerTimeForError":
                        if ((workTimeFromForError > dinnerTimeForError) || (dinnerTimeForError > workTimeToForError) || (workTimeFromForError <= 0) || (workTimeFromForError >= 10000000))
                        {
                            error = errorText;
                        }
                        break;
                    case "workTimeToForError":
                        if ((numberOfPForError <= 0) || (numberOfPForError >= 10000000) || (dinnerTimeForError > workTimeToForError))
                        {
                            error = errorText;
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
