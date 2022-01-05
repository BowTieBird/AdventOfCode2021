string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 2\input.txt");

int horizpos = 0;
int depth = 0;
int aim = 0;

foreach (string line in lines) {
    string[] l = line.Split();
    string dir = l[0];
    int X = Convert.ToInt32(l[1]);
        
    if (dir.Equals("forward")) {
        horizpos += X;
        depth += aim * X; // remove for morning
    } else {
        if (dir.Equals("down")) {
            aim += X;
        } else if (dir.Equals("up")) {
            aim -= X;
        }
        // depth = aim;
    }
}

Console.WriteLine(horizpos);
Console.WriteLine(depth);
Console.WriteLine(depth*horizpos);
