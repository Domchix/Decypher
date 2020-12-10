import math

def QuickRemainder(x, n, s):
    binary = str(bin(n))[2:]
    binary = binary[::-1]
    rPrev = 0
    rMultProduct = 1

    for i in range(len(binary)):
        remainder = 0
        if i == 0:  
            remainder = x % s
        else:
            remainder = (rPrev * rPrev) % s

        rPrev = remainder
        if binary[i] == "1":
            rMultProduct = (remainder * rMultProduct) % s

    return rMultProduct

if __name__ == "__main__":
    print(QuickRemainder(1712190, 103, 86))
