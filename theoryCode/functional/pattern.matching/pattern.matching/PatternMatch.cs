using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.PatternMatching {

    /// <summary>
    /// This class models a pattern match expression
    /// </summary>
    /// <typeparam name="ElementType">The type of the elmento to be checked in the pattern match expression</typeparam>
    /// <typeparam name="ReturnType">The type to be returned in the pattern match expression</typeparam>
    public class PatternMatchExpression<ElementType, ReturnType> {

        /// <summary>
        /// List of alternatives stores for this pattern match expression.
        /// They are ordered, keeping the insertion order.
        /// </summary>
        private IList<PatternMatchItem<ElementType,ReturnType>> alternatives = 
                        new List<PatternMatchItem<ElementType,ReturnType>>();

        /// <summary>
        /// The expression against we pattern match
        /// </summary>
        private ElementType element;

        public PatternMatchExpression(ElementType element) {
            this.element = element;
        }

        /// <summary>
        /// Method to add a new alternative in the pattern match expression
        /// </summary>
        /// <param name="guard">Condition to be fulfilled to run the corresponding action.</param>
        /// <param name="action">The action to be executed if the condition (guard) is true.</param>
        public PatternMatchExpression<ElementType,ReturnType> With(Predicate<ElementType> guard, 
                                        Func<ElementType,ReturnType> action) {
            this.alternatives.Add(new PatternMatchItem<ElementType,ReturnType>(guard, action));
            return this;
        }

        /// <summary>
        /// Method that evaluates the pattern match expression
        /// </summary>
        /// <returns>The retured value of the first action that fulfills its guard is true.</returns>
        public ReturnType Evaluate() {
            foreach (var alternative in this.alternatives)
                if (alternative.Guard(element))
                    return alternative.Action(element);
            throw new NotFoundPatternException("Incomplete pattern");
        }

    }

}
