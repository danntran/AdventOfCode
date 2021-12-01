import copy

def check_cell(x,y,z,v,w,u):
    if(width>x+v>=0):
       if(width>y+w>=0):
         if(width>z+u>=0):
            if g[x+v][y+w][z+u] == '#':
                if (v!=0) or (u!=0) or (w!=0):
                    return 1
    return 0

text_file = open('17-input.txt', "r")
f = text_file.read().split('\n')
text_file.close()

cycles = 6
width = cycles + len(f[0]) + cycles
box_range = range(width)

g = [[['.' for x in box_range] for y in box_range] for z in box_range]

for i in range(len(f)):
    for w in range(len(f)):
        g[9][i+cycles][w+cycles] = f[i][w]

for cy in range(6):
    
  nwidth = [x[:] for x in g]
  nwidth = copy.deepcopy(g)

  for x in box_range:
    for y in box_range:
      for z in box_range:
        ct = 0
        for v in [-1,0,1]:
         for w in [-1,0,1]:
          for u in [-1,0,1]:
           ct += check_cell(x,y,z,v,w,u)
        if g[x][y][z] == '#':
           if ct not in [2,3]:
            nwidth[x][y][z] = '.'
        if g[x][y][z] == '.':
           if ct in [3]:
            nwidth[x][y][z] = '#'
  g = copy.deepcopy(nwidth)


ct = 0
for x in box_range:
   for y in box_range:
     for z in box_range:
         if g[x][y][z] == '#':
             ct += 1
print ('part 1 -',ct)
