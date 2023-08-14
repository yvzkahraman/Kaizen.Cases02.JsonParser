using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Application.Interfaces
{
    public interface IJsonParser
    {
        string ConvertToStringFromJson(string data);
    }
}
