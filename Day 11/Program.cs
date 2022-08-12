string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 11\input.txt");

int m = lines.Length;
int n = lines[0].Length;

int[,] grid =  new int[m,n];

double flashes = 0;
double flashesThisStep = 0;

for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
        grid[i,j] = Convert.ToInt32(lines[i][j]) - 48;
    }
}

void increase(int x, int y) {
    grid[x, y]++;
    if (grid[x,y] > 9) {
        // flash
        flashesThisStep++;
        grid[x,y] = -1;
        if (x > 0 && grid[x-1,y] != -1) increase(x-1,y);
        if (y > 0 && grid[x,y-1] != -1) increase(x,y-1);
        if (x < m-1 && grid[x+1,y] != -1) increase(x+1,y);
        if (y < n-1 && grid[x,y+1] != -1) increase(x,y+1);  
        if (x > 0 && y > 0 && grid[x-1,y-1] != -1) increase(x-1,y-1);
        if (x > 0 && y < n-1 && grid[x-1,y+1] != -1) increase(x-1,y+1);
        if (x < m-1 && y > 0 && grid[x+1,y-1] != -1) increase(x+1,y-1);
        if (x < m-1 && y < n-1 && grid[x+1,y+1] != -1) increase(x+1,y+1);  
    }
}


for (int step = 0; step < 1000; step++) {
    flashesThisStep = 0;
    for(int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            if (grid[i,j] != -1) increase(i, j);
        }
    }
    flashes += flashesThisStep;

    // if (step % 10 == 9) Console.WriteLine("step" + (step+1));
    for (int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            if (grid[i,j] == -1) grid[i,j] = 0;
            // if (step % 10 == 9) Console.Write(grid[i,j]);
        }
        // if (step % 10 == 9) Console.WriteLine();
    }

    if (flashesThisStep == m*n) {
        Console.WriteLine(step+1);
        break;
    }
}

