#!/bin/env python

l = 3000
op = l
i = 0.12
p = 484.31042278198714

c = 0
print("Dur\tPay\t\tInt\t\tPR\t\tOP")
print("0\t-\t\t-\t\t-\t\t{0}".format(l))

while op >= 0:
    I = i * op
    pr = p - I
    op = op - pr
    c= c + 1
    print("{0}\t{1:.5f}\t\t{2:.5f}\t\t{3:.5f}\t\t{4:.5f}".format(c,p,I,pr,op))

