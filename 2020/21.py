import copy
if __name__ == '__main__':
    # Open the file called "inputbits.txt" and store the text into
    # an array called input_array. Use input_array to 
    input_txt = open('21.txt','r')
    input_array = input_txt.read().splitlines()
    input_txt.close()
    print(input_array)
    new_array = []
    for val in input_array:
        new_array.append((val.replace(" (contains ",":")).replace(")",""))
    
    my_dict = {}
    for val in new_array:
        idx_semicolon = val.find(":")
        ingred = val[:idx_semicolon].split()
        alleg = val[idx_semicolon+1:]
        if alleg in my_dict:
            intersect = set(my_dict[alleg]).intersection(ingred)
            my_dict[alleg] = list(intersect)
        else:
            my_dict[alleg] = list(ingred)

    new_dict = {}
    while (len(my_dict['sesame']) > 1 or len(my_dict['shellfish']) > 1 or len(my_dict['fish']) > 1 or len(my_dict['nuts']) > 1 or len(my_dict['soy']) > 1 or len(my_dict['dairy']) > 1 or len(my_dict['wheat']) > 1 or len(my_dict['peanuts']) > 1):
        for key1 in my_dict:
            if len(my_dict[key1]) > 1:
                continue
            for key2 in my_dict:
                if key1 != key2:
                    if my_dict[key1][0] in my_dict[key2]:
                        my_dict[key2].remove(my_dict[key1][0])

    input_txt = open('21_og.txt','r')
    input_array = input_txt.read().splitlines()
    input_txt.close()

    string = []
    for line in input_array:
        idx_semicolon = line.find("(")
        string += line[:idx_semicolon].split()
    for key in my_dict:
        new_string = []
        new_string = [i for i in string if i!=my_dict[key][0]]
        string = []
        string = copy.deepcopy(new_string)
    print( len(string))