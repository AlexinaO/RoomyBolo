using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roomy.Controllers;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Roomy.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var controller = new UsersController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        /*[TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void ListTest()
        {
            var controller = new UsersController();
            var result = controller.List() as ViewResult;
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<User>));
            var model = result.Model as IEnumerable<User>;
            Assert.AreNotEqual(0, model.Count());
        }
    }
}