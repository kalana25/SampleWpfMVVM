using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace DataModel
{
    public delegate void CustomeEventHandler();
    public class Appointment:INotifyPropertyChanged
    {
        private int _doctorId;
        [ForeignKey("Doctor")]
        [Required]
        public int DoctorId
        {
            get { return _doctorId; }
            set
            {
                _doctorId = value;
                OnPropertyChanged("DoctorId");
            }
        }

        private int _pacientId;
        [ForeignKey("Patient")]
        [Required]
        public int PatientId
        {
            get { return _pacientId; }
            set
            {
                _pacientId = value;
                OnPropertyChanged("PatientId");
            }
        }

        private DateTime? _date;
        [Column(TypeName = "Date")]
        public DateTime? Date
        {
            get { return _date; }
            set
            {
                _date = value;
                AppointmentDateChanged();
                OnPropertyChanged("Date");
                OnPropertyChanged("DayCount");
                OnPropertyChanged("AppointmentId");
            }
        }

        private DateTime? _startTime;
        [DataType(DataType.Time)]
        public DateTime? StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private DateTime? _endTime;
        [DataType(DataType.Time)]
        public DateTime? EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        private string _appointmentId;
        [Key]
        public string AppointmentId
        {
            get
            { 
                return (!_date.HasValue)?string.Empty: _date.Value.Year.ToString() + _date.Value.Month.ToString().PadLeft(2, '0') +
                                 _date.Value.Day.ToString().PadLeft(2, '0') + _dayCount.ToString().PadLeft(4, '0');
            }
            set
            {
                _appointmentId = value;
                OnPropertyChanged("AppointmentId");
            }
        }

        private int _dayCount;
        public int DayCount
        {
            get { return _dayCount; }
            set
            {
                _dayCount = value;
                OnPropertyChanged("DayCount");
                OnPropertyChanged("AppointmentId");
            }
        }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

        public Appointment()
        {
            this.AppointmentDateChanged += Appointment_AppointmentDateChanged;
        }

        void Appointment_AppointmentDateChanged()
        {
            using (DBContext dbContext = new DBContext())
            {
                Appointment lastAppointment = dbContext.Appointments.Where(x => x.Date == Date).ToList().LastOrDefault();
                DayCount = (lastAppointment == null) ? DayCount++ : lastAppointment.DayCount++;
            }
        }


        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Custome Event
        public event CustomeEventHandler AppointmentDateChanged;
        #endregion
    }
}
