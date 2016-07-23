using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class KDNode
    {
        Node value_;
        KDNode left;
        KDNode right;
        public KDNode()
        {

        }
       
        public KDNode(Node node)
        {
            value_ = node;
        }
        

           
        public Node Value
        {
            get { return value_; }
            set { value_ = value; }
        }
        public KDNode Left
        {
            get { return left; }
            set { left = value; }
        }
        public KDNode Right
        {
            get { return right; }
            set { right = value; }
        }


    }
}
