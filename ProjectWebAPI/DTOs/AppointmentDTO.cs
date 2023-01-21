using System;
using ProjectWebApi.Entities;

namespace ProjectWebAPI.DTOs
{
	public class AppointmentDTO
	{
		public string PatientName { get; init; }
		public DateTime AppointmentDateTime { get; init; }
		public string AppointmentKind { get; init; }

        public AppointmentDTO(Appointment appointment)
		{
			PatientName = appointment.PatientFirstName + " " + appointment.PatientLastName;
			AppointmentDateTime = appointment.AppointmentDate;
			AppointmentKind = GetAppointmentTypeString(appointment.AppointmentType);
		}

		private static string GetAppointmentTypeString(AppointmentType type)
		{
			if(type.Equals(AppointmentType.NewPatient))
			{
				return "NewPatient";
			}
			else
			{
				return "Follow-Up";
			}
		}
	}
}

