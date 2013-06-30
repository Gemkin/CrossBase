using System;
using CrossBase.Platform.Shared;
using NUnit.Framework;

namespace Test.CrossBase.Base
{
    [TestFixture]
    public abstract class TestBase
    {
        private static readonly ISystemServicesConstructor systemServicesConstructor;

        static TestBase()
        {
            systemServicesConstructor = GetSystemServiceConstructor();
        }

        private static ISystemServicesConstructor GetSystemServiceConstructor()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Name != "SystemServicesConstructor") 
                        continue;
                    var constructor = type.GetConstructor(new Type[] {});
                    if (constructor != null) 
                        return (ISystemServicesConstructor)constructor.Invoke(new object[] { });
                }
            }
            return null;
        }

        [SetUp]
        public virtual void SetUp()
        {
            if (systemServicesConstructor == null)
                throw new Exception("SystemServicesesConstructor not found");
            systemServicesConstructor.Construct();
        }


        [TearDown]
        public virtual void TearDown()
        {
            if (systemServicesConstructor == null)
                return;
            systemServicesConstructor.Destruct();
        }
    }
}