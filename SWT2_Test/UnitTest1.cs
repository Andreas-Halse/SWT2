using ClassLibrary;
namespace SWT2_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            IChargeControl mockCharge= new MockChargeControl();
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        #region ChargeControlTests
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
        #endregion
       
    }
}