using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.visitor
{
      public class twoKeyDictionary : Element
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

        public Dictionary<string, Operator> convertionDictionary;

        public twoKeyDictionary()
        {
            convertionDictionary = new Dictionary<string, Operator>();
        }

        public void add(string key1, string key2, double value)
        {
            addEntry(key1, key2, value);
            addEntry(key2, key1, 1 / value);
            addEntry(key1, key1, 1);
            addEntry(key2, key2, 1);
        }

        public void addEntry(string key1, string key2, double value)
        {
            Operator currentDictionary;
            if (convertionDictionary.ContainsKey(key1))
            {
                currentDictionary = convertionDictionary[key1];
            }
            else
            {
                currentDictionary = new Operator();
                convertionDictionary.Add(key1, currentDictionary);
            }
            if (!currentDictionary.operations.ContainsKey(key2))
            {
                currentDictionary.operations.Add(key2, value);
            }
        }

        public override string accept(IVisitor visitor, string from, string to, double value)
        {
            return visitor.visit(this, from, to, value);
        }
    }

    public interface IVisitor
    {
        string visit(twoKeyDictionary element, string from, string to, double value);

    }
    public class OperationVisitor : IVisitor
    {
        private List<string> visited;
        public OperationVisitor()
        {
            visited = new List<string>();
        }
        
        public string visit(twoKeyDictionary element, string from, string to, double value)
        {
            visited.Clear();
            var resultDouble = visitLoop(element, from, to, value);
            if (resultDouble != null)
            {
                return String.Format("{0} {1} = {2} {3}",  value.ToString(),from,resultDouble.ToString(), to);
            }
            else
            {
                return "There was an error with the selected conversion";
            }
        }

        public double? visitLoop(twoKeyDictionary element,  string from, string to, double value)
        {
            if (!element.convertionDictionary.ContainsKey(from) || visited.Contains(from))
            {
                return null;
            }

            var values = new List<double?>();
            var current = element.convertionDictionary[from];
            visited.Add(from);
            if (current.operations.ContainsKey(to))
            {
                values.Add(current.operations[to]);
            }
            else
            {
                foreach (var opperation in current.operations)
                {
                    values.Add(visitLoop(element, opperation.Key, to, opperation.Value));
                }
            }
            var possibleValueList = values.Where(t => t != null).Distinct();
            if (possibleValueList.Distinct().Count() != 0)
            {
                return possibleValueList.ElementAt(0) * value;
            }

            return null;
        }

        
    }
    public abstract class Element
    {
        public abstract string accept(IVisitor visitor, string from, string to, double value);
    }
    public class Operator
    {
        public Dictionary<string, double> operations = new Dictionary<string, double>();


    }
}