Trying out my first solo TDD coding excercise...
(so I'm not such a newbie at next dojo)

This is from cyber-dojo.com. Exercise: Number Names (spell out a number).

Written in C# using Visual Studio 2010 and Nunit 2.6.2.

Starting point is class Library: NumberSpeller:
1. SpellOutNumberTest.cs
2. Int32Extender.cs

First Iteration was to create test for int = 1 to return "one".
Next tests were:
int = 2 to return "two" (if 1 return "one" else return "two")
int = 0 to return "zero" (this is a special case).
int = negative numbers (throw exception since it isn't clear from spec. what should happen).
Add test cases for other numbers, e.g. 3, 9, 15.
Then add lookup table for numbers 1 - 19.

Second version of code:
Tests for 20, 30, 90, then code to pass (10s lookup table).
Tests for 24, 37, 99, then code to pass (10s lookup + remainder).
Tests for 100, 200, 300, then code to pass (if num < 100 round code above + do hundreds).

Third version of code:
Tests for 310, 2001, 3012, then code to pass (add to 100s code, use "and").
Tests for 3599, 1501, 12609, then code to pass (commas and "and").
Refactor:
Create new class - NumberString - move bulk of code from Int32Extender to new class. Retest to pass.
Remove duplicate code with hundreds and numbers under 20. Retest to pass.
Extract methods for hundreds, thousands and numbers to 20 (not happy with name - but that can be changed later).

And that's how far I've got.


Next iteration would be to test 512607 (from spec.).
Then more tests to make sure commas and "and"s are in the right place.
Then tests for millions, then billions - somewhere here the code would need to be refactored, because of the common code with thousands, millions, billions etc.

Conclusions (so far)
1. This problem was a lot more complicated than I thought it would be to start with.
2. The tests seem very simple though (I guess that's a good thing).
