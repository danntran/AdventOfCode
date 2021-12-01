import copy

def check_cell(x, y, z, w, chk_x, chk_y, chk_z, chk_w):
  if(width > x + chk_x >= 0):
      if(width > y + chk_y >= 0):
        if(width > z + chk_z >= 0):
          if(width > w + chk_w >= 0):
            if g[x + chk_x][y + chk_y][z + chk_z][w + chk_w] == '#':
              if (chk_x != 0) or (chk_y != 0) or (chk_z != 0) or (chk_w != 0):
                  return 1
  return 0

text_file = open('17-input.txt', "r")
f = text_file.read().split('\n')
text_file.close()

cycles = 6
width = cycles + len(f[0]) + cycles
box_range = range(width)

g = [[[['.' for x in box_range] for y in box_range] for z in box_range] for w in box_range]

for i_x in range(len(f)):
    for i_y in range(len(f)):
        g[7][7][i_x+cycles][i_y+cycles] = f[i_x][i_y]

for cy in range(6):
    
  nwidth = [x[:] for x in g]
  nwidth = copy.deepcopy(g)

  for x in box_range:
    for y in box_range:
      for z in box_range:
        for w in box_range:
          ct = 0
          for chk_x in [-1,0,1]:
            for chk_y in [-1,0,1]:
              for chk_z in [-1,0,1]:
                for chk_w in [-1,0,1]:
                  ct += check_cell(x,y,z,w,chk_x,chk_y,chk_z,chk_w)
          if g[x][y][z][w] == '#':
            if ct not in [2,3]:
              nwidth[x][y][z][w] = '.'
          if g[x][y][z][w] == '.':
            if ct in [3]:
              nwidth[x][y][z][w] = '#'
  g = copy.deepcopy(nwidth)


ct = 0
for x in box_range:
   for y in box_range:
     for z in box_range:
       for w in box_range:
         if g[x][y][z][w] == '#':
             ct += 1
print ('part 2 -',ct)