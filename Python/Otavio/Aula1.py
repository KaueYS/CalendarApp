

for i in range(6):
    print(" ")
    for j in range(6):
        print("#", end="")
		
print (" ")



for i in range(0, 6):

    # loop interno para lidar com o número de colunas
    for j in range(0, i + 1):
    
        # número de impressão
        print("#", end="")
    
    # linha final após cada linha
    print("")

print("   ")

def piramide_metade(n):
	
	# número de espaços
	k = n

	# loop externo para lidar com o número de linhas
	for i in range(0, n):
	
		# loop interno para lidar com espaços numéricos
		for j in range(0, k):
			print(end=" ")
	
		# decrementando k após cada loop
		k = k - 1
	
		# loop interno para lidar com o número de colunas
		for j in range(0, i+1):
		
			# impressão de estrelas
			print("#", end="")
	
		# linha final após cada linha
		print("")


piramide_metade(8)






