using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {

                string[] command = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                if (command[0].Equals("End"))
                {
                    break;
                }
                string soldierType = command[0];
                int id = int.Parse(command[1]);
                string firstName = command[2];
                string lastName = command[3];
                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(command, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddLieutenantGeneral(command, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(command[4]);
                    string corps = command[5];
                    try
                    {
                        soldier = AddEngineer(command, id, firstName, lastName, salary, corps);
                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (InvalidCorpsException ice)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(command[4]);
                    string corps = command[5];
                    try
                    {
                        soldier = AddCommando(command, id, firstName, lastName, salary, corps);
                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (InvalidCorpsException ice)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    soldier = AddSpy(command, id, firstName, lastName);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }
            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier AddSpy(string[] command, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            int codeNumber = int.Parse(command[4]);
            soldier = new Spy(id, firstName, lastName, codeNumber);
            return soldier;
        }

        private static ISoldier AddCommando(string[] command, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArguments = command.Skip(6).ToArray();

            for (int i = 0; i < missionArguments.Length; i += 2)
            {
                try
                {
                    string missionCodeName = missionArguments[i];
                    string missionState = missionArguments[i + 1];
                    IMission mission = new Mission(missionCodeName, missionState);
                    commando.AddMission(mission);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (InvalidMissionStateException imse)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    continue;
                }
            }

            soldier = commando;
            return soldier;
        }

        private static ISoldier AddEngineer(string[] command, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairArguments = command.Skip(6).ToArray();

            for (int i = 0; i < repairArguments.Length; i += 2)
            {
                string partName = repairArguments[i];
                int hoursWorked = int.Parse(repairArguments[i + 1]);
                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }
            soldier = engineer;
            return soldier;
        }

        private ISoldier AddLieutenantGeneral(string[] command, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(command[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
            foreach (var pid in command.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }
            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] command, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(command[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}
