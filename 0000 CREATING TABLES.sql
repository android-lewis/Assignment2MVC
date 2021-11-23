CREATE TABLE TestCentre (
	TestCentreID bigint identity primary key,
	CentreName nvarchar(200),
	CentreOperatingTimes nvarchar(200),
	CentreAddress nvarchar(200),
	CentreContactNo nvarchar(200),
	CentreCounty nvarchar(200)
);

CREATE TABLE Appointment (
	AppointmentID bigint identity primary key,
	PatientName nvarchar(200),
	PatientContactNo nvarchar(200),
	PatientAddress nvarchar(200),
	AppointmentDate date,
	AppointmentTime time,
	TestCentreID bigint,
	FOREIGN KEY (TestCentreID) REFERENCES TestCentre(TestCentreID)
);