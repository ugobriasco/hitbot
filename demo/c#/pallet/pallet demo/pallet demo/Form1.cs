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
using System.Threading;
using Newtonsoft.Json;

namespace pallet_demo
{
    public partial class Form1 : Form
    {

        Pallet pallet_from;
        Pallet pallet_to;
        public ControlBeanEx robot;
        GlobalParameter global;

        public Form1()
        {
            InitializeComponent();
            pallet_from = new Pallet();
            pallet_to = new Pallet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpserverEx.net_port_initial();
            sync_config();
            btn_resume_pause.Enabled = false;
            timer1.Interval = 100;
            timer1.Start();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    for(int i = 1; i < 12; i++)
        //    {
        //        for(int j = 1; j < 12; j++)
        //        {
        //           Position p= pallet_from.GetPosition(i, j);
        //            Console.Write("(" + i.ToString() + "," + j.ToString() + ") : ");
        //            Console.WriteLine(p.x.ToString() + "," + p.y.ToString() + "," + p.z.ToString() + "," + p.r.ToString() + ",");

        //        }
        //    }


        //}

        private void btn_debug_robot_Click(object sender, EventArgs e)
        {
            DebugForm debugForm = new DebugForm(this);
            debugForm.Show();

        }

        private void combox_robot_list_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
        }

        private void btn_refresh_robot_Click(object sender, EventArgs e)
        {
            IList<int> connectDeviceList = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                if (TcpserverEx.card_number_connect(i) == 1)
                {

                    connectDeviceList.Add(i);
                }
            }
            this.combox_robot_list.DataSource = connectDeviceList;
        }

        private void btn_initial_robot_Click(object sender, EventArgs e)
        {

            
            int id=(int)combox_robot_list.SelectedItem;
            robot = TcpserverEx.get_robot(id);
            int ret=robot.initial(1, 210);
            if (ret != 1)
            {
                et_log.AppendText("机械臂初始化失败，返回值 = " + ret.ToString() + "\r\n");

            }
            else
            {
                robot.unlock_position();
                robot.set_catch_or_release_accuracy(0.5f);
                MessageBox.Show("初始化成功");
            }

        }

        private void btn_read_config_file_Click(object sender, EventArgs e)
        {
            sync_config();
        }

        private void sync_config()
        {
            //读取配置文件
            try
            {
                string config = ConfigHelp.read_config_file();
                global = JsonConvert.DeserializeObject<GlobalParameter>(config);
                //取料盘
                pallet_from.SetPosition1(global.P1_for_pallet_from);
                pallet_from.SetPosition2(global.P2_for_pallet_from);
                pallet_from.SetPosition3(global.P3_for_pallet_from);
                pallet_from.setRowCount(global.Row_count_for_pallet_from);
                pallet_from.setColumnCount(global.Column_count_for_pallet_from);

                //取料盘
                pallet_to.SetPosition1(global.P1_for_pallet_to);
                pallet_to.SetPosition2(global.P2_for_pallet_to);
                pallet_to.SetPosition3(global.P3_for_pallet_to);
                pallet_to.setRowCount(global.Row_count_for_pallet_to);
                pallet_to.setColumnCount(global.Column_count_for_pallet_to);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                global = new GlobalParameter();
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                robot.get_scara_param();
                if (robot.initial_finish)
                {
                      process_index = 0;
                      btn_start.Enabled = false;
                      btn_resume_pause.Enabled = true;
                      robot_error = false;
                      resume = true;
                }
                else
                {
                    MessageBox.Show("机械臂未初始化");
                }
             
            }

        }


