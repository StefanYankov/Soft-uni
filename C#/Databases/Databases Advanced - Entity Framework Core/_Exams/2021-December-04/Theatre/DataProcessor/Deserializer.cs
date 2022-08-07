using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Plays");
            var xmlSerializer = new XmlSerializer(typeof(ImportPlaysDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var playsDto = (ImportPlaysDto[])xmlSerializer.Deserialize(stringReader);

            List<Play> plays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;

                if (!TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.CurrentCulture, out duration))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;

                if (!Enum.TryParse(playDto.Genre, out genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.ScreenWriter,
                };
                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre, playDto.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Casts");
            var xmlSerializer = new XmlSerializer(typeof(ImportCastsDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var castsDto = (ImportCastsDto[])xmlSerializer.Deserialize(stringReader);

            List<Cast> casts = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };

                casts.Add(cast);
                string mainChar = castDto.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, mainChar));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var projectionsDto = JsonConvert.DeserializeObject<List<ImportTheatreDto>>(jsonString);

            List<Data.Models.Theatre> theatersToImport = new List<Data.Models.Theatre>();

            foreach (var projectionDto in projectionsDto)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Ticket> ticketsToAdd = new List<Ticket>();

                foreach (var ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    ticketsToAdd.Add(ticket);
                }

                Data.Models.Theatre theatre = new Data.Models.Theatre
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls,
                    Director = projectionDto.Director,
                    Tickets = ticketsToAdd
                };

                theatersToImport.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
