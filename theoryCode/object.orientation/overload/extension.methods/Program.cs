using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.ObjectOrientation.Overload {

    class Program {

        static void Main(string[] args) {
            string paragraph = @"
                The W3C mission is to lead the World Wide Web to its full 
                potential by developing protocols and guidelines that ensure 
                the long-term growth of the Web. 
                Below we discuss important aspects of this mission, all of 
                which further W3C's vision of One Web.
        ";
            Console.WriteLine("The paragraph has {0} words.", paragraph.CountWords());
        }
    }


}
