using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace ClassProducer
{
    [DataContract]
    class StoryReader
    {
        
        string _Folder;
        string _AudioFile;
        string _TextFile;
        string _Text;
        string[] _Lines;
        bool initialTimecodeWereSet;
        List<Paragraph> _Paragraphs;
        private static readonly string[] LINE_DELIMITER = new string[] { "\r\n" };

        
        internal StoryReader() : this(@"C:\Users\Alma\Documents\GitHub\LaBaignoireRoot\episode1")
        {
        }
        [DataMember]
        public List<Paragraph> Paragraphs
        {
            get
            {
                return _Paragraphs;
            }
            set
            {
                _Paragraphs = value;
                foreach (Paragraph p in _Paragraphs)
                    p.Story = this;
            }
        }
            
        internal StoryReader(string folder)
        {
            this._Folder = folder;
            _AudioFile = SelectFileOfType("mp3");
            _TextFile = SelectFileOfType("txt");
            Text = ReadFile();
                        
        }

        internal bool SetMediaDuration(double duration)
        {
            if (initialTimecodeWereSet)
                return false;
            float TotalCharacters = 0;
            foreach (Paragraph p in _Paragraphs)
                TotalCharacters += p.CharLength;
            double durationPerCharacter = duration / TotalCharacters;
            double pos = 0;
            foreach(Paragraph p in _Paragraphs)
                pos = p.SetAudioBounds(pos, durationPerCharacter);
            return initialTimecodeWereSet = true;
        }

        internal char GetLineInTaatik(int i)
        {
            throw new NotImplementedException();
        }

        private String ConcatenateParagraphs()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _Paragraphs.Count; ++i)
                sb.Append(_Paragraphs[i].Text);
            return sb.ToString();
        }

        private String ConcatenateParagraphsTaatik()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _Paragraphs.Count; ++i)
                sb.Append(_Paragraphs[i].Taatik);
            return sb.ToString();
        }

        public string Text
        {
            get
            {
                return ConcatenateParagraphs();
            }
            set
            {
                
                _Lines = value.Split(LINE_DELIMITER, StringSplitOptions.None);
                for (int i = 0; i < _Lines.Length; ++i)
                    _Lines[i] = _Lines[i].Trim();
                _Paragraphs = CalculateParagraphs();
            }
        }

        private List<Paragraph> CalculateParagraphs()
        {
            List<Paragraph> RetVal = new List<Paragraph>();
                        
            for (int StartLine = 0; StartLine < _Lines.Length; ++StartLine)
            {
                if (_Lines[StartLine] != string.Empty)
                {
                    int EndLine = GoToParagraphEnd(StartLine);
                    RetVal.Add(new Paragraph(this, StartLine, EndLine, LINE_DELIMITER[0].Length));
                    StartLine = EndLine;
                }
            }
            //int StartChar = 0;
            //foreach (Paragraph p in RetVal)
            //    StartChar = p.SetStartCharacter(StartChar);
            return RetVal;
        }
        [DataMember]
        public string[] Lines
        {
            get
            {
                return _Lines;
            }
            set
            {
                _Lines = value;
            }
        }

        private int GoToParagraphEnd(int StartLine)
        {
            while (StartLine < _Lines.Length && _Lines[StartLine] != string.Empty)
                ++StartLine;
            while (StartLine + 1 < _Lines.Length && _Lines[StartLine + 1] == string.Empty)
                ++StartLine;
            return StartLine;
        }

        private string ReadFile()
        {
            return ReadFile(_TextFile);
        }

        private string ReadFile(string File)
        {
            StreamReader reader = new StreamReader(File);
            string retVal = reader.ReadToEnd();
            reader.Close();
            return retVal;
        }

        internal void CreateCharMap()
        {
            Dictionary<char, int> Values = new Dictionary<char, int>();
            foreach (char c in Text) {
                if (c  < 1000)
                    continue;
                if (!Values.ContainsKey(c))
                    Values[c] = 1;
                else
                    Values[c]++;
            }
            List<char> chars = Values.Keys.ToList();
            chars.Sort();
            StreamWriter writer = new StreamWriter("test.txt");
            foreach (char c in chars)
            {
                writer.WriteLine(String.Format("{0}\t{1}\t{2}", c, Values[c], Convert.ToInt32(c).ToString("X")));
            }
            writer.Close();
        }

        public string TextFile
        {
            get
            {
                return TextFile;
            }
        }
        [DataMember]
        public string AudioFile
        {
            get
            {
                return _AudioFile;
            }
            set
            {
                _AudioFile = value;
            }
        }

        public string Taatik {
            get
            {
                return ConcatenateParagraphsTaatik();
            }
        }

        private string SelectFileOfType(string type)
        {
            string[] files = Directory.GetFiles(_Folder, "*." + type);
            if (files.Length == 1)
                return files[0];
            throw new Exception("More than one file was found");
        }
    }
}
