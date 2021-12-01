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
    # line[0] = first char pos
    # line[1] = second char pos
    # line[2] = character
    # line[3] = matching string
    chr_chk = line[2]
    # check first position
    if line[3][line[0]-1] == line[2]:
        first_char_chk = 1
    else:
        first_char_chk = 0
    # check second position
    if line[3][line[1]-1] == line[2]:
        second_char_chk = 1
    else:
        second_char_chk = 0
    # if they are not the same
    if second_char_chk != first_char_chk:
        nCorrect_PW += 1

print(nCorrect_PW)
