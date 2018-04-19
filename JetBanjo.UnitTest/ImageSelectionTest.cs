using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;
using System.Threading.Tasks;

namespace JetBanjo.UnitTest
{
    [TestClass]
    public class ImageSelectionTest
    {
        private static IAvatarLogic logic = new AvatarPageLogic();

        [TestMethod]
        public async Task BaseTest()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }


        [TestMethod]
        public async Task AQ1()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async Task AQ2()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async Task AQ3()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async Task AQ4()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async Task AQ5()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character), //Change to correct image later
                new CImage("child-arms-down.png",ImageType.Arms) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async Task AQ6()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2001, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character), //Change to correct image later
                new CImage("child-arms-down.png",ImageType.Arms) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            expectedOutput.Sort();
            actualOutput.Sort();

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

    }
}
