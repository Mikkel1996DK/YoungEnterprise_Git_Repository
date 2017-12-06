using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoungEnterprise_API.Models;

namespace Admin.ViewModels
{
    public class EventViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private ObservableCollection<TblJudgePair> judgePairs = new ObservableCollection<TblJudgePair>();
        public ObservableCollection<TblJudgePair> JudgePairs
        {
            get { return judgePairs; }
            set { judgePairs = value; }
        }



    }
}
