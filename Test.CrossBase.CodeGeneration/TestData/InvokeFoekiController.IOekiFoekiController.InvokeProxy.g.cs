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
	public partial class InvokeFoekiController
	{
        public IDispatcher DownDispatcher { get; set; }
        
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InProgress;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InBuilding;
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
				public event EventHandler<EventArgs> CleanUpStarted;
		public event EventHandler<EventArgs> CleanUpFinished;
		
		private void InvokeCleanUpStarted(EventArgs e)
	    {
	       	var handler = CleanUpStarted;
	       	if (handler != null) handler(this, e);
	    }
			
		private void InvokeCleanUpFinished(EventArgs e)
	    {
	       	var handler = CleanUpFinished;
	       	if (handler != null) handler(this, e);
	    }	
				public event EventHandler<EventArgs> BuildStarted;
		public event EventHandler<EventArgs> BuildFinished;
		
		private void InvokeBuildStarted(EventArgs e)
	    {
	       	var handler = BuildStarted;
	       	if (handler != null) handler(this, e);
	    }
			
		private void InvokeBuildFinished(EventArgs e)
	    {
	       	var handler = BuildFinished;
	       	if (handler != null) handler(this, e);
	    }	
				public event EventHandler<EventArgs> DisposeStarted;
		public event EventHandler<EventArgs> DisposeFinished;
		
		private void InvokeDisposeStarted(EventArgs e)
	    {
	       	var handler = DisposeStarted;
	       	if (handler != null) handler(this, e);
	    }
			
		private void InvokeDisposeFinished(EventArgs e)
	    {
	       	var handler = DisposeFinished;
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
		private void OnInProgressHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
			var clone = e.DeepClone();
			var handler = InProgress;
			if (handler != null) handler(this, clone);
		}
		private void OnInBuildingHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
			var clone = e.DeepClone();
			var handler = InBuilding;
			if (handler != null) handler(this, clone);
		}
		public void UnsubscribeToController()
		{
			if (controller == null)
				return;
			controller.OekiDoeki -= OnOekiDoekiHandler;
			controller.InProgress -= OnInProgressHandler;
			controller.InBuilding -= OnInBuildingHandler;
		}		

		private void SubscribeToController()
		{
			controller.OekiDoeki += OnOekiDoekiHandler;
			controller.InProgress += OnInProgressHandler;
			controller.InBuilding += OnInBuildingHandler;
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
		public void CleanUp()
		{
			DownDispatcher.Invoke(() => 
				{
					InvokeCleanUpStarted(EventArgs.Empty);
					try
					{
						controller.CleanUp();
					}
					finally
					{
						InvokeCleanUpFinished(EventArgs.Empty);
					}
				});
		}
		public void Build()
		{
			DownDispatcher.Invoke(() => 
				{
					InvokeBuildStarted(EventArgs.Empty);
					try
					{
						controller.Build();
					}
					finally
					{
						InvokeBuildFinished(EventArgs.Empty);
					}
				});
		}
		public void Dispose()
		{
			DownDispatcher.Invoke(() => 
				{
					InvokeDisposeStarted(EventArgs.Empty);
					try
					{
						controller.Dispose();
					}
					finally
					{
						InvokeDisposeFinished(EventArgs.Empty);
					}
				});
		}
	}
}

// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
