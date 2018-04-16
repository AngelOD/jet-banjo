using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;

namespace JetBanjo.UnitTest
{
    [TestClass]
    public class ImageSelectionTest
    {
        private static IAvatarLogic logic = new AvatarPageLogic();

        [TestMethod]
        public async void BaseTest()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }


        [TestMethod]
        public async void AQ1()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async void AQ2()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("dizzy.png", ImageType.CO2) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async void AQ3()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("dizzy.png", ImageType.CO2) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async void AQ4()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character), //Change to correct image later
                new CImage("child-arms-down.png",ImageType.Arms), //Change to correct image later
                new CImage("dizzy.png", ImageType.CO2)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async void AQ5()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character), //Change to correct image later
                new CImage("child-arms-down.png",ImageType.Arms) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        [TestMethod]
        public async void AQ6()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2001, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("child-no-arms.png", ImageType.Character), //Change to correct image later
                new CImage("child-arms-down.png",ImageType.Arms) //Change to correct image later
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

    }
}
