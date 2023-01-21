using System;
using ProjectWebApi.Entities;

namespace ProjectWebApi.Repository
{
	public class InMemAppointmentRepository : IAppointmentRepository
	{

        private readonly List<Appointment> appointments = new()
        {
            new Appointment(1, "Sterling","Archer" , new DateTime(2008,5,9,8,0,0), AppointmentType.NewPatient, 1 ),
              new Appointment(2, "Cyril","Figis" , new DateTime(2008,5,9,8,30,0), AppointmentType.FollowUp,1 ),
              new Appointment(3, "Ray","Gilette" , new DateTime(2008,5,9,9,0,0), AppointmentType.FollowUp,1 ),
              new Appointment(4, "Lana","Kane" , new DateTime(2008,5,9,9,30,0), AppointmentType.NewPatient,2 ),
              new Appointment(5, "Pam","Poovey" , new DateTime(2008,5,9,10,0,0), AppointmentType.FollowUp,2 ),
              new Appointment(6, "Pam","Poovey" , new DateTime(2008,5,9,10,0,0), AppointmentType.FollowUp,3 ),


        };

        public InMemAppointmentRepository()
		{
		}

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return appointments;
        }

        // delete appointment by id
        // return true if found and deleted
        // return false if not found
        public bool DeleteAppointment(int appointmentId)
        {
            Appointment appointmentToRemove = appointments.SingleOrDefault(r => r.AppointmentId == appointmentId);
            if (appointmentToRemove != null)
            {
                appointments.Remove(appointmentToRemove);
                return true;
            }
            else
            {
                return false;
            }  
        }


        public bool CreateAppointment(Appointment appointment)
        {
            Appointment thisApp = appointments.SingleOrDefault(r => r.AppointmentId == appointment.AppointmentId);
            if(thisApp != null)
            {
                return false;
            }
            appointments.Add(appointment);
            return true;
        }

        public bool UpdateAppointment(Appointment appointment)
        {
          var index = appointments.FindIndex(existingAppointment => existingAppointment.AppointmentId == appointment.AppointmentId);
            appointments[index]= appointment;
            //  appointments.
            return true;
        }

	}
}

