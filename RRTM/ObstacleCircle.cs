using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RRTM
{
    [Serializable]
    class ObstacleCircle : Obstacle
    {
        public ObstacleCircle() : base()
        { 
        }
        public ObstacleCircle(Rectangle new_obstacle) : base(new_obstacle)
        {
            obstacle = new_obstacle;
        }
        public override bool intersects(int x, int y)
        {

            float radiusx = obstacle.Width / 2;
            float radiusy = obstacle.Height / 2;


            float[] center = new float[2];
            center[0] = (obstacle.Width/2) + obstacle.X;
            center[1] = (obstacle.Height/2) + obstacle.Y;



            double distance = (Math.Pow((x - center[0]), 2) / Math.Pow(radiusx, 2)) + (Math.Pow(center[1] - y, 2) / Math.Pow(radiusy, 2));
            

            if(distance <= 1)
                return true;
            else 
                return false;
        }
        public override bool intersects(Robot robot)
        {
            return false;
        }
    }
}
