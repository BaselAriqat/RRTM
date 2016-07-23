using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class NearestNeighborLinear : NearestNeighbor
    {
        public override void addNode(Node node)
        {
            base.addNode(node);
        }
        public override Node nearest(LinkedList<Node> ALLNODES, State random)
        {
            Node nearest_;
            int min_dis;
            float distance;
            nearest_ = new Node();
            min_dis = Int32.MaxValue;
            LinkedList<Node>.Enumerator e = ALLNODES.GetEnumerator();

            while (e.MoveNext())
            {
                NumberofComputaions++;
                distance = dist_fun(e.Current.State_, random);
                if (distance < min_dis)
                {
                    nearest_ = e.Current;
                    min_dis = (int)distance;
                }
            }
            //if (random.Dimensions.Length == 3 && nearest_.State_.Dimensions.Length == 3)
            //    nearest_.State_.Dimensions[2] = Math.Min(Math.Abs(random.Dimensions[2] - nearest_.State_.Dimensions[2]), Math.Abs(360 - (Math.Abs(random.Dimensions[2] - nearest_.State_.Dimensions[2]))));

            return nearest_; 
        }
    }
}
