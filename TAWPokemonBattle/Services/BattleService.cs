using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TAWPokemonBattle.Models;

namespace TAWPokemonBattle.Services
{
    class BattleService : IBattleService
    {
        static HttpClient client = new HttpClient();
        public Pokemon GetRandomPokemon()
        {
            var number = new Random().Next(386);

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://pokeapi.co/api/v2/pokemon/" + number.ToString()));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonString);
            return pokemon;
        }

        public List<Move> GetMoves (List<MoveReference> moveReferences)
        {
            var moves = new List<Move>();

            foreach (var MoveReference in moveReferences)
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(MoveReference.URL));
                WebReq.Method = "GET";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                moves.Add(JsonConvert.DeserializeObject<Move>(jsonString));
            }
            return moves;
        }
    }

      
}
