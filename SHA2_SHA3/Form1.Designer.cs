namespace SHA2_SHA3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SHA2_224 = new System.Windows.Forms.RadioButton();
            this.SHA2_256 = new System.Windows.Forms.RadioButton();
            this.SHA2_384 = new System.Windows.Forms.RadioButton();
            this.SHA2_512_256 = new System.Windows.Forms.RadioButton();
            this.SHA2_512 = new System.Windows.Forms.RadioButton();
            this.SHA2_512_224 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SHA3_512 = new System.Windows.Forms.RadioButton();
            this.SHA3_224 = new System.Windows.Forms.RadioButton();
            this.SHA3_384 = new System.Windows.Forms.RadioButton();
            this.SHA3_256 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_CalculateHASH = new System.Windows.Forms.Button();
            this.text_input = new System.Windows.Forms.TextBox();
            this.lower_uppercase = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button_saveHASH = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.clear_login = new System.Windows.Forms.Button();
            this.groupBox_Login = new System.Windows.Forms.GroupBox();
            this.CheckbxShowPas_log = new System.Windows.Forms.CheckBox();
            this.groupBox_Signup = new System.Windows.Forms.GroupBox();
            this.CheckbxShowPas_sign = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.clear_signup = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.clear_savedHASH = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Login.SuspendLayout();
            this.groupBox_Signup.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ReadFile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(282, 200);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(297, 66);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OpenFile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(282, 272);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SHA2_224);
            this.groupBox1.Controls.Add(this.SHA2_256);
            this.groupBox1.Controls.Add(this.SHA2_384);
            this.groupBox1.Controls.Add(this.SHA2_512_256);
            this.groupBox1.Controls.Add(this.SHA2_512);
            this.groupBox1.Controls.Add(this.SHA2_512_224);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 128);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SHA-2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Output length (bits)";
            // 
            // SHA2_224
            // 
            this.SHA2_224.AutoSize = true;
            this.SHA2_224.Location = new System.Drawing.Point(6, 48);
            this.SHA2_224.Name = "SHA2_224";
            this.SHA2_224.Size = new System.Drawing.Size(43, 17);
            this.SHA2_224.TabIndex = 12;
            this.SHA2_224.TabStop = true;
            this.SHA2_224.Text = "224";
            this.SHA2_224.UseVisualStyleBackColor = true;
            this.SHA2_224.CheckedChanged += new System.EventHandler(this.SHA2_224_CheckedChanged);
            // 
            // SHA2_256
            // 
            this.SHA2_256.AutoSize = true;
            this.SHA2_256.Location = new System.Drawing.Point(6, 71);
            this.SHA2_256.Name = "SHA2_256";
            this.SHA2_256.Size = new System.Drawing.Size(43, 17);
            this.SHA2_256.TabIndex = 12;
            this.SHA2_256.TabStop = true;
            this.SHA2_256.Text = "256";
            this.SHA2_256.UseVisualStyleBackColor = true;
            this.SHA2_256.CheckedChanged += new System.EventHandler(this.SHA2_256_CheckedChanged);
            // 
            // SHA2_384
            // 
            this.SHA2_384.AutoSize = true;
            this.SHA2_384.Location = new System.Drawing.Point(6, 94);
            this.SHA2_384.Name = "SHA2_384";
            this.SHA2_384.Size = new System.Drawing.Size(43, 17);
            this.SHA2_384.TabIndex = 13;
            this.SHA2_384.TabStop = true;
            this.SHA2_384.Text = "384";
            this.SHA2_384.UseVisualStyleBackColor = true;
            this.SHA2_384.CheckedChanged += new System.EventHandler(this.SHA2_384_CheckedChanged);
            // 
            // SHA2_512_256
            // 
            this.SHA2_512_256.AutoSize = true;
            this.SHA2_512_256.Location = new System.Drawing.Point(112, 94);
            this.SHA2_512_256.Name = "SHA2_512_256";
            this.SHA2_512_256.Size = new System.Drawing.Size(66, 17);
            this.SHA2_512_256.TabIndex = 16;
            this.SHA2_512_256.TabStop = true;
            this.SHA2_512_256.Text = "512/256";
            this.SHA2_512_256.UseVisualStyleBackColor = true;
            this.SHA2_512_256.CheckedChanged += new System.EventHandler(this.SHA2_512_256_CheckedChanged);
            // 
            // SHA2_512
            // 
            this.SHA2_512.AutoSize = true;
            this.SHA2_512.Location = new System.Drawing.Point(112, 48);
            this.SHA2_512.Name = "SHA2_512";
            this.SHA2_512.Size = new System.Drawing.Size(43, 17);
            this.SHA2_512.TabIndex = 14;
            this.SHA2_512.TabStop = true;
            this.SHA2_512.Text = "512";
            this.SHA2_512.UseVisualStyleBackColor = true;
            this.SHA2_512.CheckedChanged += new System.EventHandler(this.SHA2_512_CheckedChanged);
            // 
            // SHA2_512_224
            // 
            this.SHA2_512_224.AutoSize = true;
            this.SHA2_512_224.Location = new System.Drawing.Point(112, 71);
            this.SHA2_512_224.Name = "SHA2_512_224";
            this.SHA2_512_224.Size = new System.Drawing.Size(66, 17);
            this.SHA2_512_224.TabIndex = 15;
            this.SHA2_512_224.TabStop = true;
            this.SHA2_512_224.Text = "512/224";
            this.SHA2_512_224.UseVisualStyleBackColor = true;
            this.SHA2_512_224.CheckedChanged += new System.EventHandler(this.SHA2_512_224_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SHA3_512);
            this.groupBox2.Controls.Add(this.SHA3_224);
            this.groupBox2.Controls.Add(this.SHA3_384);
            this.groupBox2.Controls.Add(this.SHA3_256);
            this.groupBox2.Location = new System.Drawing.Point(6, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 101);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SHA-3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Output length (bits)";
            // 
            // SHA3_512
            // 
            this.SHA3_512.AutoSize = true;
            this.SHA3_512.Location = new System.Drawing.Point(112, 71);
            this.SHA3_512.Name = "SHA3_512";
            this.SHA3_512.Size = new System.Drawing.Size(43, 17);
            this.SHA3_512.TabIndex = 17;
            this.SHA3_512.TabStop = true;
            this.SHA3_512.Text = "512";
            this.SHA3_512.UseVisualStyleBackColor = true;
            this.SHA3_512.CheckedChanged += new System.EventHandler(this.SHA3_512_CheckedChanged);
            // 
            // SHA3_224
            // 
            this.SHA3_224.AutoSize = true;
            this.SHA3_224.Location = new System.Drawing.Point(6, 48);
            this.SHA3_224.Name = "SHA3_224";
            this.SHA3_224.Size = new System.Drawing.Size(43, 17);
            this.SHA3_224.TabIndex = 17;
            this.SHA3_224.TabStop = true;
            this.SHA3_224.Text = "224";
            this.SHA3_224.UseVisualStyleBackColor = true;
            this.SHA3_224.CheckedChanged += new System.EventHandler(this.SHA3_224_CheckedChanged);
            // 
            // SHA3_384
            // 
            this.SHA3_384.AutoSize = true;
            this.SHA3_384.Location = new System.Drawing.Point(112, 48);
            this.SHA3_384.Name = "SHA3_384";
            this.SHA3_384.Size = new System.Drawing.Size(43, 17);
            this.SHA3_384.TabIndex = 19;
            this.SHA3_384.TabStop = true;
            this.SHA3_384.Text = "384";
            this.SHA3_384.UseVisualStyleBackColor = true;
            this.SHA3_384.CheckedChanged += new System.EventHandler(this.SHA3_384_CheckedChanged);
            // 
            // SHA3_256
            // 
            this.SHA3_256.AutoSize = true;
            this.SHA3_256.Location = new System.Drawing.Point(6, 71);
            this.SHA3_256.Name = "SHA3_256";
            this.SHA3_256.Size = new System.Drawing.Size(43, 17);
            this.SHA3_256.TabIndex = 18;
            this.SHA3_256.TabStop = true;
            this.SHA3_256.Text = "256";
            this.SHA3_256.UseVisualStyleBackColor = true;
            this.SHA3_256.CheckedChanged += new System.EventHandler(this.SHA3_256_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 261);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algorithm";
            // 
            // button_CalculateHASH
            // 
            this.button_CalculateHASH.Location = new System.Drawing.Point(39, 152);
            this.button_CalculateHASH.Name = "button_CalculateHASH";
            this.button_CalculateHASH.Size = new System.Drawing.Size(114, 23);
            this.button_CalculateHASH.TabIndex = 13;
            this.button_CalculateHASH.Text = "Calculate HASH";
            this.button_CalculateHASH.UseVisualStyleBackColor = true;
            this.button_CalculateHASH.Click += new System.EventHandler(this.button_CalculateHASH_Click);
            // 
            // text_input
            // 
            this.text_input.Enabled = false;
            this.text_input.Location = new System.Drawing.Point(62, 126);
            this.text_input.Name = "text_input";
            this.text_input.Size = new System.Drawing.Size(229, 20);
            this.text_input.TabIndex = 14;
            // 
            // lower_uppercase
            // 
            this.lower_uppercase.AutoSize = true;
            this.lower_uppercase.Location = new System.Drawing.Point(159, 156);
            this.lower_uppercase.Name = "lower_uppercase";
            this.lower_uppercase.Size = new System.Drawing.Size(118, 17);
            this.lower_uppercase.TabIndex = 15;
            this.lower_uppercase.Text = "Lowercase symbols";
            this.lower_uppercase.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lower_uppercase);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.button_CalculateHASH);
            this.groupBox4.Controls.Add(this.text_input);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(282, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(297, 182);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select input data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Plain text";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(6, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 78);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Calculate File Hash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path File";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(133, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 17);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Calculate File Hash";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Calculate Hash";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button_saveHASH
            // 
            this.button_saveHASH.Location = new System.Drawing.Point(363, 272);
            this.button_saveHASH.Name = "button_saveHASH";
            this.button_saveHASH.Size = new System.Drawing.Size(75, 23);
            this.button_saveHASH.TabIndex = 17;
            this.button_saveHASH.Text = "Save HASH";
            this.button_saveHASH.UseVisualStyleBackColor = true;
            this.button_saveHASH.Click += new System.EventHandler(this.button_saveHASH_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Password";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "LogIn";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(65, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(65, 42);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = 'x';
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 22;
            // 
            // clear_login
            // 
            this.clear_login.Location = new System.Drawing.Point(90, 91);
            this.clear_login.Name = "clear_login";
            this.clear_login.Size = new System.Drawing.Size(75, 23);
            this.clear_login.TabIndex = 23;
            this.clear_login.Text = "Clear";
            this.clear_login.UseVisualStyleBackColor = true;
            this.clear_login.Click += new System.EventHandler(this.clear_login_Click);
            // 
            // groupBox_Login
            // 
            this.groupBox_Login.Controls.Add(this.CheckbxShowPas_log);
            this.groupBox_Login.Controls.Add(this.clear_login);
            this.groupBox_Login.Controls.Add(this.label5);
            this.groupBox_Login.Controls.Add(this.button6);
            this.groupBox_Login.Controls.Add(this.textBox4);
            this.groupBox_Login.Controls.Add(this.textBox5);
            this.groupBox_Login.Controls.Add(this.label6);
            this.groupBox_Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_Login.Location = new System.Drawing.Point(585, 12);
            this.groupBox_Login.Name = "groupBox_Login";
            this.groupBox_Login.Size = new System.Drawing.Size(175, 120);
            this.groupBox_Login.TabIndex = 24;
            this.groupBox_Login.TabStop = false;
            this.groupBox_Login.Text = "Log In";
            // 
            // CheckbxShowPas_log
            // 
            this.CheckbxShowPas_log.AutoSize = true;
            this.CheckbxShowPas_log.Location = new System.Drawing.Point(67, 68);
            this.CheckbxShowPas_log.Name = "CheckbxShowPas_log";
            this.CheckbxShowPas_log.Size = new System.Drawing.Size(102, 17);
            this.CheckbxShowPas_log.TabIndex = 23;
            this.CheckbxShowPas_log.Text = "Show Password";
            this.CheckbxShowPas_log.UseVisualStyleBackColor = true;
            this.CheckbxShowPas_log.CheckedChanged += new System.EventHandler(this.CheckbxShowPas_log_CheckedChanged);
            // 
            // groupBox_Signup
            // 
            this.groupBox_Signup.Controls.Add(this.CheckbxShowPas_sign);
            this.groupBox_Signup.Controls.Add(this.label9);
            this.groupBox_Signup.Controls.Add(this.label8);
            this.groupBox_Signup.Controls.Add(this.label7);
            this.groupBox_Signup.Controls.Add(this.textBox8);
            this.groupBox_Signup.Controls.Add(this.textBox7);
            this.groupBox_Signup.Controls.Add(this.clear_signup);
            this.groupBox_Signup.Controls.Add(this.textBox6);
            this.groupBox_Signup.Controls.Add(this.button4);
            this.groupBox_Signup.Location = new System.Drawing.Point(585, 138);
            this.groupBox_Signup.Name = "groupBox_Signup";
            this.groupBox_Signup.Size = new System.Drawing.Size(175, 164);
            this.groupBox_Signup.TabIndex = 25;
            this.groupBox_Signup.TabStop = false;
            this.groupBox_Signup.Text = "SIgn Up";
            // 
            // CheckbxShowPas_sign
            // 
            this.CheckbxShowPas_sign.AutoSize = true;
            this.CheckbxShowPas_sign.Location = new System.Drawing.Point(67, 106);
            this.CheckbxShowPas_sign.Name = "CheckbxShowPas_sign";
            this.CheckbxShowPas_sign.Size = new System.Drawing.Size(102, 17);
            this.CheckbxShowPas_sign.TabIndex = 8;
            this.CheckbxShowPas_sign.Text = "Show Password";
            this.CheckbxShowPas_sign.UseVisualStyleBackColor = true;
            this.CheckbxShowPas_sign.CheckedChanged += new System.EventHandler(this.CheckbxShowPas_sign_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 26);
            this.label9.TabIndex = 7;
            this.label9.Text = "Confirm\r\npassword";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Login";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(64, 80);
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = 'x';
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 4;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(64, 54);
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = 'x';
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 3;
            // 
            // clear_signup
            // 
            this.clear_signup.Location = new System.Drawing.Point(90, 129);
            this.clear_signup.Name = "clear_signup";
            this.clear_signup.Size = new System.Drawing.Size(75, 23);
            this.clear_signup.TabIndex = 1;
            this.clear_signup.Text = "Clear";
            this.clear_signup.UseVisualStyleBackColor = true;
            this.clear_signup.Click += new System.EventHandler(this.clear_signup_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(65, 19);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Sign Up";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(444, 272);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(134, 23);
            this.button7.TabIndex = 26;
            this.button7.Text = "View saved HASHes";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(823, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "LOGIN";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(766, 279);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 28;
            this.button8.Text = "LogOut";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(826, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 90);
            this.panel1.TabIndex = 29;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(766, 124);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(205, 149);
            this.richTextBox3.TabIndex = 30;
            this.richTextBox3.Text = "";
            // 
            // clear_savedHASH
            // 
            this.clear_savedHASH.Location = new System.Drawing.Point(847, 279);
            this.clear_savedHASH.Name = "clear_savedHASH";
            this.clear_savedHASH.Size = new System.Drawing.Size(124, 23);
            this.clear_savedHASH.TabIndex = 31;
            this.clear_savedHASH.Text = "Clear saved HASHes";
            this.clear_savedHASH.UseVisualStyleBackColor = true;
            this.clear_savedHASH.Click += new System.EventHandler(this.clear_savedHASH_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(982, 305);
            this.Controls.Add(this.clear_savedHASH);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox_Signup);
            this.Controls.Add(this.groupBox_Login);
            this.Controls.Add(this.button_saveHASH);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "HASH Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Login.ResumeLayout(false);
            this.groupBox_Login.PerformLayout();
            this.groupBox_Signup.ResumeLayout(false);
            this.groupBox_Signup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SHA2_224;
        private System.Windows.Forms.RadioButton SHA2_256;
        private System.Windows.Forms.RadioButton SHA2_384;
        private System.Windows.Forms.RadioButton SHA2_512_256;
        private System.Windows.Forms.RadioButton SHA2_512;
        private System.Windows.Forms.RadioButton SHA2_512_224;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton SHA3_512;
        private System.Windows.Forms.RadioButton SHA3_224;
        private System.Windows.Forms.RadioButton SHA3_384;
        private System.Windows.Forms.RadioButton SHA3_256;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_CalculateHASH;
        private System.Windows.Forms.TextBox text_input;
        private System.Windows.Forms.CheckBox lower_uppercase;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_saveHASH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button clear_login;
        private System.Windows.Forms.GroupBox groupBox_Login;
        private System.Windows.Forms.GroupBox groupBox_Signup;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button clear_signup;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CheckbxShowPas_log;
        private System.Windows.Forms.CheckBox CheckbxShowPas_sign;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button clear_savedHASH;
    }
}
