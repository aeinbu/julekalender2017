
def makeGrid(x, y):
    grid = []
    for i in range(x):
        row = []
        for j in range(y):
            row.append("-")
        grid.append(row)
    return grid



def kalkuler(xKoordinat, yKoordinat):
    return ((yKoordinat**3) + (12 * xKoordinat * yKoordinat) + (5 * yKoordinat * (xKoordinat**2)))

def printGrid(grid):
    for row in grid:
        for elem in row:
            print(elem, end="")
        print()

def countOnes(number):
    binary = str(bin(number))
    num = 0
    for i in range(2, len(binary)):
        if binary[i] == "1":
            num += 1
    return num

def aapenLukket(num):
    if num % 2 == 0:
        return True
    return False

def lukk(xKoordinat, yKoordinat, grid):
    grid[xKoordinat][yKoordinat] = "#"
    
def kalkulerGrid(grid):
    for i in range(len(grid)):
        for j in range(len(grid[0])):
            kalk = kalkuler(i+1, j+1)
            num = countOnes(kalk)
            if not aapenLukket(num):
                lukk(i, j, grid)

                
                

            
grid = makeGrid(20, 20)
            

printGrid(grid)
print()

kalkulerGrid(grid)

printGrid(grid)
    
