using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class Developer_Repo
    {
        public readonly List<Developer> _developerDirectory = new List<Developer>();

        //Create
        public bool AddDeveloperToDirectory(Developer developer)
        {
            int startingCount = _developerDirectory.Count;

            _developerDirectory.Add(developer);

            bool wasAdded = (_developerDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        //Update
        public bool UpdateDeveloper(int iD, Developer newDev)
        {
            Developer oldDev = GetDevByID(iD);

            if(oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.IDNumber = newDev.IDNumber;
                oldDev.AccessToPluralsight = newDev.AccessToPluralsight;

                return true;
            }

            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDeveloper(int iD)
        {
            Developer dev = GetDevByID(iD);

            if(dev != null)
            {
                int initialCount = _developerDirectory.Count;
                _developerDirectory.Remove(dev);

                if(initialCount > _developerDirectory.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        //Helper Method
        public Developer GetDevByID(int iD)
        {
            foreach(Developer dev in _developerDirectory)
            {
                if(dev.IDNumber == iD)
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
