using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    public interface Operator {
    }

    public class AdditionOperator : Operator {
        public override string ToString() {
            return "+";
        }
    }

    public class EqualToOperator : Operator {
        public override string ToString() {
            return "==";
        }
    }

    public class AndOperator : Operator {
        public override string ToString() {
            return "&&";
        }
    }

}
