using JsonParser.Application.Defaults;
using JsonParser.Application.Features;

class Program
{
    static void Main(string[] args)
    {
        var parser = new JsonParser.Application.Features.JsonParser();
        Console.WriteLine(parser.ConvertToStringFromJson(JsonParserDatas.Data));

    }
}

