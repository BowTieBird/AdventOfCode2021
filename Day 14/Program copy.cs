string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 14\input.txt");

string polymer = lines[0];

Dictionary<string, string> insertions = new Dictionary<string, string>();
for (int i = 2; i < lines.Length; i++) {
    string[] line = lines[i].Split(" -> ");
    insertions[line[0]] = line[1];
}

Dictionary<string, long> paircount = new Dictionary<string, long>();
// Count the number of pairs
for (int i = 0; i < polymer.Length - 1; i++) {
    string p = polymer.Substring(i,2);
    if (paircount.ContainsKey(p)) {
        paircount[p]++;
    } else {
        paircount[p] = 1;
    }
}

int n = 40;

for (int iteration = 0; iteration < n; iteration++) {
    Dictionary<string, long> next = new Dictionary<string, long>();
    foreach(KeyValuePair<string, long> entry in paircount) {
        // Console.WriteLine("{0} str {1} ct", entry.Key, entry.Value);
        if (insertions.ContainsKey(entry.Key)) {
            string c = insertions[entry.Key];
            string left = entry.Key[0] + c;
            string right = c + entry.Key[1];
            if (next.ContainsKey(left)) {
                next[left] += entry.Value;
            } else {
                next[left] = entry.Value;
            }
            if (next.ContainsKey(right)) {
                next[right] += entry.Value;
            } else {
                next[right] = entry.Value;
            }
        } else next.Add(entry.Key, entry.Value);
    }
    paircount = next;
    Console.WriteLine(iteration);
    Console.WriteLine((paircount.Values.Sum()+2)/2);
}

Dictionary<char, long> charcount = new Dictionary<char, long>();
foreach(KeyValuePair<string, long> entry in paircount) {
    char l = entry.Key[0];
    if (charcount.ContainsKey(l)) {
        charcount[l] += entry.Value;
    } else {
        charcount[l] = entry.Value;
    }

    char r = entry.Key[1];
    if (charcount.ContainsKey(r)) {
        charcount[r] += entry.Value;
    } else {
        charcount[r] = entry.Value;
    }
}
// Note: this double counts everything except first and last char.
charcount[polymer[0]]++;
charcount[polymer[polymer.Length-1]]++;

Console.WriteLine((charcount.Values.Max() - charcount.Values.Min())/2);