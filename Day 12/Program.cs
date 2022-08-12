string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 12\input.txt");

Dictionary<string, List<string>> adjacency = new Dictionary<string, List<string>>();

// Make Adjacency List
for (int i = 0; i < lines.Length; i++) {
    string[] edge = lines[i].Split('-');
    if (!adjacency.ContainsKey(edge[0])) {
        adjacency[edge[0]] = new List<string>();
    }
    adjacency[edge[0]].Add(edge[1]);

    if (!adjacency.ContainsKey(edge[1])) {
        adjacency[edge[1]] = new List<string>();
    }
    adjacency[edge[1]].Add(edge[0]);
}

Stack<List<string>> paths = new Stack<List<string>>();
List<string> startpath = new List<string>();
startpath.Add("");
startpath.Add("start");
paths.Push(startpath);

double numbpaths = 0;

void printpath(List<string> path) {
    Console.WriteLine();
    for (int j = 0; j < path.Count; j++) {
        Console.Write(path[j] + "-");
    }
}

bool cango(List<string> path, string s) {
    if(Char.IsUpper(s, 0)) return true;

    if(s == "start") return false;

    if(path[0] == "") return true;

    else return !path.Contains(s);
}



while (paths.Count > 0) {
    List<string> path = paths.Pop();
    if (path.Last() == "end") {  
        // printpath(path);
        numbpaths++;
    } else {
        foreach(string s in adjacency[path.Last()]) {
            if (cango(path, s)) {
                List<string> newpath = new List<string>(path);
                newpath.Add(s);

                if (newpath[0] == "" && !Char.IsUpper(s, 0)) {
                    for (int j = 0; j < path.Count; j++) {
                        if (newpath[j] == s) {
                            newpath[0] = s;
                            break;
                        }
                    }     
                }

                paths.Push(newpath);
            }
        }
    }
}

Console.WriteLine(numbpaths);