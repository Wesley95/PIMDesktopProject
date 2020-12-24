namespace PIMDesktopProject
{
    partial class FrmUpdateUserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClean = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDOC = new System.Windows.Forms.Label();
            this.txtDOC = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.lblSecondaryContact = new System.Windows.Forms.Label();
            this.lblFirstContact = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContactSecundary = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComplement = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnContact = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTittle = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.pnlContacts.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.Maroon;
            this.btnClean.FlatAppearance.BorderSize = 0;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.ForeColor = System.Drawing.Color.White;
            this.btnClean.Location = new System.Drawing.Point(152, 478);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(100, 35);
            this.btnClean.TabIndex = 10;
            this.btnClean.Text = "Limpar";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Maroon;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(46, 478);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Atualizar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.dateTimePicker1);
            this.pnlInfo.Controls.Add(this.lblDOC);
            this.pnlInfo.Controls.Add(this.txtDOC);
            this.pnlInfo.Controls.Add(this.lblDate);
            this.pnlInfo.Controls.Add(this.txtBirthDate);
            this.pnlInfo.Controls.Add(this.lblNome);
            this.pnlInfo.Controls.Add(this.txtName);
            this.pnlInfo.Location = new System.Drawing.Point(390, 373);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(550, 213);
            this.pnlInfo.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(249, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(285, 22);
            this.dateTimePicker1.TabIndex = 26;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblDOC
            // 
            this.lblDOC.AutoSize = true;
            this.lblDOC.BackColor = System.Drawing.Color.Transparent;
            this.lblDOC.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDOC.Location = new System.Drawing.Point(3, 45);
            this.lblDOC.Name = "lblDOC";
            this.lblDOC.Size = new System.Drawing.Size(46, 18);
            this.lblDOC.TabIndex = 25;
            this.lblDOC.Text = "CPNJ:";
            // 
            // txtDOC
            // 
            this.txtDOC.Location = new System.Drawing.Point(153, 42);
            this.txtDOC.Name = "txtDOC";
            this.txtDOC.ReadOnly = true;
            this.txtDOC.Size = new System.Drawing.Size(141, 22);
            this.txtDOC.TabIndex = 24;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(3, 72);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(138, 18);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "Data de Fundação:";
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(153, 69);
            this.txtBirthDate.MaxLength = 10;
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.ReadOnly = true;
            this.txtBirthDate.Size = new System.Drawing.Size(90, 22);
            this.txtBirthDate.TabIndex = 22;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.Transparent;
            this.lblNome.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNome.Location = new System.Drawing.Point(3, 18);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(117, 18);
            this.lblNome.TabIndex = 21;
            this.lblNome.Text = "Nome Fantasia:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(153, 15);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 22);
            this.txtName.TabIndex = 20;
            // 
            // pnlContacts
            // 
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.Controls.Add(this.lblSecondaryContact);
            this.pnlContacts.Controls.Add(this.lblFirstContact);
            this.pnlContacts.Controls.Add(this.label9);
            this.pnlContacts.Controls.Add(this.txtContactSecundary);
            this.pnlContacts.Controls.Add(this.label8);
            this.pnlContacts.Controls.Add(this.txtContact);
            this.pnlContacts.Controls.Add(this.label7);
            this.pnlContacts.Controls.Add(this.txtEmail);
            this.pnlContacts.Location = new System.Drawing.Point(390, 151);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(320, 213);
            this.pnlContacts.TabIndex = 1;
            // 
            // lblSecondaryContact
            // 
            this.lblSecondaryContact.AutoSize = true;
            this.lblSecondaryContact.Location = new System.Drawing.Point(242, 74);
            this.lblSecondaryContact.Name = "lblSecondaryContact";
            this.lblSecondaryContact.Size = new System.Drawing.Size(0, 17);
            this.lblSecondaryContact.TabIndex = 25;
            // 
            // lblFirstContact
            // 
            this.lblFirstContact.AutoSize = true;
            this.lblFirstContact.Location = new System.Drawing.Point(242, 47);
            this.lblFirstContact.Name = "lblFirstContact";
            this.lblFirstContact.Size = new System.Drawing.Size(0, 17);
            this.lblFirstContact.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Contato 2:";
            // 
            // txtContactSecundary
            // 
            this.txtContactSecundary.Location = new System.Drawing.Point(88, 71);
            this.txtContactSecundary.MaxLength = 11;
            this.txtContactSecundary.Name = "txtContactSecundary";
            this.txtContactSecundary.Size = new System.Drawing.Size(147, 22);
            this.txtContactSecundary.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(9, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Contato 1:";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(88, 43);
            this.txtContact.MaxLength = 11;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(147, 22);
            this.txtContact.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 15);
            this.txtEmail.MaxLength = 70;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(217, 22);
            this.txtEmail.TabIndex = 18;
            // 
            // pnlAddress
            // 
            this.pnlAddress.BackColor = System.Drawing.Color.White;
            this.pnlAddress.Controls.Add(this.label2);
            this.pnlAddress.Controls.Add(this.txtEstado);
            this.pnlAddress.Controls.Add(this.txtNumber);
            this.pnlAddress.Controls.Add(this.label13);
            this.pnlAddress.Controls.Add(this.label16);
            this.pnlAddress.Controls.Add(this.txtDistrict);
            this.pnlAddress.Controls.Add(this.label15);
            this.pnlAddress.Controls.Add(this.txtTown);
            this.pnlAddress.Controls.Add(this.label14);
            this.pnlAddress.Controls.Add(this.txtComplement);
            this.pnlAddress.Controls.Add(this.label11);
            this.pnlAddress.Controls.Add(this.txtCEP);
            this.pnlAddress.Controls.Add(this.label10);
            this.pnlAddress.Controls.Add(this.txtStreet);
            this.pnlAddress.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlAddress.Location = new System.Drawing.Point(46, 228);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(320, 240);
            this.pnlAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(110, 185);
            this.txtEstado.MaxLength = 70;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(197, 24);
            this.txtEstado.TabIndex = 44;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(110, 73);
            this.txtNumber.MaxLength = 10;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(66, 24);
            this.txtNumber.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(7, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Número:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(7, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 18);
            this.label16.TabIndex = 41;
            this.label16.Text = "Bairro:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(110, 157);
            this.txtDistrict.MaxLength = 70;
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(197, 24);
            this.txtDistrict.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(7, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 39;
            this.label15.Text = "Cidade:";
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(110, 129);
            this.txtTown.MaxLength = 70;
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(197, 24);
            this.txtTown.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(7, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 18);
            this.label14.TabIndex = 37;
            this.label14.Text = "Complemento:";
            // 
            // txtComplement
            // 
            this.txtComplement.Location = new System.Drawing.Point(110, 101);
            this.txtComplement.MaxLength = 70;
            this.txtComplement.Name = "txtComplement";
            this.txtComplement.Size = new System.Drawing.Size(197, 24);
            this.txtComplement.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(7, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 18);
            this.label11.TabIndex = 35;
            this.label11.Text = "CEP:";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(110, 17);
            this.txtCEP.MaxLength = 8;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(90, 24);
            this.txtCEP.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "Logradouro:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(110, 45);
            this.txtStreet.MaxLength = 70;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(197, 24);
            this.txtStreet.TabIndex = 32;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 82);
            this.textBox1.MaxLength = 14;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neo Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(46, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "CPF/CNPJ:";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Maroon;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(46, 131);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(90, 35);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Procurar";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.BackColor = System.Drawing.Color.Maroon;
            this.btnAddress.FlatAppearance.BorderSize = 0;
            this.btnAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddress.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddress.ForeColor = System.Drawing.Color.White;
            this.btnAddress.Location = new System.Drawing.Point(236, 187);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(100, 35);
            this.btnAddress.TabIndex = 4;
            this.btnAddress.Text = "Endereço";
            this.btnAddress.UseVisualStyleBackColor = false;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnContact
            // 
            this.btnContact.BackColor = System.Drawing.Color.Maroon;
            this.btnContact.FlatAppearance.BorderSize = 0;
            this.btnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContact.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContact.ForeColor = System.Drawing.Color.White;
            this.btnContact.Location = new System.Drawing.Point(136, 187);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(100, 35);
            this.btnContact.TabIndex = 3;
            this.btnContact.Text = "Contatos";
            this.btnContact.UseVisualStyleBackColor = false;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.btnInfo.ForeColor = System.Drawing.Color.Maroon;
            this.btnInfo.Location = new System.Drawing.Point(36, 187);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(100, 35);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "Informações";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTittle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(841, 41);
            this.pnlTop.TabIndex = 11;
            // 
            // lblTittle
            // 
            this.lblTittle.AutoSize = true;
            this.lblTittle.Font = new System.Drawing.Font("Neo Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittle.ForeColor = System.Drawing.Color.White;
            this.lblTittle.Location = new System.Drawing.Point(12, 9);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(225, 25);
            this.lblTittle.TabIndex = 43;
            this.lblTittle.Text = "Atualizar Informações";
            // 
            // FrmUpdateUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 604);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlContacts);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.pnlAddress);
            this.Controls.Add(this.btnAddress);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateUserInfo";
            this.ShowInTaskbar = false;
            this.Text = "FrmUpdateUserInfo";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlContacts.ResumeLayout(false);
            this.pnlContacts.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlContacts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtContactSecundary;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtComplement;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDOC;
        private System.Windows.Forms.TextBox txtDOC;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblSecondaryContact;
        private System.Windows.Forms.Label lblFirstContact;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTittle;
    }
}