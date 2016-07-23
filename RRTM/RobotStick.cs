using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRTM
{
    class RobotStick : Robot
    {
        
        public override State GenerateRandomState(int w, int h)
        {
            //throw new NotImplementedException();
            float[] dimensions = new float[3];
            dimensions[0] = rand.Next(0, w);
            dimensions[1] = rand.Next(0, h);
            dimensions[2] = rand.Next(0, 360);
            return new State(dimensions);
        }
        

        //public float lengthofrobot
        //{
        //    set { LengthOfRobot = value; }
        //    get { return LengthOfRobot; }
        //}
        public override float RobotHieght
        {
            get
            {
                return robotheight;
            }
            set
            {
                robotheight = value;
            }
        }
        public override State GetTopPoint()
        {

            float[] newdimensions = new float[3];
            float angleinRadians = robotBody.Dimensions[2] * ((float)Math.PI / 180);

            newdimensions[0] = ((float)Math.Cos(angleinRadians) * (robotheight / 2)) + robotBody.Dimensions[0];
            newdimensions[1] = ((float)Math.Sin(angleinRadians) * (robotheight / 2)) + robotBody.Dimensions[1];
            newdimensions[2] = robotBody.Dimensions[2];
            return new State(newdimensions);
        }

        public override State GetBotPoint()
        {

            float[] newdimensions = new float[3];
            float angleinRadians = robotBody.Dimensions[2] * ((float)Math.PI / 180);

            newdimensions[0] = ((float)Math.Cos(angleinRadians) * (-robotheight / 2)) + robotBody.Dimensions[0];
            newdimensions[1] = ((float)Math.Sin(angleinRadians) * (-robotheight / 2)) + robotBody.Dimensions[1];
            newdimensions[2] = robotBody.Dimensions[2];
            return new State(newdimensions);
        }



        public float[] calculateTopBot(bool top)
        {

            float[] newdimensions = new float[3];
            float angleinRadians = robotBody.Dimensions[2] * ((float)Math.PI / 180);
            if (top)
            {
                newdimensions[0] = ((float)Math.Cos(angleinRadians) * (robotheight / 2)) + robotBody.Dimensions[0];
                newdimensions[1] = ((float)Math.Sin(angleinRadians) * (robotheight / 2)) + robotBody.Dimensions[1];
                newdimensions[2] = robotBody.Dimensions[2];
            }
            else
            {
                newdimensions[0] = ((float)Math.Sin(angleinRadians) * (-robotheight / 2)) + robotBody.Dimensions[0];
                newdimensions[1] = ((float)Math.Cos(angleinRadians) * (-robotheight / 2)) + robotBody.Dimensions[1];
                newdimensions[2] = robotBody.Dimensions[2];
            }
            return newdimensions;
        }
    }
}
