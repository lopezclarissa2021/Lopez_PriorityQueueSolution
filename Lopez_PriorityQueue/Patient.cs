using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez_PriorityQueue
{
    internal class Patient
    {
        string LastName;
        string FirstName;
        DateTime Birthdate;
        int Priority;

        public Patient(string lastName, string firstName, DateTime birthdate, int priority)
        {
            LastName = lastName;
            FirstName = firstName;
            Birthdate = birthdate;
            Priority = priority;

            SetPriority();
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {Birthdate}, {Priority}";
        }

        public void SetPriority()
        {
            if (Age < 21 || Age > 65)
            {
                this.Priority = 1;
            }
        }
        public int PriorityLevel { get => this.Priority; }
        public int Age
        {
            get
            {
                int age = 0;
                age = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now.DayOfYear < Birthdate.DayOfYear)
                    age = age - 1;

                return age;
            }
        }
    }
}
