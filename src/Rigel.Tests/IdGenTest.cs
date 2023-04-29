using System;
using Rigel.Helpers.Impl;
using Xunit.Abstractions;

namespace Rigel.Tests
{
    public class IdGenTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public IdGenTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void TestIdGen() 
        {
            var idgen = new IdGenerator();
            _testOutputHelper.WriteLine(idgen.NewId());
        }
        [Fact]
        public void TestIdGenSpeed()
        {
            var idgen = new IdGenerator();
            long start = DateTime.Now.Ticks;
            idgen.NewId();
            _testOutputHelper.WriteLine((DateTime.Now.Ticks - start).ToString());

        }
    }
}