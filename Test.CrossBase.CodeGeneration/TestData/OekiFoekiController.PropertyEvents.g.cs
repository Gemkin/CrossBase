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
using System.ComponentModel;
using Test.CrossBase.CodeGeneration.TestData;
using System.Collections.Generic;
using CrossBase.CodeGeneration.Attributes;

namespace Test.CrossBase.CodeGeneration.TestData	
{
    public partial class OekiFoekiController
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
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
