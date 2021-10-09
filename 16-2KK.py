f = open('20-16.txt').read().split('\n\n')
s = f[0].split('\n')
v = []

# Alot of mucking around, but got there in the end
# not my tidiest work

v1 = {}
for r in range(len(s)):
    h = s[r].split()
    l = len(h)
    g = s[r].split()[l-3].split('-')    
    for i in range(int(g[0]),int(g[1])+1):        
        v1[i] = True
    g = s[r].split()[l-1].split('-')
    for i in range(int(g[0]),int(g[1])+1):
        v1[i] = True
ty, ct = 0,0
ct = 0
gdn = []
for h in f[2].split('\n')[1:]:
    gd = True
    for n in h.split(','):
        nn = int(n)
        if nn not in v1.keys(): 
            ty += nn
            gd = False
    if gd:
        gdn.append(ct)
    ct += 1
print('part 1 -',ty)
v = []
for r in range(len(s)):
    h = s[r].split()
    l = len(h)
    g = s[r].split()[l-3].split('-')
    vp = []
    for i in range(int(g[0]),int(g[1])+1):
        vp.append(i)
    g = s[r].split()[l-1].split('-')
    for i in range(int(g[0]),int(g[1])+1):
        vp.append(i)
    v.append(vp)
ty = 0
s = f[1].split('\n')
for r in range(len(s[1:])):
    yt = [int(x) for x in s[1:][r].split(',')]
s = f[2].split('\n')
t = []
for r in range(len(s[1:])):
    j = s[1:][r].split(',')
    if r in gdn:
        t.append([int(x) for x in j])
g = {-1}
gm = []
w = {}
for rf in range(len(v)):
  c = v[rf][:]
  g = {-1}
  for j in range(len(t[0])):        
    gd = True
    for tk in range(len(t)):
       if t[tk][j] not in c:
         gd = False
    if gd:
        g.add(j)
  g.remove(-1)
  tr = []
  for x in g:
      tr.append(x)
  gm.append(tr)
sv = []
rm = 0
for ui in range(len(gm)):
  for it in range(len(gm)):
    if len(gm[it]) == 1:
       sv.append([it,gm[it][0]])
       rm = gm[it][0]
  ngm = []
  for ghh in range(len(gm)):
      addr = []
      for bt in range(len(gm[ghh])):        
            if gm[ghh][bt] != rm:
                 addr.append(gm[ghh][bt])
      ngm.append(addr[:])
  gm = ngm
mult = 1
for ct in [0,1,2,3,4,5]:
    for ref in range(len(sv)):
      if sv[ref][0] == ct:
        mult *= yt[sv[ref][1]]
print('part 2 -',mult)