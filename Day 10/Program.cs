string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 10\input.txt");

double syntaxscore = 0;
List<double> linescores = new List<double>();

for (int i = 0; i < lines.Length; i++) {
    string line = lines[i];

    Stack<char> brackets = new Stack<char>();

    bool corrupted = false;
    for(int j = 0; j < line.Length; j++) {
        char c = line[j];
        if (c == '(' || c == '[' || c == '{' || c == '<') brackets.Push(c);
        if (c == ')') {
            int l = brackets.Pop();
            if (l != '(') {
                syntaxscore += 3;
                corrupted = true;
                break;
            }
        }
        if (c == ']') {
            int l = brackets.Pop();
            if (l != '[') {
                syntaxscore += 57;
                corrupted = true;
                break;
            }
        }
        if (c == '}') {
            int l = brackets.Pop();
            if (l != '{') {
                syntaxscore += 1197;
                corrupted = true;
                break;
            }
        }
        if (c == '>') {
            int l = brackets.Pop();
            if (l != '<') {
                syntaxscore += 25137;
                corrupted = true;
                break;
            }
        }
    }

    if (!corrupted) {
        double linescore = 0;
        while (brackets.Count > 0) {
            linescore *= 5;
            char c = brackets.Pop();
            if (c == '(') linescore += 1;
            if (c == '[') linescore += 2;
            if (c == '{') linescore += 3;
            if (c == '<') linescore += 4;
        }
        linescores.Add(linescore);
    }
}

Console.WriteLine(syntaxscore);

linescores.Sort();
int n = linescores.Count;
Console.WriteLine(linescores[(n-1)/2]);
