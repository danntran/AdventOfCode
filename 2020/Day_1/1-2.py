text_file = open("input.txt", "r")
lines = text_file.readlines()
num_array = []
for line in lines:
    num_array.append(int(line.strip()))
print(num_array)
print(len(num_array))
text_file.close()

valid_results = []
for num_1 in num_array:
    for num_2 in num_array:
        for num_3 in num_array:
            result = num_1 + num_2 + num_3
            if result == 2020:
                valid_results.append(num_1)
                valid_results.append(num_2)
                valid_results.append(num_3)
                valid_results.append(num_1*num_2*num_3)

print(valid_results)
