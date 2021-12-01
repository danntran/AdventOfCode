import sys
# if __name__ == '__main__':
#     # Open the file called "inputbits.txt" and store the text into
#     # an array called input_array. Use input_array to 
#     input_txt = open('22.txt','r')
#     input_array = input_txt.read().splitlines()
#     input_txt.close()
#     print(input_array)

#     idx_player2 = input_array.index("Player 2:")
#     # create dictionary
#     my_dict = {}
#     my_dict["1"] = input_array[1:idx_player2-1]
#     my_dict["2"] = input_array[idx_player2+1:]

#     while len(my_dict["1"]) > 0 and len(my_dict["2"]) > 0 :
#         cardval1 = my_dict["1"][0]
#         my_dict["1"].pop(0)
#         cardval2 = my_dict["2"][0]
#         my_dict["2"].pop(0)

#         if  int(cardval1) > int(cardval2) :
#             my_dict["1"].append(cardval1)
#             my_dict["1"].append(cardval2)
#         else:
#             my_dict["2"].append(cardval2)
#             my_dict["2"].append(cardval1)
    
#     if len(my_dict["1"]) > len(my_dict["2"]) :
#         array = my_dict["1"]
#     else:
#         array = my_dict["2"]

#     score_array = []
#     for idx, val in enumerate(array):
#         score_array.append(int(int(val)*(len(array)-idx)))
    
#     print(sum(score_array))

if __name__ == '__main__':
    # Open the file called "inputbits.txt" and store the text into
    # an array called input_array. Use input_array to 
    input_txt = open('22test.txt','r')
    input_array = input_txt.read().splitlines()
    input_txt.close()
    print(input_array)

    idx_player2 = input_array.index("Player 2:")
    # create dictionary
    my_dict = {}
    my_dict["1"] = input_array[1:idx_player2-1]
    my_dict["2"] = input_array[idx_player2+1:]

    while len(my_dict["1"]) > 0 and len(my_dict["2"]) > 0 :
        cardval1 = my_dict["1"][0]
        my_dict["1"].pop(0)
        cardval2 = my_dict["2"][0]
        my_dict["2"].pop(0)

        if  int(cardval1) > int(cardval2) :
            my_dict["1"].append(cardval1)
            my_dict["1"].append(cardval2)
        else:
            my_dict["2"].append(cardval2)
            my_dict["2"].append(cardval1)
    
    if len(my_dict["1"]) > len(my_dict["2"]) :
        array = my_dict["1"]
    else:
        array = my_dict["2"]

    score_array = []
    for idx, val in enumerate(array):
        score_array.append(int(int(val)*(len(array)-idx)))
    
    print(sum(score_array))
    sys.exit()

def game(p1cards, p2cards):
    