using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.PatternMatching {

    class NotFoundPatternException: ApplicationException {
        public NotFoundPatternException(string message) :
            base(message) { }
    }

}
