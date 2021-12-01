import copy

text_file = open("13-input.txt", "r")
lines = text_file.readlines()
text_file.close()

data = lines[1].rstrip().split(",")

newlist = []
for count,val in enumerate(data):
    if val != 'x':
        newlist.append([count,int(val)])

print(newlist)

val = 1
skip = 1
cur_num = -1

while True:
    for div in newlist:
        if (val+div[0])%div[1] == 0:
            if cur_num < div[0]:              
                cur_num = div[0]
                skip *= div[1] 
                print(val, cur_num, div[1])
            continue
        else:
            break
    else:
        break
    
    val += skip
    continue
    
print(val)
