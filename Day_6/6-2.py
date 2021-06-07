text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    cleaned_list.append(line_str)

cleaned_list.append("")

print(cleaned_list)

unique_questions = []
members_in_group = []
master_list = []
question_list = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']

for person in cleaned_list:
    if person == "":
        total_q_group = 0

        for q_num in question_list:
            # print(q_num)
            in_list = 1
            for mem in members_in_group:
                if q_num not in mem:
                    in_list = 0
                    break
            total_q_group += in_list
        master_list.append(total_q_group)
        members_in_group = []
    else:
        members_in_group.append(person)

print(master_list)
print(sum(master_list))
