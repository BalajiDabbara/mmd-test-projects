
# Online Calculator Function App

## Purpose
The purpose of this document is to describe system design and implementation details for Online Calculator.

## Problem
Provide system design for an Online Calculator. The Online Calculator should support:
1. Parsing complex arithmetic expressions e.g. (4+2) x 4 / 2.
2. Should support Memory Save and Recall e.g. <MR> + 3. 
3. Memory Save should persist across sessions.
4. Memory save for one user should not be visible to other users.
 
## Scope
To provide design and implementation details on online calculator that can evaluate a simple infix expression and provides basic support for session and memory management. 

## Design Diagram
### Class Diagram
The below class diagram is generated using Visual Studio 2019 by Class Designer extension.

![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/OnlineCalculator/OnlineCalculatorApp/Images/OnlineCalculator_ClassDiagram_Collapsed.png?raw=true)

### Code Map Diagram
The following code map diagram shows the call interaction and dependency between different objects of the application.

|**Arrow Color**| **Category**|
|--|--|
|Green	|Inheritance|
|Pink	|Calls|
|Grey	|Return|
|Dotted Green|	Interface|


![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/OnlineCalculator/OnlineCalculatorApp/Images/OnlineCalculatorApp_CodeMap_Diagram.png?raw=true)

### Sequence Diagram
The sequence of actions between the objects while evaluation expression is depicted in the below sequence diagram.

![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/OnlineCalculator/OnlineCalculatorApp/Images/OnlineCalculatorApp_Sequence_Diagram.png?raw=true)

## Steps To Run Code
Code is deployed into a GitHub repository at the location  [OnlineCalculator](https://github.com/BalajiDabbara/mmd-test-projects/tree/main/OnlineCalculator)

Follow the below steps to run the app
1)	Clone the Git repo
2)	Open Visual Studio 2019 in administration mode.
3)	Open the solution file (\OnlineCalculator\Online Calculator App \Online Calculator App .sln)
4)	Build the solution
5)	Run the App (Ctrl + F5)
6)	Local function app will be started.
7)	Test using Postman or any other API tester.

## Extensibility
This app is designed which can be extended further in the future. The following operations are not supported in the current implementation and can be extended.
- Implemented to be extended to different type of operators.
- Advanced calculator.
- Custom logger for telemetry logging.
- Unary operator
- Double digit operators.
- User level authentication.
- On-demand Save
- Multi-level Save.
- Dependence injection container.
- Durable function app.
- Memory clear.
- Advanced Session management.

## Deployment
The Online Calculator App function app is deployed in Azure cloud as a Function App.

## Testing
Online Calculator App  is tested by unit tests with xUnit framework and evaluated the API using Postman.

### Unit Tests
Added unit tests are added in the project Online Calculator App .Tests
Following are the different test scenarios added for the function app.
1)	ValidateInfixExpressionEvaluationSuccess
2)	ValidateInfixExpressionEvaluationFailedOnInvalidInput
3)	ValidateInfixExpressionEvaluationSuccesssOnAllOperators
4)	ValidateEmptyUserNameThrowsAnError
5)	ValidateMemoryRecall
6)	ValidateOperationOnMemoryRecall
7)	ValidateMemoryRecallForDifferentUsers

### Manual Verification
Online Calculator App API functionality can be validated using Postman. The URL and request body to be passed for the request should be as shown below.

|**Parameter** |**Input**|
|--|--|
| Function App URL| [Deployed Function App](https://onlinecalculatorapp.azurewebsites.net/api/OnlineCalculator_Evaluate)|
| Content Type |JSON |
| Request Body |`{ "UserName": "Balaji", "InfixExpression": "(((2+2)*4/2+2))*10/5*2*100"}`|
| Response |Hello, Balaji. Your input expression ((((2+2)*4/2+2))*10/5*2*100) has been evaluated to : 4000. |

The results can be found as shown below.
#### Success

![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/OnlineCalculator/OnlineCalculatorApp/Images/Evaluate_Success.PNG?raw=true)

#### Failure


![alt text](https://github.com/BalajiDabbara/mmd-test-projects/blob/main/OnlineCalculator/OnlineCalculatorApp/Images/Evaluate_Failure.PNG?raw=true)

## Limitations
Online Calculator App has following limitations.
- Two or more letter operators are not supported (e.g.: ++, --, log, sin, cos).
- This is not extendable to double, float. Should be impleted with Generics.
- Can't support multiple types of braces are not supported like {, [ etc.
- Can't support  multiple expression validations.


