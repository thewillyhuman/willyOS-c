using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaSesion01 {
	interface IPila {
		void Push(Object element);
		Object Pop();
		void PilaIsNull();
		void PilaLLena();
		void PilaVacia();
	}
}
