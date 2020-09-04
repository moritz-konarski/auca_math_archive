# Final Exam Preparation

Problems are from the preliminary final exam:

## Problem 5

$f(x) = 0$  where $f(x) = x^3$

We shall use Newton's Method of simple iteration.

$0 = x^3$ has the root $x_0=0$

$$x_{n+1}=x_k-\frac{f(x_k)}{f`(x_k)},\ k=0,1,...$$
$$x_0\ is\ known$$

We solve this

$$x_{k+1}=x_k-\frac{x_k^3}{3x_k^2}=x_k-\frac{x_k}{3}$$

then we use it on itself

$$x_{k+1}=\frac{2}{3}x_k=\bigg(\frac{2}{3}\bigg)^2x_{k-1}$$

$$x_k=\bigg(\frac{2}{3}\bigg)^kx_0$$