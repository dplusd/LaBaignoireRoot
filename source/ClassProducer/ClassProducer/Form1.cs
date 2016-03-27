using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClassProducer
{
    public partial class Form1 : Form
    {
        private StoryReader story;
        public Form1()
        {
            InitializeComponent();
            ArabicTranscriptor.Transcript("");
            story = new StoryReader();
            rtbText.Text = story.Text;
            
            Player.URL = story.AudioFile;

            lstParagraphs.Items.Clear();
            foreach(Paragraph p in story.Paragraphs)
            {
                lstParagraphs.Items.Add(p);
            }
            
        }

        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (Player.Ctlcontrols.currentItem != null && Player.Ctlcontrols.currentItem.duration > 0)
                if (story.SetMediaDuration(Player.Ctlcontrols.currentItem.duration))
                    Player.Ctlcontrols.stop();
        }

        private void lstParagraphs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParagraphs.SelectedItem != null)
            {
                ShowParagraphInfo((Paragraph)lstParagraphs.SelectedItem);
                
            }
        }

        private void ShowParagraphInfo(Paragraph p)
        {
            txtStartPosition.Text = Math.Round(p.StartAudioPos, 2).ToString();
            txtEndPosition.Text = Math.Round(p.EndAudioPos, 2).ToString();
        }

        private void btnSetEnd_Click(object sender, EventArgs e)
        {
            if (lstParagraphs.SelectedIndex == -1)
                return;
            story.Paragraphs[lstParagraphs.SelectedIndex].EndAudioPos = Player.Ctlcontrols.currentPosition;
            if (lstParagraphs.SelectedIndex < story.Paragraphs.Count - 1)
                story.Paragraphs[lstParagraphs.SelectedIndex + 1].StartAudioPos = Player.Ctlcontrols.currentPosition;
            ShowParagraphInfo(story.Paragraphs[lstParagraphs.SelectedIndex]);
        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            if (lstParagraphs.SelectedIndex == -1)
                return;
            story.Paragraphs[lstParagraphs.SelectedIndex].StartAudioPos = Player.Ctlcontrols.currentPosition;
            if (lstParagraphs.SelectedIndex > 0)
                story.Paragraphs[lstParagraphs.SelectedIndex - 1].EndAudioPos = Player.Ctlcontrols.currentPosition;
            ShowParagraphInfo(story.Paragraphs[lstParagraphs.SelectedIndex]);
        }

        private bool HasSelectedParagraph
        {
            get
            {
                return lstParagraphs.SelectedIndex != -1;
            }
        }

        private Paragraph SelectedParagraph
        {
            get
            {
                return (Paragraph)lstParagraphs.SelectedItem;
            }
        }

        private void btnPlayStart_Click(object sender, EventArgs e)
        {
            if (!HasSelectedParagraph)
                return;
            Player.Ctlcontrols.currentPosition = SelectedParagraph.StartAudioPos;
            Player.Ctlcontrols.play();

        }

        private void btnPlayEnd_Click(object sender, EventArgs e)
        {
            if (!HasSelectedParagraph)
                return;
            Player.Ctlcontrols.currentPosition = SelectedParagraph.EndAudioPos - 5;
            Player.Ctlcontrols.play();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //rtbText.Text = story.Taatik;
            ArabicTranscriptor.ToJson();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FileStream stream1 = new FileStream("obj.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StoryReader), new Type[] { typeof(Paragraph) });
            ser.WriteObject(stream1, story);
            stream1.Close();
            
        }
    }
}
