using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.flyweight
{

    public class Flyweight
    {
        //flyweight Objects
        public Dictionary<string, flyweightPlayer> flyweightPlayers = new Dictionary<string, flyweightPlayer>();

        public static List<pawnPOCO> pawns = new List<pawnPOCO>{
            new pawnPOCO("Hamm", false,"http://a.dilcdn.com/bl/wp-content/uploads/sites/2/2013/07/HammPirate.jpg"),
            new pawnPOCO("Witch", false,  "http://cdn04.cdn.justjaredjr.com/wp-content/uploads/headlines/2012/06/meet-brave-witch.jpg"),
            new pawnPOCO("Syndrome", false,  "http://icant.co.uk/talks/h5/pictures/senchacon/syndrome-closeup.jpg"),
            new pawnPOCO("Chick", false,  "http://vignette2.wikia.nocookie.net/pixar/images/1/17/Cars-the-movie-chick-hicks.jpg/revision/latest?cb=20140413122344"),
            new pawnPOCO("Randell", false,  "http://ia.media-imdb.com/images/M/MV5BMjEzODE1NDMxMF5BMl5BanBnXkFtZTYwNTIwODA3._V1_SX640_SY720_.jpg"),
            new pawnPOCO("Woody", true,  "http://img3.wikia.nocookie.net/__cb20131121214608/disney/images/a/a5/Woody_Promational_Art.jpg"),
            new pawnPOCO("Marida", true,  "http://24.media.tumblr.com/tumblr_lw5pwd4crV1r6g6cuo1_500.png"),
            new pawnPOCO("Dash", true,  "http://www.writeups.org/img/fiche/2861c.jpg"),
            new pawnPOCO("Lightning", true, "http://vignette2.wikia.nocookie.net/maditsmadfunny/images/2/29/Lightning_McQueen_Cars_2.png/revision/latest?cb=20130429200451"),
            new pawnPOCO("Sully", true,  "http://img3.wikia.nocookie.net/__cb20130414194442/disney/images/3/3b/Sully.png")
        };


        public static Flyweight _flyweight;
        public List<player> players;
        public List<player> _badPlayers;
        public List<player> _goodPlayers;
        public List<player> badPlayers { get { return players.Where(t => flyweightPlayers[t.name].good == false).ToList(); } }
        public List<player> goodPlayers { get { return players.Where(t => flyweightPlayers[t.name].good).ToList(); } }
        public static Flyweight Instance
        {
            get
            {

                if (_flyweight == null)
                {
                    _flyweight = new Flyweight(5);
                }

                return _flyweight;

            }
        }
        public static void reset()
        {
            _flyweight = null;
        }

        public string battle(ref player attacher1, ref player attacker2)
        {
            var attacker1Power = attacher1.getPower(flyweightPlayers);
            var attecker2Power = attacker2.getPower(flyweightPlayers);
            attacher1.battle(attecker2Power, flyweightPlayers);
            attacker2.battle(attacker1Power, flyweightPlayers);


            return attacher1.printStatus(flyweightPlayers) + "<br>" + attacker2.printStatus(flyweightPlayers);
        }

        

        public Flyweight(int count)
        {
            players = new List<player>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                players.Add(createPlayer(true, rnd));
                players.Add(createPlayer(false, rnd));
            }

        }

        public player createPlayer( bool good, Random rnd)
        {
            var possiblePawns = pawns.Where(t => t.Good == good).ToArray();
            var rand = rnd.Next(possiblePawns.Count());
            var player = new player(possiblePawns[rand], rnd);
            flyweightPlayerFactory(possiblePawns[rand]);
            return player;
        }

        public void flyweightPlayerFactory(pawnPOCO pawn)
        {
            if (!flyweightPlayers.ContainsKey(pawn.Name))
            {
                flyweightPlayers.Add(pawn.Name, new flyweightPlayer(pawn));
            }
        }


        public string round(int playerNumber)
        {
            var goodPlayers = players.Where(t => flyweightPlayers[t.name].good);
            var goodPlayer = players.ElementAt(getCurrentPosition(players, goodPlayers.ElementAt(playerNumber)));
            if (!goodPlayer.alive)
            {
                return goodPlayer.name + " is Dead and can not go to battle.";
            }
            var avalableBadPlayers = players.Where(t => t.alive && flyweightPlayers[t.name].good == false).ToList();
            var aliveBadPlayer = avalableBadPlayers.ElementAt(getRandomPlayer(avalableBadPlayers));
            var badPlayer = players.ElementAt(getCurrentPosition(players, aliveBadPlayer));

            var battleResult = battle(ref goodPlayer, ref badPlayer);
            var result = "";



            if (getAliveCountGoodOrBad(players, false).Count == 0)
            {
                result = "You won the fight for good and evil.  Good Prevails!!!  <img src='http://gb.images.s3.amazonaws.com/wp-content/uploads/2012/01/WALLE.png' class='flighweight_image_small img-circle'><br>";
            }
            else if (getAliveCountGoodOrBad(players, true).Count == 0)
            {
                result = "You lost the fight for good and evil.  Evil Prevails!!! <br>";
            }

            if (goodPlayer.alive && badPlayer.alive)
            {
                result += "The battle was a draw.";
            }
            else if (goodPlayer.alive)
            {
                result += "You won the battle";
            }
            else
            {
                result += "You lost the battle";
            }

            return result + "<br>" + battleResult;

        }

        public int getCurrentPosition(List<player> list, player player)
        {
            return list.IndexOf(player);
        }

        public int getRandomPlayer(List<player> list)
        {
            Random rnd = new Random();
            var aliveList = getAliveCount(list);
            return rnd.Next(aliveList.Count);
        }

        public List<player> getAliveCount(List<player> list)
        {
            return list.Where(t => t.alive == true).ToList();
        }

        public List<player> getAliveCountGoodOrBad(List<player> list, bool good)
        {
            return list.Where(t => t.alive == true && flyweightPlayers[t.name].good == good).ToList();
        }
    }

    public class flyweightPlayer
    {

        private int _strength;
        public int strength { get { return _strength; } }
        private bool _good;
        public bool good { get { return _good; } }
        private string _image;
        public string image { get { return _image; } }
        private string _name;
        public string name { get { return _name; } }


        public flyweightPlayer(pawnPOCO pawn)
        {
            _strength = 20;
            _name = pawn.Name;
            _image = pawn.Url;
            _good = pawn.Good;
        }

    }

    public class player
    {
        private int _life;
        public int life { get { return _life; } set { _life = value; } }
        private bool _alive;
        public bool alive { get { return _alive; } set { _alive = value; } }
        private string _name;
        public string name { get { return _name; } }
        public player(pawnPOCO pawn, Random rnd)
        {
            _alive = true;
            _life = rnd.Next(20);
            _name = pawn.Name;

        }

        public void battle(int attackerPower, Dictionary<string, flyweightPlayer> flyweightPlayers)
        {
            var strength = flyweightPlayers[name].strength;
            life -= attackerPower / strength;
            if (life <= 0)
            {
                alive = false;
                life = 0;
            }
        }

        public int getPower(Dictionary<string, flyweightPlayer> flyweightPlayers)
        {
            if (flyweightPlayers.ContainsKey(name))
            {
                return flyweightPlayers[name].strength * life;
            }

            return 0;
        }

        public string printStatus(Dictionary<string, flyweightPlayer> flyweightPlayers)
        {
            if (flyweightPlayers.ContainsKey(name))
            {

                if (alive)
                {
                    return String.Format("<img src='{0}' class='flighweight_image_small img-circle' > survived the battle and has {1} life left", flyweightPlayers[name].image, life);
                }
                else
                {
                    return String.Format("<img src='{0}' class='flighweight_image_small img-circle' > has died in the battle", flyweightPlayers[name].image);
                }
            }
            return "";
        }

    }


    public class pawnPOCO
    {
        public string Name;
        public bool Good;
        public string Url;
        public pawnPOCO(string name, bool good, string url)
        {
            Name = name;
            Good = good;
            Url = url;
        }
    }
}