using System;
namespace ProjectWebApi.Entities
{
	public class Doctor
	{
		public int DoctorId { get; init; }

		public string FirstName { get; init; }

		public string LastName { get; init; }

		public List<int> AppointmentIds { get; set; }

		public Doctor(int doctorId, string firstname, string lastname)
		{
			DoctorId = doctorId;
			FirstName = firstname;
			LastName = lastname;
		}

        public Doctor(int doctorId, string firstname, string lastname, List<int> appointmentIds)
        {
            DoctorId = doctorId;
            FirstName = firstname;
            LastName = lastname;
			AppointmentIds = appointmentIds;
        }

    }
}

