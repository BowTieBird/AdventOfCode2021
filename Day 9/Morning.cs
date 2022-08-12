// string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 9\input.txt");

// int sum = 0;

// for (int i = 0; i < lines.Length; i++) {
//     for (int j = 0; j < lines[i].Length; j++) {
//         if (
//             (i == 0 || lines[i-1][j] > lines[i][j])
//             && (i == lines.Length-1 || lines[i+1][j] > lines[i][j])
//             && (j == 0 || lines[i][j-1] > lines[i][j])
//             && (j == lines[i].Length-1 || lines[i][j+1] > lines[i][j])
//         ) {
//             Console.WriteLine(lines[i][j]);
//             sum += lines[i][j] - 47;
//         }
//     }
// }

// Console.WriteLine(sum);