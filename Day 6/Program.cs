string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 6\input.txt");

int[] initial = Array.ConvertAll(lines[0].Split(','), s => Convert.ToInt32(s));

double[] lanternfishcount = new double[7]; // lanternfishcount[i] = number of lantern fish with internal timer set to i - day%7
double[] newfishcount = new double[7]; // newfishcount[i] = number of lantern fish with internal timer set to 7 + i - day%7

for (int i = 0; i < initial.Length; i++) {
    lanternfishcount[initial[i]]++;
}

int maxdays = 256;
for (int day = 0; day < maxdays; day++) {
    int mod = day % 7;
    newfishcount[(mod+2)%7] = lanternfishcount[mod];
    lanternfishcount[mod] += newfishcount[mod];
    newfishcount[mod] = 0;
}

double count = 0;
for (int i = 0; i < lanternfishcount.Length; i++) {
    count += lanternfishcount[i];
    count += newfishcount[i];
}

Console.WriteLine(count);
