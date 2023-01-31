using System;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.Entities;
using ProjectWebApi.Repository;
using ProjectWebAPI.DTOs;

namespace ProjectWebApi.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
	{
        private IAppointmentRepository appointmentRepository;
        private IDoctorRepository doctorRepository;

        public AppointmentController(IAppointmentRepository repository, IDoctorRepository doctorRepository)
		{
            appointmentRepository = repository;
            this.doctorRepository = doctorRepository;
		}

        // get appointments of a doctor on a particular date
        [HttpGet("{doctorId}/{date}")]
        public IEnumerable<AppointmentDTO> GetAppointmentsByDoctorAndDate(int doctorId, DateTime date)
        {
            IEnumerable<Appointment> allAppointments = appointmentRepository.GetAllAppointments();

            IEnumerable<Appointment> appointmentsByDoctorAndDate =
                allAppointments.Where(appointment => appointment.DoctorId == doctorId)
                .Where(appointment => appointment.AppointmentDate.Date.Equals(date));

            IEnumerable<AppointmentDTO> appointments = appointmentsByDoctorAndDate
                .Select(appointment => new AppointmentDTO(appointment))
                .ToList();

            return appointments;
        }

        //Delete an existing appointment from a doctor's calendar
        [HttpDelete("{appointmentId}")]
        public ActionResult DeleteAppointment(int appointmentId)
        {
            if (appointmentRepository.DeleteAppointment(appointmentId))
            {
                return Ok();
            }
            else return NotFound("Appointment not found");
        }

        //Add a new appointment to a doctor's calendar
        [HttpPost]
        public ActionResult CreateAppointment(Appointment appointment)
        {
            //check doctorId exists
            Doctor doc = doctorRepository.GetDoctorById(appointment.DoctorId);
            if(doc == null)
            {
                return NotFound("Doctor not found");
            }

            //check time in 15s
            int appMinutes = appointment.AppointmentDate.Minute;
            if((appMinutes % 15) != 0)
            {
                return Content("Invalid appointment time");
            }

            //check doctor's appointments
            IEnumerable<Appointment> appointmentsByDoctorAndDateTime = appointmentRepository.GetAllAppointments()
                .Where(app => app.DoctorId == doc.DoctorId)
                .Where(app => app.AppointmentDate.Equals(appointment.AppointmentDate));
            int count = appointmentsByDoctorAndDateTime.Count();
            if(count > 2)
            {
                return Content("Not more than 3 appointments allowed for this doctor at this time");
            }

            if(appointmentRepository.CreateAppointment(appointment))
                return Ok();

            else
            {
                return Content("Appointment with this appointmentId exists");
            }
        }


        [HttpPut("{AppointmentId}")]
        public ActionResult<bool> UpdateAppointment( Appointment appointment)
        {
            //check doctorId exists
            Doctor doc = doctorRepository.GetDoctorById(appointment.DoctorId);
            if (doc == null)
            {
                return NotFound("Doctor not found");
            }

            //check time in 15s
            int appMinutes = appointment.AppointmentDate.Minute;
            if ((appMinutes % 15) != 0)
            {
                return Content("Invalid appointment time");
            }
            IEnumerable<Appointment> getallapps = appointmentRepository.GetAllAppointments()
            .Where(app => app.AppointmentId.Equals(appointment.AppointmentId));
            int count = getallapps.Count();
            if (count == 0)
            {
                return Content("AppointmentID not found");
            }
            if (appointmentRepository.UpdateAppointment(appointment))
            {
                return Ok();
            }
            else return Content("update fail");
            

        }
	}
}

