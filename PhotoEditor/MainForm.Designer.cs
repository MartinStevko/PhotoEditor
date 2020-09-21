namespace PhotoEditor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.helpMenuButton = new System.Windows.Forms.Button();
            this.editMenuButton = new System.Windows.Forms.Button();
            this.fileMenuButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.minimizeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resetPreviewButton = new System.Windows.Forms.Button();
            this.redPreviewButton = new System.Windows.Forms.Button();
            this.greenPreviewButton = new System.Windows.Forms.Button();
            this.bluePreviewButton = new System.Windows.Forms.Button();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.verticalFlipButton = new System.Windows.Forms.Button();
            this.horizontalFlipButton = new System.Windows.Forms.Button();
            this.graystyleButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.invertColorButton = new System.Windows.Forms.Button();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.clarityLabel = new System.Windows.Forms.Label();
            this.clarityTrackBar = new System.Windows.Forms.TrackBar();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationTrackBar = new System.Windows.Forms.TrackBar();
            this.secondColorComboBox = new System.Windows.Forms.ComboBox();
            this.betweenColorLabel = new System.Windows.Forms.Label();
            this.firstColorComboBox = new System.Windows.Forms.ComboBox();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.clarityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.brightnessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saturationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saturationLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.Panel();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.editPanel = new System.Windows.Forms.Panel();
            this.applyLutButton = new System.Windows.Forms.Button();
            this.exportLutButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.helpPanel = new System.Windows.Forms.Panel();
            this.reportIssueButton = new System.Windows.Forms.Button();
            this.documentationButton = new System.Windows.Forms.Button();
            this.manualButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.openConfirmationPanel = new System.Windows.Forms.Panel();
            this.openCancelButton = new System.Windows.Forms.Button();
            this.openConfirmButton = new System.Windows.Forms.Button();
            this.openFileLabel = new System.Windows.Forms.Label();
            this.lutPanel = new System.Windows.Forms.Panel();
            this.applyConfirmButton = new System.Windows.Forms.Button();
            this.lutComboBox = new System.Windows.Forms.ComboBox();
            this.navigationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.toolboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clarityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clarityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationNumericUpDown)).BeginInit();
            this.filePanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.helpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.openConfirmationPanel.SuspendLayout();
            this.lutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.navigationPanel.Controls.Add(this.iconPictureBox);
            this.navigationPanel.Controls.Add(this.helpMenuButton);
            this.navigationPanel.Controls.Add(this.editMenuButton);
            this.navigationPanel.Controls.Add(this.fileMenuButton);
            this.navigationPanel.Controls.Add(this.minimizeButton);
            this.navigationPanel.Controls.Add(this.closeButton);
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(1067, 37);
            this.navigationPanel.TabIndex = 2;
            this.navigationPanel.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.iconPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconPictureBox.BackgroundImage")));
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox.InitialImage = null;
            this.iconPictureBox.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(40, 37);
            this.iconPictureBox.TabIndex = 5;
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // helpMenuButton
            // 
            this.helpMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.helpMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.helpMenuButton.FlatAppearance.BorderSize = 0;
            this.helpMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.helpMenuButton.ForeColor = System.Drawing.Color.White;
            this.helpMenuButton.Location = new System.Drawing.Point(173, 0);
            this.helpMenuButton.Margin = new System.Windows.Forms.Padding(0);
            this.helpMenuButton.Name = "helpMenuButton";
            this.helpMenuButton.Size = new System.Drawing.Size(67, 37);
            this.helpMenuButton.TabIndex = 4;
            this.helpMenuButton.Text = "Help";
            this.helpMenuButton.UseVisualStyleBackColor = true;
            this.helpMenuButton.Click += new System.EventHandler(this.button9_Click);
            // 
            // editMenuButton
            // 
            this.editMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.editMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editMenuButton.FlatAppearance.BorderSize = 0;
            this.editMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editMenuButton.ForeColor = System.Drawing.Color.White;
            this.editMenuButton.Location = new System.Drawing.Point(107, 0);
            this.editMenuButton.Margin = new System.Windows.Forms.Padding(0);
            this.editMenuButton.Name = "editMenuButton";
            this.editMenuButton.Size = new System.Drawing.Size(67, 37);
            this.editMenuButton.TabIndex = 3;
            this.editMenuButton.Text = "Edit";
            this.editMenuButton.UseVisualStyleBackColor = true;
            this.editMenuButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // fileMenuButton
            // 
            this.fileMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fileMenuButton.FlatAppearance.BorderSize = 0;
            this.fileMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fileMenuButton.ForeColor = System.Drawing.Color.White;
            this.fileMenuButton.Location = new System.Drawing.Point(40, 0);
            this.fileMenuButton.Margin = new System.Windows.Forms.Padding(0);
            this.fileMenuButton.Name = "fileMenuButton";
            this.fileMenuButton.Size = new System.Drawing.Size(67, 37);
            this.fileMenuButton.TabIndex = 2;
            this.fileMenuButton.Text = "File";
            this.fileMenuButton.UseVisualStyleBackColor = true;
            this.fileMenuButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(947, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(60, 37);
            this.minimizeButton.TabIndex = 1;
            this.minimizeToolTip.SetToolTip(this.minimizeButton, "Minimize");
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(1008, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 37);
            this.closeButton.TabIndex = 0;
            this.closeToolTip.SetToolTip(this.closeButton, "Close");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // closeToolTip
            // 
            this.closeToolTip.AutoPopDelay = 5000;
            this.closeToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeToolTip.ForeColor = System.Drawing.Color.White;
            this.closeToolTip.InitialDelay = 300;
            this.closeToolTip.ReshowDelay = 100;
            this.closeToolTip.Tag = "";
            // 
            // minimizeToolTip
            // 
            this.minimizeToolTip.AutoPopDelay = 5000;
            this.minimizeToolTip.InitialDelay = 300;
            this.minimizeToolTip.ReshowDelay = 100;
            // 
            // resetPreviewButton
            // 
            this.resetPreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPreviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.resetPreviewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.resetPreviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetPreviewButton.Enabled = false;
            this.resetPreviewButton.FlatAppearance.BorderSize = 0;
            this.resetPreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetPreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPreviewButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.resetPreviewButton.Location = new System.Drawing.Point(0, 455);
            this.resetPreviewButton.Margin = new System.Windows.Forms.Padding(0);
            this.resetPreviewButton.Name = "resetPreviewButton";
            this.resetPreviewButton.Size = new System.Drawing.Size(200, 98);
            this.resetPreviewButton.TabIndex = 2;
            this.resetPreviewButton.UseVisualStyleBackColor = false;
            this.resetPreviewButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // redPreviewButton
            // 
            this.redPreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redPreviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.redPreviewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.redPreviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.redPreviewButton.Enabled = false;
            this.redPreviewButton.FlatAppearance.BorderSize = 0;
            this.redPreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redPreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redPreviewButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.redPreviewButton.Location = new System.Drawing.Point(200, 455);
            this.redPreviewButton.Margin = new System.Windows.Forms.Padding(0);
            this.redPreviewButton.Name = "redPreviewButton";
            this.redPreviewButton.Size = new System.Drawing.Size(200, 98);
            this.redPreviewButton.TabIndex = 4;
            this.redPreviewButton.UseVisualStyleBackColor = false;
            this.redPreviewButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // greenPreviewButton
            // 
            this.greenPreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.greenPreviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.greenPreviewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.greenPreviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.greenPreviewButton.Enabled = false;
            this.greenPreviewButton.FlatAppearance.BorderSize = 0;
            this.greenPreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenPreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenPreviewButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.greenPreviewButton.Location = new System.Drawing.Point(400, 455);
            this.greenPreviewButton.Margin = new System.Windows.Forms.Padding(0);
            this.greenPreviewButton.Name = "greenPreviewButton";
            this.greenPreviewButton.Size = new System.Drawing.Size(200, 98);
            this.greenPreviewButton.TabIndex = 5;
            this.greenPreviewButton.UseVisualStyleBackColor = false;
            this.greenPreviewButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // bluePreviewButton
            // 
            this.bluePreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bluePreviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.bluePreviewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bluePreviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bluePreviewButton.Enabled = false;
            this.bluePreviewButton.FlatAppearance.BorderSize = 0;
            this.bluePreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bluePreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bluePreviewButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.bluePreviewButton.Location = new System.Drawing.Point(600, 455);
            this.bluePreviewButton.Margin = new System.Windows.Forms.Padding(0);
            this.bluePreviewButton.Name = "bluePreviewButton";
            this.bluePreviewButton.Size = new System.Drawing.Size(200, 98);
            this.bluePreviewButton.TabIndex = 6;
            this.bluePreviewButton.UseVisualStyleBackColor = false;
            this.bluePreviewButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolboxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.toolboxPanel.Controls.Add(this.verticalFlipButton);
            this.toolboxPanel.Controls.Add(this.horizontalFlipButton);
            this.toolboxPanel.Controls.Add(this.graystyleButton);
            this.toolboxPanel.Controls.Add(this.colorButton);
            this.toolboxPanel.Controls.Add(this.invertColorButton);
            this.toolboxPanel.Controls.Add(this.brightnessLabel);
            this.toolboxPanel.Controls.Add(this.clarityLabel);
            this.toolboxPanel.Controls.Add(this.clarityTrackBar);
            this.toolboxPanel.Controls.Add(this.brightnessTrackBar);
            this.toolboxPanel.Controls.Add(this.saturationTrackBar);
            this.toolboxPanel.Controls.Add(this.secondColorComboBox);
            this.toolboxPanel.Controls.Add(this.betweenColorLabel);
            this.toolboxPanel.Controls.Add(this.firstColorComboBox);
            this.toolboxPanel.Controls.Add(this.colorsLabel);
            this.toolboxPanel.Controls.Add(this.clarityNumericUpDown);
            this.toolboxPanel.Controls.Add(this.brightnessNumericUpDown);
            this.toolboxPanel.Controls.Add(this.saturationNumericUpDown);
            this.toolboxPanel.Controls.Add(this.saturationLabel);
            this.toolboxPanel.Location = new System.Drawing.Point(800, 37);
            this.toolboxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(267, 517);
            this.toolboxPanel.TabIndex = 3;
            this.toolboxPanel.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // verticalFlipButton
            // 
            this.verticalFlipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.verticalFlipButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verticalFlipButton.Enabled = false;
            this.verticalFlipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verticalFlipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalFlipButton.Location = new System.Drawing.Point(215, 450);
            this.verticalFlipButton.Name = "verticalFlipButton";
            this.verticalFlipButton.Size = new System.Drawing.Size(175, 36);
            this.verticalFlipButton.TabIndex = 20;
            this.verticalFlipButton.Text = "Flip vertical";
            this.verticalFlipButton.UseVisualStyleBackColor = true;
            this.verticalFlipButton.Click += new System.EventHandler(this.button27_Click);
            // 
            // horizontalFlipButton
            // 
            this.horizontalFlipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.horizontalFlipButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.horizontalFlipButton.Enabled = false;
            this.horizontalFlipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.horizontalFlipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalFlipButton.Location = new System.Drawing.Point(20, 450);
            this.horizontalFlipButton.Name = "horizontalFlipButton";
            this.horizontalFlipButton.Size = new System.Drawing.Size(175, 36);
            this.horizontalFlipButton.TabIndex = 19;
            this.horizontalFlipButton.Text = "Flip horizontal";
            this.horizontalFlipButton.UseVisualStyleBackColor = true;
            this.horizontalFlipButton.Click += new System.EventHandler(this.button26_Click);
            // 
            // graystyleButton
            // 
            this.graystyleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.graystyleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.graystyleButton.Enabled = false;
            this.graystyleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graystyleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graystyleButton.Location = new System.Drawing.Point(20, 390);
            this.graystyleButton.Name = "graystyleButton";
            this.graystyleButton.Size = new System.Drawing.Size(175, 36);
            this.graystyleButton.TabIndex = 18;
            this.graystyleButton.Text = "Graystyle filter";
            this.graystyleButton.UseVisualStyleBackColor = true;
            this.graystyleButton.Click += new System.EventHandler(this.button25_Click);
            // 
            // colorButton
            // 
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.colorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorButton.Enabled = false;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButton.Location = new System.Drawing.Point(290, 337);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(100, 36);
            this.colorButton.TabIndex = 14;
            this.colorButton.Text = "Change";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.button24_Click);
            // 
            // invertColorButton
            // 
            this.invertColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.invertColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.invertColorButton.Enabled = false;
            this.invertColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invertColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invertColorButton.Location = new System.Drawing.Point(20, 250);
            this.invertColorButton.Name = "invertColorButton";
            this.invertColorButton.Size = new System.Drawing.Size(175, 36);
            this.invertColorButton.TabIndex = 9;
            this.invertColorButton.Text = "Invert color";
            this.invertColorButton.UseVisualStyleBackColor = true;
            this.invertColorButton.Click += new System.EventHandler(this.button23_Click);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.brightnessLabel.Location = new System.Drawing.Point(15, 90);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(90, 20);
            this.brightnessLabel.TabIndex = 3;
            this.brightnessLabel.Text = "Brightness";
            // 
            // clarityLabel
            // 
            this.clarityLabel.AutoSize = true;
            this.clarityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clarityLabel.Location = new System.Drawing.Point(15, 170);
            this.clarityLabel.Name = "clarityLabel";
            this.clarityLabel.Size = new System.Drawing.Size(57, 20);
            this.clarityLabel.TabIndex = 6;
            this.clarityLabel.Text = "Clarity";
            // 
            // clarityTrackBar
            // 
            this.clarityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clarityTrackBar.Enabled = false;
            this.clarityTrackBar.LargeChange = 3;
            this.clarityTrackBar.Location = new System.Drawing.Point(15, 200);
            this.clarityTrackBar.Maximum = 100;
            this.clarityTrackBar.Minimum = -100;
            this.clarityTrackBar.Name = "clarityTrackBar";
            this.clarityTrackBar.Size = new System.Drawing.Size(120, 56);
            this.clarityTrackBar.TabIndex = 17;
            this.clarityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.clarityTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseAllPopUps);
            this.clarityTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar3_MouseUp);
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessTrackBar.Enabled = false;
            this.brightnessTrackBar.LargeChange = 3;
            this.brightnessTrackBar.Location = new System.Drawing.Point(15, 120);
            this.brightnessTrackBar.Maximum = 100;
            this.brightnessTrackBar.Minimum = -100;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(120, 56);
            this.brightnessTrackBar.TabIndex = 16;
            this.brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseAllPopUps);
            this.brightnessTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseUp);
            // 
            // saturationTrackBar
            // 
            this.saturationTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationTrackBar.Enabled = false;
            this.saturationTrackBar.LargeChange = 3;
            this.saturationTrackBar.Location = new System.Drawing.Point(15, 40);
            this.saturationTrackBar.Maximum = 100;
            this.saturationTrackBar.Minimum = -100;
            this.saturationTrackBar.Name = "saturationTrackBar";
            this.saturationTrackBar.Size = new System.Drawing.Size(120, 56);
            this.saturationTrackBar.TabIndex = 15;
            this.saturationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.saturationTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseAllPopUps);
            this.saturationTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // secondColorComboBox
            // 
            this.secondColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.secondColorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secondColorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondColorComboBox.ForeColor = System.Drawing.Color.White;
            this.secondColorComboBox.FormattingEnabled = true;
            this.secondColorComboBox.Items.AddRange(new object[] {
            "red",
            "green",
            "blue"});
            this.secondColorComboBox.Location = new System.Drawing.Point(170, 340);
            this.secondColorComboBox.Name = "secondColorComboBox";
            this.secondColorComboBox.Size = new System.Drawing.Size(100, 28);
            this.secondColorComboBox.TabIndex = 13;
            this.secondColorComboBox.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // betweenColorLabel
            // 
            this.betweenColorLabel.AutoSize = true;
            this.betweenColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.betweenColorLabel.Location = new System.Drawing.Point(130, 344);
            this.betweenColorLabel.Name = "betweenColorLabel";
            this.betweenColorLabel.Size = new System.Drawing.Size(29, 20);
            this.betweenColorLabel.TabIndex = 12;
            this.betweenColorLabel.Text = "for";
            this.betweenColorLabel.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // firstColorComboBox
            // 
            this.firstColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.firstColorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstColorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstColorComboBox.ForeColor = System.Drawing.Color.White;
            this.firstColorComboBox.FormattingEnabled = true;
            this.firstColorComboBox.Items.AddRange(new object[] {
            "red",
            "green",
            "blue"});
            this.firstColorComboBox.Location = new System.Drawing.Point(20, 340);
            this.firstColorComboBox.Name = "firstColorComboBox";
            this.firstColorComboBox.Size = new System.Drawing.Size(100, 28);
            this.firstColorComboBox.TabIndex = 11;
            this.firstColorComboBox.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // colorsLabel
            // 
            this.colorsLabel.AutoSize = true;
            this.colorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.colorsLabel.Location = new System.Drawing.Point(15, 310);
            this.colorsLabel.Name = "colorsLabel";
            this.colorsLabel.Size = new System.Drawing.Size(117, 20);
            this.colorsLabel.TabIndex = 10;
            this.colorsLabel.Text = "Change colors";
            this.colorsLabel.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // clarityNumericUpDown
            // 
            this.clarityNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clarityNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.clarityNumericUpDown.Enabled = false;
            this.clarityNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clarityNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.clarityNumericUpDown.Location = new System.Drawing.Point(160, 200);
            this.clarityNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.clarityNumericUpDown.Name = "clarityNumericUpDown";
            this.clarityNumericUpDown.Size = new System.Drawing.Size(80, 26);
            this.clarityNumericUpDown.TabIndex = 8;
            this.clarityNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clarityNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            this.clarityNumericUpDown.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // brightnessNumericUpDown
            // 
            this.brightnessNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.brightnessNumericUpDown.Enabled = false;
            this.brightnessNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.brightnessNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.brightnessNumericUpDown.Location = new System.Drawing.Point(160, 120);
            this.brightnessNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.brightnessNumericUpDown.Name = "brightnessNumericUpDown";
            this.brightnessNumericUpDown.Size = new System.Drawing.Size(80, 26);
            this.brightnessNumericUpDown.TabIndex = 5;
            this.brightnessNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.brightnessNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.brightnessNumericUpDown.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // saturationNumericUpDown
            // 
            this.saturationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.saturationNumericUpDown.Enabled = false;
            this.saturationNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saturationNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.saturationNumericUpDown.Location = new System.Drawing.Point(160, 40);
            this.saturationNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.saturationNumericUpDown.Name = "saturationNumericUpDown";
            this.saturationNumericUpDown.Size = new System.Drawing.Size(80, 26);
            this.saturationNumericUpDown.TabIndex = 2;
            this.saturationNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.saturationNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.saturationNumericUpDown.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // saturationLabel
            // 
            this.saturationLabel.AutoSize = true;
            this.saturationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saturationLabel.Location = new System.Drawing.Point(15, 10);
            this.saturationLabel.Name = "saturationLabel";
            this.saturationLabel.Size = new System.Drawing.Size(85, 20);
            this.saturationLabel.TabIndex = 0;
            this.saturationLabel.Text = "Saturation";
            this.saturationLabel.Click += new System.EventHandler(this.CloseAllPopUps);
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.filePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.filePanel.Controls.Add(this.saveAsButton);
            this.filePanel.Controls.Add(this.saveButton);
            this.filePanel.Controls.Add(this.openFileButton);
            this.filePanel.Location = new System.Drawing.Point(40, 37);
            this.filePanel.Margin = new System.Windows.Forms.Padding(4);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(133, 147);
            this.filePanel.TabIndex = 7;
            this.filePanel.Visible = false;
            // 
            // saveAsButton
            // 
            this.saveAsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveAsButton.Enabled = false;
            this.saveAsButton.FlatAppearance.BorderSize = 0;
            this.saveAsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAsButton.Location = new System.Drawing.Point(0, 98);
            this.saveAsButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.saveAsButton.Size = new System.Drawing.Size(133, 49);
            this.saveAsButton.TabIndex = 2;
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.button12_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(0, 49);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.saveButton.Size = new System.Drawing.Size(133, 49);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openFileButton.FlatAppearance.BorderSize = 0;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(0, 0);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.openFileButton.Size = new System.Drawing.Size(133, 49);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open new";
            this.openFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.button10_Click);
            // 
            // editPanel
            // 
            this.editPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.editPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editPanel.Controls.Add(this.applyLutButton);
            this.editPanel.Controls.Add(this.exportLutButton);
            this.editPanel.Controls.Add(this.redoButton);
            this.editPanel.Controls.Add(this.undoButton);
            this.editPanel.Location = new System.Drawing.Point(107, 37);
            this.editPanel.Margin = new System.Windows.Forms.Padding(4);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(133, 197);
            this.editPanel.TabIndex = 8;
            this.editPanel.Visible = false;
            // 
            // applyLutButton
            // 
            this.applyLutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.applyLutButton.Enabled = false;
            this.applyLutButton.FlatAppearance.BorderSize = 0;
            this.applyLutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyLutButton.Location = new System.Drawing.Point(0, 147);
            this.applyLutButton.Margin = new System.Windows.Forms.Padding(0);
            this.applyLutButton.Name = "applyLutButton";
            this.applyLutButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.applyLutButton.Size = new System.Drawing.Size(133, 49);
            this.applyLutButton.TabIndex = 3;
            this.applyLutButton.Text = "Apply LUT file";
            this.applyLutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyLutButton.UseVisualStyleBackColor = true;
            this.applyLutButton.Click += new System.EventHandler(this.button14_Click);
            // 
            // exportLutButton
            // 
            this.exportLutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exportLutButton.Enabled = false;
            this.exportLutButton.FlatAppearance.BorderSize = 0;
            this.exportLutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportLutButton.Location = new System.Drawing.Point(0, 98);
            this.exportLutButton.Margin = new System.Windows.Forms.Padding(0);
            this.exportLutButton.Name = "exportLutButton";
            this.exportLutButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.exportLutButton.Size = new System.Drawing.Size(133, 49);
            this.exportLutButton.TabIndex = 2;
            this.exportLutButton.Text = "Export LUT";
            this.exportLutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportLutButton.UseVisualStyleBackColor = true;
            this.exportLutButton.Click += new System.EventHandler(this.button15_Click);
            // 
            // redoButton
            // 
            this.redoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.redoButton.Enabled = false;
            this.redoButton.FlatAppearance.BorderSize = 0;
            this.redoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redoButton.Location = new System.Drawing.Point(0, 49);
            this.redoButton.Margin = new System.Windows.Forms.Padding(0);
            this.redoButton.Name = "redoButton";
            this.redoButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.redoButton.Size = new System.Drawing.Size(133, 49);
            this.redoButton.TabIndex = 1;
            this.redoButton.Text = "Redo";
            this.redoButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.button16_Click);
            // 
            // undoButton
            // 
            this.undoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.undoButton.Enabled = false;
            this.undoButton.FlatAppearance.BorderSize = 0;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Location = new System.Drawing.Point(0, 0);
            this.undoButton.Margin = new System.Windows.Forms.Padding(0);
            this.undoButton.Name = "undoButton";
            this.undoButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.undoButton.Size = new System.Drawing.Size(133, 49);
            this.undoButton.TabIndex = 0;
            this.undoButton.Text = "Undo";
            this.undoButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.button17_Click);
            // 
            // helpPanel
            // 
            this.helpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.helpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.helpPanel.Controls.Add(this.reportIssueButton);
            this.helpPanel.Controls.Add(this.documentationButton);
            this.helpPanel.Controls.Add(this.manualButton);
            this.helpPanel.Location = new System.Drawing.Point(173, 37);
            this.helpPanel.Margin = new System.Windows.Forms.Padding(4);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(160, 148);
            this.helpPanel.TabIndex = 9;
            this.helpPanel.Visible = false;
            // 
            // reportIssueButton
            // 
            this.reportIssueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reportIssueButton.FlatAppearance.BorderSize = 0;
            this.reportIssueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportIssueButton.Location = new System.Drawing.Point(0, 98);
            this.reportIssueButton.Margin = new System.Windows.Forms.Padding(0);
            this.reportIssueButton.Name = "reportIssueButton";
            this.reportIssueButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.reportIssueButton.Size = new System.Drawing.Size(160, 49);
            this.reportIssueButton.TabIndex = 2;
            this.reportIssueButton.Text = "Report issue";
            this.reportIssueButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportIssueButton.UseVisualStyleBackColor = true;
            this.reportIssueButton.Click += new System.EventHandler(this.button19_Click);
            // 
            // documentationButton
            // 
            this.documentationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.documentationButton.FlatAppearance.BorderSize = 0;
            this.documentationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.documentationButton.Location = new System.Drawing.Point(0, 49);
            this.documentationButton.Margin = new System.Windows.Forms.Padding(0);
            this.documentationButton.Name = "documentationButton";
            this.documentationButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.documentationButton.Size = new System.Drawing.Size(160, 49);
            this.documentationButton.TabIndex = 1;
            this.documentationButton.Text = "Documentation";
            this.documentationButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.documentationButton.UseVisualStyleBackColor = true;
            this.documentationButton.Click += new System.EventHandler(this.button20_Click);
            // 
            // manualButton
            // 
            this.manualButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.manualButton.FlatAppearance.BorderSize = 0;
            this.manualButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manualButton.Location = new System.Drawing.Point(0, 0);
            this.manualButton.Margin = new System.Windows.Forms.Padding(0);
            this.manualButton.Name = "manualButton";
            this.manualButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.manualButton.Size = new System.Drawing.Size(160, 49);
            this.manualButton.TabIndex = 0;
            this.manualButton.Text = "User manual";
            this.manualButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.Click += new System.EventHandler(this.button21_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.mainPictureBox.Location = new System.Drawing.Point(13, 49);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(773, 394);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainPictureBox.TabIndex = 10;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.CloseAllPopUps);
            this.mainPictureBox.DoubleClick += new System.EventHandler(this.button10_Click);
            // 
            // openConfirmationPanel
            // 
            this.openConfirmationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.openConfirmationPanel.Controls.Add(this.openCancelButton);
            this.openConfirmationPanel.Controls.Add(this.openConfirmButton);
            this.openConfirmationPanel.Controls.Add(this.openFileLabel);
            this.openConfirmationPanel.Location = new System.Drawing.Point(173, 37);
            this.openConfirmationPanel.Name = "openConfirmationPanel";
            this.openConfirmationPanel.Size = new System.Drawing.Size(524, 98);
            this.openConfirmationPanel.TabIndex = 11;
            this.openConfirmationPanel.Visible = false;
            // 
            // openCancelButton
            // 
            this.openCancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openCancelButton.FlatAppearance.BorderSize = 0;
            this.openCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openCancelButton.Location = new System.Drawing.Point(262, 49);
            this.openCancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.openCancelButton.Name = "openCancelButton";
            this.openCancelButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.openCancelButton.Size = new System.Drawing.Size(262, 49);
            this.openCancelButton.TabIndex = 3;
            this.openCancelButton.Text = "No, take me back";
            this.openCancelButton.UseVisualStyleBackColor = true;
            this.openCancelButton.Click += new System.EventHandler(this.button18_Click);
            // 
            // openConfirmButton
            // 
            this.openConfirmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openConfirmButton.FlatAppearance.BorderSize = 0;
            this.openConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openConfirmButton.Location = new System.Drawing.Point(0, 49);
            this.openConfirmButton.Margin = new System.Windows.Forms.Padding(0);
            this.openConfirmButton.Name = "openConfirmButton";
            this.openConfirmButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.openConfirmButton.Size = new System.Drawing.Size(262, 49);
            this.openConfirmButton.TabIndex = 2;
            this.openConfirmButton.Text = "Yes, I am sure";
            this.openConfirmButton.UseVisualStyleBackColor = true;
            this.openConfirmButton.Click += new System.EventHandler(this.button22_Click);
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Location = new System.Drawing.Point(0, 0);
            this.openFileLabel.Margin = new System.Windows.Forms.Padding(0);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Padding = new System.Windows.Forms.Padding(13, 16, 13, 16);
            this.openFileLabel.Size = new System.Drawing.Size(524, 49);
            this.openFileLabel.TabIndex = 0;
            this.openFileLabel.Text = "Are you sure you want to open a new image? All unsaved changes will be lost!";
            this.openFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lutPanel
            // 
            this.lutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.lutPanel.Controls.Add(this.applyConfirmButton);
            this.lutPanel.Controls.Add(this.lutComboBox);
            this.lutPanel.Location = new System.Drawing.Point(240, 185);
            this.lutPanel.Name = "lutPanel";
            this.lutPanel.Size = new System.Drawing.Size(300, 49);
            this.lutPanel.TabIndex = 12;
            this.lutPanel.Visible = false;
            // 
            // applyConfirmButton
            // 
            this.applyConfirmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.applyConfirmButton.Enabled = false;
            this.applyConfirmButton.FlatAppearance.BorderSize = 0;
            this.applyConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyConfirmButton.Location = new System.Drawing.Point(200, 0);
            this.applyConfirmButton.Margin = new System.Windows.Forms.Padding(0);
            this.applyConfirmButton.Name = "applyConfirmButton";
            this.applyConfirmButton.Size = new System.Drawing.Size(100, 49);
            this.applyConfirmButton.TabIndex = 4;
            this.applyConfirmButton.Text = "Apply";
            this.applyConfirmButton.UseVisualStyleBackColor = true;
            this.applyConfirmButton.Click += new System.EventHandler(this.button28_Click);
            // 
            // lutComboBox
            // 
            this.lutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.lutComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lutComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lutComboBox.ForeColor = System.Drawing.Color.White;
            this.lutComboBox.FormattingEnabled = true;
            this.lutComboBox.Location = new System.Drawing.Point(11, 10);
            this.lutComboBox.Name = "lutComboBox";
            this.lutComboBox.Size = new System.Drawing.Size(178, 28);
            this.lutComboBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lutPanel);
            this.Controls.Add(this.openConfirmationPanel);
            this.Controls.Add(this.helpPanel);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.navigationPanel);
            this.Controls.Add(this.resetPreviewButton);
            this.Controls.Add(this.redPreviewButton);
            this.Controls.Add(this.greenPreviewButton);
            this.Controls.Add(this.bluePreviewButton);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.mainPictureBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PhotoEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.CloseAllPopUps);
            this.navigationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.toolboxPanel.ResumeLayout(false);
            this.toolboxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clarityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clarityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationNumericUpDown)).EndInit();
            this.filePanel.ResumeLayout(false);
            this.editPanel.ResumeLayout(false);
            this.helpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.openConfirmationPanel.ResumeLayout(false);
            this.openConfirmationPanel.PerformLayout();
            this.lutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip closeToolTip;
        private System.Windows.Forms.ToolTip minimizeToolTip;
        private System.Windows.Forms.Button resetPreviewButton;
        private System.Windows.Forms.Button redPreviewButton;
        private System.Windows.Forms.Button greenPreviewButton;
        private System.Windows.Forms.Button bluePreviewButton;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.Button fileMenuButton;
        private System.Windows.Forms.Button helpMenuButton;
        private System.Windows.Forms.Button editMenuButton;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Button applyLutButton;
        private System.Windows.Forms.Button exportLutButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Panel helpPanel;
        private System.Windows.Forms.Button reportIssueButton;
        private System.Windows.Forms.Button documentationButton;
        private System.Windows.Forms.Button manualButton;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel openConfirmationPanel;
        private System.Windows.Forms.Button openCancelButton;
        private System.Windows.Forms.Button openConfirmButton;
        private System.Windows.Forms.Label openFileLabel;
        private System.Windows.Forms.Label saturationLabel;
        private System.Windows.Forms.NumericUpDown saturationNumericUpDown;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.NumericUpDown brightnessNumericUpDown;
        private System.Windows.Forms.NumericUpDown clarityNumericUpDown;
        private System.Windows.Forms.Label clarityLabel;
        private System.Windows.Forms.Button invertColorButton;
        private System.Windows.Forms.ComboBox firstColorComboBox;
        private System.Windows.Forms.Label colorsLabel;
        private System.Windows.Forms.ComboBox secondColorComboBox;
        private System.Windows.Forms.Label betweenColorLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.TrackBar saturationTrackBar;
        private System.Windows.Forms.TrackBar clarityTrackBar;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Button verticalFlipButton;
        private System.Windows.Forms.Button horizontalFlipButton;
        private System.Windows.Forms.Button graystyleButton;
        private System.Windows.Forms.Panel lutPanel;
        private System.Windows.Forms.ComboBox lutComboBox;
        private System.Windows.Forms.Button applyConfirmButton;
    }
}

