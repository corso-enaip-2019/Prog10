# PROGRAMMING EXERCISES - PROCEDURAL PARADIGM

## 1.1
As we all know, the answer to all the quesions is 42 (if you don't know that, search on the Internet!).

Generate a string with this truthy sentence, concatenating the sentence and the number, and print it on the Console.


## 1.2
42 is the answer to all questions.

Read a number from the Console, and print on the Console if it is divisible by 42 or not.


## 2
Create a variable with a number of your choice.

Print the double and the triple of the number.

The numbers must be printed with adequate messages, concatenating strings and numbers.


## 3.1
Print all the numbers divisible by 3 and 5, from 1 to 100.

Print all the numbers divisible by 3 or 5, from 1 to 100.

Print the first 100 numbers that are divisible by 3 or 5.


## 3.2
Fizz Buzz: list all the numbers between 1 and 100, but:

1) the multiple of 3 must be replaced with the word "fizz";

2) the multiple of 5 must be replaced with the word "buzz";

3) the multiple of both 3 and 5 must be replaced with the word "fizzbuzz"


## 4
Create 3 strings, then print their concatenations forward and backward

(ex: string1 is 'Hello' and string2 is 'World', we want printed 'HelloWorld' and 'WorldHello').


## 5.1
Read 2 numbers from the Console, then print on the Console all the 5 integer operations ( "a + b", "a - b", etc) with the results of the operations.


## 5.2
Read 2 numbers from the Console (giving good input messages to the user), and print all the 5 integer operations in a "decorated way", like this:

    =====================
    == the sum is: 45! ==
    =====================

Hint: the number does not have a fixed lenght: as an int, it can have from 1 to 10 digits.

How can you check the lenght of the number as a string, in order to calculate how many "=" to write?


## 6.1
Create enough variables to contain the following information about a person: name, surname, age, work.

Filling them asking to the User the values.

Then print them in a user-friendly manner (like: "Name: Mario", etc.).


## 6.2
Just as the previous exercise, but writing the labels (name, surname...) with a different color from the values ("Mario", "Rossi", ...).


## 7
Print all the numbers between -4 and 19, in backward order.
Print all the numbers between -4 and 19 with a step of 3 (i.e. -4, -1, 2, ...).


## 8
This code is not working:

    int a = 2000000000;
    int b = 2000000000;
    int sum = a+b;

The value of `sum` is not as expected. Why? How can we fix the problem?


## 9.1
Print a matrix with product calculations, like:

         5  6  7 ...
     5  25 30 35 ...
     6  30 36 42 ...
     7  35 42 49 ...
     .   .  .  . ...

From 1 to 10.


## 9.2
Print a matrix with product calculations, from 50 to 60, like:

           50    51   52  ...
     50  2500  2550  ...  ...
     51  2550  2601  ...  ...
     52   ...   ...  ...  ...
      .   ...   ...  ...  ...


## 10.1
Print a numeric triangle, with values up to 10. A numeric tringle is something like this:

    1
    1 2
    1 2 3
    1 2 3 4


## 10.2 *
A Christmas-lover manager wants a isosceles numeric triangle, like a Christmas tree, with values up to 10.
Like:

            1
          1   2
        1   2   3
      1   2   3   4      


## 11
Implement the "power" operator for integers, using multiplications and a `while` o `for` loop.


## 12
Implement the moltiplication for integers, without using the `*`, but only with sums and a `while` o `for` loop.


## 13 *
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.

The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.


## 14.1 *
The Fibonacci sequence works in this way:

    F[0] = 0
    F[1] = 1
    ...
    F[n] = F[n-1] + F[n-2]

So the sequence starts with these numbers:

    0 1 1 2 3 5 8 13 21 34 55 89 ...

Every number is the sum of the two previous ones.
Print all the Fibonacci numbers up to 1000.


## 14.2 *
Print the first 1000 Fibonacci numbers, using an array to calculate and store them.


## 14.3 **
Keep printing all the Fibonacci numbers until the sum of all the printed ones remains under 1000000.


## 15 ***
Implement a `while` loop just with `if/else` e `goto` instructions, without the `while` keyword.


## 16 *
Implement a function that, given a number, creates a string with the binary rapresentation of the number (ex: 9 => 1001)


## 17
Implement a function that, given a number, tells the absolute value of the number. You cannot use `Math.Abs()`.


## 18.1
Ask 10 numbers to the user. In the end, print the max, the min and the average.

Do NOT declare 10 different variable.

Use a `while` or a `for` loop.


## 18.2 *
As 18.1, but DO NOT use lists or arrays.


## 19 ***
Calculate the Tartaglia's triangle up to row `n`, where `n` is a number inserted by the user.


## 20 *
Calculate and print the first 100 prime numbers that are also palindrome (es: 601 is NOT palindrome; 151 IS palindrome).

Encapsulate the functions of "is prime" and "is palindrome" in separate methods


## 21 **
Ask for a number in Console.

Calculate the cubic root of the number, without using the Math.Pow method.

Print that root in the Console.

Implement the three steps in different functions.


## 22 ***
Find the max `double` number, without using `double.MaxValue`.


## 23.1
Implement a CALCULATOR.

Ask to the user for 2 number and an operation ('+', '*', ...).

Execute the operation and show to the user the result in Console.

You can assume that the input is always ok (so you don't need to use `TryParse`).


## 23.2
As **25.1**, but check every input of the user to be valid (ex: `"ciao"` is not a valid input for the first number)


## 24 **
Read about the bisection method, and implement a program that uses it to solve the intersection points of the function `1.2x^2 - 4.75x + 1.234` with the X axis.


## 25
Implement a program that calculates a side of a rectangle triangle, given the first two.

Two sides are given by the user in Console. For every side, the program must ask: "are you inserting the hypotenuse or a cateto?".

If the first side was already the hypotenuse, the question must not be asked for the second side because it's obviously a cateto.

Calculate the third side once you got the first two.

Encapsulate the parts of the application in different functions.


## 26
Calculate the factorial of a number with a `for` / `while` loop.


## 27
Implement a program that asks to the user for 2 parameters of a 2nd-grade equation, calculates the two solutions and prints them in Console.

Handle the cases in which there are two solutions, one solution, or the equation is impossible or indeterminate.


## 28 **
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
