using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class AppointmentBLL
    {
        public Appointment GetNextAppointment()
        {
            try
            {
                //string DatePart = (DateTime.Today).Day.ToString().PadLeft(2, '0');
                //string MonthPart = (DateTime.Today).Month.ToString().PadLeft(2, '0');
                //string YearPart = (DateTime.Today).Year.ToString();
                using (DBContext dbcontext = new DBContext())
                {
                    //Appointment temp =dbcontext.Appointments.Where(x => x.Date == (DateTime.Today).Date).ToList().LastOrDefault();
                    Appointment temp=new Appointment();
                    if (temp != null)
                    {
                        temp.DayCount =dbcontext.Appointments.Where(x => x.Date == (DateTime.Today).Date).ToList().Count;
                        temp.DayCount++;
                        //temp.AppointmentId = YearPart + MonthPart + DatePart + temp.DayCount.ToString().PadLeft(4, '0');
                        //temp.DoctorId = 0;
                        //temp.PatientId = 0;
                        //temp.StartTime = null;
                        //temp.EndTime = null;
                        //temp.Date = null;
                        return temp;
                    }
                    temp = new Appointment();
                    temp.DayCount =dbcontext.Appointments.Where(x => x.Date == (DateTime.Today).Date).ToList().Count;
                    temp.DayCount++;
                    //temp.AppointmentId = YearPart + MonthPart + DatePart + temp.DayCount.ToString().PadLeft(4, '0');
                    //temp.StartTime = null;
                    //temp.EndTime = null;
                    return temp;
                }
            }
            catch
            {throw;}
        }
        public int InsertAppointment(Appointment appointment)
        {
            try
            {
                int result = 0;
                using (DBContext dbcontext = new DBContext())
                {
                    dbcontext.Appointments.Add(appointment);
                    result = dbcontext.SaveChanges();
                }
                return result;
            }
            catch (Exception)
            {throw;}
        }

    }
}
