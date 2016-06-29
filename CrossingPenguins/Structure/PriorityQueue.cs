using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoGrafos.DataStructure;

namespace EP
{
    public class PriorityQueue: LinkedList<Node>
    {
     
        #region Métodos Públicos
        /// <summary>
        /// Remove um nó da fila e retorna
        /// </summary>
        /// <returns></returns>
        public Node Remove()
        {
            Node n = this.First.Value;
            this.RemoveFirst();
            return n;
        }

        /// <summary>
        /// Insere um novo nó na fila
        /// </summary>
        /// <param name="n"></param>
        public void Insert(Node n)
        {
            bool b = true;
            if (this.Count == 0 || n.Heuristic - n.Level < this.ElementAt(0).Heuristic - this.ElementAt(0).Level)
                this.AddFirst(n);
            else
            {
                LinkedListNode<Node> p = this.First;
                while (p != null)
                {
                    if (n.Heuristic - n.Level <= p.Value.Heuristic - p.Value.Level)
                    {
                        b = false;
                        this.AddAfter(p, n);
                        return;
                    }
                    if (p.Next == null)
                        break;
                    p = p.Next;
                }
                if (b)
                    this.AddLast(n);
            }
        }
        #endregion

    }
}
