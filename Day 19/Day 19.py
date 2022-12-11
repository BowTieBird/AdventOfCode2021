# import numpy as np

file = open("input.txt")
scanners_txt = ''.join(file.readlines()).split('\n\n')
scanners = [ [ list(map(int, coords.split(','))) for coords in scanner.split('\n')[1:]] for scanner in scanners_txt ]

def getRotations(scanner):
    rotations = [
        lambda x,y,z : [x, y, z],
        lambda x,y,z : [x, z, -y],
        lambda x,y,z : [x, -y, -z],
        lambda x,y,z : [x, -z, y],
        lambda x,y,z : [-x, -y, z],
        lambda x,y,z : [-x, -z, -y],
        lambda x,y,z : [-x, y, -z],
        lambda x,y,z : [-x, z, y],
        lambda x,y,z : [y, z, x],
        lambda x,y,z : [y, x, -z],
        lambda x,y,z : [y, -z, -x],
        lambda x,y,z : [y, -x, z],
        lambda x,y,z : [-y, -z, x],
        lambda x,y,z : [-y, -x, -z],
        lambda x,y,z : [-y, z, -x],
        lambda x,y,z : [-y, x, z],
        lambda x,y,z : [z, x, y],
        lambda x,y,z : [z, y, -x],
        lambda x,y,z : [z, -x, -y],
        lambda x,y,z : [z, -y, x],
        lambda x,y,z : [-z, -x, y],
        lambda x,y,z : [-z, -y, -x],
        lambda x,y,z : [-z, x, -y],
        lambda x,y,z : [-z, y, x]
    ]

    return [[rotation(v[0], v[1], v[2]) for v in scanner] for rotation in rotations]

def getDifferences(scanner):
    return [[[b - a for a,b in zip(beacon1, beacon2)] for beacon2 in scanner] for beacon1 in scanner] # Dist from beacon1 to beacon2

def checkOverlap(beacons1, beacons2):
    for i in range(len(beacons1)):
        for j in range(len(beacons2)):
            # Suppose beacons1[i] is beacons2[j]
            # So relative position of scanner2 from scanner1 is:
            scanner2Position = [ a - b for a,b in zip(beacons1[i], beacons2[j]) ]
            # Positions of beacons from scanner1 perspective:
            beacons2Positions = [[ b + r for b,r in zip(beacon, scanner2Position) ] for beacon in beacons2 ]
            matchingBeacons = [ beacon for beacon in beacons1 if beacon in beacons2Positions ]
            if len(matchingBeacons) >= 12:
                return scanner2Position
    return None

explored = set()
reached = {0}
scannerPositions = [[0,0,0] for _ in scanners]
beaconPositions = { tuple(b) for b in scanners[0] } # relative to scanners[0]
while len(explored) < len(scanners):
    x = reached.pop()
    for y in range(len(scanners)):
        if x == y or y in reached or y in explored: continue
        print(f"Found {len(explored)}/{len(scanners)} scanner positions. Checking pair: {x:2}, {y:2}", end='\r')
        for rotation in getRotations(scanners[y]):
            if (relativePos := checkOverlap(scanners[x], rotation)) is not None:
                scannerPositions[y] = [ a + b for a,b in zip(scannerPositions[x], relativePos) ]
                scanners[y] = rotation # Set the scanner to the rotation aligned with scanners[0]
                beaconPositions = beaconPositions.union({ tuple([ a + b for a,b in zip(beacon, scannerPositions[y])]) for beacon in rotation })
                reached.add(y)
                break
    explored.add(x)

print(sorted(beaconPositions))
print(len(beaconPositions))
print(scannerPositions)
print(max([ sum([ abs(a - b) for a,b in zip(scanner1, scanner2) ]) for scanner1 in scannerPositions for scanner2 in scannerPositions ]))

