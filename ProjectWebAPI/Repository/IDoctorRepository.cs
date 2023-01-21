using System;
using ProjectWebApi.Entities;

namespace ProjectWebApi.Repository
{
	public interface IDoctorRepository
	{
        IEnumerable<Doctor> GetDoctors();

        Doctor GetDoctorById(int id);
    }
}

