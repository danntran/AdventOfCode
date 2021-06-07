text_file = open("input.txt", "r")
lines = text_file.readlines()
text_file.close()

cleaned_list = []
for line in lines:
    # remove newline
    line_str = line.strip()
    cleaned_list.append(line_str)

# cleaned_list = ["BFFFBBFRRR", "FFFBBBFRRR", 'BBFFBBFRLL']

# print(cleaned_list)

seat_ids = []

for ticket in cleaned_list:
    rows = list(range(128))
    cols = list(range(8))
    for rowcol in ticket:
        # print(rowcol)
        if rowcol == "F":
            del rows[int(len(rows)/2):]
        elif rowcol == "B":
            del rows[:int(len(rows)/2)]
        elif rowcol == "L":
            del cols[int(len(cols)/2):]
        elif rowcol == "R":
            del cols[:int(len(cols)/2)]
        # print(rows,cols)
    seat_ids.append(rows[0]*8+cols[0])

seat_ids.sort()
# print(seat_ids)

check = list(range(12,872,1))
for check_seat in check:
    if check_seat in seat_ids:
        continue
    else:
        print(check_seat)
        break
