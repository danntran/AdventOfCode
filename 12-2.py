def rotate( cur_points, rotation_dir, rotation_deg ):
    if rotation_dir == "L":
        if rotation_deg == 90:
            return [(-1 * cur_points[1]), (cur_points[0])]
        elif rotation_deg == 270:
            return [(cur_points[1]), (-1 * cur_points[0])]
    if rotation_dir == "R":
        if rotation_deg == 90:
            return [(cur_points[1]), (-1 * cur_points[0])]
        elif rotation_deg == 270:
            return [(-1 * cur_points[1]), (cur_points[0])]
    if rotation_deg == 180:
            return [(-1 * cur_points[0]), (-1 * cur_points[1])]
            
def move_waypoint( cur_points, cmd, value ):
    if cmd == "N":
        return [cur_points[0], cur_points[1]+value]
    elif cmd == "S":
        return [cur_points[0], cur_points[1]-value]
    elif cmd == "E":
        return [cur_points[0]+value, cur_points[1]]
    elif cmd == "W":
        return [cur_points[0]-value, cur_points[1]]
        
def move_ship( ship_pos, waypoint_pos, value ):
    return [ship_pos[0] + (waypoint_pos[0] * value), ship_pos[1] + (waypoint_pos[1] * value)]


text_file = open("12-input.txt", "r")
lines = text_file.readlines()
text_file.close()

data = []
for line in lines:
    # remove newline
    line_str = line.strip()
    data.append([line_str[0], int(line_str[1:])])

# print(data)

waypoint_coord = [10, 1]
boat_coord = [0, 0]

for cmd in data:
    if cmd[0] == "N" or cmd[0] == "S" or cmd[0] == "W" or cmd[0] == "E":
        ans = move_waypoint(waypoint_coord, cmd[0], cmd[1])
        waypoint_coord[0] = ans[0]
        waypoint_coord[1] = ans[1]
    elif cmd[0] == "L" or cmd[0] == "R":
        ans = rotate(waypoint_coord, cmd[0], cmd[1])
        waypoint_coord[0] = ans[0]
        waypoint_coord[1] = ans[1]
    elif cmd[0] == "F":
        answer = move_ship(boat_coord, waypoint_coord, cmd[1])
        boat_coord[0] = answer[0]
        boat_coord[1] = answer[1]

print( abs(boat_coord[0])+abs(boat_coord[1]))