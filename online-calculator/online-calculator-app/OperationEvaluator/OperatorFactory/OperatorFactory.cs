using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineCalculator
{
    public static class OperatorFactory
    {
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

        public static Operator GetOperator(List<Operator> listOperators, char operatorToken, long leftOperand, long rightOperand)
        {

            Type type = Assembly.GetExecutingAssembly().GetType();
            Operator arithmeticOperator = listOperators.FirstOrDefault(op => op.OperatorChar == operatorToken);

            arithmeticOperator = (Operator)Activator.CreateInstance(arithmeticOperator.GetType(), leftOperand, rightOperand);

            return arithmeticOperator != null ? arithmeticOperator : null;
        }
    }
}
