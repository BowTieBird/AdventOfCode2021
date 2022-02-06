// string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 14\input.txt");

// string polymer = lines[0];

// Dictionary<string, string> insertions = new Dictionary<string, string>();
// for (int i = 2; i < lines.Length; i++) {
//     string[] line = lines[i].Split(" -> ");
//     insertions[line[0]] = line[1];
// }

// int n = 40;
// for (int iteration = 0; iteration < n; iteration++) {
//     string next = "";
//     for (int i = 0; i < polymer.Length; i++) {
//         next += polymer[i];
//         if (i < polymer.Length - 1) {
//             string key = polymer.Substring(i,2);
//             if (insertions.ContainsKey(key)) {
//                 next += insertions[key];
//             }
//         }
//     }
//     polymer = next;
//     Console.WriteLine(iteration);
// }

// Dictionary<char, int> count = new Dictionary<char, int>();
// for (int i = 0; i < polymer.Length; i++) {
//     if (count.ContainsKey(polymer[i])) {
//         count[polymer[i]]++;
//     } else {
//         count[polymer[i]] = 1;
//     }
// }

// Console.WriteLine(count.Values.Max() - count.Values.Min());