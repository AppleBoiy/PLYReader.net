using System.Text;


namespace PLYReader.net;

internal readonly struct Vertex(float x, float y, float z, uint r, uint g, uint b)
{
    public override string ToString()
    {
        return $"Vertex: ({x}, {y}, {z}) RGB: ({r}, {g}, {b})";
    }
}

internal abstract class DotnetPlyReader
{
    private const string FilePattern = "data/pointclouds/low.ply";

    private static (string[] header, List<Vertex> vertices) ReadBinaryLittleEndianFile(string file)
    {
        using var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(fs, Encoding.ASCII);
        
        var header = new List<string>();
        while (reader.ReadLine() is { } line)
        {
            header.Add(line);
            if (line == "end_header") break;
        }

        long dataStartPosition = fs.Position;
        fs.Position = dataStartPosition;

        using var binaryReader = new BinaryReader(fs);

        var vertices = new List<Vertex>();

        try
        {
            while (fs.Position < fs.Length)
            {
                float x = binaryReader.ReadSingle();
                float y = binaryReader.ReadSingle();
                float z = binaryReader.ReadSingle();
                uint r = binaryReader.ReadByte();
                uint g = binaryReader.ReadByte();
                uint b = binaryReader.ReadByte();
                binaryReader.ReadByte(); // Skip alpha channel if present
                vertices.Add(new Vertex(x, y, z, r, g, b));
            }
        }
        catch (EndOfStreamException)
        {
            // End of stream reached, which is expected
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading vertices: {ex.Message}");
        }
        
        return (header.ToArray(), vertices);
    }

    private static void Main(string[] args)
    {
        var root = RootPath();
        if (string.IsNullOrEmpty(root))
        {
            Console.WriteLine("Root path not found");
            return;
        }

        var files = Directory.GetFiles(root, FilePattern, SearchOption.AllDirectories);

        if (files.Length == 0)
        {
            Console.WriteLine("No PLY files found");
            return;
        }

        var file = files.First();
        Console.WriteLine($"Reading file: {file}");
        
        var (header, vertices) = ReadBinaryLittleEndianFile(file);
        Console.WriteLine($"Header: {header.Length} lines");
        Console.WriteLine($"Data: {vertices.Count} vertices");
        
        if (vertices.Count > 0)
        {
            Console.WriteLine("Vertices:");
            Console.WriteLine("First vertex | " + vertices.First());
            Console.WriteLine("Last vertex  | " + vertices.Last());
        }
    }

    private static string RootPath()
    {
        var workingDirectory = Environment.CurrentDirectory;
        if (string.IsNullOrEmpty(workingDirectory)) return string.Empty;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
        return projectDirectory ?? string.Empty;
    }
}
