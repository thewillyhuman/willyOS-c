using System;
using System.IO;

namespace TPP.ObjectOrientation.DynamicTyping {

    class Program {

        static void Main() {
            Expression[] expressions = new Expression[] { new IntegerExpression(3), new DoubleExpression(4.3), new BoolExpression(true) };
            Operator[] operators = new Operator[] { new AdditionOperator(), new EqualToOperator(), new AndOperator() };
            foreach (Operator op in operators)
                foreach (Expression op1 in expressions)
                    foreach (Expression op2 in expressions) {
                        Expression result = null;
                        try {
                            Multimethod.MultimethodEvaluate(op1, op, op2);
                        } catch (ArgumentException) {
                            // operation not supported (result == null)
                        }
                        Console.WriteLine("{0} {1} {2} = {3}", op1, op, op2, result);
                    }
        }

    }
}
