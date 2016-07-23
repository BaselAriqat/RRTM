using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RRTM
{
    [Serializable]
    class Obstacle
    {
         protected Rectangle obstacle;
        public Obstacle()
        { 
        
        }
        public void delete_obstacle()
        {
            obstacle.Height = 0;
            obstacle.Width = 0;
        }
        public Obstacle(Rectangle new_obstacle)
        {
            obstacle = new_obstacle;
        }
        public void add_obstacle(Rectangle new_obstacle)
        {
            obstacle = new_obstacle;
        }

        public Rectangle getObstacle()
        {
            return obstacle;
        }
        public void OBS_MOVE(int x, int y)
        {
            obstacle.X = x;
            obstacle.Y = y;

        }
        public virtual bool intersects(int x, int y)
        {
            if (obstacle.Contains(x, y))
                return true;
            else         
                return false;
        }

        public virtual bool intersects(Robot robot)
        {
            if (obstacle.Contains((int)robot.robotBody.Dimensions[0],(int)robot.robotBody.Dimensions[1]))
                return true;
            else
                return false;
            
        }

    }
}
