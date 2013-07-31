using System;

namespace Test.CrossBase.CodeGeneration.TestData
{
    public class OekiFoekiController : IOekiFoekiController
    {
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
    }
}