using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.PatternMatching {

    /// <summary>
    /// Each of the alternatives that comprise a pattern match expression
    /// </summary>
    internal class PatternMatchItem<ElementType, ReturnType> {

        internal Predicate<ElementType> Guard { get; private set; }

        internal Func<ElementType,ReturnType> Action { get; private set; }

        internal PatternMatchItem(Predicate<ElementType> guard, Func<ElementType,ReturnType> action) {
            this.Guard = guard;
            this.Action = action;
        }

    }

}
