using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPP.ObjectOrientation.Reflection {

    public partial class FormFunction : Form {
        public FormFunction() {
            InitializeComponent();
        }

        public double From { get; private set; }
        public double To { get; private set; }
        public double Increment { get; private set; }
        public string FunctionBody { get; private set; }

        private void ButtonAccept_Click(object sender, EventArgs e) {
            this.From = Convert.ToDouble(this.textBoxFrom.Text);
            this.To = Convert.ToDouble(this.textBoxTo.Text);
            this.Increment = Convert.ToDouble(this.textBoxIncrement.Text);
            this.FunctionBody = this.textBoxFunctionBody.Text;
            this.Close();
        }
    }
}
