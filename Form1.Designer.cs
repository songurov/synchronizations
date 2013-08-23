namespace SynchronizationEbayAccaunt
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btSafe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.tbAccountkfzunion = new System.Windows.Forms.TextBox();
            this.tbPasswordkfzunion = new System.Windows.Forms.TextBox();
            this.tbPasswordatkgmbh = new System.Windows.Forms.TextBox();
            this.tbAccountatkgmbh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPasswordAfterbuy = new System.Windows.Forms.TextBox();
            this.tbAccountAfterbuy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSafe
            // 
            this.btSafe.Location = new System.Drawing.Point(510, 26);
            this.btSafe.Name = "btSafe";
            this.btSafe.Size = new System.Drawing.Size(56, 23);
            this.btSafe.TabIndex = 0;
            this.btSafe.Text = "Safe";
            this.btSafe.UseVisualStyleBackColor = true;
            this.btSafe.Click += new System.EventHandler(this.btSafe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(69, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "kfzunion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(234, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "atkgmbh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Account:";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(429, 80);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 7;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbAccountkfzunion
            // 
            this.tbAccountkfzunion.Location = new System.Drawing.Point(72, 31);
            this.tbAccountkfzunion.Name = "tbAccountkfzunion";
            this.tbAccountkfzunion.Size = new System.Drawing.Size(100, 20);
            this.tbAccountkfzunion.TabIndex = 8;
            this.tbAccountkfzunion.Text = "kfzunion";
            // 
            // tbPasswordkfzunion
            // 
            this.tbPasswordkfzunion.Location = new System.Drawing.Point(72, 56);
            this.tbPasswordkfzunion.Name = "tbPasswordkfzunion";
            this.tbPasswordkfzunion.PasswordChar = '*';
            this.tbPasswordkfzunion.Size = new System.Drawing.Size(100, 20);
            this.tbPasswordkfzunion.TabIndex = 9;
            // 
            // tbPasswordatkgmbh
            // 
            this.tbPasswordatkgmbh.Location = new System.Drawing.Point(236, 54);
            this.tbPasswordatkgmbh.Name = "tbPasswordatkgmbh";
            this.tbPasswordatkgmbh.PasswordChar = '*';
            this.tbPasswordatkgmbh.Size = new System.Drawing.Size(100, 20);
            this.tbPasswordatkgmbh.TabIndex = 11;
            // 
            // tbAccountatkgmbh
            // 
            this.tbAccountatkgmbh.Location = new System.Drawing.Point(236, 28);
            this.tbAccountatkgmbh.Name = "tbAccountatkgmbh";
            this.tbAccountatkgmbh.Size = new System.Drawing.Size(100, 20);
            this.tbAccountatkgmbh.TabIndex = 10;
            this.tbAccountatkgmbh.Text = "atkgmbh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Uptime:";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(339, 82);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(55, 20);
            this.tbTime.TabIndex = 14;
            this.tbTime.Text = "5";
            this.tbTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTime_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "min";
            // 
            // tbPasswordAfterbuy
            // 
            this.tbPasswordAfterbuy.Location = new System.Drawing.Point(404, 54);
            this.tbPasswordAfterbuy.Name = "tbPasswordAfterbuy";
            this.tbPasswordAfterbuy.PasswordChar = '*';
            this.tbPasswordAfterbuy.Size = new System.Drawing.Size(100, 20);
            this.tbPasswordAfterbuy.TabIndex = 20;
            // 
            // tbAccountAfterbuy
            // 
            this.tbAccountAfterbuy.Location = new System.Drawing.Point(404, 28);
            this.tbAccountAfterbuy.Name = "tbAccountAfterbuy";
            this.tbAccountAfterbuy.Size = new System.Drawing.Size(100, 20);
            this.tbAccountAfterbuy.TabIndex = 19;
            this.tbAccountAfterbuy.Text = "atkgmbh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(402, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Afterbuy:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(344, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Account:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(571, 110);
            this.Controls.Add(this.tbPasswordAfterbuy);
            this.Controls.Add(this.tbAccountAfterbuy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPasswordatkgmbh);
            this.Controls.Add(this.tbAccountatkgmbh);
            this.Controls.Add(this.tbPasswordkfzunion);
            this.Controls.Add(this.tbAccountkfzunion);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSafe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Synchronization Ebay Accaunt";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSafe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbAccountkfzunion;
        private System.Windows.Forms.TextBox tbPasswordkfzunion;
        private System.Windows.Forms.TextBox tbPasswordatkgmbh;
        private System.Windows.Forms.TextBox tbAccountatkgmbh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPasswordAfterbuy;
        private System.Windows.Forms.TextBox tbAccountAfterbuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

