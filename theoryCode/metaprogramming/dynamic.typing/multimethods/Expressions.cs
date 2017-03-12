using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    public interface Expression {
    }

    public class IntegerExpression: Expression {
        public int Value { get; private set; }
        public IntegerExpression(int value) {
            this.Value = value;
        }
        public override string ToString() {
            return String.Format("Integer({0})", this.Value);
        }
    }

    public class DoubleExpression : Expression {
        public double Value { get; private set; }
        public DoubleExpression(double value) {
            this.Value = value;
        }
        public override string ToString() {
            return String.Format("Double({0})", this.Value);
        }
    }

    public class BoolExpression : Expression {
        public bool Value { get; private set; }
        public BoolExpression(bool value) {
            this.Value = value;
        }
        public override string ToString() {
            return String.Format("Bool({0})", this.Value);
        }
    }

}
