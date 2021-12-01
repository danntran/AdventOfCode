import re
NBITS = 36

# Functions
def obt_reg(string):
    return re.search(r'\[(\d+)\]',string)

def obt_value(string):
    return re.search(r'(.*) \= (.*)',string)

def app_mask( mask, reg, nbits ):
    result = []
    bstrreg = ("{0:0"+ str(NBITS) + "b}").format(reg)
    for i in range(0,nbits):
        if mask[i] == "X":
            result.append("X")
        elif mask[i] == "1":
            result.append("1")
        elif mask[i] == "0":
            result.append(bstrreg[i])
    return result
    
def det_reg(mask, reg, iter, nbits):
    newMask = app_mask(mask, reg, NBITS)
    bNum = ("{0:0"+ str(nbits) + "b}").format(iter)
    for idx, m in enumerate(re.finditer('X', mask)):
        newMask[m.start()] = bNum[idx]
    return int(("".join(newMask)),2)

def count_x(mask):
    count = 0
    for c in mask:
        if c == "X":
            count += 1
    return count
        

data = []
mydict = {}

with open("14-input.txt", "r") as openfile:
    for line in openfile:
        if line[:3] == "mas":
            data.append(["mask",line[7:-1]])
        elif line[:3] == "mem":
            data.append([int(obt_reg(line).group(1)),int(obt_value(line).group(2))])
            mydict[int(obt_reg(line).group(1))] = 0

cur_mask = 0
cur_nbits = 0
for cmd in data:
    if cmd[0] == "mask":
        cur_mask = cmd[1]
        cur_nbits = count_x(cmd[1])
    else:
        for i in range(0, 2**cur_nbits):
            newreg = det_reg(cur_mask,cmd[0],i,cur_nbits)
            mydict[newreg] = cmd[1]

total = 0

for key in mydict:
    total += mydict[key]

print(total)


