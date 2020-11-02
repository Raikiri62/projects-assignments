using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class Updater
    {
        public SchedulerChecker m_SchedulerChecker;
        private MainForm m_MainForm;
        public Updater(MainForm i_MainForm)
        {
            m_MainForm = i_MainForm;
            m_SchedulerChecker = new SchedulerChecker(new QuickRefreshStrategy());
            m_SchedulerChecker.Listeners += new Action<string>(checkIfMarketIsUpToDate);
            m_SchedulerChecker.Listeners += new Action<string>(checkIfPhotosCollectionIsUpToDate);
            m_SchedulerChecker.Listeners += new Action<string>(checkIfBankIsUpToDate);
        }
        public void checkIfMarketIsUpToDate(string msg)
        {
            if(UpdaterChecker.IsMarketDataHasChanged)
            {
                m_MainForm.updateMarket();
                UpdaterChecker.IsMarketDataHasChanged = false;
            }
        }
        public void checkIfBankIsUpToDate(string msg)
        {
            if (UpdaterChecker.IsBankHasChanged)
            {
                m_MainForm.populateLabels();
                UpdaterChecker.IsBankHasChanged = false;
            }
        }
        public void checkIfPhotosCollectionIsUpToDate(string msg)
        {
            if (UpdaterChecker.IsPhotosCollectionHasChanged)
            {
                m_MainForm.updateCollectionForm();
                UpdaterChecker.IsPhotosCollectionHasChanged = false;
            }
        }
    }
    public class SchedulerChecker
    {
        private static Timer m_Timer;
        public event Action<string> Listeners;
        public IRefreshStrategy RefreshStrategy { get; set; }
        public SchedulerChecker(IRefreshStrategy strategy)
        {
            RefreshStrategy = strategy;
            m_Timer = new Timer(notify, null, 1000, RefreshStrategy.AmoumtOfTime());
        }
        private void notify(object state)
        {
            Listeners.Invoke("check");
        }
    }
    public interface IRefreshStrategy
    {
        int AmoumtOfTime();
    }
    public class QuickRefreshStrategy : IRefreshStrategy
    {
        public int AmoumtOfTime()
        {
            return 2000; // this is 10 seconds in milliseconds!
        }
    }
    public class SlowRefreshStrategy : IRefreshStrategy
    {
        public int AmoumtOfTime()
        {
            return 180000; // // this is 3 minutes in milliseconds!
        }
    }
}
