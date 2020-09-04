# Structure

1. Definition -- What is the $3x+1$ Problem
    - G: number theoretic function
    - T: map of N+1 to N+1 (positive integers)
    - L: definition of the function and all its attributes
        - stopping time
        - Ch: explanation of stopping time
        - total stopping time counts n as the 0th number
        - total stopping time
        - trajectory of a number

2. Conjecture
    - What is the Collatz conjecture?
        - Ch: because it is an integer function, T has three possible options
        - G: the conjecture is equivalent to saying that for every int there is
        a finite stopping time
        - Cr: height of all sequences is finite
        - Ch: if stopping time and height are finite for all N the conjecture 
        holds
        - Cr: if the trajectory does not contain 1, it is infinite
        - L: research areas
            - number theory
            - dynamical systems
            - ergodic theory
            - theory of computation
            - stochastic processes
            - computer science
    - What is cool about it?
        - L: the problem itself is not that important, more of a challenge
        - L: the general type of function is pretty popular rn and important
        - L: cool because it is simple to state but hard to prove
        - L: hard because it is pseudorandom and proofs need structure
        - L: subsidiary conjectures that also seem hard to prove
        
3. History of the Conjecture -- Where does it come from?
    - Ch: Paul Erdos quote
    - Ch: different names that the conjecture has
    - L: attributed to Collatz, hence the name, 1930s
    - L: at least around since the 50s
    - L: 1970s math literature began
    - L: 1971 saw the first appearance of this exact problem
    - L: another Erdos quote
    - Cr: Everett proved that almost all odd ints have finite stopping time
    - T: computational verification for all N <= 10^20

4. Closer look at some attributes of the function
    - L: many unproved conjectures regarding the original conjecture exist
    - L: general decreasing slope is equal to -0.5 log(3/4)
    - L: most trajectories just follow a downward logarithm, some are split and
    interesting
    - L: iterates can be arbitrarily larger than the starting values
    - Ch: sum of even integers equals sum of odd integers plus number of odd
    integers -- maybe check this thing computationally?
    - Plotting a graph
        - Ch: graph of the elements of a couple sequences, inspired by this and
        lagarias
        - L: one can plot log(T^k) vs k
        - L: cool plot of n = 649, make inspired diagram
        - L: illustrate pseudo-randomness using graph
        - compare the approximation in Cr with the actual stopping time for
        some values
    - Cycles
        - Ch: for all integers we get three more cycles at {0}, {-5}, {-17},
        conjectured to be all cycles
        - Ch: non-trivial cycle of at least 272,500,658 length
        - L: minimal unknown cycles must be of length 10 billion
        - G: proof that any non-trivial cycle must have thousands of terms
    - Stochastic Approximations
        - L: creation of probabilistic models used to describe discrete processes
        - L: stems from the fact that the number of even and odd iterates is basically
        equal -- this is the assumption that gives rise to the slope and general
        stopping time
        - L: because it seems so random, people are describing it probabilistically,
        this describes groups of trajectories at best
        - L: T(x) seems to be pseudorandom
        - Cr: for sufficiently large ints the collatz function yiels basically random
        variables
    - Height of the graph
        - Cr: height can also be called the cardinality of the trajectory
        - Cr: approximation of the height of any given x -- cool to visualize
    - Stopping time
        - Ch: average stopping time of odd numbers should be around 9.477955
        - L: generally is takes 6.95212 log n steps to reach 1
        - L: total stopping time is equal to the number of even numbers in the 
        sequence
        - L: largest total stopping time is at most 41.677647 log n -- quantitatively
        predicts that divergent trajectories do not exist
        - G: most ints have small stopping times, can be as large as you want though

# General features

- 15 pages
- all of the latex fancies
- quotations?
- enumerate and itemize?
- images of graphs in .eps or .svg
- indents
- footnotes
- acknowledgements

# Controversy

- what is the general sentiment
- what is actually the case
- not immediately obvious revelation
- less than 250 words
- reasonable amount of creativity
- quotes for context
- paraphrasing

# Structure

## Title

## Abstract

- present tense, passive voice
- catch interest of people in related fields
- no symbols if possible

## Table of Contents

## Introduction

- contextualize and get the reader interested

- why this topic
- how did I do it
- what was found
- what does it mean

## Body

### Section 1

### Section 2

## Conclusion

- relate to other peoples findings

## Acknowledgements

## References

-----------------------

# Talk

- tell what you are going to say
- tell it
- tell what you said
- $\leq 7$ lines per slide
- 2 slides per minute
- tell a story but tell the audience where you will end up

- explain the problem
- what is the controversy
- use examples
- only hint at how things are being proven
- give context for your results
- convince the reader or listener
- appreciate the beauty of the mathematics
- abstract in passive voice, present tense
