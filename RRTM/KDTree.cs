using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class KDTree 
    {
        KDNode root;
        float bestDistance;
        KDNode guess;
        int Num_of_NN_computations;
        public KDTree()
        {
            num_of_NN_computations = 0;
            bestDistance = float.PositiveInfinity;
        }
        
        public KDNode Root
        {
            set { root = value; }
            get { return root; }
        }

        public int num_of_NN_computations
        {
            set { Num_of_NN_computations = value; }
            get { return Num_of_NN_computations; }
        }
        public void Rebuild()
        {
            List<KDNode> SortedByX = new List<KDNode>();
            //IComparer<KDNode> comparer = new IComparer<KDNode>();
            
        }
        public KDNode Insert(Node point, KDNode t, int CurrnetDimension)
        {
            guess = null;
            if (t == null)
            {
                t = new KDNode(point);
            }
            else if (point == t.Value)
            {
                return t;
            }
            else if (point.State_.Dimensions[CurrnetDimension] < t.Value.State_.Dimensions[CurrnetDimension])
            {
                t.Left = Insert(point, t.Left, (CurrnetDimension + 1) % point.State_.Dimensions.Length);//point.State_.Dimensions.Length
            }
            else if (point.State_.Dimensions[CurrnetDimension] > t.Value.State_.Dimensions[CurrnetDimension])
            {
                t.Right = Insert(point, t.Right, (CurrnetDimension + 1) %point.State_.Dimensions.Length );//point.State_.Dimensions.Length
            }
            return t;
        }

        public void nearestGuess(State RandomPoint, KDNode t, int currentDimension)
        {
            float calculated_distance;
            if (t == null)
                return;
            // If the current location is better than the best known location,update the best known location.
            Num_of_NN_computations++;
           calculated_distance = NearestNeighbor.dist_fun(RandomPoint, t.Value.State_);
            if (calculated_distance < bestDistance)
            {
                bestDistance = calculated_distance;
                guess = t;
            }
            bool isleft = false; ;
            // Recursively search the half of the tree that contains the test point.
            if (RandomPoint.Dimensions[currentDimension] <= t.Value.State_.Dimensions[currentDimension])
            {
                isleft = true;
                nearestGuess(RandomPoint, t.Left, (currentDimension + 1) % t.Value.State_.Dimensions.Length); //t.Value.State_.Dimensions.Length
            }
            else
            {

                nearestGuess(RandomPoint, t.Right, (currentDimension + 1) % t.Value.State_.Dimensions.Length);//t.Value.State_.Dimensions.Length

            }
            
        

            if (Math.Abs(RandomPoint.Dimensions[currentDimension] - t.Value.State_.Dimensions[currentDimension]) < bestDistance)
            {
                if (isleft)
                {
                    nearestGuess(RandomPoint, t.Right, (currentDimension + 1) %t.Value.State_.Dimensions.Length);
                }
                else
                {
                    nearestGuess(RandomPoint, t.Left, (currentDimension + 1) %t.Value.State_.Dimensions.Length);
                }
            }
        }
        public Node nearest(State RandomPoint, KDNode t, int currentDimension)
        {
            nearestGuess(RandomPoint, t, currentDimension);
            bestDistance = float.PositiveInfinity;
          
            return guess.Value;
        }
        

    }
}
