using System.ComponentModel;

namespace Service.Models
{
    // This class is used to display the judgepairs with the ID of the judgepair, and the names of the judges
    public class DisplayJudgePair : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int judgePairID;
        public int JudgePairID
        {
            get { return judgePairID; }
            set {
                judgePairID = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("JudgePairID"));
            }
        }

        private string judgeNameA;
        public string JudgeNameA
        {
            get { return judgeNameA; }
            set {
                judgeNameA = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("JudgeNameA"));
            }
        }

        private string judgeNameB;
        public string JudgeNameB
        {
            get { return judgeNameB; }
            set {
                judgeNameB = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("JudgeNameB"));
            }
        }
    }
}
