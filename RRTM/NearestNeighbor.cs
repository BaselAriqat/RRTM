using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class NearestNeighbor
    {
        public int NumberofComputaions;
        protected State states;
        protected Node nodes;

        public NearestNeighbor()
        {
            NumberofComputaions = 0;

        }
        public virtual void setRoot(State root)
        {
        
        }
        public virtual void addNode(Node node)
        { 
            
        }
        public virtual int NumberOfComputations
        {
            set { NumberofComputaions = value; }
            get { return NumberofComputaions; }
        }
        public virtual Node nearest(LinkedList<Node> ALLNODES, State random)
        {
            return new Node();
        }

        public static float dist_fun(State x, State y )  //
        {
            float[] maxs = new float[3];
            maxs[0] = 663;
            maxs[1] = 1121;
            maxs[2] = 360;
            double distances = 0;
            for (int i = 0; i < x.Dimensions.Length; i++)
            {
                if (i == 2)
                {
                    distances += Math.Min(Math.Abs(y.Dimensions[2] - x.Dimensions[2]), Math.Abs(360 - (Math.Abs(y.Dimensions[2] - x.Dimensions[2]))));
                    break;
                }
                 
                distances += Math.Pow((x.Dimensions[i]) - (y.Dimensions[i]), 2);
            }
            distances = Math.Sqrt(distances);
            return (float)distances;

        }
    }

}
