using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApi.Entities
{


	public class Appointment
	{
        [Required]
        public int AppointmentId { get; init; }

		[Required]
        public string PatientFirstName { get; init; }

        [Required]
        public string PatientLastName { get; init; }

        [Required]
        public DateTime AppointmentDate { get; init; }

        [Required]
        public AppointmentType AppointmentType { get; init; }

        [Required]
        public int DoctorId { get; init; }

        public Appointment(int appointmentId, string patientfirstname, string patientlastname, DateTime appointmentdate, AppointmentType appointmentType, int doctorId)
		{
			AppointmentId = appointmentId;
			PatientFirstName = patientfirstname;
			PatientLastName = patientlastname;
			AppointmentDate = appointmentdate;
			AppointmentType = appointmentType;
			DoctorId = doctorId;
		}
	}
}

