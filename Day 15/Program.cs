string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 15\input.txt");

int w = lines[0].Length;
int h = lines.Length;
int n = 5;
int W = n*w;
int H = n*h;

int[,] grid = new int[W,H];


for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        for (int x = 0; x < w; x++) {
            for (int y = 0; y < h; y++) {
                int X = i*w + x;
                int Y = j*h + y;
                grid[X,Y] = lines[x][y] - 48 + i + j;
                while (grid[X,Y] > 9) grid[X,Y] -= 9;
            }
        }
    }
}

int[,] risk = new int[W,H];
for(int i = 0; i < W; i++) {
    for (int j = 0; j < H; j++) {
        risk[i,j] = -1;
    }
}
risk[W-1, H-1] = 0;

List<int[]> Q = new List<int[]>();
Q.Add(new int[] {W-1, H-1});


while(Q.Count > 0) {
    int minindiex = 0;
    for (int i = 0; i < Q.Count; i++) {
        if (risk[Q[i][0], Q[i][1]] < risk[Q[minindiex][0], Q[minindiex][1]]) minindiex = i;
    }
    int x = Q[minindiex][0], y = Q[minindiex][1];
    Q.RemoveAt(minindiex);

    if (x == 0 && y == 0) {
        Console.WriteLine(risk[0,0]);
        break;
    }

    int alt = risk[x,y] + grid[x,y];

    List<int[]> neighbours = new List<int[]>();
    if (x < W-1 && (alt < risk[x+1, y] || risk[x+1,y] == -1)) {
        risk[x+1, y] = alt;
        Q.Add(new int[] {x+1, y});
    }
    if (x > 0 && (alt < risk[x-1, y] || risk[x-1, y] == -1)) {
        risk[x-1, y] = alt;
        Q.Add(new int[] {x-1, y});
    }    
    if (y < H-1 && (alt < risk[x, y+1] || risk[x, y+1] == -1)) {
        risk[x, y+1] = alt;
        Q.Add(new int[] {x, y+1});
    }
    if (y > 0 && (alt < risk[x, y-1] || risk[x, y-1] == -1)) {
        risk[x, y-1] = alt;
        Q.Add(new int[] {x, y-1});
    }
}

// for (int i = 0; i < W; i++) {
//     int k = 0;
//     for (int j = 0; j < H; j++) {
//         Console.Write(risk[k,j]);
//         Console.Write(" ");
//     }
//     Console.WriteLine();
// }

Console.WriteLine(risk[0,0]);
