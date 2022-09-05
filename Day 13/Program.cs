string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 13\input.txt");

List<int[]> dots = new List<int[]>();

int dotlineindex = 0;
for (int i = 0; i < lines.Length; i++) {
    if (lines[i].Contains(',')) {
        int[] newdot = Array.ConvertAll(lines[i].Split(','), s => Convert.ToInt32(s));
        bool dotinserted = false;
        for (int j = 0; j < dots.Count; j++) {
            if (newdot[0] < dots[j][0]) {
                dots.Insert(j, newdot);
                dotinserted = true;
                break;
            }
        }
        if (!dotinserted) dots.Add(newdot);

    } else {
        dotlineindex = i;
        break;
        // blank line
    }
}


for (int i = dotlineindex+1; i < lines.Length; i++) {
    string[] line = lines[i].Split('=');
    int lineval = Int32.Parse(line[1]);
    if (line[0][line[0].Length-1] == 'x') {
        //x flip
        for (int j = 0; j < dots.Count; j++) {
            if (dots[j][0] > lineval) {
                //Search for mirror image
                bool mirrorfound = false;
                for (int k = 0; k < j; k++) {
                    if (dots[k][0] == 2*lineval - dots[j][0]) {
                        if (dots[j][1] == dots[k][1]) {
                            // found
                            dots.RemoveAt(j);
                            j--;
                            mirrorfound = true;
                            break;
                        }
                    } else if (dots[k][0] > 2*lineval - dots[j][0]) {
                        // not found
                        int[] dot = dots[j];
                        dot[0] = 2*lineval - dots[j][0];
                        dots.RemoveAt(j);
                        dots.Insert(k, dot);
                        mirrorfound = true;
                        break;
                    }
                }
                if (!mirrorfound) dots[j][0] = 2*lineval - dots[j][0];
            }
        }
    } else if (line[0][line[0].Length-1] == 'y') {
        //y flip
        for (int j = 0; j < dots.Count; j++) {
            if (dots[j][1] > lineval) {
                //Search for mirror image
                bool mirrorfound = false;
                for (int k = 0; k < dots.Count; k++) {
                    if (dots[k][0] == dots[j][0]) {
                        if (2*lineval - dots[j][1] == dots[k][1]) {
                            dots.RemoveAt(j);
                            j--;
                            mirrorfound = true;
                            break;
                        }
                    }
                }
                if (!mirrorfound) dots[j][1] = 2*lineval - dots[j][1];
            }
        }
    }

    Console.WriteLine(dots.Count);
}

// get max
int maxx = 0;
int maxy = 0;
foreach (int[] dot in dots) {
    int x = dot[0];
    int y = dot[1];
    if (x > maxx) maxx = x;
    if (y > maxy) maxy = y;
}
bool[,] grid = new bool[maxx+1, maxy+1];

foreach (int[] dot in dots) {
    int x = dot[0];
    int y = dot[1];
    grid[x,y] = true;
}

for (int y = 0; y <= maxy; y++) {
    Console.WriteLine();
    for (int x = 0; x <= maxx; x++) {
        if (grid[x,y]) Console.Write('#');
        else Console.Write(' ');
    }
}