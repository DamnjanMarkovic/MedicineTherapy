using DataModels;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DataProvider
{

    public class Archive
    {
        public ObservableCollection<Patient> GetPatients()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {

                Patient patient = new Patient();
                Medicine medicine = new Medicine();
                ObservableCollection<Patient> listPatients = new ObservableCollection<Patient>();
                ObservableCollection<Medicine> medicineList = new ObservableCollection<Medicine>();

                connection = new SqlConnection(ConfigFile.connectionString);

                command = new SqlCommand("", connection);
                connection.Open();


                listPatients = GetAllPatients(command);


                foreach (Patient patientInTheList in listPatients)
                {
                    medicine = new Medicine();
                    medicineList = new ObservableCollection<Medicine>();
                    string query = @"
                                SELECT m.MedicineID, m.MedicineName, m.GroupID
                                FROM PatientMedicine pm
                                JOIN Patients p on pm.PersonID = p.PersonID
                                JOIN Medicine m on m.MedicineID = pm.MedicineID
                                WHERE p.PersonID = @PersonID
                                order by p.PersonID
                            ";


                    command.CommandText = query;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@PersonID", patientInTheList.PersonID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                medicine = new Medicine();

                                medicine.MedicineID = reader["MedicineID"] as int? ?? default(int);
                                medicine.MedicineName = reader["MedicineName"] as string;
                                var medicineGroupID = reader["GroupID"] as int? ?? default(int);
                                medicine.MedicineType = (MedicineType)Enum.ToObject(typeof(MedicineType), medicineGroupID);

                                medicineList.Add(medicine);
                            }
                            patientInTheList.MedicineList = medicineList;
                        }
                    }
                }




                return listPatients;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }


        }

        private ObservableCollection<Patient> GetAllPatients(SqlCommand command)
        {
            Patient patient = new Patient();
            ObservableCollection<Patient> listPatients = new ObservableCollection<Patient>();
            string query = @"SELECT * from Patients";

            command.CommandText = query;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        patient = new Patient();

                        patient.PersonID = reader["PersonID"] as int? ?? default(int);
                        patient.BirthYear = reader["BirthYear"] as int? ?? default(int);
                        listPatients.Add(patient);
                    }
                }
                else
                {
                    return null;
                }
            }

            return listPatients;
        }

        public ObservableCollection<Medicine> GetMedicines()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {

                Patient patient = new Patient();
                Medicine medicine = new Medicine();
                ObservableCollection<Patient> listPatients = new ObservableCollection<Patient>();
                ObservableCollection<Medicine> medicineList = new ObservableCollection<Medicine>();

                connection = new SqlConnection(ConfigFile.connectionString);

                command = new SqlCommand("", connection);
                connection.Open();


                medicineList = GetAllMedicines(command);


                foreach (Medicine medicineInTheList in medicineList)
                {
                    patient = new Patient();
                    listPatients = new ObservableCollection<Patient>();
                    string query = @"
                                SELECT p.PersonID, p.BirthYear
                                FROM PatientMedicine pm
                                JOIN Patients p on pm.PersonID = p.PersonID
                                JOIN Medicine m on m.MedicineID = pm.MedicineID
                                WHERE m.MedicineID = @MedicineID
                                order by m.MedicineID
                            ";


                    command.CommandText = query;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@MedicineID", medicineInTheList.MedicineID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                patient = new Patient();

                                patient.PersonID = reader["PersonID"] as int? ?? default(int);
                                patient.BirthYear = reader["BirthYear"] as int? ?? default(int);
                                listPatients.Add(patient);

                            }
                            medicineInTheList.patientList = listPatients;
                        }
                    }
                }

                return medicineList;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }

        }

        private ObservableCollection<Medicine> GetAllMedicines(SqlCommand command)
        {
            Medicine medicine = new Medicine();
            ObservableCollection<Medicine> listMedicines = new ObservableCollection<Medicine>();
            string query = @"SELECT * from Medicine";

            command.CommandText = query;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        medicine = new Medicine();

                        medicine.MedicineID = reader["MedicineID"] as int? ?? default(int);
                        medicine.MedicineName = reader["MedicineName"] as string;
                        var medicineGroupID = reader["GroupID"] as int? ?? default(int);
                        medicine.MedicineType = (MedicineType)Enum.ToObject(typeof(MedicineType), medicineGroupID);
                        listMedicines.Add(medicine);
                    }
                }
                else
                {
                    return null;
                }
            }

            return listMedicines;
        }
    }
}
