using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.Entities;
using ProjectWebApi.Repository;
using ProjectWebAPI.DTOs;

namespace ProjectWebApi.Controllers
{
    [ApiController]
    [Route("doctors")]
    public class DoctorController: ControllerBase
	{
        private IDoctorRepository repository;
        private IAppointmentRepository appointmentRepository;


        public DoctorController(IDoctorRepository repository, IAppointmentRepository rep)
        {
            this.repository = repository;
            appointmentRepository = rep;
        }

        //get a list of doctors
        [HttpGet]
        public IEnumerable<DoctorDTO> GetDoctors()
        {
             IEnumerable<Doctor> docs = repository.GetDoctors();
            IEnumerable<Appointment> appointments = appointmentRepository.GetAllAppointments();

            //private IEnumerable<Appointment> GetAppointments(List<int> appointmentids)
            //{
            //    IEnumerable<Appointment> allappointments = appointmentRepository.GetAllAppointments();
            List<DoctorDTO> docDtos = new();
            foreach (Doctor doc in docs)
            {
                foreach (int id in doc.AppointmentIds)
                {
                    IEnumerable<Appointment> appByDoctor =
                        appointments.Where(appointment => appointment.AppointmentId.Equals(id));

                    docDtos.Add(new DoctorDTO(doc, appByDoctor));
                }
            }
                 return docDtos; 
        }
    }
}

