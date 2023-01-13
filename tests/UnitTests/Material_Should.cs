using Domain.Materials;
using Xunit;
using Shouldly;
using System.Linq;
using System;

namespace UnitTests
{
    public class Material_Should
    {
        [Fact]
        public void Always_be_in_stock_when_created()
        {
            var m = new Material("name", "description");
            m.InStock.ShouldBeTrue();
        }

        [Fact]
        public void Have_history_after_borrowing()
        {
            var m = new Material("name", "description");

            m.Borrow("studentcode");
            
            m.History.Count.ShouldBe(1);
            m.History.First().Action.ShouldBe(Event.ActionType.Borrow);
        }
            
        [Fact]
        public void Not_be_in_stock_after_borrowing()
        {
            var m = new Material("name", "description");

            m.Borrow("studentcode");

            m.InStock.ShouldBeFalse();
        }

        [Fact]
        public void First_be_returned_when_borrowed_again()
        {
            var m = new Material("name", "description");
            m.Borrow("studentcode");

            Should.Throw<ApplicationException>(() => m.Borrow("studentcode"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Not_Borrow_To_Invalid_Student(string studentCode)
        {
            var m = new Material("name", "description");

            Should.Throw<ArgumentException>(() => m.Borrow(studentCode));
        }
    }
}
