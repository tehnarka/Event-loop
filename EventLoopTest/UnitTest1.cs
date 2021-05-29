using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Event_loop;

namespace EventLoopTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var eventloop = new EventLoop();
            var res = eventloop.Start("123");
            Equals(res, "Recieved message: 1\nRecieved message: 2\nRecieved message: 3\n");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var eventloop = new EventLoop();
            var res = eventloop.Start("21");
            Equals(res, "Recieved message: 2\nRecieved message: 1\n");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var eventloop = new EventLoop();
            var res = eventloop.Start("12345");
            Equals(res, "Recieved message: 1\nRecieved message: 2\nRecieved message: 3\nRecieved message: 4\nRecieved message: 5\n");
        }
    }

}
