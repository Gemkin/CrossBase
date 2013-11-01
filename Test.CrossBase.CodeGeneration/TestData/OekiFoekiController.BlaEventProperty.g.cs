/**************************************************************************
AUTOMATIC GENERATED FILE! DO NOT CHANGE MANUALLY 		
CrossBase.CodeGeneration
Wies Hubbers
**************************************************************************/

using System;
using Test.CrossBase.CodeGeneration.TestData;
using System.Collections.Generic;
using CrossBase.CodeGeneration.Attributes;
namespace Test.CrossBase.CodeGeneration.TestData	
{
    public partial class OekiFoekiController
    {
        
		public event EventHandler<OekiFoekiControllerBlaChangingEventArgs> BlaChanging;
		private void InvokeBlaChanging(OekiFoekiControllerBlaChangingEventArgs e)
        {
            var handler = BlaChanging;
            if (handler != null) handler(this, e);
        }

    	public event EventHandler<OekiFoekiControllerBlaChangedEventArgs> BlaChanged;
	    private void InvokeBlaChanged(OekiFoekiControllerBlaChangedEventArgs e)
	    {
	        var handler = BlaChanged;
	        if (handler != null) handler(this, e);
	    }

		public string Bla
        {
            get { return bla; }
	        protected set
            {
                var old = bla;
				if (old == value)
                    return;
 
                UpdateBla(old, value);
            }
        }

        protected virtual void UpdateBla(string old, string value)
        {

			var changingEventArgs = new OekiFoekiControllerBlaChangingEventArgs { OldBla = old, NewBla = value };
				
			OnBaseBlaChanging(changingEventArgs);
            if (changingEventArgs.Cancel)
                return;
					
			InvokeBlaChanging(changingEventArgs);
            if (changingEventArgs.Cancel)
                return;
			value = changingEventArgs.NewBla;
		    bla = value;
				
            var changedEventArgs = new OekiFoekiControllerBlaChangedEventArgs { OldBla = old, NewBla = value };
			OnBaseBlaChanged(changedEventArgs);
            InvokeBlaChanged(changedEventArgs);
			NotifyPropertyChanged("Bla");
			
        }
	
		partial void OnBaseBlaChanging(OekiFoekiControllerBlaChangingEventArgs e);
		partial void OnBaseBlaChanged(OekiFoekiControllerBlaChangedEventArgs e);
      
        protected void SetBlaForced(string newBla)
		{
            UpdateBla(bla, newBla);
		}

      
        protected void SetBlaSilently(string newBla)
		{
			 bla = newBla;
		}
	}
    
	public class OekiFoekiControllerBlaChangingEventArgs : OekiFoekiControllerBlaChangedEventArgs
    {
        public bool Cancel { get; set; }
    }

    public class OekiFoekiControllerBlaChangedEventArgs: EventArgs
    {
        public string NewBla { get; set; }
        public string OldBla { get; set; }
	}
}
