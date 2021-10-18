using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Expression evaluator
    /// </summary>
    class ExpressionEvaluator : IExpressionEvaluator
    {
        private OperationEvaluator operationEvaluator = new OperationEvaluator();
        ExprTreeNode operatorNode, leftOperandNode, rightOperandNode;
        List<Operator> listOperators = new List<Operator>();
        private ILogger logger;

        /// <summary>
        /// ExpressionEvaluator constructo.
        /// </summary>
        public ExpressionEvaluator()
        {
            listOperators = OperatorFactory.GetAllOperators();
        }

        public ExpressionEvaluator(ILogger logger)
        {
            this.logger = logger;
            listOperators = OperatorFactory.GetAllOperators();

        }
        private OperationPrecedence GetOperatorPrecedence(char inputChar)
        {
            Operator arOperator = listOperators.FirstOrDefault(op => op.OperatorChar == inputChar);
            return arOperator != null ? arOperator.OperatorPrecedence : 0;
        }

        /// <summary>
        /// Process numbers.
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="idx"></param>
        /// <param name="nodeStack"></param>
        /// <returns></returns>
        private int EvaluateOperandNumber(string expr, int idx, Stack<ExprTreeNode> nodeStack)
        {
            long number = 0;

            while (idx < expr.Length && CalculatorHelper.IsNumber(expr[idx]))
            {
                number = 10 * number + CalculatorHelper.GetNumberFromChar(expr[idx++]);
            }

            nodeStack.Push(new ExprTreeNode(number.ToString()));

            return --idx;
        }
        private void EvaluateMemoryResult(string expr, long memoryResult, Stack<ExprTreeNode> nodeStack)
        {
            nodeStack.Push(new ExprTreeNode(memoryResult.ToString()));
        }

        private bool IsStackOperatorPrecedenceGreaterOrEqual(char stackOperatorChar, char currentOperatorChar)
        {
            Operator stackOperator = listOperators.FirstOrDefault(op => op.OperatorChar == stackOperatorChar);
            Operator currentOperator = listOperators.FirstOrDefault(op => op.OperatorChar == currentOperatorChar);
            int compareResult = stackOperator.OperatorPrecedence.CompareTo(currentOperator.OperatorPrecedence);
            return compareResult >= 0;
        }

        private void ConstructExprTreeNode(Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
        {
            operatorNode = new ExprTreeNode(CalculatorHelper.GetStringFromChar(operatorStack.Peek()));
            operatorStack.Pop();

            rightOperandNode = operandStack.Peek();
            operandStack.Pop();

            leftOperandNode = operandStack.Peek();
            operandStack.Pop();

            operatorNode.left = leftOperandNode;
            operatorNode.right = rightOperandNode;

            operandStack.Push(operatorNode);
        }
        /// <summary>
        /// Processs closing paranthesis.
        /// </summary>
        /// <param name="operandStack">The operand stack.</param>
        /// <param name="operatorStack">The operator stack.</param>
        private void EvaluateClosingParanthesis(Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
        {
            while (operatorStack.Count != 0 && !CalculatorHelper.IsOpeningParenthesis(operatorStack.Peek()))
            {
                ConstructExprTreeNode(operandStack, operatorStack);
            }
            operatorStack.Pop();
        }

        /// <summary>
        /// Processes operators
        /// </summary>
        /// <param name="arOperator">The operator character.</param>
        /// <param name="operandStack">The operand stack.</param>
        /// <param name="operatorStack">The operator stack</param>
        private void EvaluateOperator(char arOperator, Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
        {
            while (operatorStack.Count != 0 && !CalculatorHelper.IsOpeningParenthesis(operatorStack.Peek()) 
                    && IsStackOperatorPrecedenceGreaterOrEqual(operatorStack.Peek(), arOperator))
            {
                ConstructExprTreeNode(operandStack, operatorStack);
            }

            operatorStack.Push(arOperator);
        }

        /// <summary>
        /// Builds expression tree.
        /// </summary>
        /// <param name="infixExpr">The infix expression.</param>
        /// <param name="memoryResult">The memory result</param>
        /// <returns>Expression tree root.</returns>
        private ExprTreeNode BuildExpressionTree(string infixExpr, long memoryResult)
        {
            logger.LogInformation("BuildExpressionTree() : Start");
            Stack<ExprTreeNode> operandStack = new Stack<ExprTreeNode>();
            Stack<char> operatorStack = new Stack<char>();

            // Scan the input expression and build expression tree.
            for (int idx = 0; idx < infixExpr.Length; idx++)
            {
                // If character is whitespace move forward.
                if (CalculatorHelper.IsOpeningWhiteSpace(infixExpr[idx]))
                {
                    continue;
                }

                // If character is opening paranthesis push it into operator stack
                if (CalculatorHelper.IsOpeningParenthesis(infixExpr[idx]))
                {
                    operatorStack.Push(infixExpr[idx]);
                }
                else if (CalculatorHelper.IsMemoryRecall(infixExpr[idx]))
                {
                    // If character is memory recall push the number into operand stack
                    EvaluateMemoryResult(infixExpr, memoryResult, operandStack);
                }
                else if (CalculatorHelper.IsNumber(infixExpr[idx]))
                {
                    // If the character is number means it is beginnig of the number.
                    // Hence, get the full number and push the number into operand stack
                    idx = EvaluateOperandNumber(infixExpr, idx, operandStack);
                }
                else if (CalculatorHelper.IsClosingParenthesis(infixExpr[idx]))
                {
                    // If character is closing paranthesis then process the operator stack to construct a expression tree and push it to operand stack.
                    // until opening paranthesis is encountere or stack is empty.
                    EvaluateClosingParanthesis(operandStack, operatorStack);
                }
                else if (CalculatorHelper.IsOperator(infixExpr[idx]))
                {
                    // If character is operator then process the operator stack and construct expression tree
                    // until less precedence operator is encountered or stack is empty.
                    EvaluateOperator(infixExpr[idx], operandStack, operatorStack);
                }
                else
                {
                    throw new InvlalidExpressionException("Please verify the input expression.");
                }

            }
            logger.LogInformation("BuildExpressionTree() : End");
            return operandStack.Peek();
        }

        /// <summary>
        /// To evaluate expression tree
        /// </summary>
        /// <param name="exprTree">Expression tree</param>
        /// <returns>Evaluated result</returns>
        private long EvaluateExpressionTree(ExprTreeNode exprTree)
        {
            logger.LogInformation("EvaluateExpressionTree() : Start");

            long result = 0;

            if (exprTree != null)
            {
                string dataValue = exprTree.data;
                if (CalculatorHelper.IsNumber(dataValue[0]))
                {
                    return long.Parse(dataValue);
                }

                long leftOperand = EvaluateExpressionTree(exprTree.left);
                long rightOperand = EvaluateExpressionTree(exprTree.right);

                Operator arOperator = listOperators != null ? OperatorFactory.GetOperator(listOperators, dataValue[0], leftOperand, rightOperand)
                                                            : OperatorFactory.GetOperator(dataValue[0], leftOperand, rightOperand);
                result = arOperator.ExecuteOperation();
            }

            logger.LogInformation("EvaluateExpressionTree() : End");
            logger.LogInformation("EvaluateInfixExpression() : End");
            return result;
        }

        /// <summary>
        /// To evaluate infix expressions
        /// </summary>
        /// <param name="postFixExpression">The post fix expression</param>
        /// <param name="memoryResult">The memory result</param>
        /// <returns>Evaluated result</returns>
        public long EvaluateInfixExpression(string infixExpression, long memoryResult)
        {
            logger.LogInformation("EvaluateInfixExpression() : Start");
            ExprTreeNode exprTree = BuildExpressionTree(infixExpression, memoryResult);
            return EvaluateExpressionTree(exprTree);
        }
    }
}
