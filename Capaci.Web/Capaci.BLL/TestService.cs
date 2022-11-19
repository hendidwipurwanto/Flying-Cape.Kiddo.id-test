using Capaci.BLL.interfaces;
using Capaci.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.BLL
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public string GetTest()
        {
           return _testRepository.GetTest();
        }
    }
}
