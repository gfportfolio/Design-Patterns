using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.flyweight
{
    public class Flyweight
    {
        public static Flyweight _flyweight;
        public List<player> _badPlayers;
        public List<player> _goodPlayers;
        public List<player> badPlayers { get { return players.Where(t => t.good == false).ToList(); } }
        public List<player> goodPlayers { get { return players.Where(t => t.good).ToList(); } }
        public static Flyweight Instance
        {
            get
            {

                if (_flyweight == null)
                {
                    _flyweight = new Flyweight();
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
            var attacker1Power = attacher1.getPower();
            var attecker2Power = attacker2.getPower();
            attacher1.battle(attecker2Power);
            attacker2.battle(attacker1Power);


            return attacher1.printStatus() + "<br>" + attacker2.printStatus();
        }

        public List<player> players;

        public  Flyweight()
        {
            players = new List<player>();

            players.Add(new goodPlayer(20, 5, "Woody",  "http://img3.wikia.nocookie.net/__cb20131121214608/disney/images/a/a5/Woody_Promational_Art.jpg"));
            players.Add(new goodPlayer(20, 12, "Marida",  "http://24.media.tumblr.com/tumblr_lw5pwd4crV1r6g6cuo1_500.png"));
            players.Add(new goodPlayer(20, 8, "Dash",  "http://www.writeups.org/img/fiche/2861c.jpg"));
            players.Add(new goodPlayer(20, 10, "Lightning", "http://vignette2.wikia.nocookie.net/maditsmadfunny/images/2/29/Lightning_McQueen_Cars_2.png/revision/latest?cb=20130429200451"));
            players.Add(new goodPlayer(20, 15, "Sully",  "http://img3.wikia.nocookie.net/__cb20130414194442/disney/images/3/3b/Sully.png"));
          
            players.Add(new badPlayer(20, 3, "Hamm", "http://a.dilcdn.com/bl/wp-content/uploads/sites/2/2013/07/HammPirate.jpg"));
            players.Add(new badPlayer(20, 11, "Witch",  "http://cdn04.cdn.justjaredjr.com/wp-content/uploads/headlines/2012/06/meet-brave-witch.jpg"));
            players.Add(new badPlayer(20, 10, "Syndrome",  "http://icant.co.uk/talks/h5/pictures/senchacon/syndrome-closeup.jpg"));
            players.Add(new badPlayer(20, 13, "Chick",  "http://vignette2.wikia.nocookie.net/pixar/images/1/17/Cars-the-movie-chick-hicks.jpg/revision/latest?cb=20140413122344"));
            players.Add(new badPlayer(20, 8, "Randell",  "http://ia.media-imdb.com/images/M/MV5BMjEzODE1NDMxMF5BMl5BanBnXkFtZTYwNTIwODA3._V1_SX640_SY720_.jpg"));

        }

        public string round(string playerName)
        {
            var goodPlayer = players.FirstOrDefault(t => t.name.Equals(playerName));
            if (!goodPlayer.alive)
            {
                return goodPlayer.name+" is Dead and can not go to battle.";
            }
            var avalableBadPlayers = players.Where(t => t.alive && t.good==false).ToList();
            var aliveBadPlayer = avalableBadPlayers.ElementAt(getRandomPlayer(avalableBadPlayers));
            var badPlayer = players.ElementAt(getCurrentPosition(players, aliveBadPlayer));

            var battleResult = battle(ref goodPlayer, ref badPlayer);
            var result = "";



            if (getAliveCountGoodOrBad(players, false).Count == 0)
            {
                result = "You won the fight for good and evil.  Good Prevails!!!  <img src='http://gb.images.s3.amazonaws.com/wp-content/uploads/2012/01/WALLE.png' class='flighweight_image_small img-circle'><br>";
            }
            else if(getAliveCountGoodOrBad(players, true).Count == 0)
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
            return list.Where(t => t.alive == true &&t.good==good).ToList();
        }
    }

    public abstract class player
    {
        private int _life;
        public int life { get { return _life; } set { _life = value; } }
        private int _strength;
        public int strength { get { return _strength; } }
        private string _name;
        public string name { get { return _name; } }
        private bool _alive;
        public bool alive { get { return _alive; } set { _alive = value; } }
        private bool _good;
        public bool good { get { return _good; }  set { _good = value; } }
        private string _image;
        public string image { get { return _image; } }


        public player(int life, int strength, string name, string image)
        {
            _life = life;
            _strength = strength;
            _name = name;
            _alive = true;
            _image = image;
        }

        public void battle(int attackerPower)
        {
            life -= attackerPower / strength;
            if (life <= 0)
            {
                alive = false;
                life = 0;
            }
        }

        public int getPower()
        {
            return strength * life;
        }

        public string printStatus()
        {
            if (alive)
            {
                return String.Format("<img src='{0}' class='flighweight_image_small img-circle' > survived the battle and has {1} life left", image, life);
            }
            else
            {
                return String.Format("<img src='{0}' class='flighweight_image_small img-circle' > has died in the battle", image);
            }
        }

    }

    public class goodPlayer : player
    {
        public goodPlayer(int life, int strength, string name,  string image) : base(life, strength, name,  image)
        {
            base.good = true;
        }
    }

    public class badPlayer : player
    {
        public badPlayer(int life, int strength, string name, string image) : base(life, strength, name, image)
        {
            base.good = false;
        }
    }
}