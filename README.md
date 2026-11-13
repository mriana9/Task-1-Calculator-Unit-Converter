# Calculator App

## 1. Project Overview

The Calculator App is a console application that provides three main
services:

1.  **Calculator** -- performs arithmetic operations.
2.  **Unit Converter** -- converts values between common units.
3.  **Currency Converter** -- converts amounts between USD, ILS, and EUR
    using fixed sample exchange rates.

The application displays the main menu repeatedly until the user selects
**0 - Exit**.

> **Note:** The currency exchange rates in this project are fixed sample
> values for practice. They are not live market rates.

---

## 2. Main Menu

When the application starts, it displays:

```text
Welcome to the Calculator App!
--------------------------------
1 - Calculator
2 - Unit Converter
3 - Currency Converter
0 - Exit
--------------------------------
Enter a number to choose option:
```

### Main menu choices

Choice Action Expected result

---

`1` Calculator Opens the arithmetic calculator.
`2` Unit Converter Opens the unit conversion menu.
`3` Currency Converter Opens the currency conversion menu.
`0` Exit Displays an exit message and closes the application.

### Main menu test cases

---

Test User input Expected result Status

---

M01 `1` Calculator is Success
selected.

M02 `2` Unit Converter is Success
selected.

M03 `3` Currency Success
Converter is  
 selected.

M04 `0` Application Success
exits.

M05 `5` Invalid choice Failure handled
message; asks  
 again.

M06 `abc` Invalid input Failure handled
message; asks  
 again.

M07 Empty input Invalid input Failure handled
message; asks  
 again.

---

---

## 3. Calculator

The Calculator supports the following arithmetic operations:

---

Operation Symbol Description Example Expected result

---

Addition `+` Adds two `10 + 5` `15.00`
numbers.

Subtraction `-` Subtracts the `10 - 5` `5.00`
second number  
 from the  
 first.

Multiplication `*` Multiplies `10 * 5` `50.00`
two numbers.

Division `/` Divides the `10 / 5` `2.00`
first number  
 by the  
 second.

Modulus `%` Returns the `10 % 3` `1.00`
remainder  
 after  
 division.

Power `^` Raises the `2 ^ 3` `8.00`
first number  
 to the power  
 of the  
 second.

Sum `sum` Adds any `1, 2, 3, 4` `10.00`
number of  
 values  
 entered by  
 the user.

---

### 3.1 Addition

**Purpose:** Adds two numbers.

Successful test cases:

Test First number Second number Expected result

---

A01 `10` `5` `15.00`
A02 `-10` `5` `-5.00`
A03 `2.5` `3.5` `6.00`

### 3.2 Subtraction

**Purpose:** Subtracts the second number from the first number.

Successful test cases:

Test First number Second number Expected result

---

S01 `10` `5` `5.00`
S02 `5` `10` `-5.00`
S03 `8.5` `2.25` `6.25`

### 3.3 Multiplication

**Purpose:** Multiplies two numbers.

Successful test cases:

Test First number Second number Expected result

---

MU01 `10` `5` `50.00`
MU02 `-4` `3` `-12.00`
MU03 `2.5` `4` `10.00`

### 3.4 Division

**Purpose:** Divides the first number by the second number.

Successful test cases:

Test First number Second number Expected result

---

D01 `10` `2` `5.00`
D02 `7` `2` `3.50`
D03 `-12` `3` `-4.00`

Failure test cases:

---

Test First number Second number Expected behavior

---

D04 `10` `0` Displays a
friendly
division-by-zero
error. The
application must
not crash.

D05 `10` `abc` Rejects the
invalid number and
asks the user to
enter a valid
number.

---

### 3.5 Modulus

**Purpose:** Returns the remainder after dividing the first number by
the second number.

Successful test cases:

Test First number Second number Expected result

---

MO01 `10` `3` `1.00`
MO02 `20` `5` `0.00`
MO03 `17` `4` `1.00`

Failure test cases:

---

Test First number Second number Expected
behavior

---

MO04 `10` `0` Displays a
friendly error
because modulus
by zero is not
allowed.

MO05 `10` `hello` Rejects the
invalid number
and asks again.

---

### 3.6 Power

**Purpose:** Raises the base number to the specified exponent.

Successful test cases:

Test Base Exponent Expected result

---

P01 `2` `3` `8.00`
P02 `5` `2` `25.00`
P03 `10` `0` `1.00`
P04 `2` `-2` `0.25`

Failure / edge test cases:

---

Test Base Exponent Expected behavior

---

P05 `2` `abc` Rejects the
invalid exponent
and asks again.

P06 `0` `-1` The result is not
a finite decimal
value; the
application should
handle the
conversion/error
safely if this
input is tested.

---

### 3.7 Sum (`params` bonus)

**Purpose:** Adds multiple numbers. The user first chooses how many
values to enter, then enters each value. The `Sum` method uses
`params decimal[]` to accept a variable number of decimal values.

Successful test cases:

Test Number of values Values Expected result

---

SU01 `2` `5, 10` `15.00`
SU02 `3` `5, 10, 15` `30.00`
SU03 `5` `1, 2, 3, 4, 5` `15.00`
SU04 `4` `10.5, 2.5, 3, 4` `20.00`
SU05 `3` `-5, 10, -2` `3.00`

Failure test cases:

---

Test User input Expected behavior

---

SU06 Number of values = `0` Rejects the choice and
asks for a number
between 1 and 100.

SU07 Number of values = Rejects the choice and
`101` asks again.

SU08 A value is `abc` Rejects that value and
asks the user to enter
it again.

---

---

## 4. Unit Converter

The Unit Converter supports six conversion directions across three unit
pairs.

Choice Conversion Formula

---

