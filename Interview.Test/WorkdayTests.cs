using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview.Test
{
    /**
  * This class contains several test cases. 
  * The test cases cover the regular behavior of the program.
  * The regular behavior include calculation over:
  * 1. A short period inside a week: TestMethodShortMiddleOfTheWeek
  * 2. A long period that covers the weekend : TestMethodLonglPeriodOverWeekend
  * 3. A normal period that covers the weekend: TestMethodNormalPeriodOverWeekend
  * 4. short period that covers the weekend: TestMethodShortPeriodOverWeekend
  * 5. A period cover multiple weeks (two): TestMethodWithinTwoWeeks
  * 6. A period cover multiple weeks (three): TestMethodWithinThreeWeeks
  * 7. The start date is a weekend: TestMethodofSaturday
  * 8. The boundary case which is first day of the work week, that is Monday: TestMethodFirstDayofTheWeekMonday
  * 9. The boundary case which is last day of the work week, that is Friday: TestMethodLastDayofTheWeekFriday
  
  * The class also includes test cases also cover the exceptional behaviour or the software which includes:
  * 1. An input entered by the user equal to zero: TestMethodOfDaysEqualZero
  * 2. A negative input entered by the user: TestMethodForException
  * */



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
        /// </summary>
        [TestMethod]
        public void TestMethodLonglPeriodOverWeekend()
        {
            var myDay = 6;
            var myDate = DateTime.Parse("13-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("21-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This method tests the calculation for a normal period of three days over a single weekend
        /// The intention is to see whether the calculation works good over weekends
        /// The start date is a Friday day before the Weekend
        /// The calculated date is Wednesday after the Weekend
        /// </summary>
        [TestMethod]
        public void TestMethodNormalPeriodOverWeekend()
        {
            var myDay = 3;
            var myDate = DateTime.Parse("16-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("21-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This method tests the calculation for a short period of two days over a single weekend
        /// The is because we have to do special calculation for the weekend
        /// The start date is a Friday day before the Weekend
        /// The calculated date is Tuesday after the Weekend
        /// </summary>
        [TestMethod]
        public void TestMethodShortPeriodOverWeekend()
        {
            var myDay = 2;
            var myDate = DateTime.Parse("16-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("20-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This test case covers the scenario in which number of work days entered by the used is larger than a week.
        /// In such case, the calculation will be done over more than one week.
        /// The reason is that there are only five working days in each week.
        /// The test case just to make sure that the calculation will work fine over couple of weeks.
        /// </summary>
        [TestMethod]
        public void TestMethodWithinTwoWeeks()
        {
            var myDay = 8;
            var myDate = DateTime.Parse("6-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("16-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// This test case covers the scenario in which number of work days entered by the used is larger than two weeks.
        /// In other words, the test checks the scenario in which we have the calculation over multiple weeks.
        /// In this specific test case, the calculation is over three weeks.
        ///The number of working days is elven while we have only ten working days in two weeks.
        ///The test assume that the code work regarding of number of weeks
        /// </summary>
        [TestMethod]
        public void TestMethodWithinThreeWeeks()
        {
            var myDay = 11;
            var myDate = DateTime.Parse("6-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("21-March-2018");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This method test the special code for handling the Weekend days.
        /// Specifically, it is related to Saturday day.
        /// Saturday should be excluded from calculation because it not a work day.
        /// Hence, we design a test method to test that specific code.
        /// </summary>
        [TestMethod]
        public void TestMethodofSaturday()
        {
            var myDay = 2;
            var myDate = DateTime.Parse("17-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("20-March-2018");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Monday is the first day of the week. It is a boundary day.
        /// many algorithms fails with the specific case of boundaries.
        /// hence, this method test that boundary.
        /// The start date is Monday
        /// </summary>
        [TestMethod]
        public void TestMethodFirstDayofTheWeekMonday()
        {
            var myDay = 2;
            var myDate = DateTime.Parse("19-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("21-March-2018");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Friday is the first day of the week. It is a boundary day.
        /// many algorithms fails with the specific case of boundaries.
        /// hence, this method test that boundary.
        /// The start date is Friday
        /// </summary>
        [TestMethod]
        public void TestMethodLastDayofTheWeekFriday()
        {
            var myDay = 2;
            var myDate = DateTime.Parse("16-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("20-March-2018");
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        /// The user may enter number of work days equal to zero.
        /// In this case, the calculated date is equivalent the start day.
        /// The general code of the program works with input equal to zero.
        /// There is also special to break the program when the input is equal to zero.
        /// This test method tests the behavior of the program when number of work days entered is equal to zero.
        /// </summary>
        [TestMethod]
        public void TestMethodOfDaysEqualZero()
        {
            var myDay = 0;
            var myDate = DateTime.Parse("19-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
            var expected = DateTime.Parse("19-March-2018");
            Assert.AreEqual(expected, actual);
        }



        /// <summary> 
        /// This test case checks that the library throws an exception.
        /// This happens when number of days is negative.
        /// The user may enter a number of days as a negative number.
        /// In this case, the library should throw an exception.
        /// the user of the library needs catch the exception and handle it in the way he/she want
        /// This test case assure that an exception is triggred in such scenario.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethodForException()
        {
            var myDay = -3;
            var myDate = DateTime.Parse("16-March-2018");
            var actual = Interview.Workday.CalculateWorkday(myDate, myDay);
        }
    }
}
