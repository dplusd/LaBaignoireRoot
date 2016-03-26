using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProducer
{
    class Paragraph
    {
        private StoryReader _Story;
        private int _StartLine, _EndLine, _StartCharacter;
        private string _Text;
        private double _StartAudio, _EndAudio;
        

        public double StartAudioPos
        {
            get
            {
                return _StartAudio;
            }
            set
            {
                _StartAudio = value;
            }
        }

        public double EndAudioPos
        {
            get
            {
                return _EndAudio;
            }
            set
            {
                _EndAudio = value;
            }
        }

        internal int SetStartCharacter(int StartChar)
        {
            _StartCharacter = StartChar;
            return _StartCharacter + CharLength;
        }
        

        public double SetAudioBounds(double StartAudio, double secondPerCharacter)
        {
            _StartAudio = StartAudio;
            _EndAudio = StartAudio + CharLength * secondPerCharacter;
            return _EndAudio;
        }

        internal Paragraph(StoryReader story, int StartLine, int EndLine, int LineDelimiterLength)
        {
            this._Story = story;
            this._StartLine = StartLine;
            this._EndLine = EndLine;            
        }

        public override string ToString()
        {
            return _Text.Substring(0, Math.Min(15, _Text.Length));
        }
        
        internal string Text
        {
            get
            {
                if (_Text == null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = _StartLine; i <= _EndLine; ++i)
                        sb.Append(_Story.Lines[i]).Append("\n");
                    _Text = sb.ToString();
                }
                return _Text;
            }
        }


        internal string Taatik
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int i = _StartLine; i <= _EndLine; ++i)
                    sb.Append(ArabicTranscriptor.Transcript(_Story.Lines[i])).Append("\n");
                return sb.ToString();
            }
        }

        internal int CharLength
        {
            get
            {
                return Text.Length;
            }
        }

      

       
    }
}
