/**************************************************************************
AUTOMATIC GENERATED FILE! DO NOT CHANGE MANUALLY 		
CrossBase.CodeGeneration
Wies Hubbers
**************************************************************************/
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantUsingDirective
using System;
using CrossBase.Dispatch;
using CrossBase.Serialization;
using Test.CrossBase.CodeGeneration.TestData;
using CrossBase.CodeGeneration.Attributes;
using Test.CrossBase.CodeGeneration.TestData;

namespace Test.CrossBase.CodeGeneration.TestData	
{
	public interface IInvokeFoekiControllerEx
	{
		event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		void DoThis();
		event EventHandler<EventArgs> DoThisStarted;
		event EventHandler<EventArgs> DoThisFinished;
	}
	
	public partial class InvokeFoekiController: IInvokeFoekiControllerEx
	{
        public IDispatcher DownDispatcher { get; set; }
        
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		public event EventHandler<EventArgs> DoThisStarted;
		public event EventHandler<EventArgs> DoThisFinished;
		
		private void InvokeDoThisStarted(EventArgs e)
	    {
	       	var handler = DoThisStarted;
	       	if (handler != null) handler(this, e);
	    }
			
		private void InvokeDoThisFinished(EventArgs e)
	    {
	       	var handler = DoThisFinished;
	       	if (handler != null) handler(this, e);
	    }	
				private  IOekiFoekiController controller;
			
		public IOekiFoekiController Controller
		{
			get
			{
				return controller;
			}
			set
			{			
				if (controller != null) 
					UnsubscribeToController();

				controller = value;
				SubscribeToController();
			}
		}
		private void OnOekiDoekiHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
			var clone = e.DeepClone();
			var handler = OekiDoeki;
			if (handler != null) handler(this, clone);
		}
		public void UnsubscribeToController()
		{
			if (controller == null)
				return;
			controller.OekiDoeki -= OnOekiDoekiHandler;
		}		

		private void SubscribeToController()
		{
			controller.OekiDoeki += OnOekiDoekiHandler;
		}

		public void DoThis()
		{
			DownDispatcher.Invoke(() => 
				{
					InvokeDoThisStarted(EventArgs.Empty);
					try
					{
						controller.DoThis();
					}
					finally
					{
						InvokeDoThisFinished(EventArgs.Empty);
					}
				});
		}
	}
}

// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
