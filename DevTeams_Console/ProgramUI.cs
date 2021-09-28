using DevTeams_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    public class ProgramUI
    {
        private Developer_Repo _devRepo = new Developer_Repo();
        private DevTeam_Repo _devTeamRepo = new DevTeam_Repo();

        public void Run()
        {
            SeedData();
            MainMenu();
        }
        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Komodo Team Management\n\n");
                Console.WriteLine
                    (
                        "\nPlease select an option:\n\n" +
                        "1. Developers\n" +
                        "2. Teams\n" +
                        "3. Exit"
                    );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Developers_Menu();
                        break;
                    case "2":
                        Teams_Menu();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n\nYou have entered an invalid selection.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }
        private void Developers_Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "\nPlease select an option:\n\n" +
                        "1. Show All Developers\n" +
                        "2. Show All Developers Without a Plualsight License\n" +
                        "3. Add Developers\n" +
                        "4. Update Developer\n" +
                        "5. Delete Developers\n" +
                        "6. Go Back"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDevs();
                        break;
                    case "2":
                        ShowAllDevsWithoutPluralsight();
                        break;
                    case "3":
                        AddDevelopers();
                        break;
                    case "4":
                        UpdateDeveloper();
                        break;
                    case "5":
                        DeleteDevelopers();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n\nYou have entered an invalid selection.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }
        private void Teams_Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "\nPlease select an option:\n\n" +
                        "1. Show All Teams\n" +
                        "2. Add Team\n" +
                        "3. Update Team\n" +
                        "4. Delete Team\n" +
                        "5. Add Developers to Team\n" +
                        "6. Delete Developers from Team\n" +
                        "7. Go Back"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllTeams();
                        break;
                    case "2":
                        AddTeam();
                        break;
                    case "3":
                        UpdateTeam();
                        break;
                    case "4":
                        DeleteTeam();
                        break;
                    case "5":
                        AddDevsToTeam();
                        break;
                    case "6":
                        RemoveDevsFromTeam();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n\nYou have entered an invalid selection.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }
        private void ShowAllDevs()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _devRepo.GetDevelopers();

            foreach(Developer dev in listOfDevelopers)
            {
                DisplayDevs(dev);
            }

            PressAnyKeyToContinue();
        }
        private void ShowAllDevsWithoutPluralsight()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _devRepo.GetDevelopers();

            foreach(Developer dev in listOfDevelopers)
            {
                if(dev.AccessToPluralsight == false)
                {
                    DisplayDevs(dev);
                }
            }
            PressAnyKeyToContinue();

        }
        private void AddDevelopers()
        {
            Console.Clear();

            Developer newDev = new Developer();

            Console.WriteLine("\n\nEnter the first name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the last name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("\nEnter the ID number:");
            newDev.IDNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nThe developer is licensed in Pluralsight. True or False?");
            newDev.AccessToPluralsight = Convert.ToBoolean(Console.ReadLine());

            bool wasAdded =_devRepo.AddDeveloperToDirectory(newDev);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe developer was successfully added.");
            }
            else
            {
                Console.WriteLine("\nThe developer could not be added.");
            }

            PressAnyKeyToContinue();

        }
        private void UpdateDeveloper()
        {
            Console.Clear();

            ShowAllDevs();

            Console.WriteLine("\nEnter the ID number of the developer you'd like to update:");
            int dev = Convert.ToInt32(Console.ReadLine());

            Developer targetDev = _devRepo.GetDevByID(dev);

            if(targetDev == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            Developer updatedDev = new Developer();

            Console.WriteLine("\n\nIf you don't wish to update a certain property just enter the original info of that property.\n");

            Console.WriteLine($"\nOriginal first name: {targetDev.FirstName}\n" +
                $"\nEnter new first name:");
            updatedDev.FirstName = Console.ReadLine();

            Console.WriteLine($"\nOriginal last name: {targetDev.LastName}\n" +
                 $"\nEnter new last name:");
            updatedDev.LastName = Console.ReadLine();

            Console.WriteLine($"\nOriginal ID number: {targetDev.IDNumber}\n" +
                 $"\nEnter new ID number:");
            updatedDev.IDNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nOriginal Pluralsight license status: {targetDev.AccessToPluralsight}\n" +
                 $"\nEnter new Pluralsight license status:");
            updatedDev.AccessToPluralsight = Convert.ToBoolean(Console.ReadLine());

            if (_devRepo.UpdateDeveloper(targetDev.IDNumber, updatedDev))
            {
                Console.WriteLine("\nUpdate Successful");
            }
            else
            {
                Console.WriteLine("\nUpdate was not successful");
            }
            PressAnyKeyToContinue();

        }
        private void DeleteDevelopers()
        {
            ShowAllDevs();

            Console.WriteLine("\n\nEnter the ID number of the developer you'd like to delete:");

            int input = Convert.ToInt32(Console.ReadLine());

            Developer targetDev = _devRepo.GetDevByID(input);

            if (targetDev == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            bool wasDeleted = _devRepo.DeleteDeveloper(input);

            if (wasDeleted)
            {
                Console.WriteLine("\n\nThe developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("\nThe developer could not be deleted.");
            }

            PressAnyKeyToContinue();

        }
        private void ShowAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetDevTeamList();

            foreach(DevTeam team in listOfTeams)
            {
                DisplayTeams(team);
            }
            
            PressAnyKeyToContinue();
        }
        private void AddTeam()                
        {
            Console.Clear();

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("\n\nEnter the team name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("\nEnter the team ID:");
            newTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            bool wasAdded = _devTeamRepo.AddDevTeamToList(newTeam);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe team was successfully added.");
            }
            else
            {
                Console.WriteLine("\nThe team could not be added.");
            }

            PressAnyKeyToContinue();
        }
        private void UpdateTeam()
        {
            Console.Clear();

            ShowAllTeams();

            Console.WriteLine("\nEnter the ID number of the team you'd like to update:");
            int team = Convert.ToInt32(Console.ReadLine());

            DevTeam targetTeam = _devTeamRepo.GetTeamByID(team);

            if (targetTeam == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            DevTeam updatedTeam = new DevTeam();

            Console.WriteLine("\n\nIf you don't wish to update a certain property just enter the original info of that property.\n");

            Console.WriteLine($"\nOriginal team name: {targetTeam.TeamName}\n" +
                $"\nEnter new team name:");
            updatedTeam.TeamName = Console.ReadLine();

            Console.WriteLine($"\nOriginal team ID number: {targetTeam.TeamID}\n" +
                 $"\nEnter new ID number:");
            updatedTeam.TeamID = Convert.ToInt32(Console.ReadLine());
            bool wasUpdated = _devTeamRepo.UpdateTeam(targetTeam.TeamID, updatedTeam);
            if (wasUpdated)
            {
                Console.WriteLine("\nUpdate Successful");
            }
            else
            {
                Console.WriteLine("\nUpdate was not successful");
            }
            PressAnyKeyToContinue();
        }
        private void DeleteTeam()
        {
            Console.Clear();

            ShowAllTeams();

            Console.WriteLine("\n\nEnter the ID number of the team you'd like to delete:");

            int input = Convert.ToInt32(Console.ReadLine());

            DevTeam targetTeam = _devTeamRepo.GetTeamByID(input);

            if (targetTeam == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            bool wasDeleted = _devTeamRepo.RemoveDevTeam(input);

            if (wasDeleted)
            {
                Console.WriteLine("\n\nThe team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("\nThe team could not be deleted.");
            }

            PressAnyKeyToContinue();
        }
        private void AddDevsToTeam()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _devRepo.GetDevelopers();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();

            ShowAllDevs();

            Console.WriteLine("\nEnter the ID number of the developer you would like to add:");
            int dev = Convert.ToInt32(Console.ReadLine());

            Developer targetDev = _devRepo.GetDevByID(dev);
            
            if (targetDev == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }
            Console.Clear();

            ShowAllTeams();

            Console.WriteLine("\nEnter the ID number of the team you'd like to add the developer to:");
            int team = Convert.ToInt32(Console.ReadLine());

            DevTeam targetTeam = _devTeamRepo.GetTeamByID(team);

            if (targetTeam == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }
            
            bool wasAdded = _devTeamRepo.AddDevToTeam(team, targetDev);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe developer was successfully added.");
            }
            else
            {
                Console.WriteLine("\nThe developer could not be added.");
            }

            Console.WriteLine("\n\nYou would like to add another developer to a team. True or False?");
            bool answer = Convert.ToBoolean(Console.ReadLine());

            if(answer == true)
            {
                AddDevsToTeam();
            }

            PressAnyKeyToContinue();

        }
        private void RemoveDevsFromTeam()
        {
            Console.Clear();

            ShowAllTeams();

            Console.WriteLine("\n\nEnter the ID number of the developer you'd like to remove from a team:");
            int input = Convert.ToInt32(Console.ReadLine());

            Developer targetDev = _devRepo.GetDevByID(input);

            if (targetDev == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            Console.WriteLine("\nEnter the ID number of the team you'd like to remove the developer from:");
            int inputTwo = Convert.ToInt32(Console.ReadLine());

            DevTeam targetTeam = _devTeamRepo.GetTeamByID(inputTwo);

            if (targetTeam == null)
            {
                Console.WriteLine("\n\nUnable to find selection");
                PressAnyKeyToContinue();
                return;
            }

            bool wasDeleted = _devTeamRepo.RemoveDevFromTeam(inputTwo, targetDev );

            if (wasDeleted)
            {
                Console.WriteLine("\n\nThe developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("\nThe developer could not be deleted.");
            }

            PressAnyKeyToContinue();


        }

        //Helper Methods
        private void DisplayDevs(Developer dev)
        {
            Console.WriteLine
                (
                    $"\n\nFirst Name: {dev.FirstName}\n" +
                    $"Last Name: {dev.LastName}\n" +
                    $"ID Number: {dev.IDNumber}\n" +
                    $"Pluralsight licensed: {dev.AccessToPluralsight}"
                );
        }
        private void DisplayTeams(DevTeam team)
        {
            Console.WriteLine
                (
                    $"\n\nTeam Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamID}\n" +
                    $"Team Members:"
                );
            foreach(Developer dev in team.DevsOnTeam)
            {
                DisplayDevs(dev);
            }
        }
        
        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\n\nPress any key to continue...");
            Console.ReadKey();
        }

        private void SeedData()
        {
            Developer numOne = new Developer("Jesse", "Southerland", 777, true);
            Developer numTwo = new Developer("Bob", "Ross", 666, false);
            Developer numThree = new Developer("Nikola", "Tesla", 333, true);
            Developer numFour = new Developer("Jim", "Carrey", 999, true);

            DevTeam numUno = new DevTeam("Warriors", 12345);
            DevTeam numDos = new DevTeam("Worriers", 54321);

            numUno.DevsOnTeam.Add(numOne);
            numUno.DevsOnTeam.Add(numTwo);

            _devRepo.AddDeveloperToDirectory(numOne);
            _devRepo.AddDeveloperToDirectory(numTwo);
            _devRepo.AddDeveloperToDirectory(numThree);
            _devRepo.AddDeveloperToDirectory(numFour);

            _devTeamRepo.AddDevTeamToList(numUno);
            _devTeamRepo.AddDevTeamToList(numDos);
        }
    }
}





