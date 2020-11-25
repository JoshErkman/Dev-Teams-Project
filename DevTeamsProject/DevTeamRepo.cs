using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        

        //DevTeam Create
        public void AddDevTeam(DevTeam team)
        {
            _devTeams.Add(team);
        }

        /*List<string> MembersList = new List<string>();
        public void AddMembers(Developer dev)
        {
            MembersList.Add;
        }*/



        //DevTeam Read
        public List<DevTeam> GetListOfTeams()
        {
            return _devTeams;
        }


        //DevTeam Update




        //DevTeam Delete





        //DevTeam Helper (Get Team by ID)

    }
}
