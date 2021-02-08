using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TAWPokemonBattle.Services;

namespace TAWPokemonBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IBattleService, BattleService>();
            })
            .Build();

            var battleService = ActivatorUtilities.CreateInstance<BattleService>(host.Services);

            var pokemon1 = battleService.GetRandomPokemon();
            var pokemon2 = battleService.GetRandomPokemon();

            var battleModel1 = pokemon1.AsBattleModel();
            var battleModel2 = pokemon2.AsBattleModel();

            battleModel1.Moves = battleService.GetMoves(pokemon1.ChooseMoves());
            battleModel2.Moves = battleService.GetMoves(pokemon2.ChooseMoves());

            Console.WriteLine(battleModel1.Name);
            foreach(var move in battleModel1.Moves)
            {
                Console.WriteLine("   Name: " + move.Name + " Power: " + move.Power.ToString() + " | " + "PP:" + move.PP.ToString() + " | Accuracy: " + move.Accuracy.ToString());
            }

            Console.WriteLine(battleModel2.Name);
            foreach (var move in battleModel2.Moves)
            {
                Console.WriteLine("   Name: " + move.Name + " Power: " + move.Power.ToString() + " | " + "PP:" + move.PP.ToString() + " | Accuracy: " + move.Accuracy.ToString());
            }
        }
    }
}
