import random

def miller_rabin(n, k=8):
    if n == 2:
        return True

    if n % 2 == 0:
        return False

    r, s = 0, n - 1
    while s % 2 == 0:
        r += 1
        s //= 2
    for _ in range(k):
        a = random.randrange(2, n - 1)
        x = pow(a, s, n)
        if x == 1 or x == n - 1:
            continue
        for _ in range(r - 1):
            x = pow(x, 2, n)
            if x == n - 1:
                break
        else:
            return False
    return True

def checkNumberIfPrime(n):
    print(f"{n} is likely a prime number: {miller_rabin(n)}")

if __name__ == "__main__":
    checkNumberIfPrime(999983)
    checkNumberIfPrime(1234567891011)
    checkNumberIfPrime(340282366920938463463374607431768211457)
