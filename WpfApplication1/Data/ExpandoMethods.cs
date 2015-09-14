using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;

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
                if (row == string.Empty) continue;
                dynamic dynamo = new ExpandoObject();
                string[] properties = row.Split(',');
                var dictdynamo = (IDictionary<string, object>) dynamo;
                Queue<string> propertiesloaded = new Queue<string>();
                foreach (string property in properties)
                {
                    propertiesloaded.Enqueue(property);

                }
                int i = 0;
                while (propertiesloaded.Count != 0)
                {
                    var key = propertiesloaded.Dequeue();
                    var value = propertiesloaded.Dequeue();
                    if (i == 0)
                    {
                        dynamo.RowHeader = value;
                        i++;
                    }
                    if(value.Length>4)
                    {
                        var A = double.Parse(value);
                        value = A.ToString("f3");

                    }
                    dictdynamo[key] = value;

                }

                output.Add(dynamo);

            }
            
            return output;

        }
    }
   
}
