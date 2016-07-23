using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class Node
    {
        State state;
        Node parent;
        
        public Node()
        {
            //state = new State();
           // parent = new Node();
        }
        public Node(Node p, State state_)
        {
            parent = p;
            state = state_;
        }
        public Node(State s)
        {
            state = s;
        }
        public Node Parent 
        {
            get { return parent; }
            set { parent = value; }
        }

        public State State_
        {
            get { return state; }
            set { state = value; }
        }

        

    }
}
