import copy
text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()


def execute_cmd(cmd, nline, acc):
    if cmd[0] == "nop":
        return [(nline + 1), acc]
    elif cmd[0] == "acc":
        return [(nline + 1), (acc + int(cmd[1]))]
    elif cmd[0] == "jmp":
        newline = int(nline) + int(cmd[1])
        return [newline, acc]
    else:
        return -1

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip().split(' ')
    cleaned_list.append([line_str[0], int(line_str[1]), 0])

print(cleaned_list)

maxlines = len(cleaned_list)

for x in range(maxlines):

    print ("******* " + str(x) + " ************")
    cleaned_list_under_test = []
    cleaned_list_under_test = copy.deepcopy(cleaned_list)
    # print (og_cleaned_list[0])
    # print (cleaned_list_under_test[x][0])
    if cleaned_list_under_test[x][0] == 'nop':
        cleaned_list_under_test[x][0] = 'jmp'
    elif cleaned_list_under_test[x][0] == 'jmp':
        cleaned_list_under_test[x][0] = 'nop'

    cur_cmd_line = 0
    acc = 0

    while True:
        
        print( str(cur_cmd_line) + " | " + str(cleaned_list_under_test[cur_cmd_line]) + ' | ' + str(acc) )
        test = cleaned_list_under_test[cur_cmd_line]
        # print(test)
        if test[2] == 1:
            print("Executed code twice")
            break
        result = execute_cmd(cleaned_list_under_test[cur_cmd_line], cur_cmd_line, acc)
        # print(result)
        cleaned_list_under_test[cur_cmd_line][2] = 1
        cur_cmd_line = result[0]
        acc = result[1]
