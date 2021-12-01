import copy

text_file = open("13-input.txt", "r")
lines = text_file.readlines()
text_file.close()

number = int(lines[0].rstrip())

print(number)
cleaned_list = lines[1].rstrip()


data = cleaned_list.split(",")
newlist = []
for count,val in enumerate(data):
    if val != 'x':
        newlist.append(int(val))

print(newlist)

for count,val in enumerate(list(range(number,number*2))):
    for div in newlist:
        if val%div == 0:
            break
    else:
        continue
    
    break

print(count, val, count*div)