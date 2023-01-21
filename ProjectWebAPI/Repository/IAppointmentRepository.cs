using System;
using ProjectWebApi.Entities;

namespace ProjectWebApi.Repository
{
	public interface IAppointmentRepository
	{
        IEnumerable<Appointment> GetAllAppointments();

        bool DeleteAppointment(int appointmentId);

        bool CreateAppointment(Appointment appointment);

        bool UpdateAppointment(Appointment appointment);
    }
}

