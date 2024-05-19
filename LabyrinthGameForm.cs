
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
        private int coins = 0;

        Random random = new Random();
        public LabyrinthGameForm(char[,] map)
        {
            InitializeComponent();
            this.map = map;
            MazeSize = new int[map.GetLength(0), map.GetLength(1)];
            InitializeMaze();
            GenerateCoins();
            timer.Start();
        }



        private void InitializeMaze()
        {
            int cellWidth = this.ClientSize.Width / MazeSize.GetLength(1);
            int cellHeight = this.ClientSize.Height / MazeSize.GetLength(0);
            int cellSize = Math.Min(cellWidth, cellHeight);

            CellSize = cellSize;

            this.ClientSize = new Size((CellSize * MazeSize.GetLength(1)), (CellSize * MazeSize.GetLength(0)));
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Лабиринт";
        }

        private void GenerateCoins()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i, j] == ' ')
                    {
                        map[i, j] = random.Next(map.GetLength(0)) == map.GetLength(0)-1 ? '0' : ' ';
                    }
                }
            }
        }

        private void LabyrinthGameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < MazeSize.GetLength(0); i++)
            {
                for (int j = 0; j < MazeSize.GetLength(1); j++)
                {
                    Brush brush = map[i, j] == '*' ? Brushes.Black : map[i, j] == '0' ? Brushes.Gold : Brushes.White;
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

            if (map[newY, newX] == '0')
            {
                playerX = newX;
                playerY = newY;
                map[newY, newX] = ' ';
                coins++;
                Invalidate();
            }

            if (playerX == map.GetLength(1) - 1 || playerY == map.GetLength(0) - 1)
            {
                timer.Stop();
                var dialogResult = MessageBox.Show($"Вы прошли лабиринт!\n\nПотрачено времени на прохождение : {TimeSpan.FromSeconds(time)}" +
                    $"\n\nСобрано монет : {coins}\n\nХотите вернуться в главное меню?", "Победа!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
