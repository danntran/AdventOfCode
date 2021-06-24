text_file = open("10-input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    cleaned_list.append(int(line_str))

print(cleaned_list)

cur_jolts = 0

for idx, val in enumerate(cleaned_list):
    for jolts in cleaned_list:
        jolts 