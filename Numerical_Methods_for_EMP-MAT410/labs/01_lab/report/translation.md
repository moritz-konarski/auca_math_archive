DEFINITION IV.1.1 (see [17]). Discrete problem (IV.1.6)
is called monotone if the following conditions are satisfied for it:
1. $$B_1 /neq 0, C_1 \ge 0, B_n \neq 0, A_n \ge 0;$$
2. $$A_i > 0, C_i > 0, i =2,3,\dots,n-1;$$
3. $$B_1>C_1, B_i > A_i + C_i, i=2,3,\dots,n-1, B_n \ge A_n$$
and at least one of these inequalities is strict.
Difference schemes (IV.1.1), (IV.1.2); (IV.1.1), (IV.1.3) and (IV.1.4),
(IV.1.5) are called monotone if the corresponding difference
problems (IV.1.6) are monotone for any positive values
parameters h and eps.

It is known that the monotonicity of the difference scheme guarantees
unique solvability of the corresponding problem (IV.1.6) (this is
        is proved, for example, in [17]); moreover, for such a difference
scheme
the sufficient conditions of correctness are satisfied and
stability of monotonic sweep.

Suppose u (x) is a solution to the differential problem
(IV.1), the notation includes the dependence on the parameter epsilon, let
u be a grid function that is a solution to some
difference problem approximating problem (IV.1), for example, problem
(IV.1.1), (IV.1.2); (IV.1.1), (IV.1.3) or (IV.1.4), (IV.1.5). For arbitrary
of the grid function vh, we introduce a "strong" grid norm with respect to
formula:
||
we also recall that (u) h is the projection of the continuous function
u (x) onto the grid.

DEFINITION IV.1.2 (see [16]). The solution uh of the difference (discrete)
problem converges to the solution u (x) of the differential problem
with order p> 0, if there is such a constant C> 0, it is possible
depending on epsilon, but not depending on h ("classical" convergence),
that:
||
If the constant "C" in the last estimate does not depend on h and epsilon,
then they say
about "uniform in epsilon" convergence with order "p"

It is known from the literature (for example, [16]) that difference schemes
1) -
4) do not have uniform convergence in epsilon. However, orders
classical convergence for these schemes are as follows: for scheme 2) -
the first, for schemes 1), 3), 4) - the second.

Schemes 5) (Ilyina A.M.) and 6) (El_Mistikawy & Werle) both have
the second order of classical convergence, in addition, the first of these
schemes guarantees the first order of uniform convergence in epsilon, and
the second
the scheme is the second order of uniform convergence in epsilon.

All schemes, except for the scheme with a central difference 1),
are monotone in the sense of Definition IV.1.1, Scheme 1)
guarantees monotonicity only if the constraint on
selection of parameters h and epsilon:
||
therefore this scheme is usually classified as conditionally monotonic
