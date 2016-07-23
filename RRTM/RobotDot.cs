using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class RobotDot : Robot
    {
        
        public override State GenerateRandomState(int w,int h)
        {
            float[] dimensions = new float[2];
            dimensions[0] = rand.Next(0,w);
            dimensions[1] = rand.Next(0, h);
            return new State(dimensions);
        }

        public override State GetBotPoint()
        {
            return new State(robotBody.Dimensions);
        }
        public override State GetTopPoint()
        {
            return new State(robotBody.Dimensions);
        }
    }
}
