#!/bin/env python

l = 1000
op = l
i = 0.16

def get_p(c: int, op: float) -> float:
    if op > 200: 
        return 200
    else: 
        return op * (1+i)

c = 0
print("Dur\tPay\t\tInt\t\tPR\t\tOP")
print("0\t-\t\t-\t\t-\t\t{0}".format(l))

while op > 0:
    I = i * op
    pr = get_p(c, op) - I
    op = op - pr
    c= c + 1
    print("{0}\t{1:.5f}\t\t{2:.5f}\t\t{3:.5f}\t\t{4:.5f}".format(c, get_p(c-1,
        op+pr), I, pr,
        op))

