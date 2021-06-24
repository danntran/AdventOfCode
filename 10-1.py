text_file = open("10_input.txt", "r")
lines = text_file.readlines()
text_file.close()

lines = list(map(int, lines))

lines.sort()
lines.insert(0, 0)
lines.append(lines[-1]+3)

print (lines)

difs_1 = 0
difs_2 = 0
difs_3 = 0

for i in range(1, len(lines)):
    dif = lines[i] - lines[i-1] 
    if dif == 1:
        difs_1 += 1
    elif dif == 2:
        difs_2 += 1
    elif dif == 3:
        difs_3 += 1
    else:
        print("Error")

print("1 dif = ", difs_1)
print("3 dif = ", difs_3)
print("multiply ", difs_1*difs_3)