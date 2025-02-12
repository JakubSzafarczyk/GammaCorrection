namespace GammaCorrection
{
    partial class FormGamCor
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxC = new System.Windows.Forms.CheckBox();
            this.checkBoxAsm = new System.Windows.Forms.CheckBox();
            this.openFileToLoadImage = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.buttonCorrectImage = new System.Windows.Forms.Button();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.trackBarGamma = new System.Windows.Forms.TrackBar();
            this.labelGamma = new System.Windows.Forms.Label();
            this.labelOriginalPhoto = new System.Windows.Forms.Label();
            this.labelCorrectedPhoto = new System.Windows.Forms.Label();
            this.labelCorrectionStatus = new System.Windows.Forms.Label();
            this.labelCorrectionTimer = new System.Windows.Forms.Label();
            this.saveFileResult = new System.Windows.Forms.SaveFileDialog();
            this.trackBarThreads = new System.Windows.Forms.TrackBar();
            this.labelThreads = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxC
            // 
            this.checkBoxC.AutoSize = true;
            this.checkBoxC.Location = new System.Drawing.Point(1075, 48);
            this.checkBoxC.Name = "checkBoxC";
            this.checkBoxC.Size = new System.Drawing.Size(128, 24);
            this.checkBoxC.TabIndex = 0;
            this.checkBoxC.Text = "correct by C#";
            this.checkBoxC.UseVisualStyleBackColor = true;
            // 
            // checkBoxAsm
            // 
            this.checkBoxAsm.AutoSize = true;
            this.checkBoxAsm.Location = new System.Drawing.Point(1075, 132);
            this.checkBoxAsm.Name = "checkBoxAsm";
            this.checkBoxAsm.Size = new System.Drawing.Size(140, 24);
            this.checkBoxAsm.TabIndex = 1;
            this.checkBoxAsm.Text = "correct by Asm";
            this.checkBoxAsm.UseVisualStyleBackColor = true;
            // 
            // openFileToLoadImage
            // 
            this.openFileToLoadImage.FileName = "Image";
            this.openFileToLoadImage.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(155, 640);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(137, 42);
            this.buttonLoadImage.TabIndex = 2;
            this.buttonLoadImage.Text = "Load Image ";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.Location = new System.Drawing.Point(12, 196);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(490, 438);
            this.pictureBoxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoad.TabIndex = 3;
            this.pictureBoxLoad.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(508, 196);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(490, 438);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 4;
            this.pictureBoxResult.TabStop = false;
            // 
            // buttonCorrectImage
            // 
            this.buttonCorrectImage.Location = new System.Drawing.Point(1075, 221);
            this.buttonCorrectImage.Name = "buttonCorrectImage";
            this.buttonCorrectImage.Size = new System.Drawing.Size(128, 42);
            this.buttonCorrectImage.TabIndex = 5;
            this.buttonCorrectImage.Text = "Correct Image";
            this.buttonCorrectImage.UseVisualStyleBackColor = true;
            this.buttonCorrectImage.Click += new System.EventHandler(this.buttonCorrectImage_Click);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(720, 640);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(137, 42);
            this.buttonSaveImage.TabIndex = 6;
            this.buttonSaveImage.Text = "Save Image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // trackBarGamma
            // 
            this.trackBarGamma.LargeChange = 10;
            this.trackBarGamma.Location = new System.Drawing.Point(222, 12);
            this.trackBarGamma.Maximum = 400;
            this.trackBarGamma.Minimum = 1;
            this.trackBarGamma.Name = "trackBarGamma";
            this.trackBarGamma.Size = new System.Drawing.Size(697, 69);
            this.trackBarGamma.TabIndex = 3;
            this.trackBarGamma.TickFrequency = 10;
            this.trackBarGamma.Value = 100;
            this.trackBarGamma.Scroll += new System.EventHandler(this.trackBarGamma_Scroll);
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGamma.Location = new System.Drawing.Point(12, 14);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(145, 32);
            this.labelGamma.TabIndex = 8;
            this.labelGamma.Text = "Gamma: 1";
            // 
            // labelOriginalPhoto
            // 
            this.labelOriginalPhoto.AutoSize = true;
            this.labelOriginalPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOriginalPhoto.Location = new System.Drawing.Point(148, 156);
            this.labelOriginalPhoto.Name = "labelOriginalPhoto";
            this.labelOriginalPhoto.Size = new System.Drawing.Size(221, 37);
            this.labelOriginalPhoto.TabIndex = 9;
            this.labelOriginalPhoto.Text = "Original Photo";
            // 
            // labelCorrectedPhoto
            // 
            this.labelCorrectedPhoto.AutoSize = true;
            this.labelCorrectedPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCorrectedPhoto.Location = new System.Drawing.Point(607, 156);
            this.labelCorrectedPhoto.Name = "labelCorrectedPhoto";
            this.labelCorrectedPhoto.Size = new System.Drawing.Size(250, 37);
            this.labelCorrectedPhoto.TabIndex = 10;
            this.labelCorrectedPhoto.Text = "Corrected Photo";
            // 
            // labelCorrectionStatus
            // 
            this.labelCorrectionStatus.AutoSize = true;
            this.labelCorrectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCorrectionStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCorrectionStatus.Location = new System.Drawing.Point(1004, 330);
            this.labelCorrectionStatus.Name = "labelCorrectionStatus";
            this.labelCorrectionStatus.Size = new System.Drawing.Size(171, 32);
            this.labelCorrectionStatus.TabIndex = 11;
            this.labelCorrectionStatus.Text = "Load image!";
            // 
            // labelCorrectionTimer
            // 
            this.labelCorrectionTimer.AutoSize = true;
            this.labelCorrectionTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCorrectionTimer.Location = new System.Drawing.Point(1004, 429);
            this.labelCorrectionTimer.Name = "labelCorrectionTimer";
            this.labelCorrectionTimer.Size = new System.Drawing.Size(221, 32);
            this.labelCorrectionTimer.TabIndex = 12;
            this.labelCorrectionTimer.Text = "Correction time: ";
            // 
            // saveFileResult
            // 
            this.saveFileResult.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp";
            // 
            // trackBarThreads
            // 
            this.trackBarThreads.LargeChange = 8;
            this.trackBarThreads.Location = new System.Drawing.Point(222, 88);
            this.trackBarThreads.Maximum = 64;
            this.trackBarThreads.Minimum = 1;
            this.trackBarThreads.Name = "trackBarThreads";
            this.trackBarThreads.Size = new System.Drawing.Size(697, 69);
            this.trackBarThreads.SmallChange = 4;
            this.trackBarThreads.TabIndex = 4;
            this.trackBarThreads.TickFrequency = 4;
            this.trackBarThreads.Value = 1;
            this.trackBarThreads.ValueChanged += new System.EventHandler(this.trackBarThreads_ValueChanged);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelThreads.Location = new System.Drawing.Point(18, 88);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(149, 32);
            this.labelThreads.TabIndex = 14;
            this.labelThreads.Text = "Threads: 1";
            // 
            // FormGamCor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 724);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.trackBarThreads);
            this.Controls.Add(this.labelCorrectionTimer);
            this.Controls.Add(this.labelCorrectionStatus);
            this.Controls.Add(this.labelCorrectedPhoto);
            this.Controls.Add(this.labelOriginalPhoto);
            this.Controls.Add(this.labelGamma);
            this.Controls.Add(this.trackBarGamma);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.buttonCorrectImage);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxLoad);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.checkBoxAsm);
            this.Controls.Add(this.checkBoxC);
            this.Name = "FormGamCor";
            this.Text = "Gamma Correction App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxC;
        private System.Windows.Forms.CheckBox checkBoxAsm;
        private System.Windows.Forms.OpenFileDialog openFileToLoadImage;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonCorrectImage;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.TrackBar trackBarGamma;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelOriginalPhoto;
        private System.Windows.Forms.Label labelCorrectedPhoto;
        private System.Windows.Forms.Label labelCorrectionStatus;
        private System.Windows.Forms.Label labelCorrectionTimer;
        private System.Windows.Forms.SaveFileDialog saveFileResult;
        private System.Windows.Forms.TrackBar trackBarThreads;
        private System.Windows.Forms.Label labelThreads;
    }
}

