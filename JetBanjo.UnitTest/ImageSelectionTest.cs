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
        public async Task BaseTest ()
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

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        #region CO2 Quality Tests
        //Tests CO2 lower bound for "overlay-dizzy"
        [TestMethod]
        public async Task AQ01 ()
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

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy"
        [TestMethod]
        public async Task AQ02 ()
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

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy"
        [TestMethod]
        public async Task AQ03 ()
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

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping"
        [TestMethod]
        public async Task AQ04 ()
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

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping"
        [TestMethod]
        public async Task AQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping"
        [TestMethod]
        public async Task AQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2001, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region VOC Quality
        //Tests VOC lower bound for "overlay-lesser-greenfog"
        [TestMethod]
        public async Task VQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 59.9 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests VOC lower bound for "overlay-lesser-greenfog"
        [TestMethod]
        public async Task VQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 60 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-lesser-greenfog.png", ImageType.VOC)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests VOC lower bound for "overlay-lesser-greenfog"
        [TestMethod]
        public async Task VQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 59.9 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests VOC lower bound for "overlay-greater-greenfog"
        [TestMethod]
        public async Task VQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 179.9 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-lesser-greenfog.png",ImageType.VOC)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests VOC lower bound for "overlay-greater-greenfog"
        [TestMethod]
        public async Task VQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 180 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-greater-greenfog.png",ImageType.VOC)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests VOC lower bound for "overlay-greater-greenfog"
        [TestMethod]
        public async Task VQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 180.1 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-greater-greenfog.png",ImageType.VOC)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region Temperature Quality
        //Tests temp lower bound for "overlay-cold-..."
        [TestMethod]
        public async Task TQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 17.9, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-frozen.png",ImageType.Frozen)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-cold-..."
        [TestMethod]
        public async Task TQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-cold-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-cold-..."
        [TestMethod]
        public async Task TQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18.1, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-cold-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for normal
        [TestMethod]
        public async Task TQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.4, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-cold-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for normal
        [TestMethod]
        public async Task TQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.5, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for normal
        [TestMethod]
        public async Task TQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.6, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sweat"
        [TestMethod]
        public async Task TQ07 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.4, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sweat"
        [TestMethod]
        public async Task TQ08 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.5, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sweat.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sweat"
        [TestMethod]
        public async Task TQ09 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.6, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sweat.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-fire-..."
        [TestMethod]
        public async Task TQ10 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 24.9, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sweat.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-fire-..."
        [TestMethod]
        public async Task TQ11 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-fire-no-arms.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-fire-..."
        [TestMethod]
        public async Task TQ12 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25.1, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-fire-no-arms.png",ImageType.ColdSweatFire)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        #endregion

        #region Humidity Quality

        //Tests temp upper bound for "overlay-desert"
        [TestMethod]
        public async Task HQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 24.9, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-desert.png", ImageType.Humidity)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-desert"
        [TestMethod]
        public async Task HQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 25, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-desert"
        [TestMethod]
        public async Task HQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 25.1, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" summer version months 5, 6, 7, 8, 9
        [TestMethod]
        public async Task HQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 59.9, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" summer version months 5, 6, 7, 8, 9
        [TestMethod]
        public async Task HQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 60, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-watervapour.png", ImageType.Humidity)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" summer version months 5, 6, 7, 8, 9
        [TestMethod]
        public async Task HQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 60.1, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 5, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-watervapour.png", ImageType.Humidity)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" winter version months 10, 11, 12, 1, 2, 3, 4
        [TestMethod]
        public async Task HQ07 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 44.9, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 2, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" winter version months 10, 11, 12, 1, 2, 3, 4
        [TestMethod]
        public async Task HQ08 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 45, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 2, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-watervapour.png", ImageType.Humidity)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-watervapour" winter version months 10, 11, 12, 1, 2, 3, 4
        [TestMethod]
        public async Task HQ09 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 45.1, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-watervapour.png", ImageType.Humidity)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region UV Quality
        //Tests temp lower bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2.9, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 3, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-tan-arms-down", ImageType.UV),
                new CImage("overlay-tan-no-arms.png", ImageType.UV)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 3.1, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-tan-arms-down", ImageType.UV),
                new CImage("overlay-tan-no-arms.png", ImageType.UV)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 4.9, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-tan-arms-down", ImageType.UV),
                new CImage("overlay-tan-no-arms.png", ImageType.UV)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 5, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sunburn-arms-down", ImageType.UV),
                new CImage("overlay-sunburn-no-arms.png", ImageType.UV)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-tan-..."
        [TestMethod]
        public async Task UQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 5.1, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sunburn-arms-down", ImageType.UV),
                new CImage("overlay-sunburn-no-arms.png", ImageType.UV)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region Light Quality
        //Tests temp upper bound for "overlay-darkness"
        [TestMethod]
        public async Task LQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 199.9, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-darkness.png", ImageType.Dark)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-darkness"
        [TestMethod]
        public async Task LQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 200, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "overlay-darkness"
        [TestMethod]
        public async Task LQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 200.1, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sunglasses"
        [TestMethod]
        public async Task LQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 4999.9, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sunglasses"
        [TestMethod]
        public async Task LQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 5000, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sunglasses.png", ImageType.Sunglasses)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "overlay-sunglasses"
        [TestMethod]
        public async Task LQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 5000.1, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-sunglasses.png", ImageType.Sunglasses)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region Noise Quality

        //Tests temp lower bound for "child-arms-up"
        [TestMethod]
        public async Task NQ01 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "child-arms-up"
        [TestMethod]
        public async Task NQ02 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp lower bound for "child-arms-up"
        [TestMethod]
        public async Task NQ03 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "child-arms-up"
        [TestMethod]
        public async Task NQ04 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests temp upper bound for "child-arms-up"
        [TestMethod]
        public async Task NQ05 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }


        //Tests temp upper bound for "child-arms-up"
        [TestMethod]
        public async Task NQ06 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region CO2Temperature Hybrid Quality
        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ01()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 17.9, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-frozen.png",ImageType.Frozen)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ02()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ03()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18.1, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ04()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 17.9, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-frozen.png",ImageType.Frozen)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ05()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ06()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18.1, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ07()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 17.9, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-frozen.png",ImageType.Frozen)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ08()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-frozen"
        [TestMethod]
        public async Task ATQ09()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 18.1, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ10()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.4, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ11()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.5, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ12()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.6, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ13()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.4, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ14()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.5, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ15()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.6, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ16()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.4, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-cold-arms-down.png",ImageType.ColdSweatFire),
                new CImage("overlay-cold-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ17()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.5, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-cold..."
        [TestMethod]
        public async Task ATQ18()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 19.6, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ19()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.4, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ20()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.5, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-sweat.png", ImageType.ColdSweatFire)

            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ21()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.6, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ22()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.4, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ23()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.5, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png", ImageType.ColdSweatFire)

            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ24()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.6, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ25()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.4, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ26()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.5, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png", ImageType.ColdSweatFire)

            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and upper bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ27()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.6, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ28()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 24.9, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ29()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ30()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25.1, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ31()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 24.9, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ32()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ33()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25.1, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ34()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 24.9, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-sweat.png",ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-fire..."
        [TestMethod]
        public async Task ATQ35()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "child-sleeping-..." and lower bound of Temperature for "overlay-sweat..."
        [TestMethod]
        public async Task ATQ36()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 25.1, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-fire-arms-down.png", ImageType.ColdSweatFire),
                new CImage("overlay-fire-no-arms.png", ImageType.ColdSweatFire)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
        #endregion

        #region CO2Noise Hybrid Quality

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ01()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ02()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ03()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ04()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ05()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ06()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ07()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ08()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ09()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ10()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ11()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ12()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ13()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ14()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ15()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ16()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 59.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ17()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 60, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ18()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 60.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ19()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ20()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ21()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 999.9, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ22()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ23()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ24()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ25()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ26()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 lower bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ27()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1000.1, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ28()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ29()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ30()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 1999.9, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms),
                new CImage("overlay-dizzy.png", ImageType.CO2),
                new CImage("overlay-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ31()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ32()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ33()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ34()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 74.9, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-up.png",ImageType.Arms)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and lower bound of Temperature for "child-arms-up"
        [TestMethod]
        public async Task ANQ35()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 75, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }

        //Tests CO2 upper bound for "overlay-dizzy" and upper bound of noise for "child-arms-up"
        [TestMethod]
        public async Task ANQ36()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 2000.1, UV = 2, Lux = 500, dB = 75.1, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-sleeping-no-arms.png", ImageType.Character),
                new CImage("child-sleeping-arms-down.png",ImageType.Arms),
                new CImage("overlay-sleeping-earmuffs.png", ImageType.Noise)
            };

            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }










        #endregion

        #region Specific Test cases for fun
        [TestMethod]
        public async Task SpecTest1 ()
        {
            SensorData inputSensorData = new SensorData() { Temperature = 23.22, Humidity = 18.93, CO2 = 414, UV = 0, Lux = 8, dB = 66, VOC = 2 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            List<CImage> expectedOutput = new List<CImage>
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-up.png",ImageType.Arms),

                new CImage("overlay-desert.png", ImageType.Humidity),
                new CImage("overlay-darkness.png", ImageType.Dark)
            };
            List<CImage> actualOutput = await logic.GetAvatar(inputSensorData, inputTime);

            foreach (var item in actualOutput)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }


        #endregion
    }
}
