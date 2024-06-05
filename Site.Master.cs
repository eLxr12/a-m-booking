using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Booking_sample
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int total_amount;
            int weekdays = 0;
            int weekends = 0;
            int numPax = Int32.Parse(TextBox8.Text);
            int numpark = Int32.Parse(TextBox5.Text);
            int numregpass = Int32.Parse(TextBox6.Text);
            int numholpass = Int32.Parse(TextBox7.Text);
            int weekdayamt;
            int weekendamt;
            DateTime currentDate = DateTime.Parse(TextBox3.Text);
            DateTime enddate = DateTime.Parse(TextBox4.Text);
            while (currentDate <= enddate)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekends++;
                }
                else
                {
                    weekdays++;
                }

                currentDate = currentDate.AddDays(1);
            }
            if (enddate.DayOfWeek == DayOfWeek.Saturday || enddate.DayOfWeek == DayOfWeek.Sunday)
            {
                weekends--;
            }
            else 
            {
                weekdays--;
            }
            if (numPax > 2)
            {
                total_amount = (numpark * 500) + (numregpass * 150) + (numholpass * 300) + (weekdays * 2999) + (weekends * 3299);
                weekdayamt = (weekdays * 2999);
                weekendamt = (weekends * 3299);
            }
            else 
            {
                total_amount = (numpark * 500) + (numregpass * 150) + (numholpass * 300) + (weekdays * 2499) + (weekends * 2799);
                weekdayamt = (weekdays * 2499);
                weekendamt = (weekends * 2799);
            }
            TextBox1.Text = "Name: "+ TextBox2.Text+"\n"+ "💜"+ weekdays.ToString() +" night/s weekday for "+ numPax+" = "+weekdayamt.ToString()+"\n"
               +"💜" +weekends.ToString()+" night/s weekends for " + numPax+" = "+ weekendamt.ToString()+
               "\n Total Amount to be paid upon Checkin=₱" + total_amount.ToString() +"\n"+ "Security deposit paid";
        }
    }
}