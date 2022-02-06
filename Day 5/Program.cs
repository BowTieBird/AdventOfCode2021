string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 5\input.txt");

int N = 1000; //1000;
int[,] grid = new int[N,N];

int count = 0;

for (int i = 0; i < lines.Length; i++) {
    string[] line = lines[i].Split(" -> ");
    int[] x1 = Array.ConvertAll(line[0].Split(','), s => Convert.ToInt32(s));
    int[] x2 = Array.ConvertAll(line[1].Split(','), s => Convert.ToInt32(s));
    int xdir = Math.Sign(x2[0] - x1[0]);
    int ydir = Math.Sign(x2[1] - x1[1]);
    int d = Math.Max(Math.Abs(x2[0] - x1[0]), Math.Abs(x2[1] - x1[1]));
    for (int j = 0; j <= d; j++) {
        int square = grid[x1[0] + xdir * j, x1[1] + ydir * j];
        if (square <= 1) {
            if (square == 1) count++;
            grid[x1[0] + xdir * j, x1[1] + ydir * j]++;
        } 
    }    
}

Console.WriteLine(count);