string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 15\input.txt");

int h = lines.Length;
int w = lines[0].Length;

int[,] grid = new int[w,h];

for (int i = 0; i < w; i++) {
    for (int j = 0; j < h; j++) {
        grid[i,j] = lines[i][j] - 48;
    }
}

int[,] risk = new int[w,h];

for (int i = w-1; i >= 0; i--) {
    for (int j = h-1; j >= 0; j--) {
        int right=0, down=0;
        if (i < w-1) right = grid[i+1,j] + risk[i+1,j];
        if (j < h-1) down = grid[i,j+1] + risk[i,j+1];

        if (i < w-1) {
            if (j < h-1) {
                risk[i,j] = Math.Min(right, down);
            } else {
                risk[i,j] = right;
            }
        } else {
            if (j < h-1) {
                risk[i,j] = down;
            } else {
                risk[i,j] = 0;
            }
        }
    }
}

// for (int i = 0; i < w; i++) {
//     for (int j = 0; j < h; j++) {
//         Console.Write(risk[i,j]);
//         Console.Write(" ");
//     }
//     Console.WriteLine();
// }

Console.WriteLine(risk[0,0]);
