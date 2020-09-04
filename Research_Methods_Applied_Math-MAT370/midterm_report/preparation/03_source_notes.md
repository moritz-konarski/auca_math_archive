# 01 -- Tao, T. Almost All Orbits of the Collatz Map Attain Almost Bounded Values

## Abstract

- Collatz map of $N+1 \rightarrow N+1$ on the positive integers
- $N+1=\{1,2,3,\dots\}
- Col(_N_) is the normal collatz function
- $Col_{min}(N):=inf_{n \in}Col^n(N)$ is the minimal element of the collatz
orbit (sequence of applications of the function)
- conjecture is that $Col_{min}(N)=1$ for all $N \in N + 1$
- Korec showed that for any $\theta > \frac{\log 3}{\log 4} \approx 0.7924$ one
has $Col_{min}(N) \leq N^{\theta}$ for allmost all $N \in N+1$ in the sense of
natural density
- here it is shown that for any function that maps the positive natural numbers
to the real numbers where f approaches infinity if its limit is taken to
infinity has $Col_{min}(N) \leq f(N)$ for allmost all $N \in N+1$ in the sense
of logarithmic density
- the proof is described, but I do not understand a single word of it

## Introduction

### Main Result

- collatz map in terms of the normal function for all positive integers
- $Col_{min}(N)=1$ for all positive integers
- [5], [9] have extensive overviews of the conjecture
- [13] shows the computational verification for all $N \leq 10^{20}$

### Syracuse formulation (1.2)

- it is more convenient to use $N \rightarrow Col^{f(N)}(N)$ of the normal map
- we use Col2, where we immediately divide by 2 after multiplying by 3
- this reduces the "acceleration"
- this paper will use "3-adic" analysis
- Syracuse Map: $2N+1 \rightarrow 2N+1$ is the larges odd number that divides
$3N+1$
- Syracuse orbit is just the odd numbers of the Collatz orbit
- _Conjecture 1.5_ We have Syr min (N) = 1 for all $N \in 2N+1$
- Collatz theorem reformulated to use the Syracuse map 

### Probabilistic Modeling (1.8)

- they use a certain heuristic that if $N$ is a "typical" large odd natural
number, $n << \log N$ then the n-Syracuse valuation vec a behaves like
Geom(2)^n
- basically, the heuristic is justified if 

# 05 -- Chamberland, M. An Update on the $3x+1$ Problem

## Introduction

- Paul Erdos stated "Mathematics is not ready for such problems", as cited by
Chamberland
- many names
- Collatz function, conjecture, and map T
- even more streamlined function, but it's difficult to analyze

## Numerics and Stopping time

- T has the options
    1. trivial cycle {1,2}
    2. a non-trivial cycle
    3. infinity
- the claim is that 1. is always the case
- verified to now outdated numbers
- non-trivial cycle length must be no less than 272,500,658
- stopping time $\sigma (n)$ is a good algorithm for showing that n goes to one
because it assumes that all below n do and stops as soon as C(n) < n
- total stopping time to iterate to one
- height of n as the largest number one iterates to
- as long as these are not infinity, conjecture holds

### Stopping Time

- conjecture is true of every in has finite stopping time
- _graph an orbit that looks kinda cool_ -- inspired by the graphs in lagarias
and chamberland
- divergent trajectories should diverge relatively quickly
- often probabilistic because after many iterations even and odd can be seen
like a coin flip
- average stoppin time for an odd number $n \approx 9.477955$

### Total Stopping time

- stopping time ratio $\gamma (n) := \sigma \infty (n) / \log n$
- ones-ratio $\rho (n)$ ratio of odd terms in total stopping time to total
stopping time
- we have the average value of the stopping time ratio and the upper bound (p.7)

### Collatz Graph and Predecessor Sets

- collatz map T and graph are obviously connected to each other

### Representations of Iterates

## 5 - Cycles

- have received much attention
- sum of the even integers equals sum of the odd integers plus the number of
odd integers

## 6 - Extending T to Larger Spaces

### Integers Z

- three new cycles: {0}, {-5}, {-17}
- also attainable by $T'(n)=-T(-n)$
- conjecture is that these are all the cycles of __Z__

Also applied to rational numbers and 2-adic integers, Gaussian Integers

### Real line __R__

### Complex Plane C

## Generalizations of $3x+1$ Dynamics

- "$3x+d$" is conjectured to become periodic for $d \geq -1$
- "$qx+1$" for 5 there is only one non-trivial cricuit, for 7 there are none
- conjectured that all $q \geq 5$ have iterates that never reach 1
- Wirsching says that we either get divergence or different periodic orbits

## Misc

