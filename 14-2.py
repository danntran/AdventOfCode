import re
NBITS = 36

# Functions
def obt_reg(string):
    return re.search(r'\[(\d+)\]',string)

def obt_value(string):
    return re.search(r'(.*) \= (.*)',string)
    
def det_reg(mask, number, nbits):
    for m in re.finditer('X', mask):
        

data = []
mydict = {}

with open("14-input.txt", "r") as openfile:
    for line in openfile:
        if line[:3] == "mas":
            data.append(["mask",line[7:-1]])
        elif line[:3] == "mem":
            data.append([int(obt_reg(line).group(1)),int(obt_value(line).group(2))])
            mydict[int(obt_reg(line).group(1))] = 0

print(data)



print(mydict)


