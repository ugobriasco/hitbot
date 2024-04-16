using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpserverExDll;
using ControlBeanExDll;
namespace hitbot_demo_for_csharp
{
    public partial class Form1 : Form
    {
        private ControlBeanEx robot1;
        private ControlBeanEx robot2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpserverEx.net_port_initial();
            robot1 = TcpserverEx.get_robot(211);//替换为自己的机器的id号
            robot2 = TcpserverEx.get_robot(212);//替换为自己的机器的id号
        }

        private void btn_initial_robot1_Click(object sender, EventArgs e)
        {
            if (robot1.is_connected())
            {
              int ret=  robot1.initial(1, 210);//修改自己机器的型号，参数具体意义参考sdk说明文档
                if (ret == 1)
                {
                    robot1.unlock_position();
                    MessageBox.Show(robot1.get_card_num().ToString() + "初始化完成");

                }
                else
                {
                    MessageBox.Show(robot1.get_card_num().ToString() + "初始化失败，返回值 = "+ret.ToString());
                }
            }
            else
            {
                MessageBox.Show(robot1.get_card_num().ToString() + "未连接");
            }
           
        }

        private void btn_initial_robot2_Click(object sender, EventArgs e)
        {
            if (robot2.is_connected())
            {
                int ret = robot2.initial(1, 210);//修改自己机器的型号，参数具体意义参考sdk说明文档
                if (ret == 1)
                {
                    robot2.unlock_position();
                    MessageBox.Show(robot2.get_card_num().ToString() + "初始化完成");

                }
                else
                {
                    MessageBox.Show(robot2.get_card_num().ToString() + "初始化失败，返回值 = " + ret.ToString());
                }
            }
            else
            {
                MessageBox.Show(robot2.get_card_num().ToString() + "未连接");
            }
        }
        
        private void btn_robot1_move_Click(object sender, EventArgs e)
        {
            int ret=robot1.set_position_move(400, 0, 0, 0, 10, 1, 1, 1);
            if (ret != 1)
            {
                MessageBox.Show(robot1.get_card_num().ToString() + "调用set_position_move失败，返回值 = " + ret.ToString());

            }
        }

        private void btn_robot2_move_Click(object sender, EventArgs e)
        {
            int ret = robot2.set_position_move(400, 0, 0, 0, 10, 1, 1, 1);
            if (ret != 1)
            {
                MessageBox.Show(robot2.get_card_num().ToString() + "调用set_position_move失败，返回值 = " + ret.ToString());

            }
            
        }
    }
}
