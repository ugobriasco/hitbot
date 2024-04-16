using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pallet_demo
{
    class Position
    {
        public float x;
        public float y;
        public float z;
        public float r;

        public Position()
        {

        }
        public Position(float x,float y,float z,float r)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = r;
        }

    }
}
