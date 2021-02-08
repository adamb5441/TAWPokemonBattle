using System;
using System.Collections.Generic;
using System.Text;
using TAWPokemonBattle.Models;

namespace TAWPokemonBattle.Services
{
    interface IBattleService
    {
        Pokemon GetRandomPokemon();
    }
}
