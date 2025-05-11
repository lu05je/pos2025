using System;
using NUnit.Framework;
using WebAPILabor.Controllers;

namespace LaborTest
{
    public class Tests
    {
        private Labor _labor;

        [SetUp]
        public void Setup()
        {
            _labor = new Labor(); // Erstellen einer Instanz der Labor-Klasse
        }

        [Test]
        public void Test_CalcTesttime_15_00()
        {
            // Zeitpunkt der Testanmeldung: 15:00 Uhr
            DateTime anmeldung = new DateTime(2025, 5, 10, 15, 0, 0);
            DateTime erwarteteTestzeit = new DateTime(2025, 5, 10, 19, 0, 0);

            DateTime berechneteTestzeit = _labor.CalcTesttime(anmeldung);

            Assert.AreEqual(erwarteteTestzeit, berechneteTestzeit);
        }

        [Test]
        public void Test_CalcTesttime_19_07()
        {
            // Zeitpunkt der Testanmeldung: 19:07 Uhr
            DateTime anmeldung = new DateTime(2025, 5, 10, 19, 7, 0);
            DateTime erwarteteTestzeit = new DateTime(2025, 5, 11, 10, 15, 0);

            DateTime berechneteTestzeit = _labor.CalcTesttime(anmeldung);

            Assert.AreEqual(erwarteteTestzeit, berechneteTestzeit);
        }

        [Test]
        public void Test_CalcTesttime_01_31()
        {
            // Zeitpunkt der Testanmeldung: 01:31 Uhr
            DateTime anmeldung = new DateTime(2025, 5, 10, 1, 31, 0);
            DateTime erwarteteTestzeit = new DateTime(2025, 5, 10, 12, 45, 0);

            DateTime berechneteTestzeit = _labor.CalcTesttime(anmeldung);

            Assert.AreEqual(erwarteteTestzeit, berechneteTestzeit);
        }

        [Test]
        public void Test_CalcTesttime_04_47()
        {
            // Zeitpunkt der Testanmeldung: 04:47 Uhr
            DateTime anmeldung = new DateTime(2025, 5, 10, 4, 47, 0);
            DateTime erwarteteTestzeit = new DateTime(2025, 5, 10, 9, 0, 0);

            DateTime berechneteTestzeit = _labor.CalcTesttime(anmeldung);

            Assert.AreEqual(erwarteteTestzeit, berechneteTestzeit);
        }
    }
}
