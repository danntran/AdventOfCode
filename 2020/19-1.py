def replace_num(list, dict):
    pass

text_file = open('19-input.txt', "r")
f = text_file.read().split('\n')
text_file.close()

mydict = {}
for rule in f:
    colind = rule.find(":")
    mydict[int(rule[:colind])] = rule[colind+2:].replace("\"", "").split(" ")

newdict = {}
for rule in mydict:
    if len(mydict[rule])>1:
        newlist = []
        for num in mydict[rule]:
            if num == "|":
                newlist.append("|")
                continue
            newlist.append(int(num))
        newdict[rule] = newlist
    else:
        newdict[rule] = mydict[rule]

print("end")