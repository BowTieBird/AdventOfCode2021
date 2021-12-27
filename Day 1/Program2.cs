// string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 1\input.txt");

// int k = 3;
// int increasedcount = 0;
// int currentsum = 0;
// int previoussum = 0;

// for (int i = 0; i < lines.Length-k+1; i++) {
//     if (i == 0) {
//         for (int j = 0; j < k; j++) {
//             currentsum += Convert.ToInt32(lines[j]);
//         }
//     } else {
//         currentsum += Convert.ToInt32(lines[i+k-1]) - Convert.ToInt32(lines[i-1]);

//         if (currentsum > previoussum) { 
//             increasedcount++;
//         }
//     }    
//     previoussum = currentsum;  
// }

// Console.WriteLine(increasedcount);
