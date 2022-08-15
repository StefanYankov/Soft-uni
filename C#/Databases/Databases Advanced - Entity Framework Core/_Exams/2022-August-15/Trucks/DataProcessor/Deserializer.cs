using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Despatchers");
            var xmlSerializer = new XmlSerializer(typeof(ImportDespatchersDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var despatchersDto = (ImportDespatchersDto[])xmlSerializer.Deserialize(stringReader);

            List<Despatcher> despatcherToImport = new List<Despatcher>();

            foreach (var despatcherDto in despatchersDto)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // TODO: to check
                if (string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                List<Truck> trucks = new List<Truck>();

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    Truck truckToAdd = new Truck
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType) truckDto.CategoryType,
                        MakeType = (MakeType) truckDto.MakeType,
                    };

                    trucks.Add(truckToAdd);
                }

                despatcher.Trucks = trucks;

                despatcherToImport.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, $"{despatcher.Name}", $"{despatcher.Trucks.Count}"));
            }
            context.Despatchers.AddRange(despatcherToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var clientsDto = JsonConvert.DeserializeObject<List<ImportClientsDto>>(jsonString);

            List<Client> clientsToImport = new List<Client>();

            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                List<ClientTruck> ct = new List<ClientTruck>();

                foreach (var truckDto in clientDto.Trucks.Distinct())
                {
                    var truck = context.Trucks.Find(truckDto);

                    if (truck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var clientTruck = new ClientTruck
                    {
                        Client = client,
                        Truck = truck,
                    };

                    if (ct.Contains(clientTruck))
                    {
                        continue;
                    }

                    ct.Add(clientTruck);
                }

                client.ClientsTrucks = ct;

                clientsToImport.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, $"{client.Name}", client.ClientsTrucks.Count));
            }
            context.Clients.AddRange(clientsToImport);
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
