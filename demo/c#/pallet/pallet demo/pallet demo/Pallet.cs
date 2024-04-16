using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pallet_demo
{
    class Pallet
    {


        public Pallet()
        {

        }

        Position p1;
        Position p2;
        Position p3;
        /*
         *                  p1         p2
         *                                  row行数
         *                                   ^
         *                                  |                              
         *                                  |
         *                  p3              --->>>column 列数
         * 
         *                      ROBOT
         * 
         */
        int column_count;
        int row_count;
        
        public void SetPosition1(Position p1)
        {
            this.p1=p1;
        }
        public void SetPosition2(Position p2)
        {
            this.p2 = p2;
        }

        public void SetPosition3(Position p3)
        {
            this.p3 = p3;
        }
        public void setColumnCount(int column_count)
        {
            this.column_count = column_count;
        }

        public void setRowCount(int row_count)
        {
            this.row_count = row_count;
        }
        //编号从1开始
        public Position GetPosition(int row,int column)
        {
            Position row_start = new Position() ;
            row_start.x = p1.x + ((float)(row - 1) / (row_count-1)) * (p3.x - p1.x);
            row_start.y = p1.y + ((float)(row - 1) / (row_count-1)) * (p3.y - p1.y);
            row_start.z = p1.z + ((float)(row - 1) / (row_count-1)) * (p3.z - p1.z);

            Position p = new Position();
            p.x = row_start.x + ((float)(column - 1) / (column_count-1)) * (p2.x - p1.x);
            p.y = row_start.y + ((float)(column - 1) / (column_count-1)) * (p2.y - p1.y);
            p.z = row_start.z + ((float)(column - 1) / (column_count-1)) * (p2.z - p1.z);

            p.r = (p1.r + p2.r + p3.r) / 3;

            return p;
        }

    }








}
   


