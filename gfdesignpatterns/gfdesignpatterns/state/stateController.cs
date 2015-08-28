using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.state
{
    public class stateController
    {
    }



    public class twoKeyDictionary
    {
        private static twoKeyDictionary _manager;
        public static twoKeyDictionary Instance
        {

            get
            {

                if (_manager == null)
                {
                    _manager = new twoKeyDictionary();
                }

                return _manager;

            }
        }

        public List<Operation> convertionDictionary;

        public twoKeyDictionary()
        {
            convertionDictionary = new List<Operation>();
        }

        public void add(string key1, string key2, double value)
        {
            convertionDictionary.Add( new Operation {from=key1, to = key2, OperatorValue = value });
            convertionDictionary.Add(new Operation { from = key2, to = key1, OperatorValue = 1 / value });
            convertionDictionary.Add( new Operation { from = key2, to = key1, OperatorValue = 1 });
            convertionDictionary.Add( new Operation { from = key1, to = key2, OperatorValue = 1 });
        }

        public string convert(string from, string to, double value)
        {
            var resultDouble = converterTool(from, to, value);
            if (resultDouble!=null)
            {
                return resultDouble.ToString();
            }
            else
            {
                return "There was an error";
            }

        }

        public double? converterTool(string from, string to, double value)
        {
            var newDictionary = convertionDictionary.Where(t => t.from.Equals(from));
            if (newDictionary.Count() > 0)
            {
                var values = new List<double?>();
                foreach (var entry in newDictionary)
                {
                    
                    if (entry.to.Equals(to))
                    {
                        values.Add(entry.OperatorValue);
                    }
                    else
                    {
                        values.Add(converterTool(entry.to, to, value)!=null? (converterTool(entry.to, to, value) * entry.OperatorValue): null);
                    }
                }
                var possibleValueList = values.Where(t => t != null).Distinct();

                if (possibleValueList.Distinct().Count() > 1)
                {
                    return null;
                }
                else
                {
                    return possibleValueList.ElementAt(0)*value;
                }
            }
            return null;
        }
    }


    public class Operation
    {
        public string to;
        public string from;
        public double OperatorValue;
    }

}