    using NUnit.Framework;
using Robots;
using System;

    public class RobotsTests
    {
        [Test]
        public void CreateRobot()
        {
        Robot robot = new Robot("name", 100);
        Assert.AreEqual("name", robot.Name);
        Assert.AreEqual(100, robot.Battery);
        }
    [Test]
    public void TryInvalidCapacity()
    {

    }
    }