`1` Kilometers to Miles `miles = kilometers × 0.621371`
`2` Miles to Kilometers `kilometers = miles ÷ 0.621371`
`3` Celsius to Fahrenheit `fahrenheit = (celsius × 9 / 5) + 32`
`4` Fahrenheit to Celsius `celsius = (fahrenheit - 32) × 5 / 9`
`5` Kilograms to Pounds `pounds = kilograms × 2.20462`
`6` Pounds to Kilograms `kilograms = pounds ÷ 2.20462`
`0` Back to Main Menu Returns to the main menu.

### Unit conversion successful test cases

Test Choice Input value Expected result (approximately)

---

U01 `1` `10` km `6.21` miles
U02 `2` `10` miles `16.09` km
U03 `3` `0` °C `32.00` °F
U04 `3` `100` °C `212.00` °F
U05 `4` `32` °F `0.00` °C
U06 `4` `212` °F `100.00` °C
U07 `5` `10` kg `22.05` lb
U08 `6` `10` lb `4.54` kg
U09 `0` --- Returns to the main menu.

### Unit conversion failure test cases

---

Test User input Expected behavior

---

U10 Conversion choice = `7` Displays an
invalid-choice message
and asks again.

U11 Conversion choice = Rejects the input and
`abc` asks again.

U12 Value = `hello` Rejects the value and
asks again.

U13 Value is empty Rejects the empty input
and asks again.

---

---

## 5. Currency Converter

The Currency Converter supports conversions between:

- USD -- United States Dollar
- ILS -- Israeli New Shekel
- EUR -- Euro

### Fixed exchange rates

The project uses these sample constants:

Rate Value

---

`USD_TO_ILS` `3.70`
`USD_TO_EUR` `0.92`

All monetary values are handled using the `decimal` data type. Results
are displayed with two decimal places.

> These rates are fixed for this assignment and are not updated
> automatically.

### Currency conversion choices

Choice Conversion

---

`1` USD to ILS
`2` ILS to USD
`3` USD to EUR
`4` EUR to USD
`5` ILS to EUR
`6` EUR to ILS
`0` Back to Main Menu

### Currency conversion successful test cases

Test Choice Amount Expected result (approximately)

---

C01 `1` `100 USD` `370.00 ILS`
C02 `2` `370 ILS` `100.00 USD`
C03 `3` `100 USD` `92.00 EUR`
C04 `4` `92 EUR` `100.00 USD`
C05 `5` `370 ILS` `92.00 EUR`
C06 `6` `92 EUR` `370.00 ILS`
C07 `0` --- Returns to the main menu.

### Currency conversion failure test cases

---

Test User input Expected behavior

---

C08 Currency choice = `7` Displays an
invalid-choice message
and asks again.

C09 Currency choice = `abc` Rejects the input and
asks again.

C10 Amount = `one hundred` Rejects the amount and
asks again.

C11 Amount is empty Rejects the empty input
and asks again.

---

---

## 6. Input Validation and Error Handling

The application uses `TryParse` methods to validate numeric input
instead of directly converting user input with methods that may throw
exceptions.

### Number input validation

The `TryReadNumber` helper method:

- Displays a prompt.
- Attempts to parse the input as a `decimal`.
- Displays an error message if parsing fails.
- Repeats until the user enters a valid number.

Example:

```text
Enter First Number: abc
Invalid input. Please enter a valid number.
Enter First Number: 10
```

### Menu choice validation

The `TryReadChoice` helper method:

- Attempts to parse the input as an integer.
- Checks whether the value is within the allowed range.
- Repeats until the user enters a valid choice.

Example:

```text
Enter your choice: 9
Invalid input. Please enter a number between 0 and 6.
Enter your choice: 3
```

### Operation validation

The calculator checks that the entered operation is one of:

`+`, `-`, `*`, `/`, `%`, `^`, or `sum`.

If the user enters an unsupported operation, the application displays an
error and asks again.

### Exception handling

Division by zero and modulus by zero are handled with a friendly error
message. Exceptions are caught so that the application can continue
running instead of terminating unexpectedly.

---

## 7. C# Concepts Demonstrated

---

Concept Where it is used

---

Methods Each calculator operation and each
conversion has its own method.

Method overloading Calculator methods support both
`int` and `decimal` parameters.

`params` `Sum(params decimal[] numbers)`
accepts a variable number of
values.

`out` parameter `TryReadNumber` returns the parsed
number through an `out` parameter.

`TryParse` Validates numeric user input
safely.

`switch` statement Handles the main menu choices.

Switch expressions Select calculator operations and
conversion types.

Optional parameters `Round` uses a default
decimal-place value.

Named arguments `Round(value: result)` calls a
method using a named argument.

`const` Stores fixed currency exchange
rates.

`decimal` Handles currency and decimal
calculations.

`try-catch` Handles calculation errors without
crashing the application.

`do-while` Repeats the main menu until the
user chooses Exit.

Arrays and `foreach` Store and process multiple values
in the Sum operation.

---

---

## 8. Final Test Checklist

Use this checklist before submitting the project:

- [ ] The main menu appears when the application starts.
- [ ] The main menu repeats after completing an operation.
- [ ] Choosing `0` exits the application.
- [ ] All six arithmetic operations work correctly.
- [ ] The Sum bonus accepts multiple values.
- [ ] Division by zero is handled without crashing.
- [ ] Modulus by zero is handled without crashing.
- [ ] All six unit conversion directions work.
- [ ] All six currency conversion directions work.
- [ ] Currency calculations use `decimal`.
- [ ] Currency results display two decimal places.
- [ ] Invalid menu choices are rejected.
- [ ] Invalid numeric input is rejected and requested again.
- [ ] Invalid operation symbols are rejected.
- [ ] The application builds and runs successfully.

**End of Documentation**
