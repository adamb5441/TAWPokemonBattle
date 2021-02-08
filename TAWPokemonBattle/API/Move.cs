using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAWPokemonBattle.Models
{
    public class Move
    {
        public string Name { get; set; }

        public int? Accuracy { get; set; }

        public int? Power { get; set; }

        [JsonProperty("pp")]
        public int PP { get; set; }
    }
}
