using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserSys.Services.Configs;
using System.Linq;

namespace UserSys.Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t1 = typeof(UserConfig);
            var types = t1.GetInterfaces().Where(t => t.IsGenericType&&t.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            System.Console.WriteLine(types.Count());           

        }
    }
}
