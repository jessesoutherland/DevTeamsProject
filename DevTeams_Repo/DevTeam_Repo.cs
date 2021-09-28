using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DevTeam_Repo
    {
       public readonly List<DevTeam> _devTeamList = new List<DevTeam>();

        public bool AddDevTeamToList(DevTeam team)
        {
            int startingCount = _devTeamList.Count;

            _devTeamList.Add(team);

            bool wasAdded = (_devTeamList.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<DevTeam> GetDevTeamList()
        {
            return _devTeamList;  
        }

        public bool UpdateTeam(int iD, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamByID(iD);

            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamID = newTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDevToTeam(int devTeamID, Developer dev)
        {
            DevTeam team = GetTeamByID(devTeamID);
            if (team != null)
            {
                team.DevsOnTeam.Add(dev);
                //How to remove from Dev List
                return true;
            }
            return false;
        }

        public bool RemoveDevFromTeam(int devTeamID, List<Developer> devs)
        {
            DevTeam team = GetTeamByID(devTeamID);
            if (team != null)
            {
                foreach (Developer dev in devs)
                {
                    team.DevsOnTeam.Remove(dev);
                }
                return true;
            }
            return false;
        }

        public bool RemoveDevTeam(int devTeamID)
        {
            DevTeam team = GetTeamByID(devTeamID);

            if (team != null)
            {
                int initialCount = _devTeamList.Count;
                _devTeamList.Remove(team);

                if (initialCount > _devTeamList.Count)
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

        
        public DevTeam GetTeamByID(int iD)
        {
            foreach (DevTeam team in _devTeamList)
            {
                if (team.TeamID == iD)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
