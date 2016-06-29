using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoGrafos.DataStructure;
using CrossingPenguins;
using EP;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace CrossingPenguins
{
    class CP : Graph
    {

        #region Métodos Públicos
        /// <summary>
        /// Retorna uma lista com os passos ultilizados
        /// </summary>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string Penguins(char[] f, char[] s, string target)
        {
            Dictionary<string, bool> Visitados = new Dictionary<string, bool>();
            Graph arvore = new Graph();
            arvore.AddNode(getName(f, s, 1), f, s, 0, 1);
            Node n0 = arvore.Find(getName(f, s, 1));
            PriorityQueue fila = new PriorityQueue();
            fila.Insert(n0);
            Visitados[getName(f, s, 1)] = true;

            while (fila.Count > 0)
            {
                Node n = fila.Remove();
                if (n.Name == target)
                    return BuildResult(n);
                List<Node> vizinhos = GetSucessors(n);
                foreach (Node v in vizinhos)
                {
                    if (!Visitados.ContainsKey(v.Name))
                    {
                        Visitados[v.Name] = true;
                        arvore.AddNode(v.Name, v.Father, v.Son, v.Level, v.Iceberg);
                        arvore.AddEdge(v.Name, n.Name, 1);

                        Node nf = arvore.Find(v.Name);
                        fila.Insert(nf);
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Gera os próximos estados possíveis
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<Node> GetSucessors(Node n)
        {
            int count = 0;
            List<Node> sucessors = new List<Node>();
            Node current = n.Clone();
            for (int i = 0; i < current.Father.Length; i++)
            {
                if (n.Son[i] == 'I')
                    count++;
                if (n.Father[i] == 'I')
                    count++;
            }

            if (count >= 2)
            {
                current.Iceberg = 0;
                current.Name = getName(current.Father, current.Son, current.Iceberg);
                sucessors.Add(current.Clone());
                current = n.Clone();
            }

            for (int i = 0; i < current.Father.Length; i++)
            {
                if (current.Iceberg == 1)
                {
                    if (current.Father[i] == 'R')
                    {
                        current.Father[i] = 'I';
                        if (isValid(current))
                        {
                            current.Name = getName(current.Father, current.Son, current.Iceberg);
                            sucessors.Add(current.Clone());
                        }
                        current = n.Clone();
                    }
                    if (current.Son[i] == 'R')
                    {
                        current.Son[i] = 'I';
                        if (isValid(current))
                        {
                            current.Name = getName(current.Father, current.Son, current.Iceberg);
                            sucessors.Add(current.Clone());
                        }
                        current = n.Clone();
                    }
                }
                else
                {
                    if (current.Father[i] == 'I')
                    {
                        current.Father[i] = 'L';
                        current.Iceberg = 1;
                        if (isValid(current))
                        {
                            current.Name = getName(current.Father, current.Son, current.Iceberg);
                            sucessors.Add(current.Clone());
                        }
                        current = n.Clone();
                    }
                    if (current.Son[i] == 'I')
                    {
                        current.Son[i] = 'L';
                        current.Iceberg = 1;
                        if (isValid(current))
                        {
                            current.Name = getName(current.Father, current.Son, current.Iceberg);
                            sucessors.Add(current.Clone());
                        }
                        current = n.Clone();
                    }
                }

                current.Iceberg = (current.Iceberg == 1) ? 0 : 1;
                if (isValid(current))
                {
                    current.Name = getName(current.Father, current.Son, current.Iceberg);
                    sucessors.Add(current.Clone());
                }
                current = n.Clone();
            }
            return sucessors;
        }
        /// <summary>
        /// Verifica se o nó é válido como sucessor
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool isValid(Node n)
        {
            int count = 0;
            for (int i = 0; i < n.Son.Length; i++)
            {
                if (n.Son[i] == 'I')
                    count++;
                if (n.Father[i] == 'I')
                    count++;
                if (count > 2)
                    return false;

                if (n.Iceberg == 0 && count == 0)
                    return false;

                if (n.Son[i] != n.Father[i])
                {
                    for (int j = 0; j < n.Father.Length; j++)
                    {
                        if (i == j)
                            continue;
                        if (n.Father[j] == n.Son[i])
                            return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Retorna uma string contendo os pais e os filhos para ser o Name do Node
        /// </summary>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public string getName(char[] f, char[] s, int iceberg)
        {
            string name = "";
            foreach (char fa in f)
            {
                name += fa;
            }
            foreach (char so in s)
            {
                name += so;
            }
            return name + ((iceberg == 1) ? '1' : '0');
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Converte o caminho da árvore em uma string
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string BuildResult(Node n)
        {
            string s = "";

            while (n.Edges.Count > 0)
            {
                s += n.Name + ";";
                n = n.Edges[0].To;
            }
            return s;
        }
        #endregion

        #region Interface
        /// <summary>
        /// Realiza a movimentação dos botões conforme o resultado (solução)
        /// </summary>
        /// <param name="result"></param>
        /// <param name="pDir"></param>
        /// <param name="pEsq"></param>
        /// <param name="pIce"></param>
        /// <param name="btns"></param>
        /// <param name="count"></param>
        public void Result(string result, Panel pDir, Panel pEsq, Panel pIce, List<Button> btns, int count)
        {
            if (!string.IsNullOrEmpty(result))
            {
                MoveButton(result.Split(';'), pDir, pEsq, pIce, btns);
            }
        }
        /// <summary>
        /// Mostra os botões na tela
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="qntPeng"></param>
        /// <returns></returns>
        public List<Button> Paint(Panel pn, int qntPeng)
        {
            int ctPai = 1;
            int ctFilho = 1;

            List<Button> lret = new List<Button>();

            for (int i = 0; i < qntPeng * 2; i++)
            {
                Button btn = new System.Windows.Forms.Button();

                if (i < qntPeng)
                {
                    pn.Controls.Add(btn);
                    Point p = new Point { X = btn.Location.X, Y = btn.Location.Y + (i * 50) };
                    btn.Location = p;
                    btn.Name = "PAI " + ctPai;
                    btn.Text = "PAI " + ctPai;
                    btn.Size = new System.Drawing.Size(75, 45);
                    ctPai++;
                }
                else
                {
                    pn.Controls.Add(btn);
                    Point p = new Point { X = btn.Location.X, Y = btn.Location.Y + (i * 50) };
                    btn.Location = p;
                    btn.Name = "FILHO " + ctFilho;
                    btn.Text = "FILHO " + ctFilho;
                    btn.Size = new System.Drawing.Size(75, 45);
                    ctFilho++;
                }
                lret.Add(btn);
            }
            return lret;
        }
        /// <summary>
        /// Movimenta os Buttons entre os Panels
        /// </summary>
        /// <param name="result"></param>
        /// <param name="pDir"></param>
        /// <param name="pEsq"></param>
        /// <param name="pIce"></param>
        /// <param name="btns"></param>
        public void MoveButton(string[] result, Panel pDir, Panel pEsq, Panel pIce, List<Button> btns)
        {
            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    if (result[i].ToString()[j] == 'I')
                    {
                        pDir.Controls.Remove(btns[j]);
                        pIce.Controls.Add(btns[j]);
                        pDir.Update();
                        pDir.Show();
                        pIce.Update();
                        pIce.Show();
                        Thread.Sleep(90);
                    }
                    if (result[i].ToString()[j] == 'L')
                    {
                        pIce.Controls.Remove(btns[j]);
                        pEsq.Controls.Add(btns[j]);
                        pIce.Update();
                        pIce.Show();
                        pEsq.Update();
                        pEsq.Show();
                        Thread.Sleep(90);
                    }
                }
            }
        }

        /// <summary>
        /// Inverte a solução  (Estado Final -> Inicial) para (Inicial -> Estado Final)
        /// </summary>
        /// <param name="Word"></param>
        /// <returns></returns>
        public string InvertSolution(string Word)
        {
            string[] arrChar = Word.Split(';');
            List<string> ls = new List<string>();

            string invertida = string.Empty;

            for (int i = arrChar.Length - 1; i > 0; i--)
            {
                if (!string.IsNullOrEmpty(arrChar[i]))
                    ls.Add(arrChar[i]);
            }
            foreach (var i in ls)
            {
                invertida += i + ";";
            }
            return invertida;
        }
        #endregion

    }
}
