using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Controllers;
using TodoApp.Models;
using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TodoAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockService = new Mock<MyDBModel>();
         
            var controller = new WebapiController();
            var values = controller.GetAll();
            Assert.AreEqual(values.ElementAt(2).Name,"wake");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var mockService = new Mock<MyDBModel>();
            mockService.Setup(service => service.id).Returns(2);
            var controller = new WebapiController();
            var values = controller.GetAll();
            Assert.AreEqual(values.ElementAt(2).isComplete, false);




              }





        [TestMethod]
        public void TestMethod3()
        {
            var mockService = new Mock<MyDBModel>();
            mockService.Setup(service => service.id).Returns(2);
            var controller = new WebapiController();
            var values = controller.GetAll();
            Assert.AreEqual(values.ElementAt(2).Name, "wake");




        }


        [TestMethod]
        public void TestMethod34()
        {
            var mockService = new Mock<MyDBModel>();
            mockService.Setup(service => service.isComplete).Returns(false);
            var controller = new WebapiController();
            var obj = controller.GetByID("1");
            Assert.AreEqual(obj.GetType(),"wake" );




        }







    }
}
