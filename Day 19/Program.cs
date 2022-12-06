string[] lines = System.IO.File.ReadAllLines(@".\input.txt");

string[] scanners_txt = String.Join('\n', lines).Split("\n\n");
List<List<int[]>> scanners = new List<List<int[]>>();

int N = 3;

List<int[][][]> diffs = new List<int[][][]>();
foreach (string scanner_txt in scanners_txt) {
    List<int[]> scanner = new List<int[]>();
    bool firstLine = true;
    foreach (string line in scanner_txt.Split('\n')) {
        if (firstLine) {
            firstLine = false;
            continue;
        }
        scanner.Add(Array.ConvertAll(line.Split(','), s => Convert.ToInt32(s)));
    }
    scanners.Add(scanner);
    
    int n = scanner.Count;
    int[][][] diff = new int[n][][];
    for (int i = 0; i < n; i++) {
        diff[i] = new int[n][];
        for (int j = 0; j < n; j++) {
            diff[i][j] = new int[N];
            for (int k = 0; k < N; k++) {
                diff[i][j][k] = scanner[j][k] - scanner[i][k]; // Dist from i to j
            }
        }
    }
    diffs.Add(diff);
}

List<int[]> scanner_positions = new List<int[]>();
// for(int i = 0; i < scanners.Count; i++) {
    for(int j = 0; j < scanners.Count; j++) {
        // Calculate relative position of scanners (pos of j from i)
        calculateRelativePositionOfScanners(0, j);
    }
// }

int[] calculateRelativePositionOfScanners(int s1, int s2) {
    int[] relative_pos = new int[N];

    // Try each of 24 rotations:
    // for (int facing = 0; facing < N; facing++) {
    //     foreach (int[] ypos in new int[][] {new int[] {1,2}, new int[] {2,3}}) {
    //         Console.WriteLine(String.Join(',', ypos));
    //     }
    //     break;
    // }
    foreach (int x in new int[] {-1, 1}) {
        foreach (int y in new int[] {-1, 1}) {
            foreach (int z in new int[] {-1, 1}) {
                
            }
        }
    }

    // find 12 overlapping beacons
    return relative_pos;
}