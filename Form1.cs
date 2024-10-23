namespace Notepad
{
    public partial class Form1 : Form
    {
        private string path;
        public Form1()
        {
            InitializeComponent();
            path = null;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                // Save with the appropriate format
                SaveFileWithFormat(path);
                rtb_body.Clear();
                path = null;
            }
            else
            {
                if (saveFD.ShowDialog() == DialogResult.OK)
                {
                    // Save file
                    SaveFileWithFormat(saveFD.FileName);
                    rtb_body.Clear();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                // Save file
                SaveFileWithFormat(saveFD.FileName);
                rtb_body.Clear();
                path = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open file
                if (rtb_body.Text != "")
                {
                    if (MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }
                }

                LoadFileWithFormat(openFileDialog1.FileName);
                path = openFileDialog1.FileName;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_body.Text != "")
            {
                if (MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    rtb_body.Clear();
                    path = null;
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_body.Text != "")
            {
                if (MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }

                this.Close();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText != "")
                {
                    rtb_body.SelectionFont = fontD.Font;
                }
                else
                {
                    rtb_body.Font = fontD.Font;
                }

            }
        }

        // Helper method to save file with appropriate format
        private void SaveFileWithFormat(string fileName)
        {
            if (fileName.EndsWith(".rtf"))
            {
                rtb_body.SaveFile(fileName, RichTextBoxStreamType.RichText);
            }
            else
            {
                rtb_body.SaveFile(fileName, RichTextBoxStreamType.PlainText);
            }
        }

        // Helper method to load file with appropriate format
        private void LoadFileWithFormat(string fileName)
        {
            if (fileName.EndsWith(".rtf"))
            {
                // Load file with rich text format
                rtb_body.LoadFile(fileName, RichTextBoxStreamType.RichText);
            }
            else
            {
                // Load file with plain text format
                rtb_body.LoadFile(fileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText != "")
                {
                    rtb_body.SelectionColor = colorD.Color;
                }
                else
                {
                    rtb_body.ForeColor = colorD.Color;
                }
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText != "")
                {
                    rtb_body.SelectionBackColor = colorD.Color;
                }
                else
                {
                    rtb_body.BackColor = colorD.Color;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rtb_body.Text != "")
            {
                if (MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }

                else
                {
                    this.Close();
                }
            }
        }
    }
}
