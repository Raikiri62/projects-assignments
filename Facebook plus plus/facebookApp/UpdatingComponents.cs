using System;
using System.Threading;

namespace facebookApp
{
    public class Updater
    {
        public SchedulerChecker m_SchedulerChecker;
        private MainForm m_MainForm;
        private FriendList m_FriendList;

        public Updater(MainForm i_MainForm)
        {
            m_MainForm = i_MainForm;
            m_SchedulerChecker = new SchedulerChecker(new QuickRefreshStrategy());
            m_SchedulerChecker.Listeners += new Action<string>(checkIfFriendsListIsUpToDate);
        }

        public void checkIfFriendsListIsUpToDate(string i_msg)
        {
            m_FriendList = m_MainForm.fetchFriendsFromFacebookUser();

            if (!(m_FriendList.Equals(m_MainForm.m_FriendList)))
            {
                // then we need to update our data in MainForm and display again..
                m_MainForm.InitiateFriendsFeature();
                m_MainForm.showMsg(i_msg); // message that changed has been made and now the app is updating the relevant data.
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
            m_Timer = new Timer(notify, null, 5000, RefreshStrategy.AmoumtOfTime());
        }

        private void notify(object state)
        {
            Listeners.Invoke("Your Friends list has changed " + DateTime.Now + " updating list..");
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
            return 10000; // this is 10 seconds in milliseconds!
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