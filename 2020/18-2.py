import pyparsing

def islist(arg):
    return isinstance(arg, pyparsing.ParseResults)

def calc(arg):
    newlist = []
    newlist.append(int(arg[0]))
    cur_oper = ""
    for idx, val in enumerate(arg[1:]):
        if val.isnumeric():
            if cur_oper == "+":
                newlist[-1] = newlist[-1] + int(val)
            elif cur_oper == "*":
                newlist.append("*")
                newlist.append(int(val))
        else:
            cur_oper = val

    result = newlist[0]
    try:
        for val in newlist[1:]:
            if isinstance(val, int):
                if cur_oper == "+":
                    result += int(val)
                elif cur_oper == "*":
                    result *= int(val)
            else:
                cur_oper = val
        return result
    except:
        pass

    return result

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