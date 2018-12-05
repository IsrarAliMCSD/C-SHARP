using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBackByDelegatesAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //=========callback using delegates
            CallBackTest callBackTest = new CallBackTest();
            callBackTest.Test();
            Console.ReadLine();

            //=========callback using interfaace
            MeetingExecution meetingExecution = new MeetingExecution();
            meetingExecution.PerformMeeting();
            Console.ReadLine();
        }
    }
    #region Delegate
    
    public delegate void TaskCompletedCallBack(string taskResult);
    public class CallBack
    {
        public void StartNewTask(TaskCompletedCallBack taskCompletedCallBack)
        {
            Console.WriteLine("I have started new Task.");
            if (taskCompletedCallBack != null)
                taskCompletedCallBack("I have completed Task.");
        }
    }
    public class CallBackTest
    {
        public void Test()
        {
            TaskCompletedCallBack callback = TestCallBack;
            CallBack testCallBack = new CallBack();
            testCallBack.StartNewTask(callback);
        }
        public void TestCallBack(string result)
        {
            Console.WriteLine(result);
        }
    }
    #endregion

    #region interface
    public interface IMeeting
    {
        void ShowAgenda(string agenda);
        void EmployeeAttendedMeeting(string employee);
        void EmployeeLeftMeeting(string employee);
    }
    public class Meeting : IMeeting
    {
        public void ShowAgenda(string agenda)
        {
            Console.WriteLine("Agenda Details: " + agenda);
        }

        public void EmployeeAttendedMeeting(string employee)
        {
            Console.WriteLine("Employee Attended Meeting: " + employee);
        }

        public void EmployeeLeftMeeting(string employee)
        {
            Console.WriteLine("Employee Left Meeting: " + employee);
        }
    }
    public class MeetingRoom
    {
        private string message;
        public MeetingRoom(string message)
        {
            this.message = message;
        }
        public void StartMeeting(IMeeting meeting)
        {
            // Its a callback  
            if (meeting != null) meeting.ShowAgenda(message);

        }
    }

    public class MeetingExecution
    {
        public void PerformMeeting()
        {
            IMeeting meeging = new Meeting();
            MeetingRoom meetingStarted = new MeetingRoom("Code Quality Improvement.");
            meetingStarted.StartMeeting(meeging);
        }
    }
    #endregion
}
