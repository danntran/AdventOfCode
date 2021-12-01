def obtainedges(map):
    edge1 = map[0]
    edge2 = edge1[::-1]
    edge3 = map[-1]
    edge4 = edge3[::-1]
    edge5 = ''.join([i[0] for i in map])
    edge6 = edge5[::-1]
    edge7 = ''.join([i[-1] for i in map])
    edge8 = edge7[::-1]
    return ([edge1, edge2, edge3, edge4,edge5,edge6,edge7,edge8])

if __name__ == '__main__':
    # Open the file called "inputbits.txt" and store the text into
    # an array called input_array. Use input_array to 
    input_txt = open('20.txt','r')
    input_array = input_txt.read().splitlines()
    input_txt.close()
    print(input_array)

    # create dictionary
    my_dict = {}
    for idx, val in enumerate(input_array):
        if "Tile" in val:
            key = val
            map = []
            continue
        elif val == "":
            my_dict[key] = map
            continue
        else:
            map.append(val)
    
    new_dict = {}
    for key in my_dict:
        new_dict[key] = obtainedges(my_dict[key])
    
    final_dict = {}
    for key1 in new_dict:
        count = 0
        for key2 in new_dict:
            if key1 != key2:
                if any(e in new_dict[key2] for e in new_dict[key1]):
                    count += 1
        final_dict[key1] = count

    for key in final_dict:
        if final_dict[key] == 2:
            print(key)


    

print(True)


