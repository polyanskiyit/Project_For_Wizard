using System;
using System.Collections.Generic;

namespace ProjectForWizard
{
    public class SetOfParticipents
    {
        private int numberOfParticipent;
        private Random r;

        public List<Person> ListOfPersons { get; set; }

        public SetOfParticipents(Random r, int numberOfParticipent)
        {
            this.numberOfParticipent = numberOfParticipent;
            this.r = r;
            ListOfPersons = new List<Person>();
        }

        public List<Person> GetListOfParticipents()
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
            return ListOfPersons;
        }
    }
}
