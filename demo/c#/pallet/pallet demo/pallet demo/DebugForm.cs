using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace pallet_demo
{
    public partial class DebugForm : Form
    {
        //步长
        List<RadioButton> step_list;
        float[] step;
        //速度
        List<RadioButton> speed_list;
        float[] speed;
        Form1 parent;
        int move_retvalue;
        GlobalParameter global;

        public DebugForm(Form parent)
        {
            InitializeComponent();
            this.parent = (Form1)parent;
            timer1.Interval = 100;
            timer1.Start();
            

        }
        private void DebugForm_Load(object sender, EventArgs e)
        {
            //步长
            step_list = new List<RadioButton>();
            step_list.Add(rd_step_1);
            step_list.Add(rd_step_2);
            step_list.Add(rd_step_3);
            step_list.Add(rd_step_4);
            step_list.Add(rd_step_5);
            step = new float[5];
            step[0] = 0.1f;
            step[1] = 1f;
            step[2] = 10f;
            step[3] = 50f;
            step[4] = 100f;
            //速度

            speed_list = new List<RadioButton>();
            speed_list.Add(rd_speed1);
            speed_list.Add(rd_speed2);
            speed_list.Add(rd_speed3);
            speed_list.Add(rd_speed4);
            speed_list.Add(rd_speed5);
            speed = new float[5];
            speed[0] = 10f;
            speed[1] = 50f;
            speed[2] = 100f;
            speed[3] = 150f;
            speed[4] = 200f;


           
            //读取配置文件
            try
            {
                string config = ConfigHelp.read_config_file();
                global = JsonConvert.DeserializeObject<GlobalParameter>(config);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                global = new GlobalParameter();
            }
            //绑定数据到控件；
            et_save_dis_for_pallet_from.Text = global.Dis_for_pallet_from.ToString();
            et_save_dis_for_pallet_to.Text = global.Dis_for_pallet_to.ToString();
            et_save_dis_for_pallet_check.Text = global.Dis_for_check.ToString();

            et_z_speed.Text = global.Z_speed.ToString();
            et_xy_speed.Text = global.Xy_speed.ToString();

            et_save_row_count_for_pallet_from.Text = global.Row_count_for_pallet_from.ToString();
            et_save_column_count_for_pallet_from.Text = global.Column_count_for_pallet_from.ToString();

            et_save_row_count_for_pallet_to.Text = global.Row_count_for_pallet_to.ToString();
            et_save_column_count_for_pallet_to.Text = global.Column_count_for_pallet_to.ToString();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private float get_step()
        {
            int i = 0;
            foreach(RadioButton rd in step_list)
            {
                if (rd.Checked)
                {
                    return step[i]; 
                }
                i++;
            }

            return 1;
        }

        private float get_speed()
        {
            int i = 0;
            foreach (RadioButton rd in speed_list)
            {
                if (rd.Checked)
                {
                    return speed[i];
                }
                i++;
            }

            return 1;
        }


        //return 1 movej return 2 movel
        private int get_move_mode()
        {
            if (rd_movel.Checked)
            {
                return 1;
            }else
            {
                return 2;
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (parent.robot == null)
            {
                return;
            }
            parent.robot.get_scara_param();
            string robot_state = "";
            robot_state += "x : " + parent.robot.x.ToString()+"   ";
            robot_state += "y : " + parent.robot.y.ToString() + "   ";
            robot_state += "z : " + parent.robot.z.ToString() + "   ";
            robot_state += "r : " + parent.robot.rotation.ToString() + "   ";

            robot_state += "connect : " + parent.robot.communicate_success.ToString() + "   ";
            robot_state += "initial : " + parent.robot.initial_finish.ToString() + "   ";

            robot_state += "mvoe_ret : " + move_retvalue.ToString() + "   ";



            lb_robot_current_position.Text = robot_state;


        }
        //btn_x_plus
        private void button6_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= 1;
            move_to_target_by_offset(step, 0, 0, 0); 

        }


        private int move_to_target_by_offset(float x_offset,float y_offset, float z_offset,float r_offset)
        {

            int move_mode = get_move_mode();
            parent.robot.get_scara_param();
            float speed = get_speed();
            int ret = 0;
            if (move_mode == 1)
            {
                ret =parent.robot.movej_xyz(parent.robot.x + x_offset, parent.robot.y + y_offset, parent.robot.z + z_offset, parent.robot.rotation + r_offset, speed, 0);
            }else
            {
                ret = parent.robot.movel_xyz(parent.robot.x + x_offset, parent.robot.y + y_offset, parent.robot.z + z_offset, parent.robot.rotation + r_offset, speed);

            }
            move_retvalue = ret;
            return ret;

        }

        private void btn_y_plus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= 1;
            move_to_target_by_offset(0, step, 0, 0);

        }

        private void btn_z_plus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= 1;
            move_to_target_by_offset(0, 0,step, 0);

        }

        private void btn_r_plus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= 1;
            move_to_target_by_offset(0, 0, 0, step);
        }

        private void btn_x_minus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= -1;
            move_to_target_by_offset(step, 0, 0, 0);
        }

        private void btn_y_minus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= -1;
            move_to_target_by_offset(0, step, 0, 0);
        }

        private void btn_z_minus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= -1;
            move_to_target_by_offset(0, 0, step, 0);
        }

        private void btn_r_minus_Click(object sender, EventArgs e)
        {
            float step = get_step();
            step *= -1;
            move_to_target_by_offset(0, 0, 0, step);
        }
        //换手
        private void button15_Click(object sender, EventArgs e)
        {
            int ret=parent.robot.change_attitude(100);
           
            move_retvalue = ret;
           
        }

        private void btn_save_dis_for_pallet_from_Click(object sender, EventArgs e)
        {

            try
            {
                global.Dis_for_pallet_from = float.Parse(et_save_dis_for_pallet_from.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());

                MessageBox.Show("保存失败");
            }

        }

        private void btn_save_dis_for_pallet_to_Click(object sender, EventArgs e)
        {
           
            try
            {
                global.Dis_for_pallet_to = float.Parse(et_save_dis_for_pallet_to.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_dis_for_check_Click(object sender, EventArgs e)
        {
           
            try
            {
                global.Dis_for_check = float.Parse(et_save_dis_for_pallet_check.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                MessageBox.Show("保存失败");
            }
        }

        private void btn_z_speed_Click(object sender, EventArgs e)
        {
            
            try
            {
                global.Z_speed = float.Parse(et_z_speed.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_xy_speed_Click(object sender, EventArgs e)
        {
            try
            {
                global.Xy_speed = float.Parse(et_xy_speed.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_row_count_for_pallet_from_Click(object sender, EventArgs e)
        {
            try
            {
                global.Row_count_for_pallet_from = int.Parse(et_save_row_count_for_pallet_from.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_column_count_for_pallet_from_Click(object sender, EventArgs e)
        {
            try
            {
                global.Column_count_for_pallet_from = int.Parse(et_save_column_count_for_pallet_from.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_row_count_for_pallet_to_Click(object sender, EventArgs e)
        {
            
            try
            {
                global.Row_count_for_pallet_to = int.Parse(et_save_row_count_for_pallet_to.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_column_count_for_pallet_to_Click(object sender, EventArgs e)
        {
            try
            {
                global.Column_count_for_pallet_to = int.Parse(et_save_column_count_for_pallet_to.Text.ToString());
                string json = JsonConvert.SerializeObject(global);
                ConfigHelp.save_config_file(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private Position get_robot_current_position()
        {
            Position p=null;
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
               
            }
            else
            {
                parent.robot.get_scara_param();
                if (parent.robot.initial_finish)
                {
                    p = new Position();
                    p.x = parent.robot.x;
                    p.y = parent.robot.y;
                    p.z = parent.robot.z;
                    p.r = parent.robot.rotation;
                }

            }
            return p;
        }
        private void btn_save_p1_for_pallet_from_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P1_for_pallet_from = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }

        }

        private void btn_save_p2_for_pallet_from_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P2_for_pallet_from = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_p3_for_pallet_from_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P3_for_pallet_from = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_p1_for_pallet_to_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P1_for_pallet_to = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_p2_for_pallet_to_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P2_for_pallet_to = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_p3_for_pallet_to_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P3_for_pallet_to = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void btn_save_p1_for_check_position_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = get_robot_current_position();
                if (p != null)
                {
                    global.P_for_check = p;
                    string json = JsonConvert.SerializeObject(global);
                    ConfigHelp.save_config_file(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("保存失败");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private int move_to_target(float x, float y, float z, float r)
        {

            parent.robot.get_scara_param();
            int ret = 0;
            ret = parent.robot.movel_xyz(x, y, z, r, get_speed());
            move_retvalue = ret;
            return ret;

        }
        private void btn_to_pallet_from_p1_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P1_for_pallet_from.y, global.P1_for_pallet_from.z, global.P1_for_pallet_from.r);
            }
        }

  

        private void btn_to_pallet_from_p2_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P2_for_pallet_from.y, global.P2_for_pallet_from.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_from_p3_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P3_for_pallet_from.y, global.P3_for_pallet_from.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_to_p1_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P1_for_pallet_to.y, global.P1_for_pallet_to.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_to_p2_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P2_for_pallet_to.y, global.P2_for_pallet_to.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_to_p3_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P3_for_pallet_to.y, global.P3_for_pallet_to.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_check_p_forward_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(parent.robot.x, global.P_for_check.y, global.P_for_check.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_from_p1_Click_1(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P1_for_pallet_from.x , global.P1_for_pallet_from.y, global.P1_for_pallet_from.z, global.P1_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_from_p2_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P2_for_pallet_from.x, global.P2_for_pallet_from.y, global.P2_for_pallet_from.z, global.P2_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_from_p3_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P3_for_pallet_from.x, global.P3_for_pallet_from.y, global.P3_for_pallet_from.z, global.P3_for_pallet_from.r);
            }
        }

        private void btn_to_pallet_to_p1_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P1_for_pallet_to.x, global.P1_for_pallet_to.y, global.P1_for_pallet_to.z, global.P1_for_pallet_to.r);
            }
        }

        private void btn_to_pallet_to_p2_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P2_for_pallet_to.x, global.P2_for_pallet_to.y, global.P2_for_pallet_to.z, global.P2_for_pallet_to.r);
            }
        }

        private void btn_to_pallet_to_p3_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P3_for_pallet_from.x, parent.robot.y, parent.robot.z, parent.robot.rotation);
            }
        }

        private void btn_to_check_p_Click(object sender, EventArgs e)
        {
            if (parent.robot == null)
            {
                MessageBox.Show("机械臂未实例化");
            }
            else
            {
                parent.robot.get_scara_param();
                move_to_target(global.P_for_check.x, global.P_for_check.y, global.P_for_check.z, global.P_for_check.r);
            }
        }
    }
}