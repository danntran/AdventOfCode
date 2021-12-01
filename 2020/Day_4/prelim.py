text_file = open("input.txt", "r")
text_file_mod = open("input(mod).txt","w")
for line in text_file:
    if line != "\n":
        text_file_mod.write(line.strip())
        text_file_mod.write(" ")
    else:
        text_file_mod.write(line)

text_file.close()
text_file_mod.close()
