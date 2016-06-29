using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um nó dentro de um grafo.
    /// </summary>
    public class Node
    {

        #region Atributos

        public int Level { get; set; }
        public int Iceberg { get; set; }
        public char[] Son { get; set; }
        public char[] Father { get; set; }
        public int Heuristic { get; set; }

        #endregion

        #region Propriedades
        /// <summary>
        /// O nome do nó dentro do grafo.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A informação adicional armazenada no nó.
        /// </summary>
        public object Info { get; set; }
        /// <summary>
        /// A lista de arcos associada ao nó.
        /// </summary>
        public List<Edge> Edges { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        public Node()
        {
            this.Edges = new List<Edge>();
        }

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <param name="info">A informação armazenada no nó.</param>
        public Node(string name, object info) : this()
        {
            this.Name = name;
            this.Info = info;
        }
        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="name"></param>
        /// <param name="father"></param>
        /// <param name="son"></param>
        /// <param name="level"></param>
        /// <param name="iceberg"></param>
        public Node(string name, char[] father, char[] son, int level, int iceberg) : this()
        {
            this.Name = name;
            this.Father = father;
            this.Son = son;
            this.Level = level;
            this.Iceberg = iceberg;
            CalcHeuristic();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        public void AddEdge(Node to)
        {
            AddEdge(to, 0);
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        /// <param name="cost">O custo associado ao arco.</param>
        public void AddEdge(Node to, double cost)
        {
            this.Edges.Add(new Edge(this, to, cost));
        }
        public Node Clone()
        {
            Node clone = new Node();
            clone.Father = (char[])this.Father.Clone();
            clone.Son = (char[])this.Son.Clone();
            clone.Name = (string)this.Name.Clone();
            clone.Level = this.Level;
            clone.Iceberg = this.Iceberg;
            return clone;
        }
        #endregion

        #region Métodos Privados
        private void CalcHeuristic()
        {
            for (int i = 0; i < this.Father.Length; i++)
            {
                if (Father[i] == 'L')
                    Heuristic += 2;
                if (Son[i] == 'L')
                    Heuristic += 2;
                if (Father[i] == 'I')
                    Heuristic++;
                if (Son[i] == 'I')
                    Heuristic++;
            }
        }
       
        #endregion

        #region Métodos Sobrescritos

        /// <summary>
        /// Apresenta a visualização do objeto em formato texto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.Info != null)
            {
                return String.Format("{0}({1})", this.Name, this.Info);
            }
            return this.Name;
        }

        #endregion

    }
}
