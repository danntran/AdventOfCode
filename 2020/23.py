import copy
def arrange(position, array):
    func_array = copy.deepcopy(array)
    cur_cup_num = func_array[position]
    picked_cups = [func_array[(position+1)%9], func_array[(position+2)%9], func_array[(position+3)%9]]
    func_array.pop((position+1)%9)
    func_array.pop((position+1)%9)
    func_array.pop((position+1)%9)
    new_array = []
    while 1:
        checkcup = cur_cup_num - 1
        if checkcup < 1:
            checkcup = 9
        if checkcup in func_array:
            idx = func_array.index(checkcup)
            new_array = func_array[:(idx+1)%9] + picked_cups + func_array[(idx+1)%9:]
            break
        else:
            cur_cup_num = checkcup
    return new_array

def rearrange(position, array):
    func_array = copy.deepcopy(array)
    new_array = func_array[position:] + func_array[:position]
    return new_array

if __name__ == '__main__':
    puz_string = "562893147"
    # puz_string = "389125467"
    puz_array = [int(x) for x in puz_string]
    puz_array += list(range(10, 10000000))

    cur_cup = puz_array[0]
    for x in range(100):
        puz_array = arrange(puz_array.index(cur_cup),puz_array)
        # print(puz_array)
        cur_cup = puz_array[(puz_array.index(cur_cup) + 1)%9]
        puz_array = rearrange(puz_array.index(cur_cup),puz_array)
    print(True)

