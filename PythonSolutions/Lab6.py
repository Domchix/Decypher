import math
import sympy as sp

def GCD(num1, num2):
    divFinder = [[num1, num2, num1 % num2, num1 // num2]]
    n = len(divFinder)

    while divFinder[n-1][2] > 0:
        r = divFinder[n-1][1] % divFinder[n-1][2]
        d = divFinder[n-1][1] // divFinder[n-1][2]
        divFinder.append([divFinder[n-1][1], divFinder[n-1][2], r, d])
        n = len(divFinder)

    gcd = divFinder[n-1][1]
    return gcd, divFinder

def ReverseMod(number, mod):

    gcd, divFinder = GCD(number, mod)
    reverseDivFinder = divFinder[::-1]
    del reverseDivFinder[0]
    if mod % number == 0:
        mod = mod + 1
        gcd, divFinder = GCD(number, mod)
        reverseDivFinder = divFinder[::-1]
        del reverseDivFinder[0]

    n = len(reverseDivFinder)

    formula = ""

    for item in reverseDivFinder:
        temp = ""
        if formula == "":
            temp = " " + str(item[0]) + " - " + str(item[1]) + " * " + str(item[3]) + " "
            formula = temp
        else:
            old = " " + str(item[2]) + " "
            temp = "( " + str(item[0]) + " - " + str(item[1]) + " * " + str(item[3]) + " )"
            formula = formula.replace(old, temp)

    formula = formula.replace(" " + str(reverseDivFinder[n-1][0]) + " ", " x ")
    formula = formula.replace(" " + str(reverseDivFinder[n-1][1]) + " ", " y ")
    x, y = sp.symbols('x,y')
    
    formula = "g = " + formula
    ldict = {'x': sp.symbols('x'), 'y': sp.symbols('y')}
    exec(formula, globals(), ldict)

    g = ldict['g']
    g = str(g).replace(" ", "")

    temp = ""
    A = 0
    for char in str(g):
        if char != "*" and char != "x" and char != "y":
            temp += char
        elif char == "*" or char == "x":
            if temp == "":
                A = 1
            elif temp == "-":
                A = -1
            elif temp[0] == "-":
                A = int(temp[1:]) * -1
            else:
                A = int(temp)
            break

    return A % mod

if __name__ == "__main__":
    mod = 1712190
    number = 59

    result = ReverseMod(number, mod)

    print (f"Greatest common devider: {GCD(number, mod)}")
    print (f"{number}^-1 mod({mod}) = {result}")
