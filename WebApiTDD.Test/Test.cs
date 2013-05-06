using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using FluentAssertions;
using Moq;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;
using WebApiTDD.Security;
using WebApiTDD.Sevice.Interfaces;
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
        public void TestEmployeeService()
        {
            var manager = new Employee()
                {
                    Id = 1,
                    Name = "new"
                };
            var employeeService = new Mock<IEmployeeService>(MockBehavior.Strict);

            employeeService.Setup(s => s.FindById(It.IsAny<int>())).Returns(manager);

            Assert.Equal(employeeService.Object.FindById(1).GetType(),typeof(Employee));

        }

        [Fact]
        public void Claim_Count_Should_Not_Be_Zero()
        {

            ClaimsPrincipal claimPrincipal = GetClaim();

            var count = claimPrincipal.Claims.Count();
            
            count.Should().NotBe(0);

        }

        [Fact]
        public void Identity_Count_Should_Not_Be_Zero()
        {
            ClaimsPrincipal claimsPrincipal = GetClaim();

            var count = claimsPrincipal.Identities.Count();

            count.Should().NotBe(0);
        }


        [Fact]
        public void Claims_should_Contain_ClaimType_Email()
        {
            ClaimsPrincipal claimsPrincipal = GetClaim();

            var emailClaimType = claimsPrincipal.Claims.Where(a => a.Type == ClaimTypes.Email);

            bool hasemail = claimsPrincipal.HasClaim(c => c.Type == ClaimTypes.Email);

            emailClaimType.Count().Should().BeGreaterOrEqualTo(1);

            Assert.True(hasemail);

        }

        [Fact]
        public void Claims_should_Contain_ClaimType_Name()
        {
            ClaimsPrincipal claimsPrincipal = GetClaim();

            var emailClaimType = claimsPrincipal.Claims.Where(a => a.Type == ClaimTypes.Name);

            emailClaimType.Count().Should().BeGreaterOrEqualTo(1);

        }

        [Fact]
        public void First_Identity_Claims_Sould_contain_Email_claim()
        {
            ClaimsPrincipal claimsPrincipal = GetClaim();

            var claims = claimsPrincipal.Identities.First().Claims;

            var emailClaimType = claims.Where(c => c.Type == ClaimTypes.Email);

            Assert.Equal(emailClaimType.Count(),1);

        }


        private ClaimsPrincipal GetClaim()
        {
            
            IEnumerable<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,"Nino@email.com"),
                    new Claim(ClaimTypes.Name, "Nino"),
                    new Claim(ClaimTypes.GivenName,"khodabandeh"),
                    new Claim(ClaimTypes.Role,"Developer"),
                    new Claim("http://remondo.claims/Area", "Vancouver")
                };

            ClaimsIdentity identity = new ClaimsIdentity(
                claims,
                "basic",
                "UserName",
                ClaimTypes.Role);

            var auth = new WebApiTddClaimAuthenticationManager();
            ClaimsPrincipal claimPrincipalToTest = auth.Authenticate(string.Empty, new ClaimsPrincipal(new[] { identity }));

            return claimPrincipalToTest;
        }
    }
}
