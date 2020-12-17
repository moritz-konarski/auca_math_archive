# calculator for actuarial mathematics
def s_i(i, t):
    return 1 + i*t

def s_c(i, t):
    return (1+i)**t

def v(i, t):
    return 1 / ((1 + i) ** t)

def x(i, t):
    return 1 / (1 + i*t)

def d_of_i(i):
    return i / (1+i)

def i_of_d(d):
    return d / (1-d)

def v_d(d, t):
    return (1 - d)**t

def a_d(d, t):
    return 1 / (1 - d)**t

def n_i(i, m):
    return (1 + i/m)**m

def c_i(i, m):
    return ((1 + i)**(1/m)-1) * m

def delta(i):
    return log(1+i)

def a_n(i, n):
    return (1 - v(i, n)) / i

def a_n_star(i, n):
    return (1 - v(i, n)) / d_of_i(i)

def s_n(i, n):
    return ( ( 1 + i) ** n - 1 ) / i

def s_n_star(i, n):
    return ( ( 1 + i) ** n - 1 ) / d_of_i(i)

def P(i, r, F, C, n):
    return F * r * a_n(i, n) + C * v(i, n)

def iterate_i(r, F, C, P, n):
    i = 0.5
    for _ in range(100):
        i = (F * r * (1 - v(i, n))) / (P - C * v(i, n))
    return i

def calc_n(i, r, F, C, P):
    return log((P - F * r / i) / (C - F * r / i)) / log(v(i, 1))

def book_value(i, r, F, C, n, t):
    return F * r * a_n(i, n-t) + C * v(i, n-t)
