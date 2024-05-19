
using System.Drawing;

namespace Labyrinth
{
    public partial class LabyrinthGameForm : Form
    {
        private int CellSize = 40;
        private int[,] MazeSize;

        private int playerX = 1;
        private int playerY = 1;

        private char[,] map;

        private int time = 0;
        public LabyrinthGameForm(char[,] map)
        {
            InitializeComponent();
            this.map = map;
            MazeSize = new int[map.GetLength(0), map.GetLength(1)];
            InitializeMaze();
            timer.Start();
        }



        private void InitializeMaze()
        {
            this.ClientSize = new Size((CellSize * MazeSize.GetLength(1)), (CellSize * MazeSize.GetLength(0)));
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "��������";
        }

        private void LabyrinthGameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < MazeSize.GetLength(0); i++)
            {
                for (int j = 0; j < MazeSize.GetLength(1); j++)
                {
                    Brush brush = map[i, j] == '*' ? Brushes.Black : Brushes.White;
                    g.FillRectangle(brush, j * CellSize, i * CellSize, CellSize, CellSize);
                }
            }
            g.FillRectangle(Brushes.Red, playerX * CellSize, playerY * CellSize, CellSize, CellSize);
        }

        private void LabyrinthGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            int newX = playerX;
            int newY = playerY;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    newY = Math.Max(0, playerY - 1);
                    break;
                case Keys.Down:
                    newY = Math.Min(MazeSize.GetLength(0) - 1, playerY + 1);
                    break;
                case Keys.Left:
                    newX = Math.Max(0, playerX - 1);
                    break;
                case Keys.Right:
                    newX = Math.Min(MazeSize.GetLength(1) - 1, playerX + 1);
                    break;
            }

            if (map[newY, newX] == ' ')
            {
                playerX = newX;
                playerY = newY;
                Invalidate();
            }

            if (playerX == map.GetLength(1) - 1 || playerY == map.GetLength(0) - 1)
            {
                timer.Stop();
                var dialogResult = MessageBox.Show($"�� ������ ��������!\n\n��������� ������� �� ����������� : {TimeSpan.FromSeconds(time)}" +
                    $"\n\n������ ��������� � ������� ����?", "������!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
        }
    }
}
