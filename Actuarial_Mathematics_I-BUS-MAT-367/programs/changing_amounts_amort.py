#!/bin/env python

l = 2940.6004069748315
op = l
i = 0.19

def get_p(c: int) -> float:
    if c < 5:
        return 600
    elif c < 11:
        return 200
    else:
        return 1500

c = 0
print("Dur\tPay\t\tInt\t\tPR\t\tOP")
print("0\t-\t\t-\t\t-\t\t{0}".format(l))

while op >= 0:
    I = i * op
    pr = get_p(c) - I
    op = op - pr
    c= c + 1
    print("{0}\t{1:.5f}\t\t{2:.5f}\t\t\t{3:.5f}\t\t\t{4:.5f}".format(c,get_p(c-1),I,pr,op))

