/*/string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 21\input.txt");
int maxspace = 10;
int player1space = Convert.ToInt32(lines[0].Split(':')[1]);
int player2space = Convert.ToInt32(lines[1].Split(':')[1]);

int maxdie = 100;
int die = 0;
int rolls = 0;

int player1score = 0;
int player2score = 0;

while (player1score < 1000 && player2score < 1000) {
    int movement1 = 0;
    for (int i = 0; i < 3; i++) movement1 += rolldie();
    player1space = (player1space + movement1 - 1) % maxspace + 1;
    player1score += player1space;

    if (player1score < 1000) {
        int movement2 = 0;
        for (int i = 0; i < 3; i++) movement2 += rolldie();
        player2space = (player2space + movement2 - 1) % maxspace + 1;
        player2score += player2space;
    }
}

if (player1score >= 1000) Console.WriteLine(rolls * player2score);
else if (player2score >= 1000) Console.WriteLine(rolls * player1score);

int rolldie() {
    die = (die % maxdie) + 1;
    rolls++;
    return die;
}
/*/