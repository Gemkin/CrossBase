#region  Copyright Koninklijke Philips Electronics N.V. (Philips Research, Miplaza SES), 2010
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherise, is prohibited
// without the prior written consent of the copyright owner.
// 
// 
#endregion

using System;
using System.Threading;
using CrossBase;
using CrossBase.Threading;
using CrossBase.Timers;
using NUnit.Framework;
using Test.CrossBase.Base;

namespace Test.CrossBase.Timers
{
    [TestFixture]
    public class TestOneShotTimer: TestBase
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            dispatcher = new TimedStubDispatcher(SystemServices.ThreadManager.GetCurrentThread());
            callbackTimes = 0;
            timer = new OneShotTimer(TimerName, 100, dispatcher);
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
            timer.Start();
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
        }

        [Test]
        public void TimerWillTickAfterSeveralMicroSeconds()
        {
            timer.Start();
            Assert.AreEqual(callbackTimes, 0);
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.AreEqual(callbackTimes, 1);
        }

        [Test]
        public void TimerWillTickOnce()
        {
            timer.Start();
            Assert.IsTrue(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsTrue));
            Assert.IsFalse(dispatcher.InvokeOccurrsWithinTimeout(TimeOutIsFalse));
        }

        [Test]
        public void TimerWillNotTickAfterStop()
        {
            timer.Start();
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