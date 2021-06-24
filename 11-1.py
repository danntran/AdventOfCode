import copy


def seat_occupy( value ):
    if value == "#":
        return 1
    else:
        return 0

text_file = open("11_input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.rstrip()
    cleaned_list.append(line_str)

nrows = len(cleaned_list[1])
ncols = len(cleaned_list)
new_list = []

print(cleaned_list)

while True:
    new_list = []
    for rowid, rowval in enumerate(cleaned_list):
        new_col = []
        for colid, colval in enumerate(rowval):
            seatocc = 0
            if cleaned_list[rowid][colid] == "L" or cleaned_list[rowid][colid] == "#":
                # check top left
                skipflag = [0,0,0,0,0,0,0,0]
                if rowid - 1 < 0:
                    skipflag[0] = 1
                    skipflag[1] = 1
                    skipflag[2] = 1
                if colid - 1 < 0:
                    skipflag[0] = 1
                    skipflag[3] = 1
                    skipflag[5] = 1
                    
                try:
                    if not skipflag[0]:
                        seatocc += seat_occupy(cleaned_list[rowid-1][colid-1])
                except:
                    pass
                try:
                    if not skipflag[1]:
                        seatocc += seat_occupy(cleaned_list[rowid-1][colid])
                except:
                    pass
                try:
                    if not skipflag[2]:
                        seatocc += seat_occupy(cleaned_list[rowid-1][colid+1])
                except:
                    pass
                try:
                    if not skipflag[3]:
                        seatocc += seat_occupy(cleaned_list[rowid][colid-1])
                except:
                    pass
                try:
                    if not skipflag[4]:
                        seatocc += seat_occupy(cleaned_list[rowid][colid+1])
                except:
                    pass
                try:
                    if not skipflag[5]:
                        seatocc += seat_occupy(cleaned_list[rowid+1][colid-1])
                except:
                    pass
                try:
                    if not skipflag[6]:
                        seatocc += seat_occupy(cleaned_list[rowid+1][colid])
                except:
                    pass
                try:
                    if not skipflag[7]:
                        seatocc += seat_occupy(cleaned_list[rowid+1][colid+1])
                except:
                    pass
                    
                if seatocc >= 4:
                    new_col.append('L')
                elif seatocc == 0:
                    new_col.append('#')
                else:
                    new_col.append(cleaned_list[rowid][colid])
                    
            elif cleaned_list[rowid][colid] == ".":
                new_col.append(".")
            else:
                print("Unexpected input")
                quit()
        new_list.append(new_col)
    print(new_list)
    print()
    if new_list != cleaned_list:
        cleaned_list = copy.deepcopy(new_list)
    else:
        break


print (cleaned_list)

count = 0
for rowid, rowval in enumerate(cleaned_list):
    for colid, colval in enumerate(rowval):
        if cleaned_list[rowid][colid] == "#":
            count += 1
            
print (count)