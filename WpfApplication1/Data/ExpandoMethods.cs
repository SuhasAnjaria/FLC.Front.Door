using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MatrixLib.Matrix;
using System.Dynamic;
using System.Collections;

namespace flc.FrontDoor.Data
{
    public class DynamoGenerator
    {
        public static ObservableCollection<dynamic> GenerateDataGridObjects(string input)
        {
            ObservableCollection<dynamic> output = new ObservableCollection<dynamic>();
            string[] firstparse = input.Split('|');
            foreach (string row in firstparse)
            {
                if (row == String.Empty) continue;
                dynamic dynamo = new ExpandoObject();
                string[] properties = row.Split(',');
                var dictdynamo = dynamo as IDictionary<string, object>;
                Queue<string> propertiesloaded = new Queue<string>();
                foreach (string property in properties)
                {
                    propertiesloaded.Enqueue(property);

                }
                int i = 0;
                while (!(propertiesloaded.Count == 0))
                {
                    var Key = propertiesloaded.Dequeue();
                    var Value = propertiesloaded.Dequeue();
                    if (i == 0)
                    {
                        dynamo.RowHeader = Value;
                        i++;
                    }
                    if(Value.Length>4)
                    {
                        var A = double.Parse(Value);
                        Value = A.ToString("f3");

                    }
                    dictdynamo[Key] = Value;

                }

                output.Add(dynamo);

            }
            
            return output;

        }
    }
   
}
