using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.builder
{

        public class Director
        {
            public void construct(Builder builder, string name, string year, string mainChar)
            {
                builder.buildName(name);
                builder.buildType();
                builder.buildYear(year);
                builder.buildMainChar(mainChar);
            }
        }

        public abstract class Builder
        {
            protected Show _show = new Show();
            public abstract void buildType();
            public void buildName(string name)
            {
                _show.name = name;
            }

            public void buildYear(string year)
            {
                _show.year = year;
            }


            public void buildMainChar(string mainChar)
            {
                _show.mainChar = mainChar;
            }
            public string getResult()
            {
                return _show.print();
            }
        }

        class buildMovie : Builder
        {
            public override void buildType()
            {
                this._show.type = "Movie";
            }

        }

        class buildShort : Builder
        {
            public override void buildType()
            {
                this._show.type = "Short";
            }
        }


        public class Show
        {
            private string _name = "";
            private string _year = "";
            private string _mainChar = "";
            private string _type = "";

            public string name
            {
                set { _name = value; }
            }
            public string year
            {
                set { _year = value; }
            }
            public string mainChar
            {
                set { _mainChar = value; }
            }
            public string type
            {
                set { _type = value; }
            }
            public string print ()
            {
                return string.Format("The name of this show is {0}, <br> It is a {1},<br> made in {2},<br> and the main character is {3}  ",_name,_type,_year,_mainChar);
                
            }
        }

    }
