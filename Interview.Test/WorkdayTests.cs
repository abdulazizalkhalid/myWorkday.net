using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview.Test
{
	[TestClass]
	public class WorkdayTests
	{
        /// <summary>
        /// This method tests the calculation for a short period during a single week work days.
        /// The start date and the calculated date do not reach the weekends.
        /// In other words, the whole calculation is done over the main body days of the week (middle).
        /// </summary>
        [TestMethod]
        public void TestMethodShortMiddleOfTheWeek()
        {
            var myDay = 2;
            var myDate = DateTime.Parse("13-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("15-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This method tests the calculation for a normal period of six days over a single weekend
        /// The intention is to see whether the calculation works good over weekends
        /// The start date is a Tuesday day before the Weekend
        /// The calculated date is Wednesday after the Weekend
        /// </summary
        [TestMethod]
        public void TestMethodLonglPeriodOverWeekend()
        {
            var myDay = 6;
            var myDate = DateTime.Parse("13-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("21-March-2018");
            Assert.AreEqual(expected, actual);
        }


    }
}
