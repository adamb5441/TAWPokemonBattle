using System;
using System.Collections.Generic;
using System.Text;

namespace TAWPokemonBattle.Models
{
    public class BattleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Move> Moves { get; set; }
    }

}
