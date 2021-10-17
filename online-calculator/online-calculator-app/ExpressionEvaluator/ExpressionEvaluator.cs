using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCalculatorApp
{
    class ExpressionEvaluator : IExpressionEvaluator
    {
        private OperationEvaluator operationEvaluator = new OperationEvaluator();
        ExprTreeNode operatorNode, leftOperandNode, rightOperandNode;
        List<Operator> listOperators = new List<Operator>();

        public ExpressionEvaluator()
        {
            listOperators = OperatorFactory.GetAllOperators();
        }
        private int GetOperatorPrecedence(char inputChar)
        {
            Operator arOperator = listOperators.FirstOrDefault(op => op.OperatorChar == inputChar);
            return arOperator != null ? arOperator.OperatorPrecedence : 0;
        }
        private int ProcessOperand(string expr, int idx, Stack<ExprTreeNode> nodeStack)
        {
            int number = 0;
            while (idx < expr.Length && CalculatorHelper.IsNumber(expr[idx]))
            {
                number = 10 * number + CalculatorHelper.GetNumberFromChar(expr[idx++]);
            }

            nodeStack.Push(new ExprTreeNode(number.ToString()));

            return --idx;
        }
        private void ProcessMemoryResult(string expr, long memoryResult, Stack<ExprTreeNode> nodeStack)
        {
            nodeStack.Push(new ExprTreeNode(memoryResult.ToString()));
        }
        private void ProcessClosingParanthesis(Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
        {
            while (operatorStack.Count != 0 && !CalculatorHelper.IsOpeningParenthesis(operatorStack.Peek()))
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

            operatorStack.Pop();
        }

        private void ProcessOperator(char arOperator, Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
        {
            while (operatorStack.Count != 0 && !CalculatorHelper.IsOpeningParenthesis(operatorStack.Peek())
                          && GetOperatorPrecedence(operatorStack.Peek()) >= GetOperatorPrecedence(arOperator))
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

            operatorStack.Push(arOperator);
        }
        private ExprTreeNode BuildExpressionTree(string infixExpr, long memoryResult)
        {
            Stack<ExprTreeNode> operandStack = new Stack<ExprTreeNode>();
            Stack<char> operatorStack = new Stack<char>();


            for (int idx = 0; idx < infixExpr.Length; idx++)
            {
                if (CalculatorHelper.IsOpeningWhiteSpace(infixExpr[idx]))
                {
                    continue;
                }

                if (CalculatorHelper.IsOpeningParenthesis(infixExpr[idx]))
                {
                    operatorStack.Push(infixExpr[idx]);
                }
                else if (CalculatorHelper.IsMemoryRecall(infixExpr[idx]))
                {
                    ProcessMemoryResult(infixExpr, memoryResult, operandStack);
                }
                else if (CalculatorHelper.IsNumber(infixExpr[idx]))
                {
                    idx = ProcessOperand(infixExpr, idx, operandStack);
                }
                else if (CalculatorHelper.IsClosingParenthesis(infixExpr[idx]))
                {
                    ProcessClosingParanthesis(operandStack, operatorStack);
                }
                else if (CalculatorHelper.IsOperator(infixExpr[idx]))
                {
                    ProcessOperator(infixExpr[idx], operandStack, operatorStack);
                }
                else
                {
                    throw new Exception("Exception occurred. Please verify the input expression.");
                }

            }
            return operandStack.Peek();
        }

        private long EvaluateExpressionTree(ExprTreeNode exprTree)
        {
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

            return result;
        }
        public long EvaluateInfixExpression(string infixExpression, long memoryResult)
        {
            ExprTreeNode exprTree = BuildExpressionTree(infixExpression, memoryResult);
            return EvaluateExpressionTree(exprTree);
        }
    }
}
