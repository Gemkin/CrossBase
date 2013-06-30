using System;
using System.Threading;
using CrossBase.Dispatch;

namespace CrossBase.Platform.IOS
{
    public class Dispatcher : IDispatcher
	{
	    private readonly MonoTouch.Foundation.NSObject obj;
	    private readonly int threadId;
        public Dispatcher(MonoTouch.Foundation.NSObject obj, DispatcherId id)
		{
			this.obj = obj;
			Id = id;
			threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
		}
		
		
		public int ThreadId
		{
			get { return threadId; }
		}
		
		public void Invoke(Action methodToExecute)
		{
		}
		
		public void BeginInvoke(Action methodToExecute)
		{
			obj.BeginInvokeOnMainThread (() => methodToExecute());
		}
		
		public void Dispose()
		{
		}
		
		public DispatcherId Id { get; private set; }
		
	}
    
}