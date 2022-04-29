using acme.exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.exercise.Utils
{
    public static class Helper
    {
        public static Dictionary<string, int> GetCoincidencesDict(Employee employee, List<Employee> employeeCoincidences, Dictionary<string, int> result)
        {
            foreach (var item in employeeCoincidences)
            {
                string key = employee.Name + "-" + item.Name;
                if (!result.ContainsKey(key))
                {
                    result[key] = 1;
                }
                else
                {
                    result[key] = result[key] + 1;
                }
            }
            return result;
        }

        public static Dictionary<string, int> RemoveReverseKeysOnDict(Dictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                var key = item.Key.Split('-');
                var reverse_key = key[1] + "-" + key[0];
                dictionary.Remove(reverse_key);
            }
            return dictionary;
        }
    }
}
