MAX_HORIZ = 31
MAX_VERT = 323


text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    cleaned_list.append(line_str)

print(cleaned_list)
print(len(cleaned_list))
print(len(cleaned_list[0]))

ntrees_list = []

current_xpos = 0
ntrees = 0
X_INC = 1
Y_INC = 1
for index, row in enumerate(cleaned_list):
    if index % Y_INC == 0:
        if row[current_xpos] == '#':
            ntrees += 1
        current_xpos = (current_xpos + X_INC) % MAX_HORIZ
ntrees_list.append(ntrees)

current_xpos = 0
ntrees = 0
X_INC = 3
Y_INC = 1
for index, row in enumerate(cleaned_list):
    if index % Y_INC == 0:
        if row[current_xpos] == '#':
            ntrees += 1
        current_xpos = (current_xpos + X_INC) % MAX_HORIZ
ntrees_list.append(ntrees)

current_xpos = 0
ntrees = 0
X_INC = 5
Y_INC = 1
for index, row in enumerate(cleaned_list):
    if index % Y_INC == 0:
        if row[current_xpos] == '#':
            ntrees += 1
        current_xpos = (current_xpos + X_INC) % MAX_HORIZ
ntrees_list.append(ntrees)

current_xpos = 0
ntrees = 0
X_INC = 7
Y_INC = 1
for index, row in enumerate(cleaned_list):
    if index % Y_INC == 0:
        if row[current_xpos] == '#':
            ntrees += 1
        current_xpos = (current_xpos + X_INC) % MAX_HORIZ
ntrees_list.append(ntrees)

current_xpos = 0
ntrees = 0
X_INC = 1
Y_INC = 2
for index, row in enumerate(cleaned_list):
    if index % Y_INC == 0:
        if row[current_xpos] == '#':
            ntrees += 1
        current_xpos = (current_xpos + X_INC) % MAX_HORIZ
ntrees_list.append(ntrees)

print(ntrees_list)
result = 1;
for answer in ntrees_list:
    result = result * answer

print(result)
