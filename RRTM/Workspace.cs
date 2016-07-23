using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RRTM
{
    [Serializable]
    class Workspace
    {
        List<Obstacle> obstacles;
        float[] dimensions_;
        State start, goal;
        List<bool> isRect;
        int height, width;
        public Workspace()
        {
            isRect = new List<bool>();
            obstacles = new List<Obstacle>();
            dimensions_ = new float[2];
            start = new State(dimensions_);
            goal = new State(dimensions_);
        }

        public void SetHeightAndWidth(int h, int w)
        {
            height = h;
            width = w;
        }
        
        public void set_goal(float x, float y)
        {
            goal.Dimensions[0] = x;
            goal.Dimensions[1] = y;
        }
        public float[] get_goal()
        {
            return goal.Dimensions;
        }
        public State Goal
        {
            set { goal = value; }
            get { return goal; }
        }
        public State Start
        {
            set { start = value; }
            get { return start; }
        }

        public void set_start(float x, float y)
        {
            x = start.Dimensions[0] = x;
            y = start.Dimensions[1] = y;
        }
        public float[] get_start()
        {
            return start.Dimensions;
        }

        public void add_new_obstacle(Obstacle obs, bool is_rect)
        {
            if (is_rect)
                isRect.Add(true);
            else
                isRect.Add(false);
            obstacles.Add(obs);
        }
        public void Remove_everything()
        {
            obstacles = new List<Obstacle>();
            isRect = new List<bool>();
            dimensions_ = new float[2];
            start = new State(dimensions_);
            goal = new State(dimensions_);
        }
        
        public List<Obstacle> get_obs {
            set { obstacles = value; }
            get { return obstacles; }
        }

        public KeyValuePair<bool,Rectangle> get_obs_at_index(int i)
        {
            return new KeyValuePair<bool,Rectangle> (isRect[i], obstacles[i].getObstacle());
        }


        public int is_valid(int x, int y)
        {


            for (int i = 0; i < obstacles.Count; i++)
                if (obstacles[i].intersects(x,y))
                    return i;
            return -1;
        }


    }
}
