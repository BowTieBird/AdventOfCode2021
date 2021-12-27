string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\Advent Of Code\Day 2\input.txt");

static long Clamp(long value, long min, long max) {
    return (value < min) ? min : (value > max) ? max : value;
}

long oncount = 0;
long intersectioncount = 0;

List<Block> blocks = new List<Block>();
for (int i = 0; i < lines.Length; i++) {    
    string[] line = lines[i].Split(' ', ',');
    Boolean isOn = line[0] == "on";
    long[] minima = new long[3];
    long[] maxima = new long[3];
    for (long d = 0; d < 3; d++) {
        string s = line[d+1];
        minima[d] = Convert.ToInt64(s.Substring(s.IndexOf('=')+1, s.IndexOf('.')-2));
        maxima[d] = Convert.ToInt64(s.Substring(s.LastIndexOf('.')+1));
    }
    int sign = isOn ? +1 : -1;
    
 
    int maxj = blocks.Count;
    for(int j = 0; j < maxj; j++) {
        // Check intersect
        long[] otherminima = blocks[j].minima;
        long[] othermaxima = blocks[j].maxima;
        Boolean intersect = true;
        long[] intminima = new long[3];
        long[] intmaxima = new long[3];
        for (int d = 0; d < 3; d++) {
            if (othermaxima[d] >= minima[d] &&  otherminima[d] <= maxima[d]) {
                intminima[d] = Clamp(otherminima[d], minima[d], maxima[d]);
                intmaxima[d] = Clamp(othermaxima[d], minima[d], maxima[d]);
            } else {
                intersect = false;
                break;
            }
        }        
        if (intersect) {
            int othersign = blocks[j].sign;
            int intsign = othersign == sign ? -sign : sign;
            Block intBlock = new Block(intsign, intminima, intmaxima);
            blocks.Add(intBlock);
            oncount += intsign * intBlock.volume();
            intersectioncount++;
        }
    }
    
    if (isOn) {  
        Block newBlock = new Block(sign, minima, maxima);
        oncount += sign * newBlock.volume();
        blocks.Add(newBlock);
    }
}

Console.WriteLine(oncount);
Console.WriteLine(intersectioncount);

class Block {
    public Block(int s, long[] m1, long[] m2) {
        sign = s;
        minima = m1;
        maxima = m2;
    }

    public long volume() {
        long v = 1;
        for(long d = 0; d < 3; d++) {
            v *= maxima[d] - minima[d] + 1;
        }
        return v;
    }

    public int sign = +1;
    public long[] minima;
    public long[] maxima;
}