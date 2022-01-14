string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 4\input.txt");
int gridsize = 5;
int[] turns = Array.ConvertAll(lines[0].Split(','), s => Convert.ToInt32(s));

int bestwinturn = turns.Length;
int worstwinturn = -1;
int bestscore = 0;
int worstscore = 0;
List<Board> boards = new List<Board>();
Board currentboard = new Board(gridsize);
for(int i = 2; i < lines.Length; i++) {
    if (!string.IsNullOrWhiteSpace(lines[i])) {
        currentboard.addLine(Array.ConvertAll(lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries), s => Convert.ToInt32(s)));
    }
    if (string.IsNullOrWhiteSpace(lines[i]) || i == lines.Length-1) {
        // currentboard
        boards.Add(currentboard);
        int winturn = currentboard.calculatewin(turns);
        if (winturn < bestwinturn) { // winturn > bestwinturn
            bestwinturn = winturn;
            int score = currentboard.score();
            bestscore = score * turns[winturn];
        }
        if (winturn > worstwinturn) {
            worstwinturn = winturn;
            int score = currentboard.score();
            worstscore = score * turns[winturn];
        }
        currentboard = new Board(gridsize);
    } 
}

Console.WriteLine("{0}, {1}", bestscore, turns[bestwinturn]);
Console.WriteLine(bestscore);
Console.WriteLine("{0}, {1}", worstscore, turns[worstwinturn]);
Console.WriteLine(worstscore);


class Board {
    public Board(int g) {
        gridsize = g;
        board = new int[g,g];
        selected = new Boolean[g,g];
    }

    int gridsize = 5;
    public int lineadded = 0;
    public int[,] board;
    public Boolean[,] selected;


    public void addLine(int[] line) {
        for (int j = 0; j < line.Length; j++) {
            board[lineadded, j] = (line[j]);
        }
        lineadded++;
    } 

    public int calculatewin(int[] turns) {
        for (int t = 0; t < turns.Length; t++) {
            Boolean found = false;
            for (int i = 0; i < gridsize; i++) {
                for (int j = 0; j < gridsize; j++) {
                    if (board[i,j] == turns[t]) {
                        selected[i,j] = true;
                        found = true;
                        if (checkIfWin(i,j)) return t;
                        break;
                    }
                }
                if (found) break;
            }
        }
        return turns.Length+1;
    }

    public Boolean checkIfWin(int i, int j) { 
        Boolean horizwin = true;   
        Boolean vertwin = true;
        for (int k = 0; k < gridsize; k++) {
            if (!selected[i,k]) horizwin = false;
            if (!selected[k,j]) vertwin = false;
            if (!horizwin && !vertwin) return false;
        }
        return true;
    }

    public int score() {
        int score = 0;
        for (int i = 0; i < gridsize; i++) {
            for (int j = 0; j < gridsize; j++) {
                if (!selected[i,j]) score += board[i,j];
            }
        }
        return score;
    }
}