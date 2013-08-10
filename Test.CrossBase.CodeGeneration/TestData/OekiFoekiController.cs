using System;
using System.Collections.Generic;
using CrossBase.CodeGeneration.Attributes;

namespace Test.CrossBase.CodeGeneration.TestData
{
    public partial class OekiFoekiController : IOekiFoekiController
    {
        [EventProperty]
        private string ohh;

        
        [EventProperty]
        private string ahh;

        public event EventHandler<OekiFoekiEventArgs> OekiDoeki;

        protected virtual void OnOekiDoeki(OekiFoekiEventArgs e)
        {
            var handler = OekiDoeki;
            if (handler != null) handler(this, e);
        }


        public void DoThis()
        {
            OnOekiDoeki(new OekiFoekiEventArgs {Data = new OekiData {DadDa = "BlaBlaBla"}});
        }

        public void DoThis(int times)
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }

        public void CleanUp()
        {
            
        }

        public event EventHandler<OekiFoekiEventArgs> InProgress;
        public List<EventArgs> ProcessEvents(int bla)
        {
            throw new NotImplementedException();
            

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<OekiFoekiEventArgs> InBuilding;
    }
}