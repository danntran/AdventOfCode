import re
NBITS = 36

# Functions
def obt_reg(string):
    return re.search(r'\[(\d+)\]',string)

def obt_value(string):
    return re.search(r'(.*) \= (.*)',string)

def app_mask( mask, val, nbits ):
    result = 0
    for i in range(0,nbits):
        if mask[i] == "X":
            result += (val & (1<<(nbits-1-i)))
        elif mask[i] == "1":
            result = result | (1<<(nbits-1-i))
        elif mask[i] == "0":
            result = result & ~(1<<(nbits-1-i))
    return result

data = []
mydict = {}

with open("14-input.txt", "r") as openfile:
    for line in openfile:
        if line[:3] == "mas":
            data.append(["mask",line[7:-1]])
        elif line[:3] == "mem":
            data.append([int(obt_reg(line).group(1)),int(obt_value(line).group(2))])
            mydict[int(obt_reg(line).group(1))] = 0
           

cur_mask = ""

for cmd in data:
    if cmd[0] == "mask":
        cur_mask = cmd[1]
    else:
        mydict[cmd[0]] = app_mask(cur_mask,cmd[1],NBITS)

print(mydict)

total = 0

for key in mydict:
    total += mydict[key]
    
print(total)
