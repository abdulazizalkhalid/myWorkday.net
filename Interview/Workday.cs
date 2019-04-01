using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Workday
    {
        /// <summary>
        /// Calculate the number of working days.
        /// </summary>
        /// <param name="startDate">The start date from which the calculation will be started</param>
        /// <param name="numberOfWOrkdays">The number of work days need to be added to the start date </param>
        /// <returns>The work day that we get after adding the number of workdays to the start date</returns>
        public static DateTime CalculateWorkday(DateTime startDate, int numberOfWOrkdays)
        {
            DateTime myStartDate = startDate;
            // a local variable to hold the start date. We can work on the same argument of the function but my preference to define local variables.
            DateTime myUpdatedStartDate = myStartDate;

            /* a local variable to hold the value that the function will return. 
            As starting point, we assign to it the same value entered by the user for the start date.*/
            DateTime myCalulatedDate = myStartDate;

            /* a local variable to hold the number of working days. 
            We can use the same argument of the function (in the header of the function) but my preference to define a local variable.*/
            int myNumberOfWorkDays = numberOfWOrkdays;

            // We add the  days to the updated date and assign the output to the variable which will contain the calculated value.
            myCalulatedDate = myUpdatedStartDate.AddDays(myNumberOfWorkDays);

            // we return the calculated date.
            return myCalulatedDate;
        }
    }

}
