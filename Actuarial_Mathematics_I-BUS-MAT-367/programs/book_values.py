#!/bin/env python

# outstanding
book = 8677.94547488199
# redemption
redemption = 6000
face = redemption
# yield
i = 0.03
# interest
r = 0.06

inter = 0

c = 0
print("Dur   Coupon        Int            PA           BV")
print("{0:3d} {1:12.5f}  {2:12.5f}  {3:12.5f}  {4:12.5f}".format(c,0,0,0, book))

if book > redemption:
    while book > redemption:
        interest = book * i
        inter += interest
        coupon = face * r
        book = book + interest - coupon
        c = c + 1
        print("{0:3d} {1:12.5f}  {2:12.5f}  {3:12.5f}  {4:12.5f}"\
                .format(c, coupon, interest, coupon - interest, book))
else:
    while book < redemption:
        interest = book * i
        inter += interest
        coupon = face * r
        book = book + interest - coupon
        c = c + 1
        print("{0:3d} {1:12.5f}  {2:12.5f}  {3:12.5f}  {4:12.5f}"\
                .format(c, coupon, interest, coupon - interest, book))

print(inter)
