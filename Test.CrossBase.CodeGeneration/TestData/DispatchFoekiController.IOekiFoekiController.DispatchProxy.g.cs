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

		event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InProgress;
		event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InBuilding;
		event EventHandler<EventArgs> DoThisStarted;
		event EventHandler<EventArgs> DoThisFinished;
		event EventHandler<EventArgs> CleanUpStarted;
		event EventHandler<EventArgs> CleanUpFinished;
		event EventHandler<EventArgs> ProcessEventsStarted;
		event EventHandler<EventArgs> ProcessEventsFinished;
		event EventHandler<EventArgs> BuildStarted;
		event EventHandler<EventArgs> BuildFinished;
		event EventHandler<EventArgs> DisposeStarted;
		event EventHandler<EventArgs> DisposeFinished;
		ushort AddressInvoke { get; set; } 
		string NameInvoke { get; set; } 
		void DoThis();
		void DoThisInvoke();
		void DoThis(int times);
		void DoThisInvoke(int times);
		void CleanUp();
		void CleanUpInvoke();
		System.Collections.Generic.List<System.EventArgs> ProcessEventsInvoke(int bla);
		void Build();
		void BuildInvoke();
		void Dispose();
		void DisposeInvoke();
	}

	public partial class DispatchFoekiController: IDispatchFoekiController 
	{
		protected T GetCloneIfPossible<T>(T obj)
		{
			Object x = obj;
 
			if (x is ICloneable)
			{
				var cloneable = (object) x as ICloneable;
				x = cloneable.Clone();
			}
			return (T)x;
		}

		public IDispatcher UpDispatcher { get; set; }
		public IDispatcher DownDispatcher { get; set; }

		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> OekiDoeki;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InProgress;
		public event System.EventHandler<Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs> InBuilding;
		private ushort addressInvoke;

		public ushort AddressInvoke 
		{
			get
			{
				Exception exception = null;
				var value = addressInvoke;
				DownDispatcher.Invoke(() => 
				{
					try
					{
						value = controller.Address;
						value = GetCloneIfPossible(value);									 
					}
					catch (Exception ex)
					{
						exception = ex;
					}
				});
				if (exception != null)
					throw exception;
				return value;
			}
			set
			{
				Exception exception = null;
				value = GetCloneIfPossible(value);
				DownDispatcher.Invoke(() => 
				{
					try
					{
						if (value == controller.Address)
							return;
						controller.Address = value; 
					}
					catch (Exception ex)
					{
						exception = ex;
					}
				});

				if (exception != null)
					throw exception;
			}
		}
		private string nameInvoke;

		public string NameInvoke 
		{
			get
			{
				Exception exception = null;
				var value = nameInvoke;
				DownDispatcher.Invoke(() => 
				{
					try
					{
						value = controller.Name;
						value = GetCloneIfPossible(value);									 
					}
					catch (Exception ex)
					{
						exception = ex;
					}
				});
				if (exception != null)
					throw exception;
				return value;
			}
			set
			{
				Exception exception = null;
				value = GetCloneIfPossible(value);
				DownDispatcher.Invoke(() => 
				{
					try
					{
						if (value == controller.Name)
							return;
						controller.Name = value; 
					}
					catch (Exception ex)
					{
						exception = ex;
					}
				});

				if (exception != null)
					throw exception;
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
		
		public event EventHandler<EventArgs> ProcessEventsStarted;
		public event EventHandler<EventArgs> ProcessEventsFinished;
		
		private void InvokeProcessEventsStarted(EventArgs e)
		{
		var handler = ProcessEventsStarted;
		if (handler != null) handler(this, e);
		}

		private void InvokeProcessEventsFinished(EventArgs e)
		{
			var handler = ProcessEventsFinished;
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
			eventArgs = GetCloneIfPossible(eventArgs);
			UpDispatcher.BeginInvoke(() =>
				{
					var handler = OekiDoeki;
					if (handler != null) handler(this, eventArgs);
				});
		}
		private void OnInProgressHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
			var eventArgs = e;
			eventArgs = GetCloneIfPossible(eventArgs);
			UpDispatcher.BeginInvoke(() =>
				{
					var handler = InProgress;
					if (handler != null) handler(this, eventArgs);
				});
		}
		private void OnInBuildingHandler(object sender, Test.CrossBase.CodeGeneration.TestData.OekiFoekiEventArgs e)
		{
			var eventArgs = e;
			eventArgs = GetCloneIfPossible(eventArgs);
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

		public void DoThis()
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
			Exception exception = null;
			
			DownDispatcher.Invoke(() => 
				{
					InvokeDoThisStarted(EventArgs.Empty);
					try
					{
						controller.DoThis();
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeDoThisFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
		}

		public void DoThis(int times)
		{
			DownDispatcher.BeginInvoke(() => 
				{
					UpDispatcher.BeginInvoke(() => InvokeDoThisStarted(EventArgs.Empty));
					try
					{
						controller.DoThis(times);
					}
					finally
					{
						UpDispatcher.BeginInvoke(() => InvokeDoThisFinished(EventArgs.Empty));
					}
				});
		}
		public void DoThisInvoke(int times)
		{
			Exception exception = null;
			
			DownDispatcher.Invoke(() => 
				{
					InvokeDoThisStarted(EventArgs.Empty);
					try
					{
						controller.DoThis(times);
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeDoThisFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
		}

		public void CleanUp()
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
			Exception exception = null;
			
			DownDispatcher.Invoke(() => 
				{
					InvokeCleanUpStarted(EventArgs.Empty);
					try
					{
						controller.CleanUp();
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeCleanUpFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
		}

		System.Collections.Generic.List<System.EventArgs> ProcessEventsDummy;
		public System.Collections.Generic.List<System.EventArgs> ProcessEventsInvoke(int bla)
		{
			var result = ProcessEventsDummy;
			Exception exception = null;
			DownDispatcher.Invoke(() => 
				{
					InvokeProcessEventsStarted(EventArgs.Empty);
					try
					{
						result = controller.ProcessEvents(bla);
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeProcessEventsFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
			return result;
		}
		public void Build()
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
			Exception exception = null;
			
			DownDispatcher.Invoke(() => 
				{
					InvokeBuildStarted(EventArgs.Empty);
					try
					{
						controller.Build();
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeBuildFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
		}

		public void Dispose()
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
			Exception exception = null;
			
			DownDispatcher.Invoke(() => 
				{
					InvokeDisposeStarted(EventArgs.Empty);
					try
					{
						controller.Dispose();
					}
					catch(Exception ex)
					{
						exception = ex;
					}
					finally
					{
						InvokeDisposeFinished(EventArgs.Empty);
					}
				});
			if (exception != null)
				throw exception;
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
