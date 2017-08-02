using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectForWizard
{
    public abstract class AbstractResearch
    {
        public static List<Person> ListOfPersons { get; set; }

        protected TextBox
            txtNumberOfParticipent,
            txtNumberOfTest,
            breakRestTime,
            TimeForOneTest,
            workTimeFrom,
            dinnerTime,
            workTimeTo;

        protected Random r;

        protected CheckBox
            optimizationCheckBox;

        public static DateTime DateTime { get; set; }

        //  input parameters
        protected int numberOfParticipent;
        protected int numberOfTest;
        protected double pausa;
        protected double testTime;
        protected int timeFrom;
        protected int dinner;
        protected int timeTo;


        //  optimization of the Research On / Off
        protected bool optimizationValue;

        protected double timeForOneParticipent;

        //  Configurations
        protected int ForSumnumberOfTest;

        public AbstractResearch() { }

        public AbstractResearch(TextBox txtNumberOfParticipent, TextBox txtNumberOfTest,
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
        }

        protected abstract void Init();
        protected abstract void InputParameters();

        protected abstract void ResearchTest();
        protected abstract void AverageMark();
        public abstract Person MaxAverageMark();

        public abstract string ResearchMethod();
    }
}
