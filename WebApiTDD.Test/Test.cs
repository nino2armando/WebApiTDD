





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using WebApiTDD.Context.AppContext;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;
using WebApiTDD.Repository.UnitOfWork;
using WebApiTDD.Sevice.Services;

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
