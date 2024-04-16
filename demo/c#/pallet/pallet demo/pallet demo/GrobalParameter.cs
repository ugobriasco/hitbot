using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pallet_demo
{
    class GlobalParameter
    {


        public GlobalParameter()
        {
            this.P1_for_pallet_from = new Position();
            this.P2_for_pallet_from = new Position();
            this.P3_for_pallet_from = new Position();
            this.P1_for_pallet_to = new Position();
            this.P2_for_pallet_to = new Position();
            this.P3_for_pallet_to = new Position();
            this.P_for_check = new Position();


        }
        public float Dis_for_pallet_from { get; set; }//取料距离

        public float Dis_for_pallet_to { get; set; } //放料距离

        public float Dis_for_check { get; set; } //测试距离

        public float Z_speed { get; set; }//上下速度

        public float Xy_speed { get; set; }//水平速度

        public int Row_count_for_pallet_from { get; set; }//取料盘行数
   
        public int Column_count_for_pallet_from { get; set; }//取料盘列数


        public int Row_count_for_pallet_to { get; set; }//放料盘行数


        public int Column_count_for_pallet_to { get; set; }//放料盘列数

        public Position P1_for_pallet_from { get; set; }
        public Position P2_for_pallet_from { get; set; }
        public Position P3_for_pallet_from { get; set; }

        public Position P1_for_pallet_to { get; set; }
        public Position P2_for_pallet_to { get; set; }
        public Position P3_for_pallet_to { get; set; }

        public Position P_for_check { get; set; }




    }
}
