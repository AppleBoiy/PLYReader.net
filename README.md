# PLYReader.net

PLYReader.net is a simple .NET application designed to read and parse binary little-endian PLY (Polygon File Format) files. The application extracts vertex data including coordinates and RGB color values, and displays them in a human-readable format.

### Prerequisites

- .NET SDK (version 8.0 or later)

### PLY File Format
```header.ply
ply
format binary_little_endian 1.0
comment Created by #{software}
element vertex #{number of vertices}
property double x
property double y
property double z
property uchar red
property uchar green
property uchar blue
end_header

#{vertex data}
```

### Running the Application

```tree
.
├── data
│   └── pointclouds
│       └── low.ply # replace with your PLY file
├── PLYReader.net.csproj
├── Program.cs
└── README.md

3 directories, 4 files
```

1. Ensure you have a PLY file in the `data/pointclouds` directory. The file should be named `low.ply`.
2. Run the application:
    ```sh
    dotnet run
    ```

### Output

Example output from running the application:

```
Reading file: /path/to/project/data/pointclouds/low.ply
Header: 11 lines
Data: 3453384 vertices
Vertices:
First vertex | Vertex: (4.4911546E-38, 1.1247499E+23, -3.3587972E+34) RGB: (191, 208, 149)
Last vertex  | Vertex: (-2.240798E+10, -1.9314158, -1.0879884E-14) RGB: (196, 4, 14)
```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
