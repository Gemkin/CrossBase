using System.Threading;
using CrossBase;
using CrossBase.Timers;
using NUnit.Framework;
using Test.CrossBase.Base;

namespace Test.CrossBase.Timers
{
    [TestFixture]
    public class TestMultiShotTimer : TestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            dispatcher = new TimedStubDispatcher(SystemServices.ThreadManager.GetCurrentThread());
            callbackTimes = 0;
            timer = new MultiShotTimer(TimerName, 100, dispatcher);
            timer.Tick += () => { callbackTimes++; timerThread = SystemServices.ThreadManager.GetCurrentThread(); };
        }

        private TimedStubDispatcher dispatcher;
        private int callbackTimes;
        private ITimer timer;
        private Thread timerThread;
        private const int TimeOutIsTrue = 300;
        private const int TimeOutIsFalse = 300;
        private const string TimerName = "TestTimer";


        [Test]
        public void TimerWillNotTickBeforeStart()
        {
            Assert.IsFalse(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsFalse));
            Assert.AreEqual(0, callbackTimes);
            timer.Start();
            Assert.AreEqual(0, callbackTimes);
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.AreEqual(1, callbackTimes);
        }

        [Test]
        public void TimerWillTickMultipleTimesAfterSeveralMicroSeconds()
        {
            timer.Start();
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.AreEqual(4, callbackTimes);
        }

        

        [Test]
        public void TimerWillNotTickAfterStop()
        {
            timer.Start();
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            timer.Stop();
            Assert.IsFalse(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsFalse));
        }


        [Test]
        public void TickEventComesFromSameThreadAsTimerInstance()
        {
            timer.Start();
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.AreEqual(dispatcher.Thread, timerThread);
        }


    }
}