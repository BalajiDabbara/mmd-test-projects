using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// Operator factory calss
    /// </summary>
    public static class OperatorFactory
    {
        /// <summary>
        /// Get all operators
        /// </summary>
        /// <returns>List of operators</returns>
        public static List<Operator> GetAllOperators()
        {

            Type type = Assembly.GetExecutingAssembly().GetType();

            List<Operator> listOperators = new List<Operator>();
            Operator arithmeticOperator = null;

            foreach (Type Type in Assembly.GetAssembly(typeof(Operator))
                .GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Operator))))
            {

                arithmeticOperator = (Operator)Activator.CreateInstance(Type);
                listOperators.Add(arithmeticOperator);
            }

            if (listOperators != null && listOperators.Count >= 0)
                return listOperators;
            else
                return null;
        }
        /// <summary>
        /// Get operator object based on input char and operands.
        /// </summary>
        /// <param name="operatorToken">The operator character.</param>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns></returns>
        public static Operator GetOperator(char operatorToken, long leftOperand, long rightOperand)
        {

            Type type = Assembly.GetExecutingAssembly().GetType();

            List<Operator> listOperators = new List<Operator>();
            Operator arithmeticOperator = null;

            foreach (Type Type in Assembly.GetAssembly(typeof(Operator))
                .GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Operator))))
            {

                arithmeticOperator =  (Operator)Activator.CreateInstance(Type, leftOperand, rightOperand);
                listOperators.Add(arithmeticOperator);
            }

            if (listOperators != null && listOperators.Count >= 0)
                return listOperators.FirstOrDefault(op => op.OperatorChar == operatorToken);
            else
                return null; 
        }

        /// <summary>
        /// Get operator from list of available operator based on input char and operands.
        /// </summary>
        /// <param name="listOperators">The list of operators</param>
        /// <param name="operatorToken">The operator character.</param>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns></returns>
        public static Operator GetOperator(List<Operator> listOperators, char operatorToken, long leftOperand, long rightOperand)
        {

            Type type = Assembly.GetExecutingAssembly().GetType();
            Operator arithmeticOperator = listOperators.FirstOrDefault(op => op.OperatorChar == operatorToken);

            arithmeticOperator = (Operator)Activator.CreateInstance(arithmeticOperator.GetType(), leftOperand, rightOperand);

            return arithmeticOperator != null ? arithmeticOperator : null;
        }
    }
}
