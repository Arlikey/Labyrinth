namespace Labyrinth
{
    partial class LabyrinthMenuForm
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
            loadMapButton = new Button();
            startGameButton = new Button();
            mapNameLabel = new Label();
            SuspendLayout();
            // 
            // loadMapButton
            // 
            loadMapButton.Cursor = Cursors.Hand;
            loadMapButton.FlatStyle = FlatStyle.Flat;
            loadMapButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            loadMapButton.Image = Properties.Resources.free_icon_world_map_1497770__1_;
            loadMapButton.ImageAlign = ContentAlignment.MiddleLeft;
            loadMapButton.Location = new Point(101, 48);
            loadMapButton.Name = "loadMapButton";
            loadMapButton.Size = new Size(240, 65);
            loadMapButton.TabIndex = 0;
            loadMapButton.Text = "Загрузить карту";
            loadMapButton.TextAlign = ContentAlignment.MiddleRight;
            loadMapButton.UseVisualStyleBackColor = true;
            loadMapButton.Click += laodMapButton_Click;
            // 
            // startGameButton
            // 
            startGameButton.Enabled = false;
            startGameButton.FlatStyle = FlatStyle.Flat;
            startGameButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startGameButton.Location = new Point(166, 251);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(121, 45);
            startGameButton.TabIndex = 1;
            startGameButton.Text = "Начать игру";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // mapNameLabel
            // 
            mapNameLabel.AutoSize = true;
            mapNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            mapNameLabel.Location = new Point(101, 143);
            mapNameLabel.Name = "mapNameLabel";
            mapNameLabel.Size = new Size(135, 20);
            mapNameLabel.TabIndex = 2;
            mapNameLabel.Text = "Название карты : ";
            // 
            // LabyrinthMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 359);
            Controls.Add(mapNameLabel);
            Controls.Add(startGameButton);
            Controls.Add(loadMapButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LabyrinthMenuForm";
            Text = "Главное меню";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadMapButton;
        private Button startGameButton;
        private Label mapNameLabel;
    }
}