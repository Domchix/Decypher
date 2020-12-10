import math
from itertools import combinations as comb

from Lab6 import GCD

def PrimeFactors(n):
    i = 2
    factors = []
    while i * i <= n:
        if n % i:
            i += 1
        else:
            n //= i
            factors.append(i)
    if n > 1:
        factors.append(n)
    return factors

def PossibleExponents(value1):
    possibleCipherExponents = []
    n = value1

    possibleDivisorPairs = PrimeFactors(n)
    fi = n - possibleDivisorPairs[0] - possibleDivisorPairs[1] + 1
    for i in range(2, fi + 1):
        if GCD(i, fi)[0] == 1:
            possibleCipherExponents.append(i)

    return possibleCipherExponents

def getExponents(n):
    exponents = PossibleExponents(n)
    print(f"Number of possible exponents for {n}: {len(exponents)}")
    print(f"Possible exponents: {exponents}")
    print()

if __name__ == "__main__":
    getExponents(221)
    getExponents(299)
    getExponents(323)
    getExponents(391)
    getExponents(667)
