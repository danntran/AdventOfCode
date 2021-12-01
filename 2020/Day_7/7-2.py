text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    line_str = line_str.split(' contain ')
    line_str[1] = line_str[1].split(', ')
    cleaned_list.append(line_str)

clean_list2 = []
for bag in cleaned_list:
    temp_array = []
    for contain_bag in bag[1]:
        if 'no' in contain_bag:
            temp_bag = contain_bag
        else:
            temp_bag = contain_bag
            
        if '.' in temp_bag:
            temp_bag = temp_bag[:-1]
        temp_array.append(temp_bag)
    clean_list2.append([bag[0][:-1],temp_array])

print(clean_list2)