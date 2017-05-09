using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public delegate void DelegateShow(int x, int y, int number);
    public delegate void DelegateOutput(int scores);

    public partial class Game2048 : Form
    {
        static int size = 4; // Определеяет размер поля
        Label[,] box; // массив полей
        Dictionary<int, Color> back_colors; // создаем словарь цветов для кнопок
        Logic logic;

        public Game2048()
        {
            InitializeComponent();
            InitLabels();
            InitBackColor();
            logic = new Logic(size, Show);
            logic.init_game();
        }

        private void InitBackColor()
        {
            back_colors = new Dictionary<int, Color>();
            back_colors.Add(0, this.BackColor);
            back_colors.Add(2, Color.LightGray);
            back_colors.Add(4, Color.PeachPuff);
            back_colors.Add(8, Color.SandyBrown);
            back_colors.Add(16, Color.Coral);
            back_colors.Add(32, Color.OrangeRed);
            back_colors.Add(64, Color.Khaki);
            back_colors.Add(128, Color.Gold);
            back_colors.Add(256, Color.GreenYellow);
            back_colors.Add(512, Color.LawnGreen);
            back_colors.Add(1024, Color.Brown);
            back_colors.Add(2048, Color.Red);

        }

        private void InitLabels()
        {
            box = new Label[size, size];

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    box[x, y] = CreateLabels();
                    tableLayoutPanel1.Controls.Add(box[x,y], x, y);
                }
        }

        private Label CreateLabels()
        {
            Label label = new Label();
            label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Margin = new System.Windows.Forms.Padding(10);
            label.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label.Text = "-";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }

        public void Show (int x, int y, int number)
        {
            box[x, y].Text = number > 0 ? number.ToString() : "";
            box[x, y].BackColor = back_colors[number];
        }

        public void Output(int scores)
        {
            int scores1 = 0;
             scores1 = scores1 + scores;
            label1.Text = label1.Text + scores1.ToString();
        }

        private void Game2048_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left: logic.shift_left(); break;
                case Keys.Right: logic.shift_right(); break;
                case Keys.Up: logic.shift_up(); break;
                case Keys.Down: logic.shift_down(); break;
                case Keys.Escape: break;
                default: break;

            }

            if (logic.game_over())
            {
                MessageBox.Show("Игра окончена!", "Внимание");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logic.init_game();
        }
    }
}
