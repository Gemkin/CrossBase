using System.Collections.Generic;
using CrossBase;
using CrossBase.Dispatch;
using NUnit.Framework;
using Test.CrossBase.Base;

namespace Test.CrossBase.Dispatch
{
    [TestFixture]
    public abstract class TestMainLoopDispatcherBase : TestBase
    {
        private List<int> invoked;
        private MainLoopDispatcher dispatcher;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            invoked = new List<int>();
            dispatcher = new MainLoopDispatcher(DispatcherId.Logic);
        }

        [TearDown]
        public override void TearDown()
        {
            dispatcher.Dispose();
            base.TearDown();
        }

        [Test]
        public void BeginInvoke()
        {
            dispatcher.BeginInvoke(() => invoked.Add(1));
            dispatcher.BeginInvoke(() => SystemServices.ThreadManager.Sleep(500));
            dispatcher.BeginInvoke(() => invoked.Add(2));
            dispatcher.BeginInvoke(() => SystemServices.ThreadManager.Sleep(500));
            dispatcher.BeginInvoke(() => invoked.Add(3));
            dispatcher.BeginInvoke(() => invoked.Add(4));

            Assert.That(invoked.Count, Is.LessThan(4));

            while (invoked.Count < 4)
                SystemServices.ThreadManager.Sleep(100);

            for (var i = 0; i < 4; i++)
            {
                Assert.That(invoked[i], Is.EqualTo(i + 1));
            }
        }
    }
}