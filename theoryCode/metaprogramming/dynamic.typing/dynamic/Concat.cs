using System;

namespace TPP.ObjectOrientation.DynamicTyping {

    public static class Concat {
        private static int[] concat(int a, int b) {
            return new int[] { a, b };
        }

        private static int[] concat(int[] a, int b) {
            Array.Resize(ref a, a.Length + 1);
            a[a.Length-1] = b;
            return a;
        }

        private static int[] concat(int a, int[] b) {
            int[] temp = new int[b.Length +1];
            Array.Copy(b, 0, temp, 1, b.Length);
            temp[0] = a;
            return temp;
        }

        private static int[] concat(int[] a, int[] b) {
            int[] temp = new int[a.Length + b.Length];
            Array.Copy(a, temp, a.Length);
            Array.Copy(b, 0, temp, a.Length, b.Length);
            return temp;
        }

        public static int[] dynamicConcat(dynamic a, dynamic b) {
            return concat(a, b);
        }
    }

}
