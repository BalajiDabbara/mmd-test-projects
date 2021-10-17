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

        /// <summary>
        /// ExpressionEvaluator constructo.
        /// </summary>
        public ExpressionEvaluator()
        {
            listOperators = OperatorFactory.GetAllOperators();
        }
        private int GetOperatorPrecedence(char inputChar)
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
            int number = 0;

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

        /// <summary>
        /// Processs closing paranthesis.
        /// </summary>
        /// <param name="operandStack">The operand stack.</param>
        /// <param name="operatorStack">The operator stack.</param>
        private void EvaluateClosingParanthesis(Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
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

        /// <summary>
        /// Processes operators
        /// </summary>
        /// <param name="arOperator">The operator character.</param>
        /// <param name="operandStack">The operand stack.</param>
        /// <param name="operatorStack">The operator stack</param>
        private void EvaluateOperator(char arOperator, Stack<ExprTreeNode> operandStack, Stack<char> operatorStack)
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

        /// <summary>
        /// Builds expression tree.
        /// </summary>
        /// <param name="infixExpr">The infix expression.</param>
        /// <param name="memoryResult">The memory result</param>
        /// <returns>Expression tree root.</returns>
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
                    EvaluateMemoryResult(infixExpr, memoryResult, operandStack);
                }
                else if (CalculatorHelper.IsNumber(infixExpr[idx]))
                {
                    idx = EvaluateOperandNumber(infixExpr, idx, operandStack);
                }
                else if (CalculatorHelper.IsClosingParenthesis(infixExpr[idx]))
                {
                    EvaluateClosingParanthesis(operandStack, operatorStack);
                }
                else if (CalculatorHelper.IsOperator(infixExpr[idx]))
                {
                    EvaluateOperator(infixExpr[idx], operandStack, operatorStack);
                }
                else
                {
                    throw new Exception("Exception occurred. Please verify the input expression.");
                }

            }
            return operandStack.Peek();
        }

        /// <summary>
        /// To evaluate expression tree
        /// </summary>
        /// <param name="exprTree">Expression tree</param>
        /// <returns>Evaluated result</returns>
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

        /// <summary>
        /// To evaluate infix expressions
        /// </summary>
        /// <param name="postFixExpression">The post fix expression</param>
        /// <param name="memoryResult">The memory result</param>
        /// <returns>Evaluated result</returns>
        public long EvaluateInfixExpression(string infixExpression, long memoryResult)
        {
            ExprTreeNode exprTree = BuildExpressionTree(infixExpression, memoryResult);
            return EvaluateExpressionTree(exprTree);
        }
    }
}