        bool start = true;
        bool resume = false;
        bool process = false;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (start)
            {


            
                if (resume&&robot_error==false)
                {
                    if (process == false)
                    {
                         process_switch();
                    }
                 

                }
                lb_current_pallet_from_row_index.Text = pallet_from_row_index.ToString();
                lb_current_pallet_from_column_index.Text = pallet_from_column_index.ToString();
                lb_current_pallet_to_row_index.Text = pallet_to_row_index.ToString();
                lb_current_pallet_to_column_index.Text = pallet_to_column_index.ToString();



            }

        }
        //主循环定时器
        int process_index = 0;

        /*
         *  =0  安全位置
         *  
         *  =1  取料盘上方
         *  
         *  =2  取料
         *  
         *  =3 取料盘上方
         *  
         *  =4 测试位上方
         *  
         *  =5 测试位
         *  
         *  =6 输出测试到位信号
         *  
         *  =7 等待测试完成型号
         *  
         *  =8 测试位上方
         *  
         *  =9 放料位上方
         *  
         *  =10 放料位
         *  
         *  =11 放料位上方
         *  
         *  =101 急停
         * 
         */


        bool allow_move = true;
        bool robot_error = false;
        int pallet_from_row_index = 1;
        int pallet_from_column_index = 1;

        int pallet_to_row_index = 1;
        int pallet_to_column_index = 1;

        private void process_switch()
        {
            process = true;
            switch (process_index)
            {
                case 0:
                    robot.get_scara_param();
                    if(allow_move)
                    {
                        int ret1=robot.movej_angle(60, -120, robot.z, robot.rotation,100, 1) ;
                        int ret2=robot.movej_angle(60, -120,-100, 0, 100, 1);
                        if (ret1 == 1 && ret2 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = "+process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + " ret2 = " + ret2.ToString() + "\r\n");
                            robot_error = true ;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }



                    break;
                case 1:

                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_from.GetPosition(pallet_from_row_index, pallet_from_column_index);
                        int ret1 = robot.movel_xyz(p.x-global.Dis_for_pallet_from,p.y,p.z,p.r,global.Xy_speed);
                      
                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }



                    break;
                case 2:

                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_from.GetPosition(pallet_from_row_index, pallet_from_column_index);
                        int ret1 = robot.movel_xyz(p.x,  p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }

                    break;
                case 3:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_from.GetPosition(pallet_from_row_index, pallet_from_column_index);
                        int ret1 = robot.movel_xyz(p.x - global.Dis_for_pallet_from, p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                       if(robot_move_over())
                        {
                            pallet_from_column_index++;
                            if (pallet_from_column_index == global.Column_count_for_pallet_from + 1)
                            {
                                pallet_from_column_index = 1;
                                pallet_from_row_index++;
                            }

                            if (pallet_from_row_index == global.Row_count_for_pallet_from + 1)
                            {
                                pallet_from_row_index = 1;
                            }


                        }
                    }

                    break;
                case 4:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = global.P_for_check;
                        int ret1 = robot.movel_xyz(p.x - global.Dis_for_check, p.y, p.z, p.r, global.Xy_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }
                    break;
                case 5:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = global.P_for_check;
                        int ret1 = robot.movel_xyz(p.x , p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }
                    break;
                    //输出测试信号
                case 6:
                    robot.set_digital_out(0, true);
                    Thread.Sleep(50);
                    process_index++;

                    break;
                    //等待测试完成信号
                case 7:

                    //if (robot.get_digital_in(0) == true)
                    //{
                    //    process_index++;
                    //}
                    Thread.Sleep(100);
                    process_index++;
                    robot.set_digital_out(0, false);

                    break;
                case 8:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = global.P_for_check;
                        int ret1 = robot.movel_xyz(p.x - global.Dis_for_check, p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }
                    break;
                case 9:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_to.GetPosition(pallet_to_row_index, pallet_to_column_index);
                        int ret1 = robot.movel_xyz(p.x-global.Dis_for_pallet_to, p.y, p.z, p.r, global.Xy_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }
                    break;
                case 10:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_to.GetPosition(pallet_to_row_index, pallet_to_column_index);
                        int ret1 = robot.movel_xyz(p.x, p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        if (robot_move_over())
                        {
                            pallet_to_column_index++;
                            if (pallet_to_column_index == global.Column_count_for_pallet_to + 1)
                            {
                                pallet_to_column_index = 1;
                                pallet_to_row_index++;
                            }

                            if (pallet_to_row_index == global.Row_count_for_pallet_to + 1)
                            {
                                pallet_to_row_index = 1;
                            }


                        }
                    }
                    break;
                case 11:
                    robot.get_scara_param();
                    if (allow_move)
                    {
                        Position p = pallet_to.GetPosition(pallet_to_row_index, pallet_to_column_index);
                        int ret1 = robot.movel_xyz(p.x - global.Dis_for_pallet_to, p.y, p.z, p.r, global.Z_speed);

                        if (ret1 == 1)
                        {
                            allow_move = false;
                            robot_error = false;

                        }
                        else
                        {
                            et_log.AppendText("process_index = " + process_index.ToString() + "工序异常，机械臂返回值 " + " ret1 =" + ret1.ToString() + "\r\n");
                            robot_error = true;
                        }
                    }
                    else
                    {
                        robot_move_over();
                    }
                    break;

                case 101:
                    robot.pause_move();
                    robot.stop_move();

                    break;


            }
            process = false;

        }
        private bool robot_move_over()
        {
            int ret;
            for (int i= 1; i < 5; i++){
                ret=robot.get_joint_state(i);
                if (ret != 1 && ret != 4)
                {
                    et_log.AppendText("机械臂异常：" + ret.ToString());
                    robot_error = true;
                    return false;
                }
               
            }


            robot.get_scara_param();
            if (robot.move_flag == false)
            {
                Thread.Sleep(100);
                process_index++;
                if (process_index == 12)
                {
                    process_index=0;
                }
                allow_move = true;
                return true;

            }

            return false;

        }

        
        //急停
        private void button2_Click(object sender, EventArgs e)
        {
            process_index = 101;
            Thread.Sleep(1000);
            btn_start.Enabled = true;
            btn_resume_pause.Enabled = false;
            resume = false;
            
        }

        private void btn_resume_pause_Click(object sender, EventArgs e)
        {
            resume = !resume;
            if (resume == true)
            {
                btn_resume_pause.Text = "暂停运行";
            }
            else
            {
                btn_resume_pause.Text = "恢复运行";

            }
            if (robot == null)
            {
                MessageBox.Show("机械臂未实例化");

            }
            //else
            //{
            //    robot.wait_stop();
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            robot_error = false;
            et_log.Clear();
        }

        private void btn_pallet_from_clear_Click(object sender, EventArgs e)
        {
             pallet_from_row_index = 1;
             pallet_from_column_index = 1;

   
        }

        private void btn_pallet_to_clear_Click(object sender, EventArgs e)
        {
             pallet_to_row_index = 1;
             pallet_to_column_index = 1;
        }
    }
}
