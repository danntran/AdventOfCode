import pyparsing

def islist(arg):
    return isinstance(arg, pyparsing.ParseResults)

def calc(arg):
    total = int(arg[0])
    cur_oper = ""
    for idx, val in enumerate(arg[1:]):
        if val.isnumeric():
            if cur_oper == "+":
                total += int(val)
            elif cur_oper == "*":
                total *= int(val)
        else:
            cur_oper = val
    return total

def remove_nest(arg):
    newlist = [""] * len(arg)
    for idx, val in enumerate(arg):
        if islist(val):
            newlist[idx] = remove_nest(val)
        else:
            newlist[idx] = val
    
    return str(calc(newlist))

mycontent = pyparsing.Word(pyparsing.alphanums) | "+" | "*"
parens = pyparsing.nestedExpr( "(", ")", content=mycontent)

text_file = open('18-input.txt', "r")
f = text_file.read().split('\n')
text_file.close()

results = []

for eqs in f:
    usr_list = parens.parseString("(" + eqs + ")")
    results.append(remove_nest(usr_list[0]))

print(results)

final = 0
for val in results:
    final += int(val)
print(final)