using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artillery.Data;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Countries");
            var xmlSerializer = new XmlSerializer(typeof(ImportCountriesDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var countriesDtos = (ImportCountriesDto[])xmlSerializer.Deserialize(stringReader);

            List<Country> countries = new List<Country>();

            foreach (var countryDto in countriesDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };
                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Manufacturers");
            var xmlSerializer = new XmlSerializer(typeof(ImportManufacturersDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var manufacturersDto = (ImportManufacturersDto[])xmlSerializer.Deserialize(stringReader);

            List<Manufacturer> manufacturers = new List<Manufacturer>();

            foreach (var manufacturerDto in manufacturersDto)
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (manufacturers.Any(x => x.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string[] foundedArr = manufacturerDto.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string founded = string.Join(", ", foundedArr[foundedArr.Length - 2], foundedArr[foundedArr.Length - 1]);

                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = founded,
                };

                manufacturers.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, manufacturer.Founded));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportShells(ArtilleryContext context, string xmlString)
        {

            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Shells");
            var xmlSerializer = new XmlSerializer(typeof(ImportShellsDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var shellsDto = (ImportShellsDto[])xmlSerializer.Deserialize(stringReader);

            List<Shell> shells = new List<Shell>();

            foreach (var shellDto in shellsDto)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                };

                shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var guns = JsonConvert.DeserializeObject<List<ImportGunsDto>>(jsonString);

            List<Gun> gunsToImport = new List<Gun>();

            foreach (var gunsDto in guns)
            {
                if (!IsValid(gunsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunType;

                if (!Enum.TryParse(gunsDto.GunType, out gunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun
                {
                    ManufacturerId = gunsDto.ManufacturerId,
                    GunWeight = gunsDto.GunWeight,
                    BarrelLength = gunsDto.BarrelLength,
                    NumberBuild = gunsDto.NumberBuild,
                    Range = gunsDto.Range,
                    GunType = gunType,
                    ShellId = gunsDto.ShellId,
                    CountriesGuns = gunsDto.Countries.Select(x => new CountryGun
                        {
                            CountryId = x.Id
                        })
                        .ToArray()
                };
                gunsToImport.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(gunsToImport);
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
