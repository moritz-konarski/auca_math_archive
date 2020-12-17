# Lab 2 -- Weighted Scheme for the Heat Equation

- __Main Goal__: introduce the simplest 1D thermal problems (with time)

## Theory and Basic Formulas

- find a function $u(x,t)$ that satifies
$$\frac{\partial u}{\partial t} = \epsilon \frac{\partial^2 u}{\partial x^2} + f(x,t); \quad 0 < x < 1; \quad t > 0$$
- initial conditions:
$$u(x,0) = \phi(x) \quad 0 \le x \le 1$$
- boundary conditions
$$u(0,t) = \psi_0(t), \quad u(1,t) = \psi_1(t), \quad t \ge 0$$
- all functions are considered known
- $\epsilon \in (0,1]$ is also set
- these equations describe the change in heat in a homogeneous, thermally
insulated thin rod
- the temperature at the ends is set by $\psi_0, \psi_1$
- $f(x,t)$ is a know thermal source
- $\phi(x)$ is the initial temperature
- in some cases these equations can describe any process of diffusion
- in certain combinations of parameters, the equations are _correct_ --
a solution exists, is unique, and is continuous

## Simplest Numerical Solutions

- consider a uniform grid on the segment $[0,1]$
$$x_i \equiv (i-1) \cdot h, \quad h \equiv \frac{1}{n-1}, \quad 1,2,...,n$$
- the time variable is also on a grid with step $\tau$
$$t_m = m \cdot \tau, \quad m=0,1,...$$
- the function is approximated on a 2D net
$$\{(x_i, t_m) | i=1,2,...,n; m = 0,1,... \}$$
- to solve this problem, the weighted scheme (V.2.4) is used
- together with (V.2.5) and (V.2.6) the equations are approximated
- the parameter $0 \le \theta \le 1$ is the weight
- this scheme can be rewritten ($f(x,t) = 0$ is assumed) as (V.2.8)-(V.2.10)
- these equations are solved step-by-step on each time layer
- on each time step the system of equations can be solved using the Tridiagonal
Matrix algorithm (the notation of (V.2.8) is detailed in (V.2.11))
- $K$ is the Courant number
- if the conditions
    1. $A \ge 0, C \ge 0, B > A + C$
    2. $A^0 \ge 0, C^0 \ge 0, B^0 \ge 0, B \ge A + C + (A^0 + B^0 + C^0)$
are satisfied, the problem is well-posed
- the scheme is monotone if the above conditions are satisfied

## Types of Schemes

- choosing $\theta$ determines the types of the scheme
    1. $\theta = 0$ -- explicit scheme
    2. $\theta = 0.5$ -- Crank--Nicholson scheme
    3. $\theta = 1$ -- pure implicit scheme
    4. $\theta = max\left(0.5, 1 - \frac{1}{2K} \right)$ -- minimum viscosity
       scheme
    5. $\theta = max\left(0.5, 1 - \frac{3}{4K} \right)$ -- monotony preserving scheme
    6. $\theta = 0.5 \cdot \left(1 - \frac{1}{6K} \right)$ -- highest order of
       convergence scheme

## Monotonicity

If 
$$max \left(0, 1 - \frac{1}{2K} \le \theta \le 1 \right)$$
the scheme is monotone.

## Requirements for the Program

1. have difference schemes
2. set $\theta$, $T1$, $T2$
3. test problem 4
4. select space and time nodes
5. set Courant number and then $\tau$ from that or set $\tau$ and Courant from that
6. parameter $k$ to set $\epsilon = 2 ^{-k}$
7. error after formula (V.2.18)
8. graph at each time step to create animation
9. reset button to return to $t=0$

## Requirements for the report

- using (V.2.13), find the conditions for $K$ that guarantee the monotony
    - go by the formula and make some example values up
    - maybe make a table that contains some example values
    - or show that if $\epsilon = X$, $\tau \le 0.5$ or something
- does monotony guarantee the correspondence of numerical and approximate
solution
    - not totally
- does a violation of these conditions lead to deterioration of the numerical
solution?
    - not necessarily, see files and graphs for explanation
- compare the schemes with each other: error, graphs
    - graph the errors of two or 3 examples
    - show how the error behaves
- find the values of $K$ and $h$ that guarantee an error of $\le 5\%$
    - I could not so I'll leave it out

