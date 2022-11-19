using Capaci.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.DAL
{
    public class TestRepository : ITestRepository
    {
        public string GetTest()
        {
            return "from repository";
        }
    }
}
