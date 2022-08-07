using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var games = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString);

            List<Game> gamesToImport = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();
            foreach (var importGameDto in games)
            {
                if (!IsValid(importGameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importGameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;
                var isDateValid = DateTime.TryParseExact(importGameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game
                {
                    Name = importGameDto.Name,
                    Price = importGameDto.Price,
                    ReleaseDate = date,
                };
                // developer
                var developer = context.Developers
                    .FirstOrDefault(x => x.Name == importGameDto.Developer);

                if (developer == null)
                {
                    var listDeveloper = developers
                        .FirstOrDefault(x => x.Name == importGameDto.Developer);

                    if (listDeveloper == null)
                    {
                        developer = new Developer
                        {
                            Name = importGameDto.Developer,
                        };
                        developers.Add(developer);
                    }
                    else
                    {
                        developer = listDeveloper;
                    }
                }

                game.Developer = developer;

                // Genre

                var genre = context.Genres
                    .FirstOrDefault(x => x.Name == importGameDto.Genre);

                if (genre == null)
                {

                    var listGenre = genres.FirstOrDefault(x => x.Name == importGameDto.Genre);

                    if (listGenre == null)
                    {
                        genre = new Genre
                        {
                            Name = importGameDto.Genre,
                        };
                        genres.Add(genre);
                    }
                    else
                    {
                        genre = listGenre;
                    }
                }

                game.Genre = genre;

                // Tags

                foreach (var tagDto in importGameDto.Tags)

                {
                    if (string.IsNullOrEmpty(tagDto))
                    {
                        continue;
                    }

                    var tag = context.Tags
                        .FirstOrDefault(x => x.Name == tagDto);

                    if (tag == null)
                    {

                        var listTag = tags.FirstOrDefault(x => x.Name == tagDto);

                        if (listTag == null)
                        {
                            tag = new Tag
                            {
                                Name = tagDto,
                            };
                            tags.Add(tag);
                        }
                        else
                        {
                            tag = listTag;
                        }
                    }

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }
                gamesToImport.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }
            context.Games.AddRange(gamesToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var usersDto = JsonConvert.DeserializeObject<List<ImportUserDto>>(jsonString);
            List<User> usersToImport = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                if (userDto.Cards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    CardType cardType;
                    Enum.TryParse(cardDto.Type, out cardType);

                    Card card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType,

                    };

                    user.Cards.Add(card);
                }

                if (user.Cards.Count() == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                usersToImport.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, $"{user.Username}",user.Cards.Count));
            }
            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Purchases");
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            using var stringReader = new StringReader(xmlString);

            var purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            List<Purchase> purchasesToImport = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;

                var isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType;
                if (!Enum.TryParse(purchaseDto.Type, out purchaseType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Date = date,
                    Card = card,
                    Game = game
                };

                purchasesToImport.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, $"{purchase.Game.Name}", $"{card.User.Username}"));
            }
            context.Purchases.AddRange(purchasesToImport);
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