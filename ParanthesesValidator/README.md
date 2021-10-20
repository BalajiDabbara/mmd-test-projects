
# Parentheses Validator

## Purpose
The purpose of this document is to describe system design and implementation details for the longest valid parentheses finder.

## Problem
#### Find The Longest Valid Parentheses 
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

#### Examples:

##### Example 1
Input: s = "(()"

Output: 2

The longest valid parentheses substring is "()"

##### Example 2
Input: s = ")()())"

Output: 4

The longest valid parentheses substring is "()()".

 
## Scope
To provide design and implementation details on parentheses validator that can find longest length of balanced substring in parentheses string.

## Assumptions
Following assumptions are considered while designing and implementing the app.
- Only parentheses are considered as input.
- Other characters will fail and throw an excpetion.

## Code
This is developed as a console application in .NET Core using C# language by taking the advantage of Microsoft in-built dependency injection container. This has simple algorithm that will return the longest length of valid parentheses from a given input string.


## Design Diagram
### Class Diagram
The below class diagram is generated using Visual Studio 2019 by Class Designer extension.

![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/ParanthesesValidator/ParenthesesValidator/DesignDocs/ParanthesesValidator_ClassDiagram.png?raw=true)


### Code Map Diagram
The following code map diagram shows the calls interaction and dependency between different objects of the application.

|**Arrow Color**| **Category**|
|--|--|
|Green	|Inheritance|
|Pink	|Calls|
|Grey	|References|
|Dotted Green|	Interface|


![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/ParanthesesValidator/ParenthesesValidator/DesignDocs/ParanthesesValidator_CodeMap.png?raw=true)


## Steps To Run Code
Code is deployed into a GitHub repository at the location 
Follow the below steps to run the app
1)	Clone the Git repo
2)	Open Visual Studio 2019 in administration mode.
3)	Open the solution file 
4)	Build the solution
5)	Run the App (Ctrl + F5)
6)  Enter the input string
7)  Longest length of valid parentheses will be printed.



## Testing
ParenthesesValidator can be validated manually or can be tested by unit tests with MsTest framework and evaluated manually by providing input.

### Manual Verification
Please follow below steps to run the conosle application.
- Clone the code from repo
- Run the application
- The application will ask for input
- Provide the input string with parentheses for e.g : ()()()
- The longest lenght will be printed on the console.
- The application will kep on asking for inputs until "exit" is provided.
- This will allow us to test with multiple input strings.


Please find the below screen shot for a sample run.

![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/ParanthesesValidator/ParenthesesValidator/DesignDocs/ParenthesesValidator_Output.png?raw=true)

### Unit Tests
Added unit tests are added in the project 
Following are the different test scenarios added for the function app.
- ValidateLongestLengthOfAllInputWithSequentialBalancedParentheses
- ValidateLongestLengthOfAllInputWithInnerBalancedParentheses
- ValidateLongestLengthOfParanthesesWithStartingOpenParantheses
- ValidateLongestLengthOfParanthesesWithStartingClosedParantheses
- ValidateLongestLengthOfParanthesesWithAllClosedParantheses
- ValidateLongestLengthOfParanthesesWithAllOpenParantheses
- ValidateLongestLengthOfParanthesesForEmptyStringIsZero
- ValidateLongestLengthOfParanthesesForInvalidCharacters
- ValidateLongestLengthOfParanthesesForAlphabets
- ValidateLongestLengthOfParanthesesForInvalidBraces