using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class Developer
    {

        public Developer() { }

        public Developer(string firstName, string lastName, int iDNumber, bool accessToPluarlsight)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iDNumber;
            AccessToPluralsight = accessToPluarlsight;
            
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IDNumber { get; set; }

        public bool AccessToPluralsight { get; set; }
    }
}
