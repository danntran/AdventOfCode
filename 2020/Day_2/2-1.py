text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    # split each line
    line_split = line.split()
    # Change numbers 1-3 to 1, 3
    num_array = line_split[0].split("-")
    line_split[0] = int(num_array[0])
    line_split.insert(1,int(num_array[1]))
    # get the letter
    line_split[2] = line_split[2].rstrip(":")
    cleaned_list.append(line_split)

print(cleaned_list)

nCorrect_PW = 0

for line in cleaned_list:
    # line[0] = min number of char
    # line[1] = max number of char
    # line[2] = character
    # line[3] = matching string
    chr_chk = line[2]
    nchr = 0
    for chr_str in line[3]:
        if chr_chk == chr_str:
            nchr += 1
    if (line[0] <= nchr) and (nchr <= line[1]):
        nCorrect_PW += 1

print(nCorrect_PW)
