
mydict = {}

flds = {
    'dep_loc' : [[45,422],[444,950]],
    'dep_stat' : [[36,741],[752,956]],
    'dep_plat' : [[46,788],[806,967]],
    'dep_trk' : [[46,57],[70,950]],
    'dep_date' : [[35,99],[108,974]],
    'dep_time' : [[42,883],[903,962]],
    'arr_loc' : [[47,83],[95,953]],
    'arr_stat' : [[31,227],[240,970]],
    'arr_plat' : [[48,840],[853,964]],
    'arr_trk' : [[49,487],[499,964]],
    'clas' : [[33,363], [381,959]],
    'duration' : [[35,509], [522,951]],
    'price': [[38,590] , [601,950]],
    'route': [[41,266] , [285,962]],
    'row': [[44,402] , [419,962]],
    'seat': [[41,615] , [634,956]],
    'train': [[47,156] , [178,954]],
    'typ': [[44,313 ], [338,964]],
    'wagon': [[30,110], [133,970]],
    'zone': [[38,541] , [550,965]]
}

for field in flds:
    for rang in flds[field]:
        for i in range(rang[0],rang[1]):
            mydict[i] = 0

# print (mydict)

data = []
with open("16-inputmod.txt", "r") as openfile:
    for line in openfile:
        nl = line.rstrip().split(',')
        array = []
        for val in nl:
            array.append(int(val))
        data.append(array)

# print(data)

rejected = []
valid = []
for idx, tic in enumerate(data):
    for num in tic:
        try:
            if mydict[num] == 0:
                pass
        except:
            rejected.append(num)
            break
    else:
        valid.append(tic)

print(sum(rejected))

