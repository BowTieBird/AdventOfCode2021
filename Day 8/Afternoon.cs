string[] lines = System.IO.File.ReadAllLines(@"C:\Users\conac\Documents\AdventOfCode2021\Day 8\input.txt");

int[] unique = new int[] {2, 3, 4, 7};

double sum = 0;

for (int i = 0; i < lines.Length; i++) {
    string[] line = lines[i].Split('|');    
    string[] inputs = line[0].Split(' ');

    //            top
    //   topleft        topright
    //           middle
    //   botleft        botright    
    //           bottom

    char top='z', topleft='z', topright='z', middle='z', botleft='z', botright='z', bottom='z';
    string zero="z", one="z", four="z", six="z", seven="z", eight="z", nine="z";
    List<string> sixes = new List<string>();
    for(int j = 0; j < inputs.Length; j++) {
        if (inputs[j].Length == 2) one = inputs[j]; // 1
        if (inputs[j].Length == 4) four = inputs[j]; // 4
        if (inputs[j].Length == 3) seven = inputs[j]; // 7
        if (inputs[j].Length == 7) eight = inputs[j]; // 8
        if (inputs[j].Length == 6) sixes.Add(inputs[j]); // 0, 6, 9
    }

    // STEP 1: top
    for (int k = 0; k < seven.Length; k++) {
        if (!one.Contains(seven[k])) {
            top = seven[k];
            break;
        }
    }

    // STEP 2: topright, botright
    for (int k = 0; k < one.Length; k++) {
        for (int j = 0; j < sixes.Count; j++) {
            if (!sixes[j].Contains(one[k])) {
                six = sixes[j];
                topright = one[k];
                break;
            }
        }
    }
    botright = one[1] == topright ? one[0] : one[1];

    // STEP 3: topleft, middle
    string fournotone = "";
    for (int k = 0; k < four.Length; k++) {
        if (!one.Contains(four[k])) {        
            fournotone += four[k];
            for (int j = 0; j < sixes.Count; j++) {
                if (!sixes[j].Contains(four[k])) {
                    zero = sixes[j];
                    middle = four[k];
                    break;
                }
            }
        }        
    }
    topleft = fournotone[1] == middle ? fournotone[0] : fournotone[1];

    // STEP 4: botleft, bottom
    string eightnotfour = "";
    for (int k = 0; k < eight.Length; k++) {
        if (!four.Contains(eight[k]) && eight[k] != top) {        
            eightnotfour += eight[k];
            for (int j = 0; j < sixes.Count; j++) {
                if (!sixes[j].Contains(eight[k])) {
                    nine = sixes[j];
                    botleft = eight[k];
                }
            }
        }        
    }
    bottom = eightnotfour[1] == botleft ? eightnotfour[0] : eightnotfour[1];

    string[] outputs = line[1].Split(' ');
    string convert = "";
    for (int j = 0; j < outputs.Length; j++) {
        string output = outputs[j];
        if (outputs[j].Length == 2) convert += '1'; 
        else if (outputs[j].Length == 4) convert += '4';
        else if (outputs[j].Length == 3) convert += '7'; 
        else if (outputs[j].Length == 7) convert += '8'; 
        else if (outputs[j].Length == 6) {
            if (!outputs[j].Contains(middle)) convert += '0';
            else if (!outputs[j].Contains(topright)) convert += '6';
            else if (!outputs[j].Contains(botleft)) convert += '9';
            else break;
        } else if (outputs[j].Length == 5) {
            if (outputs[j].Contains(botleft)) convert += '2';
            else if (outputs[j].Contains(topright)) convert += '3';
            else convert += '5';
        }
    }
    Console.WriteLine(convert);
    sum += Convert.ToDouble(convert);
}
Console.WriteLine(sum);


