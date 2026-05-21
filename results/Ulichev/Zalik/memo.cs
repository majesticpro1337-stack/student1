using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memo
{
    public partial class Form1 : Form
    {
        private const int Rows = 4;
        private const int Cols = 4;
        private List<Button> cardButtons = new List<Button>();
        private List<Image> pairImages;
        private Image cardBack;
        private int[] cardPairId;
        private bool[] isMatched;
        private bool isRevealPhase = true;
        private bool waitingForFlip = false;
        private int? firstCardIndex = null;
        private int attempts = 0;
        private int matchedPairs = 0;
        private int seconds = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratePairImages()
        {
            pairImages = new List<Image>();
            string resourcesFolder = Path.Combine(Application.StartupPath, "Resours");

            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "blush.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "cat.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "cool.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "expression.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "flag.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "happy.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "scared.png")));
            pairImages.Add(Image.FromFile(Path.Combine(resourcesFolder, "smiley.png")));
        }

        private void LoadCardBack()
        {
            string backPath = Path.Combine(Application.StartupPath, "Resours", "cardBack.png");
            cardBack = Image.FromFile(backPath);
        }

        private void PrepareNewGame()
        {
            revealTimer.Stop();
            flipBackTimer.Stop();
            gameTimer.Stop();
            waitingForFlip = false;
            firstCardIndex = null;
            attempts = 0;
            matchedPairs = 0;
            seconds = 0;
            UpdateStats();

            int totalCards = Rows * Cols;
            cardPairId = new int[totalCards];
            isMatched = new bool[totalCards];

            List<int> pairIds = new List<int>();
            for (int i = 0; i < totalCards / 2; i++)
            {
                pairIds.Add(i);
                pairIds.Add(i);
            }

            Random rnd = new Random();
            pairIds = pairIds.OrderBy(x => rnd.Next()).ToList();
            for (int i = 0; i < totalCards; i++)
                cardPairId[i] = pairIds[i];

            tlpCards.Controls.Clear();
            cardButtons.Clear();

            for (int i = 0; i < totalCards; i++)
            {
                Button btn = new Button
                {
                    Dock = DockStyle.Fill,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = i,
                    Enabled = true
                };
                btn.Click += Card_Click;
                tlpCards.Controls.Add(btn, i % Cols, i / Cols);
                cardButtons.Add(btn);
            }

            isRevealPhase = true;
            for (int i = 0; i < totalCards; i++)
            {
                cardButtons[i].BackgroundImage = pairImages[cardPairId[i]];
            }

            revealTimer.Interval = (int)nudRevealTime.Value * 1000;
            revealTimer.Start();
            gameTimer.Start();
        }

        private void UpdateStats()
        {
            lblAttempts.Text = $"Попытки: {attempts}";
            lblTimer.Text = $"Время: {seconds} с";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnNewGame.Text = "Почати заново";
            GeneratePairImages();
            LoadCardBack();
            PrepareNewGame();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = (int)btn.Tag;
            if (isRevealPhase || waitingForFlip || isMatched[index])
                return;
            if (btn.BackgroundImage != cardBack && !isMatched[index])
                return;
            if (firstCardIndex == null)
            {
                btn.BackgroundImage = pairImages[cardPairId[index]];
                firstCardIndex = index;
                return;
            }
            if (firstCardIndex == index) return;
            attempts++;
            UpdateStats();
            btn.BackgroundImage = pairImages[cardPairId[index]];
            if (cardPairId[firstCardIndex.Value] == cardPairId[index])
            {
                isMatched[firstCardIndex.Value] = true;
                isMatched[index] = true;
                matchedPairs++;
                cardButtons[firstCardIndex.Value].Enabled = false;
                cardButtons[index].Enabled = false;

                firstCardIndex = null;

                if (matchedPairs == (Rows * Cols) / 2)
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Перемога!\nСпроб: {attempts}\nЧас: {seconds} секунд",
                                    "Гра закінчена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                waitingForFlip = true;
                int first = firstCardIndex.Value;
                int second = index;
                flipBackTimer.Stop();
                flipBackTimer.Start();
                flipBackTimer.Tag = (first, second);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!isRevealPhase)
                seconds++;
            UpdateStats();
        }

        private void revealTimer_Tick(object sender, EventArgs e)
        {
            revealTimer.Stop();
            for (int i = 0; i < cardButtons.Count; i++)
            {
                if (!isMatched[i])
                    cardButtons[i].BackgroundImage = cardBack;
            }
            isRevealPhase = false;
        }

        private void flipBackTimer_Tick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();

            if (flipBackTimer.Tag is ValueTuple<int, int> tuple)
            {
                int first = tuple.Item1;
                int second = tuple.Item2;

                if (!isMatched[first])
                    cardButtons[first].BackgroundImage = cardBack;
                if (!isMatched[second])
                    cardButtons[second].BackgroundImage = cardBack;
            }

            waitingForFlip = false;
            firstCardIndex = null;
        }
    }
}
