# calculator for actuarial mathematics

# https://docs.julialang.org/en/v1/manual/documentation/

"""
Find the simple interest of `i` and `t`
"""
s_i(i, t) = 1 + i*t


"""
Find compound interest of `i` and `t`
"""
s_c(i, t) = (1+i)^t


"""
Present value `v` based on `i` and `t`
"""
v(i, t) = 1 / ((1 + i) ^ t)


"""
Present value `x` based on `i` and `t`
"""
x(i, t) = 1 / (1 + i*t)


"""
Rate of discount based on interest `i`
"""
d_of_i(i) = i / (1+i)

    
"""
Rate of interest based on discount `d`
"""
i_of_d(d) = d / (1-d)


"""
Present value using discount v_d(d, t)
"""
v_d(d, t) = (1 - d)^t


"""
Accumulated value using discount a_d(d, t)
"""
a_d(d, t) = 1 / (1 - d)^t


"""
Find nominal interest from convertible interest n_i(i, m)
"""
n_i(i, m) = (1 + i/m)^m


"""
Find convertible interest from nominal interest c_i(i, m)
"""
c_i(i, m) = ((1 + i)^(1/m)-1) * m


"""
Force of interest delta(i)
"""
delta(i) = log(1+i)


"""
Present value of an annuity at `n`, given `i` and `n`
"""
a_n(i, n) = (1 - v(i, n)) / i


"""
Present value of an annuity at first payment, based on `i` and `n`
"""
a_n_star(i, n) = (1 - v(i, n)) / d_of_i(i)


"""
Calculate the sum of an annuity with interest `i` at time `n`
`S(i, n) = ((1+i)^n) / i `
"""
s_n(i, n) = ( ( 1 + i) ^ n - 1 ) / i


"""
Calculate the sum of an annuity with interest `i` at time `n+1`
`S(i, n) = ((1+i)^n) / i `
"""
s_n_star(i, n) = ( ( 1 + i) ^ n - 1 ) / d_of_i(i)
