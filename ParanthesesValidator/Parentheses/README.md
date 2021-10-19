
# Online Calculator Function App

## Purpose
The purpose of this document is to describe system design and implementation details for Longest Valid Parentheses validator.

## Problem
Find the Longest Valid Parentheses 
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Examples:

Input: s = "(()"
Output: 2
The longest valid parentheses substring is "()"
 
Input: s = ")()())"
Output: 4
The longest valid parentheses substring is "()()".

 
## Scope
To provide design and implementation details on parentheses validator that can find longest length of balanced substring.

## Assumptions
Following assumptions are considered while designing and implementing the app.



## Design Diagram
### Class Diagram
The below class diagram is generated using Visual Studio 2019 by Class Designer extension.



### Code Map Diagram
The following code map diagram shows the call interaction and dependency between different objects of the application.

|**Arrow Color**| **Category**|
|--|--|
|Green	|Inheritance|
|Pink	|Calls|
|Grey	|References|
|Dotted Green|	Interface|



### Sequence Diagram
The sequence of actions between the objects while evaluation expression is depicted in the below sequence diagram.


## Steps To Run Code
Code is deployed into a GitHub repository at the location 
Follow the below steps to run the app
1)	Clone the Git repo
2)	Open Visual Studio 2019 in administration mode.
3)	Open the solution file 
4)	Build the solution
5)	Run the App (Ctrl + F5)
6)	Local function app will be started.
7)	Test using Postman or any other API tester.

## Extensibility
This app is designed which can be extended further in the future. The following operations are not supported in the current implementation and can be extended.

## Testing
Online Calculator App  is tested by unit tests with xUnit framework and evaluated the API using Postman.

### Unit Tests
Added unit tests are added in the project 
Following are the different test scenarios added for the function app.

## Limitations

