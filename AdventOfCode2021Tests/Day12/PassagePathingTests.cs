using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day12;

namespace AdventOfCode2021Tests.Day12
{
    public class PassagePathingTests
    {
        private PassagePathing _sut;

        private string _firstTestInput =
            @"start-A
start-b
A-c
A-b
b-d
A-end
b-end
";
        private string _secondTestInput =
            @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc
";
        
        private string _thirdTestInput =
            @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW
";
        public PassagePathingTests()
        {
            _sut = new PassagePathing();
        }

        [Fact()]
        public void GetFirstResult_ForFirstInputTest()
        {
            var result = _sut.GetFirstResult(_firstTestInput);

            Assert.Equal("10", result);
        }

        [Fact()]
        public void GetFirstResult_ForSecondInputTest()
        {
            var result = _sut.GetFirstResult(_secondTestInput);

            Assert.Equal("19", result);
        }

        [Fact()]
        public void GetFirstResult_ForThirdInputTest()
        {
            var result = _sut.GetFirstResult(_thirdTestInput);

            Assert.Equal("226", result);
        }

        [Fact()]
        public void GetSecondResult_ForFirstInputTest()
        {
            var result = _sut.GetSecondResult(_firstTestInput);

            Assert.Equal("36", result);
        }

        [Fact()]
        public void GetSecondResult_ForSecondInputTest()
        {
            var result = _sut.GetSecondResult(_secondTestInput);

            Assert.Equal("103", result);
        }
        
        [Fact()]
        public void GetSecondResult_ForThirdInputTest()
        {
            var result = _sut.GetSecondResult(_thirdTestInput);

            Assert.Equal("3509", result);
        }
    }
}