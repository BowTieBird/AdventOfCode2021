string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 20\input.txt");

string algorithm = lines[0].Replace('.','0').Replace('#','1');

// Initialise Grid
string[] grid = new string[lines.Length-2];
for(int i = 0; i < grid.Length; i++) {
    grid[i] = lines[i+2].Replace('.','0').Replace('#','1');
}
char infinitechar = '0'; //'.'

int N = 50;
for (int iteration = 0; iteration < N; iteration++) {

    int m = grid.Length, n = grid[0].Length;
    string[] nextgrid = new string[m+2];
    for (int y = -1; y <= m; y++) { // indices x and y match with indices of the old grid
        string padding = new string(infinitechar, 2);
        if (y+1 < m) grid[y+1] = String.Concat(padding, grid[y+1], padding); // add padding
        nextgrid[y+1] = "";

        for (int x = -1; x <= n; x++) {
            string neighbours = "";
            neighbours += y <= 0 ? new string(infinitechar, 3) : grid[y-1].Substring(x+1, 3);
            neighbours += y == -1 || y == m ? new string(infinitechar, 3) : grid[y].Substring(x+1, 3);
            neighbours += y >= m-1 ? new string(infinitechar, 3) : grid[y+1].Substring(x+1, 3);

            int index = Convert.ToInt32(neighbours, 2);
            nextgrid[y+1] += algorithm[index]; // look up the new character using the algorithm

            // Console.WriteLine(neighbours.Substring(0, 3));
            // Console.WriteLine(neighbours.Substring(3, 3));
            // Console.WriteLine(neighbours.Substring(6, 3));
            // Console.WriteLine();

        }
    }

    grid = nextgrid;
    infinitechar = algorithm[Convert.ToInt32(new string(infinitechar, 9), 2)];
}

// Count lit pixels
double count = 0;
for (int i = 0; i < grid.Length; i++) {
    foreach (char c in grid[i]) if (c == '1') count++;
}
Console.WriteLine(count);