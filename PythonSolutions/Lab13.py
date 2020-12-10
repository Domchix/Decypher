from math import sqrt

from Lab6 import ReverseMod
from Lab7 import QuickRemainder

def bruteForce(g, gxmod, n):
    gj = 0
    j = 1
    while gj != gxmod:
        j += 1
        gj = QuickRemainder(g, j, n)
    return j

def crackDH(g, n, gb, ga):
    modbga = 0

    if (gb < ga):
        modbg = gb % n
        b = bruteForce(g, modbg, n)
        modbga = QuickRemainder(ga % n, b, n)
    else:
        gamod = ga % n
        a = bruteForce(g, gamod, n)
        modbga = QuickRemainder(gb % n, a, n)

    return modbga

if __name__ == "__main__":
    g = 5
    n = 131071
    gb = 19073486328125
    ga = 6103515625
    print(crackDH(g, n, gb, ga))


