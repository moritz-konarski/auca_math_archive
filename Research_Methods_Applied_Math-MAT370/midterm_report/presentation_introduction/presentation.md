# The $3x+1$ Problem

##

Moritz Konarski, 20.02.2020

## The Function

- Collatz function $C(x)$ 
$$C(x) = \left\{
    \begin{array}{ll}
        \frac{x}{2}  \quad &\text{if \emph{x} is even,} \\
        3x+1 \quad &\text{if \emph{x} is odd.}
    \end{array}
\right.
$$
- $3x+1$ function $T(x)$
$$T(x) = \left\{
    \begin{array}{ll}
        \frac{x}{2}  \quad &\text{if } x \equiv 1 \text{ (mod 2)} \\
        \frac{3x+1}{2} \quad &\text{if } x \equiv 0 \text{ (mod 2)}
    \end{array}
\right.
$$

## The Conjecture 

- starting at any positive integer, some iterate of these functions takes the
value 1
- for the $3x+1$ function $T(x)$: every $m \geq 1$ has some
$T^{(k)}(m)=1$
- repeated applications of this function yield _trajectories_ or _forward
orbits_

## Related Aspects

- _trajectory_ or _forward orbit_: $O^{+}(m):=\{m, T(m), T^{(2)}(m),\dots\}$
- _height_ $h(m)$: least $k$ for for which the _Collatz function_ $C(x)$ has
$C^{(k)}(m)=1$

## Examples of Trajectories

- $x=13 \rightarrow \{13,40,20,10,5,16,8,4,2,1,\dots\}$
- $x=20 \rightarrow \{20,10,5,16,8,4,2,1,\dots\}$
- $x=512 \rightarrow \{512,256,128,64,32,16,8,4,2,1,\dots\}$
- numbers up to $17 \times 2^{58} \approx 4.89 \times 10^{18}$ have been
computationally verified

## Why is the $3x+1$ Problem Interesting?

- simple problem but it is not solved yet
- maybe new areas of mathematics are needed to prove or disprove this
conjecture
- could lead to insights into prime factorization 

## Related Information

- part of _number theory_: study of integers and integer valued
functions
- two related questions
    - is there a divergent trajectory?
    - are there other cycles besides $\{4,2,1,4,\dots\}$?
- for negative integers there are cycles starting at $-1, -5, -17$

## Background of the $3x+1$ Problem

- also know as: Syracuse Problem, Hasse's Algorithm, Kakutani's Problem, Ulam's
Problem
- Collatz started studying the function in the 1930s
- informally discussed in his lecture at the International Math. Congress in
Cambridge, Mass. in 1950
- first published paper about the problem in 1963
- starting in 1970 there were a lot more publications

## Attempted Proofs

- Yamada 1981: had mathematical faults
- Cadogan 2006: had incorrect indices in a function
- Bruckman's 2008: proof would exclude the cycle starting at 1

## References

- Lagarias, J. C. (2011). The $3x+1$ Problem: An Annotated Bibliograhpy
(1963-1999)
- Lagarias, J. C. (2012). The $3x+1$ Problem: An Annotated Bibliograhpy, II
(2000-2009)
