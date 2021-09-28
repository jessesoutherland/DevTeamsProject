using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DevTeam
    {
        public DevTeam() { }

        public DevTeam(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }

        public string TeamName { get; set; }

        public int TeamID { get; set; }

        public List<Developer> DevsOnTeam { get; set; } = new List<Developer>();
    }
}
