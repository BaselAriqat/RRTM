using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RRTM
{
    
    class Robot
    {
        protected Random rand;
        State RobotBody;
        float Angle;
        protected float robotheight;
        public Robot()
        {
            robotBody = new State();
            rand = new Random();
        }

        public virtual float RobotHieght
        {
            set { robotheight = value; }
            get { return robotheight; }
        } 
        public virtual State GetTopPoint()
        {
            return new State();
        }

        public virtual State GetBotPoint()
        {
            return new State();
        }

        void calculate_angle(Point p1, Point p2)
        { 
            
        }



        public State robotBody
        {
            set { RobotBody = value; }
            get { return RobotBody; }
        }

        public void PlanNextMove()
        { 
            
        }
        public virtual State GenerateRandomState(int w, int h)
        {
            float[] randomDs = new float[2];
            randomDs[0] = rand.Next(0, 1121);
            randomDs[1] = rand.Next(0, 663);
            return new State(randomDs);
        }
        
            
       


    }
}
