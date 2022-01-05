string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 21\input.txt");
int maxspace = 10;
int player1space = Convert.ToInt32(lines[0].Split(':')[1]);
int player2space = Convert.ToInt32(lines[1].Split(':')[1]);

int[] dieresults = {3, 4, 5, 6, 7, 8, 9}; 
int[] diedistrib = {1, 3, 6, 7, 6, 3, 1};

long player1wincount = 0;
long player2wincount = 0;
int scoretowin = 21;
Stack<Universe> universes = new Stack<Universe>();
universes.Push(new Universe(player1space, player2space, 0, 0, 1));
while(universes.Count > 0) {
    Universe u = universes.Pop();
    // Console.WriteLine("u: {0}, {1}, {2}, {3}, {4}", u.universecount, u.player1space, u.player2space, u.player1score, u.player2score);

    for (int i = 0; i < dieresults.Length; i++) {
        int newspace1 = (u.player1space  + dieresults[i] - 1) % maxspace + 1;
        int newscore1 = u.player1score + newspace1;
        long universecount1 = u.universecount * diedistrib[i];
        if (newscore1 >= scoretowin) {
            player1wincount += universecount1;
        } else {
            for (int j = 0; j < dieresults.Length; j++) {
                int newspace2 = (u.player2space  + dieresults[j] - 1) % maxspace + 1;
                int newscore2 = u.player2score + newspace2;
                long universecount2 = universecount1 * diedistrib[j];
                if (newscore2 >= scoretowin) {
                    player2wincount += universecount2;
                } else {
                    universes.Push(new Universe(
                        newspace1,
                        newspace2,
                        newscore1,
                        newscore2,
                        universecount2));
                }
            }
        }
    }
}

Console.WriteLine(player1wincount);
Console.WriteLine(player2wincount);

class Universe { 
    public long universecount = 1;
    public int player1space, player2space, player1score, player2score;
    public Universe(int sp1, int sp2, int sc1, int sc2, long u) {
        player1space = sp1;
        player2space = sp2;            
        player1score = sc1;
        player2score = sc2;
        universecount = u;
    }
}