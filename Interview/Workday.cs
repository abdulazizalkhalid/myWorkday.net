using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Workday
    {
        // constant variable to contain number of working days per week
        public const int WORKING_DAYS = 5;
        // constant variable to contain number of days per week
        public const int DAYS_OF_WEEK = 7;
        // Default constructor of the class. It can be removed.
        public Workday()
        {
        }
        /// <summary>
        /// Calculate the number of working days.
        /// </summary>
        /// <param name="startDate">The start date from which the calculation will be started</param>
        /// <param name="numberOfWOrkdays">The number of work days need to be added to the start date </param>
        /// <returns>The work day that we get after adding the number of workdays to the start date</returns>
        public static DateTime CalculateWorkday(DateTime startDate, int numberOfWOrkdays)
        {
            /* a local variable to hold the start date. 
            We can work on the same argument of the function but my preference to define local variables.*/
            DateTime myStartDate = startDate;

            /* a local variable to hold the start date which will be updated lated. 
            We can work on the same argument of the function but my preference to define local variables.*/
            DateTime myUpdatedStartDate = myStartDate;

            /* a local variable to hold the value that the function will return. 
            As starting point, we assign to it the same value entered by the user for the start date.*/
            DateTime myCalulatedDate = myStartDate;

            /* a local variable to hold the number of working days. 
            We can use the same argument of the function (in the header of the function) but my preference to define a local variable.*/
            int myNumberOfWorkDays = numberOfWOrkdays;

            // number of working days cannot be negative value, if that happens, we need to trigger an exception
            if (myNumberOfWorkDays < 0)
            {
                throw new ArgumentException("Number of work days cannot be negative", "myNumberOfWorkDays");
            }

            /* if number of working days is equal to zero, then the calculated working
            date is equivalent to the start date. 
            This line can be removed. Program will continue to work.*/
            if (myNumberOfWorkDays == 0) return myCalulatedDate;

            // if the start date is Saturday, then we need to add two days the the start date.
            // This is because the weekend days are not work days. In addition, counting will be start from Friday.
            // In other words, it the start work day is a weekend day, I consider the start date the last working day before that date.
            // In this case, it is Friday. For example, if user entered 2, I count two days after Friday, then I get Tuesday
            if (myStartDate.DayOfWeek == DayOfWeek.Saturday)
            {
                // Adding two days for Satudrday and Sunday
                // we conunt from last working day which is Friday.
                myStartDate = myStartDate.AddDays(2);
                // Hence we decrease number of days by one.
                myNumberOfWorkDays = myNumberOfWorkDays - 1;
            }
            // it the start date is Sunday, then we need to start counting from Monday.
            // Based on my assumptions, if the start days is Friday, Saturday of Sunday, that will produce the same output
            else if (myStartDate.DayOfWeek == DayOfWeek.Sunday)
            {
                // We add one day the the start date.
                myStartDate = myStartDate.AddDays(1);
                // We start countring from Friday
                myNumberOfWorkDays = myNumberOfWorkDays - 1;
            }


            // We have 5 working days per week and 7 days per week
            // This is a local variable to have the number of working weeks equivalent to number of working days entered by the user.
            int myNumberOfWorkingWeeks = myNumberOfWorkDays / WORKING_DAYS;
            
            // we add two weekend days to each working week entered by the user (after conversion from working to working weeks) to have the right number of days.
            int myNumberOfAllDaysToBeAdded = myNumberOfWorkingWeeks * DAYS_OF_WEEK;
            
            //The updated start date will be increase to contain the calculated days.
            myUpdatedStartDate = myStartDate.AddDays(myNumberOfAllDaysToBeAdded);

            /* The remaining days are the reminder of dividing number of days entered by user 
            over the number working days by week which is five working days.*/
            int myRemainingDays = myNumberOfWorkDays % WORKING_DAYS;
            
            // casting the new day of the week to integer value
            // we add it the order of start day per week that we calculated
            int orderOfStartDayPerWeek = (int) myUpdatedStartDate.DayOfWeek;
            
            // The total number of days is the new updated order of the start day per week plus the number of remaining days.
            int myTotalDays = orderOfStartDayPerWeek + myRemainingDays;

            //if the total is greater than five days then we need to add two extra days(for the weekend) to the remaining days.
            if (myTotalDays > WORKING_DAYS)
            {
                myRemainingDays = myRemainingDays + 2;
            }

            // We add the remaining days to the update date and assign the output to the variable which will contain the calculated value.
            myCalulatedDate = myUpdatedStartDate.AddDays(myRemainingDays);

            // we return the calculated date.
            return myCalulatedDate;
        }
    }

}
