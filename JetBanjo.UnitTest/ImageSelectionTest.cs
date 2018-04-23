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
        public async Task AQ1 ()
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
        public async Task AQ2 ()
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
        public async Task AQ3 ()
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
        public async Task AQ4 ()
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
        public async Task AQ5 ()
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
        public async Task AQ6 ()
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
        public async Task VQ1 ()
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
        public async Task VQ2 ()
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
        public async Task VQ3 ()
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
        public async Task VQ4 ()
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
        public async Task VQ5 ()
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
        public async Task VQ6 ()
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
        public async Task TQ1 ()
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
        public async Task TQ2 ()
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
        public async Task TQ3 ()
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
        public async Task TQ4 ()
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
        public async Task TQ5 ()
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
        public async Task TQ6 ()
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
        public async Task TQ7 ()
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
        public async Task TQ8 ()
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
        public async Task TQ9 ()
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
        public async Task HQ1 ()
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
        public async Task HQ2 ()
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
        public async Task HQ3 ()
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
        public async Task HQ4 ()
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
        public async Task HQ5 ()
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
        public async Task HQ6 ()
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
        public async Task HQ7 ()
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
        public async Task HQ8 ()
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
        public async Task HQ9 ()
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
        public async Task UQ1 ()
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
        public async Task UQ2 ()
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
        public async Task UQ3 ()
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
        public async Task UQ4 ()
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
        public async Task UQ5 ()
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
        public async Task UQ6 ()
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
        public async Task LQ1 ()
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
        public async Task LQ2 ()
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
        public async Task LQ3 ()
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
        public async Task LQ4 ()
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
        public async Task LQ5 ()
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
        public async Task LQ6 ()
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
        public async Task NQ1 ()
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
        public async Task NQ2 ()
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
        public async Task NQ3 ()
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
        public async Task NQ4 ()
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
        public async Task NQ5 ()
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
        public async Task NQ6 ()
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

        #region Hybrids for fun and profit
        //sleeping + X
        //arms up + X


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
