using System;
using System.Collections.Generic;
using FeedManagerApp.Importers;
using FeedManagerApp.Models;
using FeedManagerApp.Repositories;

class Program
{
    static void Main(string[] args)
    {
        var repository = new InMemoryDatabaseRepository();

        var deltaImporter = new DeltaOneFeedImporter(repository);
        var emImporter = new EmFeedImporter(repository);

        Console.WriteLine("Importing DeltaOne Feeds:");
        deltaImporter.Import(new List<DeltaOneFeed>
        {
            new DeltaOneFeed
            {
                StagingId = 1,
                CounterpartyId = 100,
                PrincipalId = 200,
                SourceAccountId = 5,
                ValuationDate = DateTime.Today,
                MaturityDate = DateTime.Today.AddDays(10),
                CurrentPrice = 123.45m,
                Isin = "US1234567890"
            },
            new DeltaOneFeed
            {
                StagingId = 2,
                CounterpartyId = 100,
                PrincipalId = 200,
                SourceAccountId = 5,
                ValuationDate = DateTime.Today,
                MaturityDate = DateTime.Today.AddDays(5),
                CurrentPrice = 456.78m,
                Isin = "INVALIDISIN"
            }
        });

        Console.WriteLine("\nImporting Em Feeds:");
        emImporter.Import(new List<EmFeed>
        {
            new EmFeed
            {
                StagingId = 3,
                CounterpartyId = 150,
                PrincipalId = 250,
                SourceAccountId = 6,
                ValuationDate = DateTime.Today,
                CurrentPrice = 99.99m,
                Sedol = 50,
                AssetValue = 40
            },
            new EmFeed
            {
                StagingId = 4,
                CounterpartyId = 150,
                PrincipalId = 250,
                SourceAccountId = 6,
                ValuationDate = DateTime.Today,
                CurrentPrice = 88.88m,
                Sedol = 20,
                AssetValue = 30
            }
        });

        Console.WriteLine("\n📋 Error Log:");
        var errors = repository.GetAllErrors();
        foreach (var err in errors)
            Console.WriteLine(err);
    }
}
