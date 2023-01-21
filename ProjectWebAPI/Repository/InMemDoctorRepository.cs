using System;
using ProjectWebApi.Entities;

namespace ProjectWebApi.Repository
{
	public class InMemDoctorRepository : IDoctorRepository
    {
		private readonly List<Doctor> doctors = new()
		{
			 new Doctor(1,  "Julius",  "Hibbert", new() {1,2,3}),
			 new Doctor(2, "Algernop", "Krieger", new() {4,5}),
			 new Doctor(3, "Nick","Riviera", new() {6})
		};

        public InMemDoctorRepository()
		{
		}

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors;
        }


		public Doctor GetDoctorById(int id)
		{
			return doctors.Where(doc => doc.DoctorId == id).SingleOrDefault<Doctor>();
		}


    }
}

