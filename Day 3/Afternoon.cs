string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 3\input.txt");

int o = Convert.ToInt32(matched(true), 2);
int c = Convert.ToInt32(matched(false), 2);
Console.WriteLine(o*c);

string matched(Boolean mostcommon) {
    int l = lines[0].Length;
    string matching = ""; 
    string matched = "";

    for (int j = 0; j <= l; j++) {
        int zerocount = 0;
        int onecount = 0;
        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].Substring(0,j) == matching) {
                matched = lines[i];
                if (j < l) {
                    if(lines[i][j] == '0') {
                        zerocount++;
                    } else onecount++;
                }
            }
        }

        if (j < l) {
            matching += zerocount > onecount ^ mostcommon ? '1' : '0';
            if (zerocount + onecount == 1) return matched; 
        }      
    }
    return matched;
}