inp = [13,0,10,12,1,5,8]
mydict = { 13: 0,
            0: 1,
            10: 2,
            12: 3,
            1:  4,
            5:  5,
            8:  6}

f = open("15.txt", "w")
f.write("13\n0\n10\n12\n1\n5\n8\n")

def first_occ(list, num2match):
    try:
        comp_list = list[:-1]
        occ = len(comp_list) - 1 - comp_list[::-1].index(num2match)
        return (occ)
    except:
        return None

print(first_occ(inp, 100))

startlen = len(inp)

for i in range(startlen-1,2020-1):
    occ = first_occ(inp, inp[-1])
    if occ != None:
        inp.append(i-occ)
    else:
        inp.append(0)

print(inp[-1])

f.close()