string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 1\input.txt");

Boolean first = true;
int increasedcount = 0;
int previous = 0;

foreach (string line in lines) {
    int current = Convert.ToInt32(line);
        
    if (!first) {
        if (current > previous) {
            increasedcount++;
        }
    } else first = false;
    
    previous = current;  
}

Console.WriteLine(increasedcount);
