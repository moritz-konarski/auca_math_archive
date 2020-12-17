# Two--dimensional Poisson Equations

## Theory and basic formulas

Let 

$$\Omega = \{(x,y) | 0 \le x \le 1, 0 \le y \le 1 \},$$

a _unit--square_ in the plain $(x,y)$ and the borders

$$\begin{gathered}
\partial \Omega = \{ x = 0, 0 \le y \le 1 \} \cup \{ x = 1, 0 \le y \le 1\}\\
\cup \{0 \le x \le 1 , y = 0\} \cup \{0 \le x \le 1, y = 1 \}
\end{gathered}.$$

In the domain $\Omega$ consider the following boundary value problem, usually
called the _Dirichlet problem_ or _Poisson Problem_

$$
- \Delta u(x,y) \equiv - \left(\frac{\partial^2 u}{\partial x^2}+\frac{\partial^2 u}{\partial y^2} \right) = f(x,y), \quad (x,y) \in \stackrel{0}{\Omega} \equiv \Omega \backslash \partial \Omega
$$

$$
u(x,y) = 0, \quad (x,y) \in \partial \Omega
$$

These equations describe a stationary thermal field whose source is $f(x,y)$.
Operator $\Delta$ is the _Laplace Operator_. Consider the uniform grid in
$\Omega$

$$
\Omega^h \equiv \left\{ (x_i, y_j) | x_i = (i-1)h; \quad y_j = (j-1)h; \quad i,j
= 1,...,n; \quad h = \frac{1}{n-1}\right\}
.$$

Let's introduce the notation: inner part of the mesh area:

$$
\Omega^{h,0} \equiv \Omega^h \cap \stackrel{0}{\Omega}
$$

and the boundary of the grid domain

$$
\partial \Omega^h \equiv \Omega^h \cap \partial \Omega
$$

and the grid function defined in the domain $\Omega^h$

$$
u^h \equiv \left\{ u^h_{i,j} \right\}^n_{i,j=1}
$$

Consider the following grid problem for $u^h$

$$
-\Delta^hu^h_{i,j} \equiv - 
\left( \frac{u^h_{i+1,j} -2 u^h_{i,j} + u^h_{i-1,j}}{h^2} 
+ \frac{u^h_{i,j+1} -2 u^h_{i,j} + u^h_{i,j-1}}{h^2} \right) 
= f^h_{i,j}, \quad (x_i,y_j) \in \Omega^{h,0}
$$

$$
u^h_{i,j} = 0, \quad (x_i,y_j) \in \partial \Omega^h
$$

Here $f^h_{i,j} \equiv f(x_i,y_j)$. It follows that (V.1.3)

1. exists
2. unique
3. continuous

and depends on $f^h$. The approximate solution shall be denoted by $\bar u ^h
_{i,j}$.

To solve the equation, consider the _two--parameter family of iterative
methods_

$$
\Delta^h_0 u^h_{i,j} \equiv \frac{4}{h^2}u^h_{i,j}
$$

$$
\Delta^h_1 u^h_{i,j} \equiv -\frac{1}{h^2}\left( u^h_{i-1,j}
        + u^h_{i,j-1}\right)
$$

$$
\Delta^h_2 u^h_{i,j} \equiv -\frac{1}{h^2}\left( u^h_{i+1,j} + u^h_{i,j+1}\right), \quad (x_i, y_j) \in \Omega^{h,0}
$$

We see that 

$$
- \Delta^h = \Delta^h_1 + \Delta^h_0 + \Delta^h_2
$$

The equations can be solved on the grid $\Omega^h$ by going left--right and
bottom--up, i.e. in a double loop we'd have 

`for (int j = 1; j <= n; ++j)` 

for the outer loop and 

`for (int i = 1; i <= n; ++i)` 

for the inner loop. The proposed method is the following:

$$
\left( \Delta^h_0 + \theta \Delta^h_1 \right) \cdot \frac{u^{(k)} - u^{(k-1)}}
{\tau} - \Delta^hu^{(k-1)} = f^h, \quad \text{in the area } \Omega^{h,0}
$$

$$
u^{(k)} = 0, \text{  on  } \partial \Omega^h, \quad k = 1,2,...
$$

$$
u^{(0)} \quad \text{  -- given in  } \Omega^h.
$$

Here, $k$ is an iteration parameter, and 

$$
u^{(k)} \equiv \left\{ u^{(k)}_{i,j} \right\}^n_{i,j=1}
$$

is the grid function -- the solution to the $k$th iteration step. In
a point wise form, our equations are

$$\begin{gathered}
u^{(k)} = \frac{\theta}{4}\left( u^{(k)}_{i-1,j} + u^{(k)}_{i,j-1} \right) 
    + \frac{\tau-\theta}{4}\left( u^{(k-1)}_{i-1,j} + u^{(k-1)}_{i,j-1}
            \right) \\
    + \frac{\tau}{4}\left( u^{(k-1)}_{i+1,j} + u^{(k-1)}_{i,j+1} \right)
    + (1-\tau) u^{(k-1)}_{i,j} + \frac{\tau h^2}{4}\cdot f^h; \quad (i,j) \in
    \Omega^{h,0}
\end{gathered}$$

$$
u^{(k)}_{i,j} = 0, \quad (i,j) \in \partial \Omega^h
$$

## Properties of the iterative algorithm

Denote

$$
\mu \equiv 4 \cdot \sin^2\left(\frac{\pi h}{2} \right), \quad v \equiv 4 \cdot \cos^2\left(\frac{\pi h}{2} \right)
$$

