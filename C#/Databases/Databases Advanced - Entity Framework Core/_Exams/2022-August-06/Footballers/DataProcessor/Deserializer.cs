using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Coaches");
            var xmlSerializer = new XmlSerializer(typeof(ImportCoachesDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var coachesDto = (ImportCoachesDto[])xmlSerializer.Deserialize(stringReader);

            List<Coach> coachesToImport = new List<Coach>();

            foreach (var coachDto in coachesDto)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                List<Footballer> footballers = new List<Footballer>();

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    // TODO: check start before end
                    DateTime contractStartDate;
                    DateTime contractEndDate;

                    var isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out contractStartDate);
                    var isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out contractEndDate);

                    if (!isStartDateValid || !isEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractEndDate < contractStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    Footballer footballerToAdd = new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        PositionType = (PositionType)footballerDto.PositionType,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                    };

                    footballers.Add(footballerToAdd);

                }

                coach.Footballers = footballers;


                coachesToImport.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, $"{coach.Name}", $"{coach.Footballers.Count}"));
            }
            context.Coaches.AddRange(coachesToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var teamsDto = JsonConvert.DeserializeObject<List<ImportTeamsDto>>(jsonString);

            List<Team> teamsToImport = new List<Team>();

            foreach (var teamDto in teamsDto)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int trophiesAsInt;
                bool successfullyParsed = int.TryParse(teamDto.Trophies, out trophiesAsInt);

                if (!successfullyParsed || trophiesAsInt <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = trophiesAsInt,
                };

                List<TeamFootballer> tf = new List<TeamFootballer>();

                foreach (var footballerDto in teamDto.Footballers.Distinct())
                {

                    var footballer = context.Footballers.Find(footballerDto);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var tfToAdd = new TeamFootballer
                    {
                        Team = team,
                        Footballer = footballer,
                    };

                    if (tf.Contains(tfToAdd))
                    {
                        continue;
                    }


                    tf.Add(tfToAdd);

                }

                team.TeamsFootballers = tf;

                teamsToImport.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, $"{team.Name}", team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teamsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
