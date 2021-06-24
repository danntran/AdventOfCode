import copy

def moveboat( command, currentpos ):
    
    coorddict = {
        "N": 0,
        "E": 90,
        "S": 180,
        "W": 270
    }

    newPOS = currentpos[0]
    newEW = currentpos[1]
    newNS = currentpos[2]
    
    if command[0] == "N":
        newNS = currentpos[2] + command[1]
    elif command[0] == "S":
        newNS = currentpos[2] - command[1]
    elif command[0] == "E":
        newEW = currentpos[1] + command[1]
    elif command[0] == "W":
        newEW = currentpos[1] - command[1]
    elif command[0] == "L":
        newPOS = list(coorddict.keys())[list(coorddict.values()).index((coorddict[currentpos[0]] - command[1])%360 )]
    elif command[0] == "R":
        newPOS = list(coorddict.keys())[list(coorddict.values()).index((coorddict[currentpos[0]] + command[1])%360 )]
    elif command[0] == "F":
        if currentpos[0] == "N":
            newNS = currentpos[2] + command[1]
        elif currentpos[0] == "S":
            newNS = currentpos[2] - command[1]
        elif currentpos[0] == "E":
            newEW = currentpos[1] + command[1]
        elif currentpos[0] == "W":
            newEW = currentpos[1] - command[1]
        else:
            print(command, currentpos)
            print("error")
            return False
    else:
        print("error")
        return False
    return [newPOS, newEW, newNS]
        

text_file = open("12_input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.rstrip()
    coord = [line_str[0], int(line_str[1:])]
    cleaned_list.append(coord)

# boat info, 0 = direction, 1 = east/west, 2 = north south
boat_info = ["E", 0, 0]

for command in cleaned_list:
    boat_info = moveboat(command, boat_info)

print(cleaned_list)
print(boat_info)
print("ANS: ", abs(boat_info[1]) + abs(boat_info[2]))