using System;
using Xunit;
using Num;

namespace Test
{
    public class NumbersUnitTest
    {
        private Numbers _num;

        public NumbersUnitTest()
        {
            _num = new Numbers();
        }

        [Theory]
        [InlineData(0, "zero")]
        [InlineData(1, "um")]
        [InlineData(12, "doze")]
        [InlineData(25, "vinte e cinco")]
        [InlineData(73, "setenta e três")]
        [InlineData(60, "sessenta")]
        [InlineData(100, "cem")]
        [InlineData(111, "cento e onze")]
        [InlineData(186, "cento e oitenta e seis")]
        [InlineData(248, "duzentos e quarenta e oito")]
        [InlineData(309, "trezentos e nove")]
        [InlineData(412, "quatrocentos e doze")]
        [InlineData(500, "quinhentos")]
        [InlineData(660, "seiscentos e sessenta")]
        [InlineData(999, "novecentos e noventa e nove")]
        [InlineData(1000, "um mil")]
        [InlineData(1234, "um mil duzentos e trinta e quatro")]
        [InlineData(211234, "duzentos e onze mil duzentos e trinta e quatro")]
        [InlineData(30001, "trinta mil e um")]
        [InlineData(112000, "cento e doze mil")]
        [InlineData(112003, "cento e doze mil e três")]
        [InlineData(112013, "cento e doze mil e treze")]
        [InlineData(112014, "cento e doze mil e quatorze")]
        [InlineData(112000000, "cento e doze milhões")]
        [InlineData(112319768, "cento e doze milhões trezentos e dezenove mil setecentos e sessenta e oito")]
        [InlineData(112000394, "cento e doze milhões trezentos e noventa e quatro")]
        [InlineData(394112000, "trezentos e noventa e quatro milhões cento e doze mil")]
        [InlineData(394112000000, "trezentos e noventa e quatro bilhões cento e doze milhões")]
        [InlineData(394112000001, "trezentos e noventa e quatro bilhões cento e doze milhões e um")]
        [InlineData(Int64.MaxValue, "nove quintilhões duzentos e vinte e três quatrilhões trezentos e setenta e dois trilhões trinta e seis bilhões oitocentos e cinquenta e quatro milhões setecentos e setenta e cinco mil oitocentos e sete")]
        public void ValidNumbers(Int64 value, string output)
        {
            Assert.Equal(_num.Write(value), output);
        }

        [Theory]
        [InlineData(-1)]
        public void ArgumentOutOfRange(Int64 v)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _num.Write(v);
            });
        }
    }
}
