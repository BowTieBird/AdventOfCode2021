/*
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 3\input.txt");

int l = lines[0].Length;
int[] zerocount = new int[l];

for (int i = 0; i < lines.Length; i++) {
    for (int j = 0; j < l; j++) {
        if(lines[i][j] == '0') {
            zerocount[j]++;
        }
    }
}

Console.WriteLine();
string gamma = "";
string epsilon = "";
for (int j=0; j<l; j++) {
    if (zerocount[j] >= lines.Length / 2) {
        gamma += '0';
        epsilon += '1';
    } else {
        gamma += '1';
        epsilon += '0';
    }
}
int g = Convert.ToInt32(gamma, 2);
int e = Convert.ToInt32(epsilon, 2);
Console.WriteLine(g*e);
*/