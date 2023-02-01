#Project- REST API to manage Doctors Appointments

REST API project built on .NET 7 using C# and Docker.
Data is kept in memory.

To Test APIs hit following endpoints on Swagger/Postman-
1. GET localhost:<port>/doctors - to get list of doctors
2. GET localhost:<port>/appointments/{doctorId}/{date} - Get a list of all appointments for a particular doctor and particular day
3. DELETE localhost:<port>/appointments/{appointmentId} - Delete an existing appointment from a doctor's calendar
4. POST localhost:<port>/appointments/ - Add a new appointment to a doctor's calendar validating the following conditions-
  a. New Appointment can only start at 15 mins interval.
  b. A doctor can have no more than 3 appointments at the same time.
5. PUT localhost:<port>/appointments/{appointmentId} 
  
  
To build -
  
The project contains a DockerFile.
Use the following commands to use the Dockerfile (for MacOS)
1. Open Terminal and navigate to the project folder that contains the file named Dockerfile.
2. Use the following command to create an image -
    docker build -t <image_name> .
3. Next we need to run the application in a container using:
    docker run -dp <port_number> <image_name>

4. Open the localhost in your broweser -
  http://localhost:<port_number>
