using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAWPokemonBattle.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<MoveProperty> Moves{ get; set; }

        public List<MoveReference> ChooseMoves()
        {
            Random rnd = new Random();
            var choosenMoves = new List<MoveReference>();

            var nums = new List<int>();
            while (nums.Count < 4)
            {
                if (nums.Count == 0)
                {
                    nums.Add(rnd.Next(Moves.Count));
                }
                else
                {
                    var randomNum = rnd.Next(Moves.Count);
                    if (nums.IndexOf(randomNum) == -1) 
                    {
                        nums.Add(rnd.Next(randomNum));
                    }
                }
            }

            nums.ForEach(num =>
            {
                choosenMoves.Add(this.Moves[num].Move);
            });

            return choosenMoves;
        }
        public BattleModel AsBattleModel()
        {
            return new BattleModel
            {
                Id = this.Id,
                Name = this.Name,
                Moves = new List<Move>()
            };
        }
    }
    public class MoveReference
    {
        public string Name { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
    }
    public class MoveProperty
    {
        public MoveReference Move {get; set;}
    }
}