- histograms might be nice to make

# 06 -- Lagaris, J. C. The $3x+1$ Problem: An Overview

## Introduction

- collatz function is defined and conjecture stated
- has many other names
- $3x+1$ function is defined, relation to the original function is made clear
- this function is useful because it is more convenient for analysis
- two questions: what do we currently know? how can it be hard when it is easy
to state
- history of work on the problem is discussed
- describes generalizations and different fields of mathematics that this
problem concerns
- difficulty can only be truly assessed once the problem has been solved
- track record does suggest that it is very difficult
- one of the points is that $T(x)$ seems to be pseudorandom 
- it is nor important for its individual sake, there it's more of a challenge
- these types of functions though, ones that iterate and contract or expand
domains are very relevant and general methods and progress to solve these kinds
of equations could be very significant

## History and Background

- generally attributed to Collatz, other people are associated with it and
others claim to have come up with it
- definitely circulated since the 1950s
- early 1970 saw the first mathematical literature on the problem
- it might have taken so long because this kind of disjointed maths was not
popular at that time
- it was and is super hard to prove things about this problem
- many people strayed away from it because it might have been damaging to their
reputation to even work on it
- various similar problems appeared in print in the 1960s
- computations in the 1960s verified the conjecture for all $n \leq 10^9$
- 1971 the exact problem appeared in print for the first time
- Ulam stated the problem as one of the first people, Everett wrote one of the
early papers in 1977
- the problem can also be formulated backwards: determining the smallest set of
integers containing 1 that is closed under the affine maps $x \rightarrow 2x$
and $3x+2 \rightarrow 2x+1$, the latter only being applied when the output is
an integer
- then the conjecture asserts that this is the set of all positive integers
- __connection to problems on sets of integers that are closed under affine
maps__
- plot of $n=649$ looks cool
- it used to be a curiosity, now, because of general connections to other areas
of mathematics and computation is has become of interest

## $3x+1$ Sampler

- it's cool because it's simple to state but complex under iteration
- there have been a number of subsidiary conjectures about its behavior
- many of these subsidiary conjectures are also very hard problems

### Plots of Trajectories

- trajectory of x under a function T is the forward orbit of x, the sequence of
its forward iterates $\{x, T(x), T^{(2)}(x), T^{(3)}(x),\dots\}$
- if we plot this sequence, we get what is sometimes called "hailstone
numbers", named after hailstones that rise and fall seemingly randomly in the
clouds, just like this function
- it often helps to plot $\log T^{(K)}(n)$ versus $k$
- there seems to be a decrease at a certain geometric rate, many staying close
to $-0.5 \log (3/4)$
- it takes about $6.95212 \log n$ steps to reach 1
- because of the seemingly random nature of the iteration it appears that
elements of it can only be described only statistically -- these are statements
about groups or the majority of trajectories and not individual trajectories

### Patterns

- we can find many internal patterns for different starting values
- there are multiple patterns for initial iterates fro $n=2^m-1$
- also shows that iterates can be arbitrarily larger than starting values
- here $\sigma_{\infty}(n)$ denotes the total stopping time for $n$, number of
iterations to reach 1, counting $n$ as the 0th iterate -- this is equal to the
number of even numbers appearing in the sequence -- __WHY__
- in the long number we find only a few distinct values for the stopping time,
same for some other, equally large numbers
- we can put the total stopping time, frequency statistic for each stopping
time in the range, 1-ratio as the fraction of odd iterates up to and including
1
- we can baselessly assume the heuristic: as $n$ increases, only a few values 
of $\sigma_{\infty}(n)$ occur, slow variation of those

### Probabilistic Models

- because rigorous proof lacks behind computer experiments, _deterministic
process is described using probabilistic models_
- this creates another area: the creation of models for aspects of this problem
- observation is that the number of odd and even iterates is basically equal
- this can be seen like independent coin flips -- this suggests that the slope
of logarithmically plotted values is equal to $-1/2 \log (3/4) \approx
-0.14384$ and thus takes about $6.95212 \log n$ steps to reach 1
- here the $3x+1$ function is useful because it allows the assumption that the
results will be even about two thirds of the time
- now there are many complicated and rigorous models, these yield heuristic
prediction about the behavior of the $3x+1$ map
- most trajectories follow the logarithmic decline, but few of them follow
a different path
- equation on page 8, extremal trajectories of this form are two line segments,
descibed at the top of page 9
- importantly, stochastic models suggest that the largest total stopping time
is at most $41.677647 \log n$ and thus quantitatively predict that divergent
trajectories do not exist
- can be applied to $5x+1$, where most seem to escape to infinity, but not one
has been proven to do so yet

