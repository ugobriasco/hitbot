namespace hitbot_demo_for_csharp
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
            this.btn_initial_robot1 = new System.Windows.Forms.Button();
            this.btn_initial_robot2 = new System.Windows.Forms.Button();
            this.btn_robot1_move = new System.Windows.Forms.Button();
            this.btn_robot2_move = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_initial_robot1
            // 
            this.btn_initial_robot1.Location = new System.Drawing.Point(148, 79);
            this.btn_initial_robot1.Name = "btn_initial_robot1";
            this.btn_initial_robot1.Size = new System.Drawing.Size(196, 71);
            this.btn_initial_robot1.TabIndex = 0;
            this.btn_initial_robot1.Text = "初始化机械臂1";
            this.btn_initial_robot1.UseVisualStyleBackColor = true;
            this.btn_initial_robot1.Click += new System.EventHandler(this.btn_initial_robot1_Click);
            // 
            // btn_initial_robot2
            // 
            this.btn_initial_robot2.Location = new System.Drawing.Point(493, 79);
            this.btn_initial_robot2.Name = "btn_initial_robot2";
            this.btn_initial_robot2.Size = new System.Drawing.Size(196, 71);
            this.btn_initial_robot2.TabIndex = 0;
            this.btn_initial_robot2.Text = "初始化机械臂2";
            this.btn_initial_robot2.UseVisualStyleBackColor = true;
            this.btn_initial_robot2.Click += new System.EventHandler(this.btn_initial_robot2_Click);
            // 
            // btn_robot1_move
            // 
            this.btn_robot1_move.Location = new System.Drawing.Point(148, 225);
            this.btn_robot1_move.Name = "btn_robot1_move";
            this.btn_robot1_move.Size = new System.Drawing.Size(196, 77);
            this.btn_robot1_move.TabIndex = 1;
            this.btn_robot1_move.Text = "机械臂1各个关节回零";
            this.btn_robot1_move.UseVisualStyleBackColor = true;
            this.btn_robot1_move.Click += new System.EventHandler(this.btn_robot1_move_Click);
            // 
            // btn_robot2_move
            // 
            this.btn_robot2_move.Location = new System.Drawing.Point(493, 227);
            this.btn_robot2_move.Name = "btn_robot2_move";
            this.btn_robot2_move.Size = new System.Drawing.Size(196, 77);
            this.btn_robot2_move.TabIndex = 1;
            this.btn_robot2_move.Text = "机械臂2各个关节回零";
            this.btn_robot2_move.UseVisualStyleBackColor = true;
            this.btn_robot2_move.Click += new System.EventHandler(this.btn_robot2_move_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 446);
            this.Controls.Add(this.btn_robot2_move);
            this.Controls.Add(this.btn_robot1_move);
            this.Controls.Add(this.btn_initial_robot2);
            this.Controls.Add(this.btn_initial_robot1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_initial_robot1;
        private System.Windows.Forms.Button btn_initial_robot2;
        private System.Windows.Forms.Button btn_robot1_move;
        private System.Windows.Forms.Button btn_robot2_move;
    }
}

