using System;
using System.Collections.Generic;

namespace Test.CrossBase.CodeGeneration.TestData
{
    public interface IDoItAlso: IOekiFoekiBase
    {
        string Name { get; set; }
        void CleanUp();
        event EventHandler<OekiFoekiEventArgs> InProgress;
        List<EventArgs> ProcessEvents(int bla);

    }

    public interface IOekiFoekiBase:IDisposable
    {
        void Build();
        event EventHandler<OekiFoekiEventArgs> InBuilding;

    }

    public interface IOekiFoekiController: IDoItAlso
    {
        event EventHandler<OekiFoekiEventArgs> OekiDoeki;
        void DoThis();
        void DoThis(int times);
    }
}