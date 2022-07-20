namespace Playground;
public class Program
{
    public Dictionary<string, int[]> Data = new Dictionary<string, int[]>();

    static void Main(string[] args)
    {
        var program = new Program();
        program.Data = new Dictionary<string, int[]>
        {
            {"general", new int[]{ 2, 3, 4 }},
            {"infra", new int[]{ 3, 5 }},
            {"humor", new int[]{ 4, 6 }}
        };

        var data2 = new Dictionary<string, int[]>
        {
            {"general", new int[]{}},
            {"infra", new int[]{}},
            {"humor", new int[]{ 3, 5 }}
        };
    
        // Level 1
        program.GetChannel(4);
        // Level 2
        program.PrintDictionary(program.MergeChannel(data2));
    }

    // Alat bantu untuk print Dictionary
    public void PrintDictionary(Dictionary<string, int[]> data)
    {
        foreach (var x in data)
        {
            Console.WriteLine($"Key = {x.Key}; Value = {string.Join(", ", x.Value.Select(x => x.ToString()).ToArray())}");
        }
    }

    // level 2
    public Dictionary<string, int[]> MergeChannel(Dictionary<string, int[]> input)
    {
        var result = new Dictionary<string, int[]>();
        var newInput = new Dictionary<string, int[]>();

        // Order to asc
        foreach (var x in input)
        {
            newInput.Add(x.Key, x.Value.OrderBy(i => i).ToArray());
        }

        foreach (var x in newInput)
        {
            if (result.Count == 0)
            {
                result.Add(x.Key, x.Value);
                continue;
            }

            var search = result.Where(xx => xx.Value.SequenceEqual(x.Value));
            if (search.Count() == 0)
            {
                result.Add(x.Key, x.Value);
                continue;
            }

            string key = search.First().Key;
            result.Remove(key);
            result.Add($"{key}-{x.Key}", x.Value);
        }

        return result;
    }

    // Level 1
    public string GetChannel(int id)
    {
        var getMember = Data.Where(x => x.Value.Contains(id));
        if (getMember.Count() == 0) return "null";

        var channel = getMember.OrderBy(x => x.Value.Count()).First().Key;
        return channel;
    }
}