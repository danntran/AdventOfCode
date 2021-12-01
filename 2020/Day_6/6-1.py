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
master_list = []

for person in cleaned_list:
    if person == "":
        master_list.append(len(unique_questions))
        unique_questions = []
    else:
        for yes2question in person:
            # print(yes2question)
            if yes2question not in unique_questions:
                unique_questions.append(yes2question)

print(master_list)
print(sum(master_list))
