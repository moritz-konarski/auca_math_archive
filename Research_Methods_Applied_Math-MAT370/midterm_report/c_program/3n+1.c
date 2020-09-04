#include <stdio.h>
#include <stdbool.h>

#define START  2
#define STOP  10

void collatz(long int n);

int main(int argc, char **argv){

    long int start = START, 
             stop  = STOP;

    switch (argc) {
        case 2:
            sscanf(argv[1], "%ld", &start);
            collatz(start);
            break;
        case 3:
            sscanf(argv[1], "%ld", &start);
            sscanf(argv[2], "%ld", &stop);
        case 1:
            for (int i = start; i <= stop; ++i) {
                collatz(i);
                if (i < stop) {
                    printf("-----------------------\n");
                }
            }
            break;
    }

    return 0;
}

void collatz(long int n) {

    bool first_time = true;
    long int org = n;
    int tst = 0, st = 0;
    printf("%ld", n);

    while (n - 1) {
        n = (n % 2 == 0) ? (n / 2) : (3 * n + 1)/2;
        printf(", %ld", n);
        ++tst;
        if (first_time && n < org) {
            first_time = false;
            st = tst;
        }
    }

    printf("\nst: %d\ntst: %d\n", st, tst);
}
