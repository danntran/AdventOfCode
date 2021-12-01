import re
text_file = open("input(mod).txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    cleaned_list.append(line)

print(len(cleaned_list))
print(cleaned_list)

search_items = []

nvalidPP = 0

for curr_PP in cleaned_list:
    nvalidattr = 0

    match = re.search('.*byr:([12][90][0-9][0-9]) ', curr_PP)
    if match:
        if (1920 <= int(match.group(1)) and int(match.group(1)) <= 2002):
            nvalidattr += 1

    match = re.search('.*iyr:([2][0][12][0-9]) ', curr_PP)
    if match:
        if (2010 <= int(match.group(1)) and int(match.group(1)) <= 2020):
            nvalidattr += 1

    match = re.search('.*eyr:([2][0][23][0-9]) ', curr_PP)
    if match:
        if (2020 <= int(match.group(1)) and int(match.group(1)) <= 2030):
            nvalidattr += 1

    match = re.search('.*hgt:([0-9]+)(cm|in) ', curr_PP)
    if match:
        if match.group(2) == "cm":
            if (150 <= int(match.group(1)) and int(match.group(1)) <= 193):
                nvalidattr += 1
        else:
            if (59 <= int(match.group(1)) and int(match.group(1)) <= 76):
                nvalidattr += 1

    match = re.search('.*hcl:#([0-9a-f]+) ', curr_PP)
    if match:
        nvalidattr += 1

    match = re.search('.*ecl:(amb|blu|brn|gry|grn|hzl|oth) ', curr_PP)
    if match:
        nvalidattr += 1

    match = re.search('.*pid:([0-9]{9}) ', curr_PP)
    if match:
        nvalidattr += 1

    if nvalidattr == 7:
        nvalidPP += 1

print(nvalidPP)

def obtain_attributes(input_string):

    pass
