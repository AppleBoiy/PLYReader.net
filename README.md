# PLYReader.net

PLYReader.net is a simple .NET application designed to read and parse binary little-endian PLY (Polygon File Format) files. The application extracts vertex data including coordinates and RGB color values, and displays them in a human-readable format.

### Prerequisites

- .NET SDK (version 8.0 or later)

### Building the Project

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/PLYReader.net.git
    ```
2. Navigate to the project directory:
    ```sh
    cd PLYReader.net
    ```
3. Build the project:
    ```sh
    dotnet build
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
Header: 10 lines
Data: 1000 vertices
Vertex: (1.0, 2.0, 3.0) RGB: (255, 0, 0)
```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
