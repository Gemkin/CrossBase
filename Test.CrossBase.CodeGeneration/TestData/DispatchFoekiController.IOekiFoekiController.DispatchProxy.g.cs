/**************************************************************************
AUTOMATIC GENERATED FILE! DO NOT CHANGE MANUALLY 		
CrossBase.CodeGeneration
Wies Hubbers
**************************************************************************/
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable RedundantCast
#pragma warning disable 649
#pragma warning disable 183

using System;
using CrossBase.Dispatch;
using CrossBase.Serialization;
using CrossBase.CodeGeneration.Attributes;
using Test.CrossBase.CodeGeneration.TestData;

namespace Test.CrossBase.CodeGeneration.TestData	
{
	public interface IDispatchFoekiController 
	{
		IOekiFoekiController Controller { get; set; }
		IDispatcher UpDispatcher { get; set; }
        IDispatcher DownDispatcher { get; set; }
		event EventHandler<EventArgs> DoThisStarted;
		event EventHandler<EventArgs> DoThisFinished;
		event EventHandler<EventArgs> CleanUpStarted;
		event EventHandler<EventArgs> CleanUpFinished;
		event EventHandler<EventArgs> BuildStarted;
		event EventHandler<EventArgs> BuildFinished;
		event EventHandler<EventArgs> DisposeStarted;
		event EventHandler<EventArgs> DisposeFinished;
		string NameInvoke { get; set; } 
		void DoThisBeginInvoke();
		void DoThisInvoke();
		void CleanUpBeginInvoke();
		void CleanUpInvoke();
		void BuildBeginInvoke();
		void BuildInvoke();
		void DisposeBeginInvoke();
		void DisposeInvoke();
	}

	public partial class DispatchFoekiController: IDispatchFoekiController 
	{
		public IDispatcher UpDispatcher { get; set; }
        public IDispatcher DownDispatcher { get; set; }
        
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InProgress;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InBuilding;
		private string nameInvoke;

		public string NameInvoke 
		{
			get
			{
				var value = nameInvoke;
				DownDispatcher.Invoke(() => 
				{
					value = controller.Name;
					if (value is ICloneable)
					{
						value = (string)(value as ICloneable).Clone();
					}					 
				});
				return value;
			}
			set
			{
				if (value is ICloneable)
				{
					value = (string)(value as ICloneable).Clone();
				}
				DownDispatcher.Invoke(() => 
				{
					if (value == controller.Name)
						return;
					controller.Name = value; 
				});
			}
		}				    
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
		    var eventArgs = e;
			if (eventArgs is ICloneable)
			{
				eventArgs = (Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs)(eventArgs as ICloneable).Clone();
			}
			UpDispatcher.BeginInvoke(() =>
				{
					var handler = OekiDoeki;
					if (handler != null) handler(this, eventArgs);
				});
		}
		private void OnInProgressHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
		    var eventArgs = e;
			if (eventArgs is ICloneable)
			{
				eventArgs = (Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs)(eventArgs as ICloneable).Clone();
			}
			UpDispatcher.BeginInvoke(() =>
				{
					var handler = InProgress;
					if (handler != null) handler(this, eventArgs);
				});
		}
		private void OnInBuildingHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
		    var eventArgs = e;
			if (eventArgs is ICloneable)
			{
				eventArgs = (Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs)(eventArgs as ICloneable).Clone();
			}
			UpDispatcher.BeginInvoke(() =>
				{
					var handler = InBuilding;
					if (handler != null) handler(this, eventArgs);
				});
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

		public void DoThisBeginInvoke()
		{
			DownDispatcher.BeginInvoke(() => 
				{
					UpDispatcher.BeginInvoke(() => InvokeDoThisStarted(EventArgs.Empty));
					try
					{
						controller.DoThis();
					}
					finally
					{
						UpDispatcher.BeginInvoke(() => InvokeDoThisFinished(EventArgs.Empty));
					}
				});
		}
		public void DoThisInvoke()
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



		public void CleanUpBeginInvoke()
		{
			DownDispatcher.BeginInvoke(() => 
				{
					UpDispatcher.BeginInvoke(() => InvokeCleanUpStarted(EventArgs.Empty));
					try
					{
						controller.CleanUp();
					}
					finally
					{
						UpDispatcher.BeginInvoke(() => InvokeCleanUpFinished(EventArgs.Empty));
					}
				});
		}
		public void CleanUpInvoke()
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



		public void BuildBeginInvoke()
		{
			DownDispatcher.BeginInvoke(() => 
				{
					UpDispatcher.BeginInvoke(() => InvokeBuildStarted(EventArgs.Empty));
					try
					{
						controller.Build();
					}
					finally
					{
						UpDispatcher.BeginInvoke(() => InvokeBuildFinished(EventArgs.Empty));
					}
				});
		}
		public void BuildInvoke()
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



		public void DisposeBeginInvoke()
		{
			DownDispatcher.BeginInvoke(() => 
				{
					UpDispatcher.BeginInvoke(() => InvokeDisposeStarted(EventArgs.Empty));
					try
					{
						controller.Dispose();
					}
					finally
					{
						UpDispatcher.BeginInvoke(() => InvokeDisposeFinished(EventArgs.Empty));
					}
				});
		}
		public void DisposeInvoke()
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
// ReSharper restore SuspiciousTypeConversion.Global
// ReSharper restore RedundantCast
#pragma warning restore 649
#pragma warning restore 183
