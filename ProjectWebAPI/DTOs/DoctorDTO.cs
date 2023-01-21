using System;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.Entities;
using ProjectWebApi.Repository;
using ProjectWebAPI.DTOs;

namespace ProjectWebAPI.DTOs
{
	public class DoctorDTO 
	{
		//private IAppointmentRepository appointmentRepository;
        private Doctor getdocs;

        public string DoctorName { get; init; }
		public int DoctorId { get; init; }
		public IEnumerable<Appointment> Appointments { get; init; }
       

  //      public DoctorDTO(Doctor doc , Appointment appointment)
		//{
		//	DoctorName = doc.FirstName + " " + doc.LastName;
		//	Appointments = GetAppointments(doc.AppointmentIds);
		//	//this.appointmentRepository = appointmentRepository;

		//}

        public DoctorDTO(Doctor getdocs, IEnumerable<Appointment> appointments)
        {
            this.getdocs = getdocs;
			DoctorName = getdocs.FirstName + " " + getdocs.LastName;
			DoctorId = getdocs.DoctorId;
            Appointments = appointments;
        }

        

	}
}

