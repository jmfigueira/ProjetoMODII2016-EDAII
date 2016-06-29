using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossingPenguins
{
    public partial class Crossing : Form
    {
        private OperationForms _operations;

        public Crossing()
        {
            InitializeComponent();
            _operations = new OperationForms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _operations.Solution(txtQuant, pDir, pEsq, pIce, lblCount);
        }

        private void txtQuant_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtQuant.Text))
                _operations.ChangedNumber(pDir, pEsq, pIce, txtQuant);
        }
    }
}
