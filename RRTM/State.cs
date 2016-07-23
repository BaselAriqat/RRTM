using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
     
    [Serializable]
    class State
    {

        float [] dimensions_;
        public State()
        {
            
        }
        public State(int d)
        {
            dimensions_ = new float[d];
        }
        public State(float[] ds)
        {
            dimensions_ = ds;
        }
        
        public float[] Dimensions
        {
            get { return dimensions_; }
            set { dimensions_ = value; }
        }

        public void setDimensionAtIndex(int index, float val)
        {
            dimensions_[index] = val;
        }
       
    }
}
