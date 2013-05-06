using AutoMapper;
using Moq;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;
using Xunit;

namespace WebApiTDD.Test
{
    public class Test
    {
        [Fact]
        public void CanMapMangerToEmployee()
        {

            var manager = new Mock<Manager>(MockBehavior.Strict);

            var result = Mapper.Map<Manager, Employee>(manager.Object);

            Assert.Equal(result.GetType(),typeof(Employee));
        }


        [Fact]
        public void ClaimPrincipalTest()
        {
            
        }


    }
}
