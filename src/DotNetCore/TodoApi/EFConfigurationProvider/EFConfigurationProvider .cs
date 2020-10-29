using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.EFConfigurationProvider
{
    public class EFConfigurationProvider:ConfigurationProvider
    {
        public Action<DbContextOptionsBuilder> OptionsAction { get; private set; }
        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsActions)
        {
            OptionsAction = optionsActions;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<EFConfigurationContext>();
            OptionsAction(builder);
            using var dbContext = new EFConfigurationContext(builder.Options);
            dbContext.Database.EnsureCreated();
            Data = !dbContext.Values.Any()
              ? CreateAndSaveDefaultValues(dbContext)
              : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(EFConfigurationContext dbContext)
        {
            // Quotes (c)2005 Universal Pictures: Serenity
            // https://www.uphe.com/movies/serenity
            var configValues =
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                { "quote1", "I aim to misbehave." },
                { "quote2", "I swallowed a bug." },
                { "quote3", "You can't stop the signal, Mal." }
                };

            dbContext.Values.AddRange(configValues
                .Select(kvp => new EFConfigurationValue
                {
                    Id = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());

            dbContext.SaveChanges();

            return configValues;
        }
    }
}
