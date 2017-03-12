using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    /// <summary>
    /// Class that models the evaluate multimethod
    /// </summary>
    public static class Multimethod {

        /********************* Addition ****************************/

        private static IntegerExpression Evaluate(IntegerExpression op1, AdditionOperator op, IntegerExpression op2) {
            return new IntegerExpression(op1.Value + op2.Value);
        }

        private static DoubleExpression Evaluate(DoubleExpression op1, AdditionOperator op, IntegerExpression op2) {
            return new DoubleExpression(op1.Value + op2.Value);
        }

        private static DoubleExpression Evaluate(IntegerExpression op1, AdditionOperator op, DoubleExpression op2) {
            return new DoubleExpression(op1.Value + op2.Value);
        }

        private static DoubleExpression Evaluate(DoubleExpression op1, AdditionOperator op, DoubleExpression op2) {
            return new DoubleExpression(op1.Value + op2.Value);
        }

        /********************* EqualTo ****************************/

        private static BoolExpression Evaluate(IntegerExpression op1, EqualToOperator op, IntegerExpression op2) {
            return new BoolExpression(op1.Value == op2.Value);
        }

        private static BoolExpression Evaluate(DoubleExpression op1, EqualToOperator op, IntegerExpression op2) {
            return new BoolExpression((int)(op1.Value) == op2.Value);
        }

        private static BoolExpression Evaluate(IntegerExpression op1, EqualToOperator op, DoubleExpression op2) {
            return new BoolExpression(op1.Value == ((int)op2.Value));
        }

        private static BoolExpression Evaluate(DoubleExpression op1, EqualToOperator op, DoubleExpression op2) {
            return new BoolExpression(op1.Value == op2.Value);
        }

        private static BoolExpression Evaluate(BoolExpression op1, EqualToOperator op, BoolExpression op2) {
            return new BoolExpression(op1.Value == op2.Value);
        }

        /********************* And ****************************/

        private static BoolExpression Evaluate(BoolExpression op1, AndOperator op, BoolExpression op2) {
            return new BoolExpression(op1.Value && op2.Value);
        }

        /********************* The rest of combinations ****************************/

        private static Expression Evaluate(Expression op1, Operator op, Expression op2) {
            throw new ArgumentException(String.Format("The operation ({0} {1} {2}) is not supported.", op1, op, op2));
        }

        /********************* The multimethod ****************************/

        /// <summary>
        /// Multimethod that evaluates to operands of different types with different operators
        /// </summary>
        public static Expression MultimethodEvaluate(dynamic op1, dynamic op, dynamic op2) {
            return Evaluate(op1, op, op2);
        }
    }

}
