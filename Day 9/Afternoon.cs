string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 9\input.txt");

int m = lines.Length;
int n = lines[0].Length;

int[,] grid =  new int[m,n]; // 0 for unvisited, 1 for visited

for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
        grid[i,j] = lines[i][j] == '9' ? 9 : 0;
    }
}

int[] largestbasins = new int[3];



for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
        if (grid[i,j] == 0) { // unvisited
            grid[i,j] = 1; // set to visited
            int size = 0;
            Queue<int[]> unexplored = new Queue<int[]>();
            // Start the traversal from this point
            unexplored.Enqueue(new int[] {i, j});

            while(unexplored.Count > 0) {
                size++;
                int[] next = unexplored.Dequeue();
                int x = next[0], y = next[1];
                if (x > 0 && grid[x-1,y] == 0) {
                    grid[x-1,y] = 1;
                    unexplored.Enqueue(new int[] {x-1, y});
                }
                if (x < m-1 && grid[x+1,y] == 0) {
                    grid[x+1,y] = 1;
                    unexplored.Enqueue(new int[] {x+1, y});
                }
                if (y > 0 && grid[x,y-1] == 0) {
                    grid[x,y-1] = 1;
                    unexplored.Enqueue(new int[] {x, y-1});
                }
                if (y < n-1 && grid[x,y+1] == 0) {
                    grid[x,y+1] = 1;
                    unexplored.Enqueue(new int[] {x, y+1});
                }  
            }

            Console.WriteLine(size);

            for (int k = 0; k < largestbasins.Length; k++) {
                if (size > largestbasins[k]) {
                    int temp = largestbasins[k];
                    largestbasins[k] = size;
                    size = temp;
                }
            }
        }
    }
}

Console.WriteLine(largestbasins[0] * largestbasins[1] * largestbasins[2]);
