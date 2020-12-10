import math
import random
import textwrap

from Lab6 import ReverseMod, GCD
from Lab7 import QuickRemainder
from Lab10 import PrimeFactors


def checkIfPrime(num):
    if num > 1:
        if num == 2:
            return True
        if num % 2 == 0:
            return False
        i = 3
        while i*i <= num:
            if num % i == 0:
                return False
            i += 2
        return True
    else:
        return False

def generatePQ(e):
    if not checkIfPrime(e):
        print("The given exponent is not a prime number")
        return
    p = 0
    q = 0
    check = 0
    while GCD(e, p*q - p - q + 1)[0] != 1 or p*q < 0b111111111111111:
        p = random.randrange(128, 256, 2)
        q = random.randrange(128, 256, 2)
        p = 227
        p = 239

        if p == q:
            p = 0
            q = 0

        check += 1
    return p, q

def Encrypt(text, e, p = None, q = None):
    if p == None or q == None:
        p, q = generatePQ(e)

    n = p*q
    fi = n - p - q + 1

    d = ReverseMod(e, fi)
    cipher = ""
    encodingLength = 3
    blockLength = len(str(n)) - 1

    print ("viesas raktas = ({}, {})".format(n, e))
    print ("privatus raktas = ({}, {})".format(n, d))

    asciiBlocks = []
    block = ""
    for char in text:
        tempOrd = str(ord(char))
        while len(tempOrd) < encodingLength:
            tempOrd = "0" + tempOrd
        asciiBlocks.append(tempOrd)
    
    asciiText = ''.join(asciiBlocks)[::-1]

    blocks = textwrap.wrap(asciiText, blockLength)
    for i in range(len(blocks)):
        blocks[i] = blocks[i][::-1]
    blocks = blocks[::-1]

    originalBlockLength = blockLength
    blockLength = len(str(n))
    for block in blocks:
        cipherBlock = str(QuickRemainder(int(block), e, n))
        while len(cipherBlock) < blockLength:
            cipherBlock = "0" + cipherBlock
        
        cipher += cipherBlock
    return cipher

if __name__ == "__main__":
    text = "Dominykas Stumbras"
    e = 131
    p = 239
    q = 246
    cipher = Encrypt(text, e, p, q)
    print("Tekstas:", text)
    print("Sifras:", cipher)
