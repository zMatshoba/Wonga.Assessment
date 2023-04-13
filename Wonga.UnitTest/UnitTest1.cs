using NUnit.Framework;

using Wonga.ServiceB;
using Wonga.ServiceA;

namespace Wonga.UnitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnMessageIsCorrect()
        {
            //Arrange 
            string TestName = "Hello my name is, Zola";

            //Act
            var result = ValidateMessage.Validate(TestName);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnMessageIsNotCorrect()
        {
            //Arrange 
            string TestName = "Hello my name is Zola";

            //Act
            var result = ValidateMessage.Validate(TestName);

            //Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void CanSplit()
        {
            //Arrange 
            string TestName = "Hello my name is, Zola";
            string answer = "Zola";
            //Act
            var result = ValidateMessage.MessageSplit(TestName);

            //Assert
            Assert.AreEqual(answer, result);
        }

        [Test]
        public void CantSplit()
        {
            //Arrange 
            string TestName = "Hello my name is Zola";
            //Act
            var result = ValidateMessage.MessageSplit(TestName);

            //Assert
            Assert.IsEmpty(result);
        }

        
    }
}