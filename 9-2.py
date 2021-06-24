text_file = open("9-input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    cleaned_list.append(int(line_str))

# print(cleaned_list)

preamble = 0
sumflag = 0

for idx, val in enumerate([cleaned_list[572]]):
    print(idx, val)
    sumflag = 0
    if idx >= preamble:
        for idnum1, num1 in enumerate(cleaned_list[:572-1]):
            sumnum = num1
            maxnum = num1
            minnum = num1
            for idnum2, num2 in enumerate(cleaned_list[idnum1+1:572]):
                sumnum += num2
                if num2 > maxnum:
                    maxnum = num2
                if num2 < minnum:
                    minnum = num2
                print(str(num1) + "+" + str(num2) + "=" + str(sumnum))
                if (val == sumnum):
                    sumflag = 1
                    break
            if (sumflag == 1):
                print( minnum + maxnum )
                break
            
        # print(sumflag)
        if (sumflag == 0):
            print(val)
            break
                    