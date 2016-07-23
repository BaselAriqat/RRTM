using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class KDTreeNN : NearestNeighbor
    {
        KDTree tree;

        public KDTreeNN()
        {
            tree = new KDTree();
        }
        public override int NumberOfComputations
        {
            get
            {
                NumberofComputaions = tree.num_of_NN_computations;
                return base.NumberOfComputations;
            }
            set
            {
                NumberofComputaions = tree.num_of_NN_computations;
            }
        }
        public override void setRoot(State Root)
        {
            tree.Root = new KDNode(new Node(null,Root));
        }
        public override void addNode(Node node)
        {
            tree.Insert(node, tree.Root, 0);
        }
        public override Node nearest(LinkedList<Node> ALLNODES, State random)
        {
            Node nearest = tree.nearest(random, tree.Root, 0);
            
            return nearest;
        }
    }
}
