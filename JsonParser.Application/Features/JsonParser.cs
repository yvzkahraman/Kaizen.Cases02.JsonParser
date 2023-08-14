using JsonParser.Application.Interfaces;
using JsonParser.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonParser.Application.Features
{
    public class JsonParser : IJsonParser
    {
        public string ConvertToStringFromJson(string data)
        {
            var datas = JsonConvert.DeserializeObject<List<Item>>(data);

            var normalizedItems = new List<NormalizedItem>();

            //4 tane koordinat var, bunların normalize edilmesi gerekiyor. En azından merkez noktanın bulunması lazim

            foreach (var item in datas)
            {
                //solüst
                var x1 = item.BoundingPoly.Vertices[0].X;
                var y1 = item.BoundingPoly.Vertices[0].Y;

                //sağüst
                var x2 = item.BoundingPoly.Vertices[1].X;
                var y2 = item.BoundingPoly.Vertices[1].Y;

                // sağ alt 
                var x3 = item.BoundingPoly.Vertices[2].X;
                var y3 = item.BoundingPoly.Vertices[2].Y;

                //sol alt
                var x4 = item.BoundingPoly.Vertices[3].X;
                var y4 = item.BoundingPoly.Vertices[3].Y;

                var normalizedItem = new NormalizedItem();

                normalizedItem.Description = item.Description;
                normalizedItem.CenterX = (x1 + x2) / 2;
                normalizedItem.CenterY = (y2 + y3) / 2;

                normalizedItems.Add(normalizedItem);
            }


            var fullText = new StringBuilder();
            fullText.AppendLine("line text");
            var lineNumber = 0;

            //suradaki değer ile oynanalıabilir.
            double thresholt = 1;   

            for (int i = 0; i<normalizedItems.Count; i++)
            {
                var singleLine = normalizedItems.Where(x => x.CenterY == normalizedItems[i].CenterY).OrderBy(x => x.CenterY).Select(x => x.Description);

                var result = string.Join(" ", singleLine);

                if (normalizedItems[i+1].CenterY > normalizedItems[i].CenterY+thresholt)
                {
                    fullText.AppendLine($"{lineNumber + 1} {result}");
                }
                else
                {
                    fullText.Append($"{lineNumber + 1} {result}");
                }
                
                
                i = i + singleLine.Count();
                lineNumber++;
            }

            var converted = fullText.ToString();

            return converted;
        }
    }
}
