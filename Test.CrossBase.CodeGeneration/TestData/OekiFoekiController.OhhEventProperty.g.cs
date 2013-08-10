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
		//private string ohh in C:\projects\CrossBase\Test.CrossBase.CodeGeneration\TestData\OekiFoekiController.cs (NotifyPropertyAndEventProperty)
        
		public event EventHandler<OekiFoekiControllerOhhChangingEventArgs> OhhChanging;
		private void InvokeOhhChanging(OekiFoekiControllerOhhChangingEventArgs e)
        {
            var handler = OhhChanging;
            if (handler != null) handler(this, e);
        }

    	public event EventHandler<OekiFoekiControllerOhhChangedEventArgs> OhhChanged;
	    private void InvokeOhhChanged(OekiFoekiControllerOhhChangedEventArgs e)
	    {
	        var handler = OhhChanged;
	        if (handler != null) handler(this, e);
	    }

		public string Ohh
        {
            get { return ohh; }
            set
            {
                var old = ohh;
				if (old == value)
                    return;
 

				var changingEventArgs = new OekiFoekiControllerOhhChangingEventArgs { OldOhh = old, NewOhh = value };
				
				OnBaseOhhChanging(changingEventArgs);
                if (changingEventArgs.Cancel)
                    return;
					
				InvokeOhhChanging(changingEventArgs);
                if (changingEventArgs.Cancel)
                    return;
				value = changingEventArgs.NewOhh;
				ohh = value;
				
                var changedEventArgs = new OekiFoekiControllerOhhChangedEventArgs { OldOhh = old, NewOhh = value };
				OnBaseOhhChanged(changedEventArgs);
                InvokeOhhChanged(changedEventArgs);
				NotifyPropertyChanged("Ohh");
			}
        }
	
		partial void OnBaseOhhChanging(OekiFoekiControllerOhhChangingEventArgs e);
		partial void OnBaseOhhChanged(OekiFoekiControllerOhhChangedEventArgs e);
	}
    
	public class OekiFoekiControllerOhhChangingEventArgs : OekiFoekiControllerOhhChangedEventArgs
    {
        public bool Cancel { get; set; }
    }

    public class OekiFoekiControllerOhhChangedEventArgs: EventArgs
    {
        public string NewOhh { get; set; }
        public string OldOhh { get; set; }
	}
}
// ReSharper restore PartialMethodWithSinglePart
// ReSharper restore RedundantNameQualifier
// ReSharper restore RedundantUsingDirective
// ReSharper restore SuspiciousTypeConversion.Global
// ReSharper restore RedundantCast
#pragma warning restore 649
#pragma warning restore 183