Consider the following areas on the parametric plane

$$
\Pi_1 \equiv \left\{(\theta, \tau) | 0 \le \theta, 0 < \tau < \theta
        + \text{min} \left\{\frac{2}{\mu}(2-\theta), \frac{(2-\theta)^3}{\theta \mu v + 2(2-\theta)^2}  \right\} \right\}
$$

$$
\Pi_2 \equiv \left\{(\theta, \tau) | 0 \le \theta \le 2; \theta + \frac{(2-\theta)^3}{\theta \mu v + 2(2-\theta)^2} \le \tau < \theta + \frac{2}{v} (2-\theta)\right\}
$$

If $(\theta, \tau) \in \Pi_1 \cup \Pi_2$, then the iterative process converges
and the following estimate holds

$$
|| u^h - u^{(k)}||_{\infty} \le q^k \cdot || u^h - u^{(0)} ||_{\infty}
$$

where $q$ is

$$
q^2 = 1 - \tau \mu \cdot \frac{\mu(\theta-\tau) + 2 (2-\theta)}{2\mu\theta + (2-\theta)^2}, \text{  for  } (\theta, \tau) \in \Pi_1
$$

or 

$$
q^2 = 1 - \tau v \cdot \frac{v(\theta-\tau) + 2 (2-\theta)}{2v\theta + (2-\theta)^2}, \text{  if  } (\theta, \tau) \in \Pi_2.
$$

Because the process is iterative, we need to know how many times we need to
iterate to reduce the initial error $m$ times. $k$ satisfies the estimate

$$
k \ge \frac{\ln(m)}{\ln\left(\frac{1}{q}\right)}
$$

The value $\ln\left(\frac{1}{q}\right)$ is called the _rate of convergence of the
iterative method_ -- the larger the value, the faster it converges.

## Schemes

### Jacobi's Method

$\theta = 0, \tau = 1$. In this case, we are in the region $\Pi_2$, and we find 

$$
q = \cos (\pi h).
$$

The rate of convergence is 

$$
\frac{1}{q} \approx 1 + \frac{\pi^2 h^2}{2} \rightarrow \ln\left(\frac{1}{q}\right) = O \left( \frac{\pi^2 h^2}{2}\right), \text{  for  } h \rightarrow 0.
$$

### Seidel's Method

$\theta = \tau = 1$, we are in the region $\Pi_1$. We find $q$ as

$$
q^2 = \frac{1}{1 + 8 \sin^2\left(\frac{\pi h}{2} \right)}
$$

and 

$$
\frac{1}{q} = O\left(1 + \pi^2 h^2 \right)
$$

thus the speed of convergence is

$$
\ln\left( \frac{1}{q} \right) = O\left(\pi^2 h^2 \right), \text{  for
} h \rightarrow 0.
$$

## Test Tasks

### Eigenfunctions of the grid Laplace operator $\Delta^h$

The parameters $l=m=2$ are selected. This pair determines the solution

$$
f^h_{i,j} = \lambda_{l,m} - \sin(\pi l x_i) \cdot \sin(\pi m y_j); \quad i,j
= 1,2,...,n
$$

where

$$
\lambda_{l,m} = \frac{4}{h^2} \cdot \left[ \sin^2\left(\frac{\pi l h}{2}\right) +  \sin^2\left(\frac{\pi m h}{2}\right) \right]; \quad l = m = 2.
$$

The exact solution depends on $l,m$

$$
u^h_{i,j} = \sin(\pi l x_i) \cdot \sin(\pi m y_j), \quad i,j=1,2,...,n
$$

## Program requirements

1. iterative process with choice of $\theta$ and $\tau$
2. test problems
3. choice of grid nodes $n$
    $$
    n = 1 + d^k, k=2,3,...
    $$
4. finding the error
    $$
    \stackrel{\text{max}}{(x_i,y_j)\in\Omega^h} | u(x_i, y_j) - \bar u^h_{i,j}
    $$
5. entering $\sigma$, the condition for stopping the iterative process, else
    $$
    \sigma = (N-1)^{-3}
    $$
6. show number of iterations required for the method to converge
7. simultaneously render $\sin(\pi l x) \cdot \sin(\pi m y)$ and piecewise
   linear interpolation of $\bar u ^h _{i,j}$     
   2D graphs are sufficient, with the slices
   $$
   \left\{ (x,y) | x = \left[ \frac{n}{2} \right], y \in [0,1] \right\}
   $$
   $$
   \left\{ (x,y) | x \in [0,1], y = \left[ \frac{n}{2} \right]\right\}
   $$
8. Additional capabilities
    1. render the areas $\Pi_1$ and $\Pi_2$ dependent on the parameters
    2. 3D graphs of the exact solution and a linear interpolation of the grid
       function

## Report requirements

Use the function $u^{(0)} \equiv 0$ everywhere

1. How does the change in the number of grid nodes (parameter n) affect the
   speed of convergence of methods?
2. Does the "complexity of the solution" (parameters $l$ and $m$ in Problem 1) 
    affect the convergence of methods?
3. Compare the effectiveness of the methods.
    1. number of required iterations for convergence
    2. errors
    3. visual proximity of the two graphs
4. _Additional tasks_: explore the domains $\Pi_1$ and $\Pi_2$ as well as
   $q^2$, find the parameters $(\theta, \tau)$ that make the method converge
   the fastest
