using System.Reflection;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling.Business.Interfaces;

namespace T9Spelling.Tests
{
    [TestClass]
    public class CodesServiceTest
    {
        private static IContainer _container;

        private ICodesService _codesService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICodesService)))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            _container = builder.Build();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _codesService = _container.Resolve<ICodesService>();
        }

        [TestMethod]
        public void GetStringCode_AllAlphabetWithRepeats_ReturnsEqualString()
        {
            var result = _codesService.GetStringCode("abbccdefghijkl  mnopqrstuvwxyz");
            Assert.AreEqual("2 22 22 222 2223 33 3334 44 4445 55 5550 06 66 6667 77 777 77778 88 8889 99 999 9999", result);
        }
    }
}
