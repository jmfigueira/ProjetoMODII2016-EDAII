using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossingPenguins
{
    class OperationForms
    {

        #region Atributos

        private CP cp;
        private List<Button> btns;

        #endregion

        #region Construtor

        public OperationForms()
        {
            cp = new CP();
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Chama o método que realizará a solução
        /// </summary>
        /// <param name="txtQuant"></param>
        /// <param name="pDir"></param>
        /// <param name="pEsq"></param>
        /// <param name="pIce"></param>
        /// <param name="lblCount"></param>
        public void Solution(TextBox txtQuant, Panel pDir, Panel pEsq, Panel pIce, Label lblCount)
        {
            List<char> fList = new List<char>();
            List<char> sList = new List<char>();
            string target = string.Empty;

            for (int i = 0; i < Convert.ToInt32(txtQuant.Text); i++)
            {
                fList.Add('R');
                sList.Add('R');
                target += "LL";
            }
            target += '1';
            string result = cp.Penguins(fList.ToArray(), sList.ToArray(), target);
            cp.Result(cp.InvertSolution(result) + target + ";", pDir, pEsq, pIce, btns, 0);
            lblCount.Text = (result.Split(';').Count() - 1).ToString();
        }
        /// <summary>
        /// Chama a operação de mudar os botões
        /// </summary>
        /// <param name="pDir"></param>
        /// <param name="pEsq"></param>
        /// <param name="pIce"></param>
        /// <param name="txtQuant"></param>
        public void ChangedNumber(Panel pDir, Panel pEsq, Panel pIce, TextBox txtQuant)
        {
            pEsq.Controls.Clear();
            pDir.Controls.Clear();
            pIce.Controls.Clear();
            btns = cp.Paint(pDir, Convert.ToInt32(txtQuant.Text));
        }
        #endregion

    }
}
