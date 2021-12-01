inp = [13,0,10,12,1,5,8]
mydict = { 13: 0,
            0: 1,
            10: 2,
            12: 3,
            1:  4,
            5:  5}

def first_occ(mydict, array, num2match):
    try:
        occ = mydict[num2match]
        return occ
    except:
        return None

startlen = len(inp)

lastnum = inp[-1]

for i in range(startlen-1,30000000-1):
    occ = first_occ(mydict, inp, inp[-1])
    mydict[inp[-1]]=i
    if occ != None:
        inp.append(i-occ)
    else:
        inp.append(0)

print(inp[-1])