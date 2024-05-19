using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class LabyrinthMenuForm : Form
    {
        private char[,] map;
        public LabyrinthMenuForm()
        {
            InitializeComponent();
        }

        private void laodMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(ofd.FileName);
                    map = new char[lines.Length, lines[0].Length];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        for (int j = 0; j < lines[i].Length; j++)
                        {
                            map[i, j] = lines[i][j];
                        }
                    }
                    mapNameLabel.Text = $"Название карты : {Path.GetFileNameWithoutExtension(ofd.FileName)}";
                    mapNameLabel.Location = new Point((ClientSize.Width - mapNameLabel.Width) / 2, mapNameLabel.Location.Y);
                    startGameButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            LabyrinthGameForm labyrinthGameForm = new LabyrinthGameForm(map);
            labyrinthGameForm.ShowDialog();
        }
    }
}
