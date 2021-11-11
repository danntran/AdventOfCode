if __name__ == '__main__':
    # Open the file called "inputbits.txt" and store the text into
    # an array called input_array. Use input_array to 
    input_txt = open('19test.txt','r')
    input_array = input_txt.read().splitlines()
    input_txt.close()
    print(input_array)

    # create dictionary
    my_dict = {}
    for idx, val in enumerate(input_array):
        idx_semicolon = val.find(":")
        my_dict[(val[:idx_semicolon]).strip()] = (val[idx_semicolon + 1:]).strip()

print(True)