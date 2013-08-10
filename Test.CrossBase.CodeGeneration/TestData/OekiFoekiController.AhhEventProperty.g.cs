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
using Test.CrossBase.CodeGeneration.TestData;
using System.Collections.Generic;
using CrossBase.CodeGeneration.Attributes;
namespace Test.CrossBase.CodeGeneration.TestData	
{
    public partial class OekiFoekiController
    {
		//private string ahh in C:\projects\CrossBase\Test.CrossBase.CodeGeneration\TestData\OekiFoekiController.cs (NotifyPropertyAndEventProperty)
        
		public event EventHandler<OekiFoekiControllerAhhChangingEventArgs> AhhChanging;
		private void InvokeAhhChanging(OekiFoekiControllerAhhChangingEventArgs e)
        {
            var handler = AhhChanging;
            if (handler != null) handler(this, e);
        }

    	public event EventHandler<OekiFoekiControllerAhhChangedEventArgs> AhhChanged;
	    private void InvokeAhhChanged(OekiFoekiControllerAhhChangedEventArgs e)
	    {
	        var handler = AhhChanged;
	        if (handler != null) handler(this, e);
	    }

		public string Ahh
        {
            get { return ahh; }
            set
            {
                var old = ahh;
				if (old == value)
                    return;
 

				var changingEventArgs = new OekiFoekiControllerAhhChangingEventArgs { OldAhh = old, NewAhh = value };
				
				OnAhhChanging(changingEventArgs);
                if (changingEventArgs.Cancel)
                    return;
					
				InvokeAhhChanging(changingEventArgs);
                if (changingEventArgs.Cancel)
                    return;
				value = changingEventArgs.NewAhh;
				ahh = value;
				
                var changedEventArgs = new OekiFoekiControllerAhhChangedEventArgs { OldAhh = old, NewAhh = value };
				OnAhhChanged(changedEventArgs);
                InvokeAhhChanged(changedEventArgs);
				NotifyPropertyChanged("Ahh");
			}
        }
	
		protected void OnAhhChanging(OekiFoekiControllerAhhChangingEventArgs e) {}
		protected void OnAhhChanged(OekiFoekiControllerAhhChangedEventArgs e) {}
	}
    
	public class OekiFoekiControllerAhhChangingEventArgs : OekiFoekiControllerAhhChangedEventArgs
    {
        public bool Cancel { get; set; }
    }

    public class OekiFoekiControllerAhhChangedEventArgs: EventArgs
    {
        public string NewAhh { get; set; }
        public string OldAhh { get; set; }
	}
}
// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
// ReSharper restore SuspiciousTypeConversion.Global
// ReSharper restore RedundantCast
#pragma warning restore 649
#pragma warning restore 183
