string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 7\input.txt");

int[] arr = Array.ConvertAll(lines[0].Split(','), s => Convert.ToInt32(s));

int[] pos = new int[arr.Max()+1];

for (int i = 0; i < arr.Length; i++) {
    pos[arr[i]]++;
}

double[] rightweights = new double[arr.Max()+1];
double rightinc = 0;
double rightcount = 0;

for (int j = 1; j < pos.Length; j++) {
    rightcount += pos[j-1];
    rightinc += rightcount;
    rightweights[j] = rightweights[j-1] + rightinc;
}

double min = -1;
double leftinc = 0;
double leftcount = 0;
double leftweight = 0;

for (int j = pos.Length-2; j >= 0; j--) {
    leftcount += pos[j+1];
    leftinc += leftcount;
    leftweight += leftinc;
    if (leftweight + rightweights[j] < min || min == -1) {
        min = leftweight + rightweights[j];
    }
}

Console.WriteLine(min);