## Generalized $3x+1$ functions

- today it is often studied as a discrete dynamical system
- generalized collatz functions are a very useful class of functions
- number-theoretical properties have to do with the existence of p-adic
extensions of these maps for various primes p
- most often viewed as a discrete dynamical system of an arithmetical kind
- such systems can be seen as simple models of the more complicated ones that
often arise
- __look into discrete dynamical systems__
- we can generalize the function to k instead of one, to include all rational
numbers in a well-defined function
- most generally: $f(x)=(a_i+b_i)/(d)$ if $x \equiv i \quad (\mod d), 0 \leq i \leq d -1$
- here we have a collection of integer pairs $\{(a_i, b_i):0 \leq i \leq d-1\}$
- function is admissible if the integer pairs satisfy $ia_i + b_i \equiv 0$
(mod $d$) for $0 \leq i \leq d-1$
- important subclass are those of _relatively prime type_
- here $\text{gcd}(a_0 a_1 \dots a_{d-1},d)=1$ which includes the $3x+1$
function but not the collatz function

## Research Areas

1. Number Theory -- analysis of periodic orbits of the map. Immediately obvious
because this is a problem from that field. page 12
2. Dynamical Systems -- behavior of generalizations of the map. Functions under
iteration are the concern and this can be seen as an iterating map
3. Ergodic Theory -- invariant measures for generalized maps. Some type of
measures and invariants.
4. Theory of Compuatation -- undecidable iteration problems. will this
iteration with these starting values ever be a power of 2?
5. Stochastic Process -- models yielding predictions for the behavior of
iterates. Models behavior on large set of integers, how does the probability
distribution evolve under iteration? 
6. Computer Science -- algorithms for computing iterates and statistics;
explicit computations. models of computation are sometimes based on this. Also,
the necessity to use computers to find and test things about the conjecture:
how to hangle large computations etc

## Current Status

### Where does research currently stand on the $3x+1$ problem?

- remains unsolved
- "Mathematics is not yet ready for such problems." - p. 14
- verified for all $n < 20 \times 2^{58}$
- minimal period of unknown cycle: 10,439,860,591 and only cycle containing
less than 6,586,818,670 odd integers
- infinitely many integers take at least $6.143 \log n$ steps to reach 0
- largest count of $C$ in $C \log n$ iterations: 
$n=7,219,136,416,377,236,271,195$ with $C \approx 36.7169$
- the number of integers $1 \leq n \leq X$ that iterate to 1 is at least
$X^{0.84}$ for all sufficiently large $X$

### Where does research stand on generalizations of the $3x+1$ problem?

- methods for $3x+1$ generally apply to $3x+k$ too
- functions of relatively prime type are very ergodic?
- all functions in the generalized Collatz class have a unique continuous
extension to the domain of $d$-adic integers

### How can the be a hard problem, when it is so easy to state?

- pseudo-randomness is a problem because it makes it very hard to prove because
proofs need structure
- non-computability is relevant because it may not be decidable or at least
difficult to decide

## Hardness of the $3x+1$ problem

- a bunch of stuff on computation and shit

## Future Prospects

- the "World Records" can certainly be improved upon
- a bunch of unproven conjectures on page 20

# 07 -- Garner, L. E. On the Collatz $3n+1$ Algorithm

## Abstract

- number theoretic function
- collatz sequence is generated from the usual function
- if any other cycle than the $\{4,2,1,4,\dots\}$ cycle is entered, it must
have thousands of terms

## Introduction

- defines the Collatz function and sequence, example for $C(17)$
- _Collatz conjecture_: every sequence ends in the cycle $\{4,2,1,4,2,\dots\}$
- high numbers have been verified
- proofs tend to be probabilistic in nature, strengthen belief in the
conjecture
- this paper proves that if there are other cycles that do not contain 1, they
have many thousands of terms

## Stopping Time

- CC is equivalent to: for every $n \in N, n > 1$ there is a $k \in N$ such
that $s^k(n) < n$
- the least $k$ is called the stopping time of n, denoted $\sigma(n)$
- stopping times are easy to verify
- _Everett_ proves that almost all $n \in N$ have a finite stopping time,
Terras giving a probability distribution function for the same
- most ints have a small stopping time
- stopping times can be arbitrarily large though

## Term Formula

- a formula to find the next term in a collatz sequence

## Coefficient Stopping Time

- the point when one of the coefficients of the term formula is less than one
- under certain conditions the coefficient stopping time is equal to the
stopping time

## Powers of 2 and 3

- powers of 2 appear to be bounded away from the powers of 3

## Main Theorem

