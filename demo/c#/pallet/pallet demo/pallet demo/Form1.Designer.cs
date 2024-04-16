namespace pallet_demo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_initial_robot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_refresh_robot = new System.Windows.Forms.Button();
            this.combox_robot_list = new System.Windows.Forms.ComboBox();
            this.btn_debug_robot = new System.Windows.Forms.Button();
            this.et_log = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_read_config_file = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_current_pallet_from_row_index = new System.Windows.Forms.Label();
            this.lb_current_pallet_from_column_index = new System.Windows.Forms.Label();
            this.lb_current_pallet_to_column_index = new System.Windows.Forms.Label();
            this.lb_current_pallet_to_row_index = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_pallet_from_clear = new System.Windows.Forms.Button();
            this.btn_pallet_to_clear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_resume_pause = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_initial_robot
            // 
            this.btn_initial_robot.Location = new System.Drawing.Point(32, 80);
            this.btn_initial_robot.Name = "btn_initial_robot";
            this.btn_initial_robot.Size = new System.Drawing.Size(98, 30);
            this.btn_initial_robot.TabIndex = 1;
            this.btn_initial_robot.Text = "初始化机械臂";
            this.btn_initial_robot.UseVisualStyleBackColor = true;
            this.btn_initial_robot.Click += new System.EventHandler(this.btn_initial_robot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_refresh_robot);
            this.groupBox1.Controls.Add(this.combox_robot_list);
            this.groupBox1.Controls.Add(this.btn_initial_robot);
            this.groupBox1.Location = new System.Drawing.Point(41, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 190);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机械臂初始化部分";
            // 
            // btn_refresh_robot
            // 
            this.btn_refresh_robot.Location = new System.Drawing.Point(151, 43);
            this.btn_refresh_robot.Name = "btn_refresh_robot";
            this.btn_refresh_robot.Size = new System.Drawing.Size(105, 28);
            this.btn_refresh_robot.TabIndex = 3;
            this.btn_refresh_robot.Text = "刷新链接设备";
            this.btn_refresh_robot.UseVisualStyleBackColor = true;
            this.btn_refresh_robot.Click += new System.EventHandler(this.btn_refresh_robot_Click);
            // 
            // combox_robot_list
            // 
            this.combox_robot_list.FormattingEnabled = true;
            this.combox_robot_list.Location = new System.Drawing.Point(32, 43);
            this.combox_robot_list.Name = "combox_robot_list";
            this.combox_robot_list.Size = new System.Drawing.Size(98, 20);
            this.combox_robot_list.TabIndex = 2;
            this.combox_robot_list.SelectedIndexChanged += new System.EventHandler(this.combox_robot_list_SelectedIndexChanged);
            // 
            // btn_debug_robot
            // 
            this.btn_debug_robot.Location = new System.Drawing.Point(41, 601);
            this.btn_debug_robot.Name = "btn_debug_robot";
            this.btn_debug_robot.Size = new System.Drawing.Size(118, 55);
            this.btn_debug_robot.TabIndex = 3;
            this.btn_debug_robot.Text = "调试界面";
            this.btn_debug_robot.UseVisualStyleBackColor = true;
            this.btn_debug_robot.Click += new System.EventHandler(this.btn_debug_robot_Click);
            // 
            // et_log
            // 
            this.et_log.Location = new System.Drawing.Point(427, 105);
            this.et_log.Multiline = true;
            this.et_log.Name = "et_log";
            this.et_log.Size = new System.Drawing.Size(573, 464);
            this.et_log.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(427, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(573, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_read_config_file
            // 
            this.btn_read_config_file.Location = new System.Drawing.Point(41, 267);
            this.btn_read_config_file.Name = "btn_read_config_file";
            this.btn_read_config_file.Size = new System.Drawing.Size(314, 74);
            this.btn_read_config_file.TabIndex = 6;
            this.btn_read_config_file.Text = "加载运行参数";
            this.btn_read_config_file.UseVisualStyleBackColor = true;
            this.btn_read_config_file.Click += new System.EventHandler(this.btn_read_config_file_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(41, 380);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(314, 74);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "开始运行";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(429, 596);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(125, 12);
            this.label.TabIndex = 8;
            this.label.Text = " 当前取料盘 行索引：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = " 当前取料盘 列索引：";
            // 
            // lb_current_pallet_from_row_index
            // 
            this.lb_current_pallet_from_row_index.AutoSize = true;
            this.lb_current_pallet_from_row_index.Location = new System.Drawing.Point(561, 599);
            this.lb_current_pallet_from_row_index.Name = "lb_current_pallet_from_row_index";
            this.lb_current_pallet_from_row_index.Size = new System.Drawing.Size(41, 12);
            this.lb_current_pallet_from_row_index.TabIndex = 11;
            this.lb_current_pallet_from_row_index.Text = "label2";
            // 
            // lb_current_pallet_from_column_index
            // 
            this.lb_current_pallet_from_column_index.AutoSize = true;
            this.lb_current_pallet_from_column_index.Location = new System.Drawing.Point(766, 599);
            this.lb_current_pallet_from_column_index.Name = "lb_current_pallet_from_column_index";
            this.lb_current_pallet_from_column_index.Size = new System.Drawing.Size(41, 12);
            this.lb_current_pallet_from_column_index.TabIndex = 11;
            this.lb_current_pallet_from_column_index.Text = "label2";
            // 
            // lb_current_pallet_to_column_index
            // 
            this.lb_current_pallet_to_column_index.AutoSize = true;
            this.lb_current_pallet_to_column_index.Location = new System.Drawing.Point(766, 637);
            this.lb_current_pallet_to_column_index.Name = "lb_current_pallet_to_column_index";
            this.lb_current_pallet_to_column_index.Size = new System.Drawing.Size(41, 12);
            this.lb_current_pallet_to_column_index.TabIndex = 14;
            this.lb_current_pallet_to_column_index.Text = "label2";
            // 
            // lb_current_pallet_to_row_index
            // 
            this.lb_current_pallet_to_row_index.AutoSize = true;
            this.lb_current_pallet_to_row_index.Location = new System.Drawing.Point(561, 637);
            this.lb_current_pallet_to_row_index.Name = "lb_current_pallet_to_row_index";
            this.lb_current_pallet_to_row_index.Size = new System.Drawing.Size(41, 12);
            this.lb_current_pallet_to_row_index.TabIndex = 15;
            this.lb_current_pallet_to_row_index.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 637);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = " 当前放料盘 列索引：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 634);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = " 当前放料盘 行索引：";
            // 
            // btn_pallet_from_clear
            // 
            this.btn_pallet_from_clear.Location = new System.Drawing.Point(849, 594);
            this.btn_pallet_from_clear.Name = "btn_pallet_from_clear";
            this.btn_pallet_from_clear.Size = new System.Drawing.Size(112, 23);
            this.btn_pallet_from_clear.TabIndex = 16;
            this.btn_pallet_from_clear.Text = "取料盘 盘空";
            this.btn_pallet_from_clear.UseVisualStyleBackColor = true;
            this.btn_pallet_from_clear.Click += new System.EventHandler(this.btn_pallet_from_clear_Click);
            // 
            // btn_pallet_to_clear
            // 
            this.btn_pallet_to_clear.Location = new System.Drawing.Point(849, 629);
            this.btn_pallet_to_clear.Name = "btn_pallet_to_clear";
            this.btn_pallet_to_clear.Size = new System.Drawing.Size(112, 23);
            this.btn_pallet_to_clear.TabIndex = 16;
            this.btn_pallet_to_clear.Text = "放料盘 盘空";
            this.btn_pallet_to_clear.UseVisualStyleBackColor = true;
            this.btn_pallet_to_clear.Click += new System.EventHandler(this.btn_pallet_to_clear_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Brown;
            this.button2.Location = new System.Drawing.Point(1061, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 504);
            this.button2.TabIndex = 17;
            this.button2.Text = "急停";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_resume_pause
            // 
            this.btn_resume_pause.Location = new System.Drawing.Point(41, 503);
            this.btn_resume_pause.Name = "btn_resume_pause";
            this.btn_resume_pause.Size = new System.Drawing.Size(314, 75);
            this.btn_resume_pause.TabIndex = 18;
            this.btn_resume_pause.Text = "暂停运行";
            this.btn_resume_pause.UseVisualStyleBackColor = true;
            this.btn_resume_pause.Click += new System.EventHandler(this.btn_resume_pause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 691);
            this.Controls.Add(this.btn_resume_pause);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_pallet_to_clear);
            this.Controls.Add(this.btn_pallet_from_clear);
            this.Controls.Add(this.lb_current_pallet_to_column_index);
            this.Controls.Add(this.lb_current_pallet_to_row_index);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_current_pallet_from_column_index);
            this.Controls.Add(this.lb_current_pallet_from_row_index);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_read_config_file);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.et_log);
            this.Controls.Add(this.btn_debug_robot);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_initial_robot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_debug_robot;
        private System.Windows.Forms.ComboBox combox_robot_list;
        private System.Windows.Forms.Button btn_refresh_robot;
        private System.Windows.Forms.TextBox et_log;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_read_config_file;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_current_pallet_from_row_index;
        private System.Windows.Forms.Label lb_current_pallet_from_column_index;
        private System.Windows.Forms.Label lb_current_pallet_to_column_index;
        private System.Windows.Forms.Label lb_current_pallet_to_row_index;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_pallet_from_clear;
        private System.Windows.Forms.Button btn_pallet_to_clear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_resume_pause;
    }
}