- if the number of odd terms in the collatz sequence is not too great, the
coefficient stopping time equals the normal stopping time

## Application to Cycles

- suppose a sequence enters a cycle that does not contain 1
- let n be the smallest term in the cycle
- by the foregoing theorems $n$ cannot be the least element in the cycle
- another contradiction arises from the number of odd numbers a cycle without
one must satisfy
- using some of the proven numbers at the time, some short cycles would be at
least 105,000 terms
- __only known short cycle is the known one, and that seems to hold__

## Notes

- find how long a cycle would need to be for the numbers that are currently
verified, that would be a cool piece of math

# 09 -- Crandall, R. E. On the $3x+1$ Problem

## Abstract

- open conjecture, this time for positive odd integers in the form 
$C(m)=(3m+1)/2^{e(m)}$, $e(m)$ is chosen in a way that $C(m)$ is again odd
- conjecture: $C^h(m)=1$ for some $h$
- number of $m \leq x$ satifying the conjecture is at least $x^c$ for some
positive constant $c$
- connection between the conjecture and the diophantine equation $2^x-3^y=p$ is
established
- conjecture fails if $m=C^k(m)$, k must be greater than 17,985

## Introduction

- in the definition $2^{e(x)}$ is the highest power of 2 that divides $3x+1$
- this can be iterated any number of times
- is an iteration of this function eventually equal to one?

## Preliminary Observations

- mapping of odd positive integers to odd positive integers has some properties
- trajectory is the sequence of iterations that terminates on the first
occurrence of 1
- if that term does not exist, it is an infinite sequence
- height of m is the cardinality of the trajectory, least number of iterations
that reach 1
- inf Tm is the least positive integer in the sequence Tm
- sup Tm is the greatest integer in the sequence
- conjecture is that the height of all sequences is finite
- Everett proved that almost all odd positive integers have inf Tm < m
- if this were to be proven for all n, the conjecture would be true
- as m increases, (sup Tm) / m is unbounded
- there must be arbitrarily large members in trajectories

## Random Walk Argument

- heuristic argument states the following: for sufficiently large integers
$\ln(C(m)/m)$ is a random variable, distributed by $e(m)$
- expected $e(m)=k$ with probability $2^{-k}$, thus the random variable is
expected to be $-\log(4/3)$, indicating that, overall, $C(m) < m$
- imagine a random walk, then $h(m) \sim \frac{\log m}{\log(4/3)}$
- another conjecture $H(x) \sim 2(\log(16/9))^{-1}\log x$ or 
$H(x) \sim 2 \log x / \log (16/9)$

## Uniqueness Theorem

- $M=\{m \in D^+, m > 1 | h(m) finite\}$, then for each $m \in M$ there is
a unique backwards sequence starting at one that reaches $m$

## Numbers with Given Height

- set of integers $M$ is naturally partitioned by their height $h$
- there numbers of any given height
- define a function that returns an estimate of the number of sequences below
a certain initial value $x$ that have height $h$

## An Estimate for $\pi(x)$

- is the estimate of the number of integers $m \leq x$ belonging to the set $M$
- from 2.1 we get that $\pi(x)$ is the number of odd integers greater 1 but not
greater $x$
- for sufficiently large $x$ there exists a positive constant $c$ such that
$\pi(x) > x^c$

## Cycles

- assume all trajectories are bounded and that no $m > 1$ has its own
trajectory
- with these two assumptions the conjecture must be true
- it is however not certain if either of these are true
- if numbers have their own trajectories, they are difficult to find
- establish a lower bound for the period of an infinite cyclic trajectory in
terms of the smallest member
- if a certain sequence exists, either $n=1$ or the $k$th element of Tm is n
- because one of the terms here is a diophantine equation, getting results
about the collatz conjecture could yield new information about this equation
- specifically, there would be more solutions to the equation that currently
assumed
- the powers of two and three are poor approximations of each other
- $\log_2 3$ must be difficult to approximate using rational numbers
- if the conjecture is true, we'd get some interesting stuff about the
approximation of powers of 2 by powers of 3

## The $qx+r$ Problem

- define $C_{qr}(m)=(qm+r)/2^{e_{qr}(m)}$ for m as a positive odd integer
- conjecture is that m fails to satisfy the normal equation except in the case
$(q,r)=(3,1)$ 
- diophantine equations can be used to prove $q=5,181,1093$, but that's it
- speaking in terms of the heuristic from above, it should be about
$\log(q/4)$, meaning that for all odd integers $>3$ the value is positive,
"pushing" the value upwards
- $7x+1$ is interesting because $m=3$ seems to give rise to an apparently
infinitely increasing trajectory
