-- =============================================
-- HEALTH CLINIC DATABASE - MSSQL COMPLETE SCRIPT
-- =============================================

-- STEP 1: Create Database
CREATE DATABASE HealthCareDB;

USE HealthCareDB;

-- Specialities Tables 
CREATE TABLE specialties (
    specialty_id INT PRIMARY KEY IDENTITY(1,1),
    specialty_name VARCHAR(100) NOT NULL
);

-- Patient Table
CREATE TABLE patients (
    patient_id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    dob DATE,
    contact VARCHAR(15) NOT NULL UNIQUE,
    email VARCHAR(100) UNIQUE,
    address VARCHAR(MAX),
    blood_group VARCHAR(5)
);

-- Doctor Table
CREATE TABLE doctors (
    doctor_id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    specialty_id INT,
    contact VARCHAR(15),
    consultation_fee DECIMAL(10,2),
    is_active BIT DEFAULT 1,
    
    FOREIGN KEY (specialty_id) REFERENCES specialties(specialty_id)
);

-- Appointments Table
CREATE TABLE appointments (
    appointment_id INT PRIMARY KEY IDENTITY(1,1),
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    appointment_date DATETIME DEFAULT GETDATE(),
    appointment_time TIME NOT NULL,
    status VARCHAR(20) DEFAULT 'SCHEDULED',
    
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id)
);

-- Visit Table
CREATE TABLE visits (
    visit_id INT PRIMARY KEY IDENTITY(1,1),
    appointment_id INT,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    visit_date DATETIME DEFAULT GETDATE(),
    diagnosis VARCHAR(MAX),
    notes VARCHAR(MAX),
    
    FOREIGN KEY (appointment_id) REFERENCES appointments(appointment_id),
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id)
);

-- Prescription Table
CREATE TABLE prescription (
    prescription_id INT PRIMARY KEY IDENTITY(1,1),
    visit_id INT NOT NULL,
    medicine_name VARCHAR(200) NOT NULL,
    dosage VARCHAR(100),
    duration VARCHAR(50),

    FOREIGN KEY (visit_id) REFERENCES visits(visit_id)
);

-- Bills Table
CREATE TABLE bills (
    bill_id INT PRIMARY KEY IDENTITY(1,1),
    visit_id INT NOT NULL,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL,
    payment_status VARCHAR(20) DEFAULT 'UNPAID',
    payment_mode VARCHAR(50),
    payment_date DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (visit_id) REFERENCES visits(visit_id),
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id)
);

-- Payment Transaction
CREATE TABLE payment_transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    bill_id INT NOT NULL,
    amount_paid DECIMAL(10,2) NOT NULL,
    payment_date DATETIME DEFAULT GETDATE(),
    payment_mode VARCHAR(50) NOT NULL,
    
    FOREIGN KEY (bill_id) REFERENCES bills(bill_id)
);

-- Search Master Table
CREATE TABLE search_master (
    id INT PRIMARY KEY IDENTITY(1,1),
    patient_id INT,
    doctor_id INT,
    bill_id INT,
    
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id),
    FOREIGN KEY (bill_id) REFERENCES bills(bill_id)
);

-- Audit log Table
CREATE TABLE audit_log (
    audit_id INT PRIMARY KEY IDENTITY(1,1),
    table_name VARCHAR(50) NOT NULL,
    record_id INT NOT NULL,
    action VARCHAR(20) NOT NULL,
    old_data VARCHAR(MAX),
    new_data VARCHAR(MAX),
    changed_by VARCHAR(50),
    changed_at DATETIME DEFAULT GETDATE()
);

-- All Indexes
CREATE INDEX idx_patient_contact ON patients(contact);
CREATE INDEX idx_patient_name ON patients(name);
CREATE INDEX idx_doctor_specialty ON doctors(specialty_id);
CREATE INDEX idx_doctor_active ON doctors(is_active);
CREATE INDEX idx_appointment_date ON appointments(appointment_date);
CREATE INDEX idx_appointment_patient ON appointments(patient_id);
CREATE INDEX idx_appointment_doctor ON appointments(doctor_id);
CREATE INDEX idx_visit_patient ON visits(patient_id);
CREATE INDEX idx_visit_doctor ON visits(doctor_id);
CREATE INDEX idx_visit_date ON visits(visit_date);
CREATE INDEX idx_bill_status ON bills(payment_status);
CREATE INDEX idx_bill_patient ON bills(patient_id);
CREATE INDEX idx_search_patient ON search_master(patient_id);
CREATE INDEX idx_search_doctor ON search_master(doctor_id);
CREATE INDEX idx_search_bill ON search_master(bill_id);
CREATE INDEX idx_audit_table ON audit_log(table_name);
CREATE INDEX idx_audit_date ON audit_log(changed_at);
GO
-- Speacialities Triggers
CREATE TRIGGER trg_specialties_after_insert
ON specialties
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'specialties', i.specialty_id, 'INSERT', NULL,
        'specialty_name:' + i.specialty_name, SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_specialties_after_update
ON specialties
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'specialties', i.specialty_id, 'UPDATE',
        'specialty_name:' + d.specialty_name,
        'specialty_name:' + i.specialty_name, SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.specialty_id = d.specialty_id;
END;
GO

CREATE TRIGGER trg_specialties_after_delete
ON specialties
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'specialties', d.specialty_id, 'DELETE',
        'specialty_name:' + d.specialty_name, NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Patient Triggers
CREATE TRIGGER trg_patients_after_insert
ON patients
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'patients', i.patient_id, 'INSERT', NULL,
        'name:' + i.name + ', contact:' + i.contact + ', email:' + ISNULL(i.email,'') + ', blood_group:' + ISNULL(i.blood_group,''),
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_patients_after_update
ON patients
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'patients', i.patient_id, 'UPDATE',
        'name:' + d.name + ', contact:' + d.contact + ', email:' + ISNULL(d.email,''),
        'name:' + i.name + ', contact:' + i.contact + ', email:' + ISNULL(i.email,''),
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.patient_id = d.patient_id;
END;
GO

CREATE TRIGGER trg_patients_after_delete
ON patients
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'patients', d.patient_id, 'DELETE',
        'name:' + d.name + ', contact:' + d.contact, NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Doctors Triggers
CREATE TRIGGER trg_doctors_after_insert
ON doctors
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'doctors', i.doctor_id, 'INSERT', NULL,
        'name:' + i.name + ', specialty_id:' + CAST(i.specialty_id AS VARCHAR) + ', fee:' + CAST(i.consultation_fee AS VARCHAR),
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_doctors_after_update
ON doctors
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'doctors', i.doctor_id, 'UPDATE',
        'name:' + d.name + ', fee:' + CAST(d.consultation_fee AS VARCHAR) + ', is_active:' + CAST(d.is_active AS VARCHAR),
        'name:' + i.name + ', fee:' + CAST(i.consultation_fee AS VARCHAR) + ', is_active:' + CAST(i.is_active AS VARCHAR),
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.doctor_id = d.doctor_id;
END;
GO

CREATE TRIGGER trg_doctors_after_delete
ON doctors
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'doctors', d.doctor_id, 'DELETE',
        'name:' + d.name + ', fee:' + CAST(d.consultation_fee AS VARCHAR), NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Appointment Triggers

CREATE TRIGGER trg_appointments_after_insert
ON appointments
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'appointments', i.appointment_id, 'INSERT', NULL,
        'patient_id:' + CAST(i.patient_id AS VARCHAR) + ', doctor_id:' + CAST(i.doctor_id AS VARCHAR) + ', date:' + CAST(i.appointment_date AS VARCHAR) + ', status:' + i.status,
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_appointments_after_update
ON appointments
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'appointments', i.appointment_id, 'UPDATE',
        'date:' + CAST(d.appointment_date AS VARCHAR) + ', status:' + d.status,
        'date:' + CAST(i.appointment_date AS VARCHAR) + ', status:' + i.status,
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.appointment_id = d.appointment_id;
END;
GO

CREATE TRIGGER trg_appointments_after_delete
ON appointments
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'appointments', d.appointment_id, 'DELETE',
        'patient_id:' + CAST(d.patient_id AS VARCHAR) + ', doctor_id:' + CAST(d.doctor_id AS VARCHAR),
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Visits Triggers
CREATE TRIGGER trg_visits_after_insert
ON visits
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'visits', i.visit_id, 'INSERT', NULL,
        'appointment_id:' + CAST(ISNULL(i.appointment_id, 0) AS VARCHAR) + 
        ', patient_id:' + CAST(i.patient_id AS VARCHAR) + 
        ', doctor_id:' + CAST(i.doctor_id AS VARCHAR) + 
        ', visit_date:' + CAST(i.visit_date AS VARCHAR) + 
        ', diagnosis:' + ISNULL(i.diagnosis, ''),
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_visits_after_update
ON visits
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'visits', i.visit_id, 'UPDATE',
        'diagnosis:' + ISNULL(d.diagnosis, '') + ', notes:' + ISNULL(d.notes, ''),
        'diagnosis:' + ISNULL(i.diagnosis, '') + ', notes:' + ISNULL(i.notes, ''),
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.visit_id = d.visit_id;
END;
GO

CREATE TRIGGER trg_visits_after_delete
ON visits
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'visits', d.visit_id, 'DELETE',
        'patient_id:' + CAST(d.patient_id AS VARCHAR) + 
        ', doctor_id:' + CAST(d.doctor_id AS VARCHAR) + 
        ', diagnosis:' + ISNULL(d.diagnosis, ''),
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Prescrptions Triggers
CREATE TRIGGER trg_prescriptions_after_insert
ON prescription
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'prescriptions', i.prescription_id, 'INSERT', NULL,
        'visit_id:' + CAST(i.visit_id AS VARCHAR) + 
        ', medicine:' + i.medicine_name + 
        ', dosage:' + ISNULL(i.dosage, '') + 
        ', duration:' + ISNULL(i.duration, ''),
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_prescriptions_after_update
ON prescription
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'prescriptions', i.prescription_id, 'UPDATE',
        'medicine:' + d.medicine_name + ', dosage:' + ISNULL(d.dosage, '') + ', duration:' + ISNULL(d.duration, ''),
        'medicine:' + i.medicine_name + ', dosage:' + ISNULL(i.dosage, '') + ', duration:' + ISNULL(i.duration, ''),
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.prescription_id = d.prescription_id;
END;
GO

CREATE TRIGGER trg_prescriptions_after_delete
ON prescription
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'prescriptions', d.prescription_id, 'DELETE',
        'visit_id:' + CAST(d.visit_id AS VARCHAR) + 
        ', medicine:' + d.medicine_name + 
        ', dosage:' + ISNULL(d.dosage, ''),
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Bills Triggers
CREATE TRIGGER trg_bills_after_insert
ON bills
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'bills', i.bill_id, 'INSERT', NULL,
        'patient_id:' + CAST(i.patient_id AS VARCHAR) + ', amount:' + CAST(i.total_amount AS VARCHAR) + ', status:' + i.payment_status,
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_bills_after_update
ON bills
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'bills', i.bill_id, 'UPDATE',
        'amount:' + CAST(d.total_amount AS VARCHAR) + ', status:' + d.payment_status,
        'amount:' + CAST(i.total_amount AS VARCHAR) + ', status:' + i.payment_status,
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.bill_id = d.bill_id;
END;
GO

CREATE TRIGGER trg_bills_after_delete
ON bills
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'bills', d.bill_id, 'DELETE',
        'patient_id:' + CAST(d.patient_id AS VARCHAR) + ', amount:' + CAST(d.total_amount AS VARCHAR),
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Payment Transaction Triggers
CREATE TRIGGER trg_payment_transactions_after_insert
ON payment_transactions
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'payment_transactions', i.transaction_id, 'INSERT', NULL,
        'bill_id:' + CAST(i.bill_id AS VARCHAR) + 
        ', amount_paid:' + CAST(i.amount_paid AS VARCHAR) + 
        ', payment_date:' + CAST(i.payment_date AS VARCHAR) + 
        ', payment_mode:' + i.payment_mode,
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_payment_transactions_after_update
ON payment_transactions
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'payment_transactions', i.transaction_id, 'UPDATE',
        'amount_paid:' + CAST(d.amount_paid AS VARCHAR) + ', payment_mode:' + d.payment_mode,
        'amount_paid:' + CAST(i.amount_paid AS VARCHAR) + ', payment_mode:' + i.payment_mode,
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.transaction_id = d.transaction_id;
END;
GO

CREATE TRIGGER trg_payment_transactions_after_delete
ON payment_transactions
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'payment_transactions', d.transaction_id, 'DELETE',
        'bill_id:' + CAST(d.bill_id AS VARCHAR) + 
        ', amount_paid:' + CAST(d.amount_paid AS VARCHAR) + 
        ', payment_mode:' + d.payment_mode,
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- Search Master Triggers
CREATE TRIGGER trg_search_master_after_insert
ON search_master
AFTER INSERT
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'search_master', i.id, 'INSERT', NULL,
        'patient_id:' + CAST(ISNULL(i.patient_id, 0) AS VARCHAR) + 
        ', doctor_id:' + CAST(ISNULL(i.doctor_id, 0) AS VARCHAR) + 
        ', bill_id:' + CAST(ISNULL(i.bill_id, 0) AS VARCHAR),
        SYSTEM_USER
    FROM INSERTED i;
END;
GO

CREATE TRIGGER trg_search_master_after_update
ON search_master
AFTER UPDATE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'search_master', i.id, 'UPDATE',
        'patient_id:' + CAST(ISNULL(d.patient_id, 0) AS VARCHAR) + 
        ', doctor_id:' + CAST(ISNULL(d.doctor_id, 0) AS VARCHAR) + 
        ', bill_id:' + CAST(ISNULL(d.bill_id, 0) AS VARCHAR),
        'patient_id:' + CAST(ISNULL(i.patient_id, 0) AS VARCHAR) + 
        ', doctor_id:' + CAST(ISNULL(i.doctor_id, 0) AS VARCHAR) + 
        ', bill_id:' + CAST(ISNULL(i.bill_id, 0) AS VARCHAR),
        SYSTEM_USER
    FROM INSERTED i
    INNER JOIN DELETED d ON i.id = d.id;
END;
GO

CREATE TRIGGER trg_search_master_after_delete
ON search_master
AFTER DELETE
AS
BEGIN
    INSERT INTO audit_log (table_name, record_id, action, old_data, new_data, changed_by)
    SELECT 'search_master', d.id, 'DELETE',
        'patient_id:' + CAST(ISNULL(d.patient_id, 0) AS VARCHAR) + 
        ', doctor_id:' + CAST(ISNULL(d.doctor_id, 0) AS VARCHAR) + 
        ', bill_id:' + CAST(ISNULL(d.bill_id, 0) AS VARCHAR),
        NULL, SYSTEM_USER
    FROM DELETED d;
END;
GO

-- =============================================
-- ALL 27 STORED PROCEDURES
-- =============================================

-- =============================================
-- 1. SPECIALTIES PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_specialty
    @specialty_name VARCHAR(100)
AS
BEGIN
    INSERT INTO specialties (specialty_name)
    VALUES (@specialty_name);
    SELECT SCOPE_IDENTITY() AS new_specialty_id;
END;
GO

CREATE PROCEDURE sp_update_specialty
    @specialty_id INT,
    @specialty_name VARCHAR(100)
AS
BEGIN
    UPDATE specialties
    SET specialty_name = @specialty_name
    WHERE specialty_id = @specialty_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_specialty
    @specialty_id INT
AS
BEGIN
    DELETE FROM specialties WHERE specialty_id = @specialty_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 2. PATIENTS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_patient
    @name VARCHAR(100),
    @dob DATE,
    @contact VARCHAR(15),
    @email VARCHAR(100),
    @address VARCHAR(MAX),
    @blood_group VARCHAR(5)
AS
BEGIN
    INSERT INTO patients (name, dob, contact, email, address, blood_group)
    VALUES (@name, @dob, @contact, @email, @address, @blood_group);
    SELECT SCOPE_IDENTITY() AS new_patient_id;
END;
GO

CREATE PROCEDURE sp_update_patient
    @patient_id INT,
    @name VARCHAR(100),
    @dob DATE,
    @contact VARCHAR(15),
    @email VARCHAR(100),
    @address VARCHAR(MAX),
    @blood_group VARCHAR(5)
AS
BEGIN
    UPDATE patients
    SET name = @name, dob = @dob, contact = @contact,
        email = @email, address = @address, blood_group = @blood_group
    WHERE patient_id = @patient_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_patient
    @patient_id INT
AS
BEGIN
    DELETE FROM patients WHERE patient_id = @patient_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 3. DOCTORS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_doctor
    @name VARCHAR(100),
    @specialty_id INT,
    @contact VARCHAR(15),
    @consultation_fee DECIMAL(10,2)
AS
BEGIN
    INSERT INTO doctors (name, specialty_id, contact, consultation_fee, is_active)
    VALUES (@name, @specialty_id, @contact, @consultation_fee, 1);
    SELECT SCOPE_IDENTITY() AS new_doctor_id;
END;
GO

CREATE PROCEDURE sp_update_doctor
    @doctor_id INT,
    @name VARCHAR(100),
    @specialty_id INT,
    @contact VARCHAR(15),
    @consultation_fee DECIMAL(10,2),
    @is_active BIT
AS
BEGIN
    UPDATE doctors
    SET name = @name, specialty_id = @specialty_id, contact = @contact,
        consultation_fee = @consultation_fee, is_active = @is_active
    WHERE doctor_id = @doctor_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_doctor
    @doctor_id INT
AS
BEGIN
    DELETE FROM doctors WHERE doctor_id = @doctor_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 4. APPOINTMENTS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_appointment
    @patient_id INT,
    @doctor_id INT,
    @appointment_time TIME
AS
BEGIN
    INSERT INTO appointments (patient_id, doctor_id, appointment_date, appointment_time, status)
    VALUES (@patient_id, @doctor_id, GETDATE(), @appointment_time, 'SCHEDULED');
    SELECT SCOPE_IDENTITY() AS new_appointment_id;
END;
GO

CREATE PROCEDURE sp_update_appointment
    @appointment_id INT,
    @patient_id INT,
    @doctor_id INT,
    @appointment_date DATETIME,
    @appointment_time TIME,
    @status VARCHAR(20)
AS
BEGIN
    UPDATE appointments
    SET patient_id = @patient_id, doctor_id = @doctor_id,
        appointment_date = @appointment_date, appointment_time = @appointment_time, status = @status
    WHERE appointment_id = @appointment_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_appointment
    @appointment_id INT
AS
BEGIN
    DELETE FROM appointments WHERE appointment_id = @appointment_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 5. VISITS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_visit
    @appointment_id INT,
    @patient_id INT,
    @doctor_id INT,
    @diagnosis VARCHAR(MAX),
    @notes VARCHAR(MAX)
AS
BEGIN
    INSERT INTO visits (appointment_id, patient_id, doctor_id, visit_date, diagnosis, notes)
    VALUES (@appointment_id, @patient_id, @doctor_id, GETDATE(), @diagnosis, @notes);
    
    UPDATE appointments SET status = 'COMPLETED' WHERE appointment_id = @appointment_id;
    
    SELECT SCOPE_IDENTITY() AS new_visit_id;
END;
GO

CREATE PROCEDURE sp_update_visit
    @visit_id INT,
    @diagnosis VARCHAR(MAX),
    @notes VARCHAR(MAX)
AS
BEGIN
    UPDATE visits
    SET diagnosis = @diagnosis, notes = @notes
    WHERE visit_id = @visit_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_visit
    @visit_id INT
AS
BEGIN
    DELETE FROM visits WHERE visit_id = @visit_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 6. PRESCRIPTIONS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_prescription
    @visit_id INT,
    @medicine_name VARCHAR(200),
    @dosage VARCHAR(100),
    @duration VARCHAR(50)
AS
BEGIN
    INSERT INTO prescription (visit_id, medicine_name, dosage, duration)
    VALUES (@visit_id, @medicine_name, @dosage, @duration);
    SELECT SCOPE_IDENTITY() AS new_prescription_id;
END;
GO

CREATE PROCEDURE sp_update_prescription
    @prescription_id INT,
    @medicine_name VARCHAR(200),
    @dosage VARCHAR(100),
    @duration VARCHAR(50)
AS
BEGIN
    UPDATE prescription
    SET medicine_name = @medicine_name, dosage = @dosage, duration = @duration
    WHERE prescription_id = @prescription_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_prescription
    @prescription_id INT
AS
BEGIN
    DELETE FROM prescription WHERE prescription_id = @prescription_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 7. BILLS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_bill
    @visit_id INT,
    @patient_id INT,
    @doctor_id INT,
    @total_amount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO bills (visit_id, patient_id, doctor_id, total_amount, payment_status, payment_date)
    VALUES (@visit_id, @patient_id, @doctor_id, @total_amount, 'UNPAID', GETDATE());
    SELECT SCOPE_IDENTITY() AS new_bill_id;
END;
GO

CREATE PROCEDURE sp_update_bill
    @bill_id INT,
    @total_amount DECIMAL(10,2),
    @payment_status VARCHAR(20),
    @payment_mode VARCHAR(50)
AS
BEGIN
    UPDATE bills
    SET total_amount = @total_amount, payment_status = @payment_status,
        payment_mode = @payment_mode, payment_date = GETDATE()
    WHERE bill_id = @bill_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_bill
    @bill_id INT
AS
BEGIN
    DELETE FROM bills WHERE bill_id = @bill_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 8. PAYMENT_TRANSACTIONS PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_payment_transaction
    @bill_id INT,
    @amount_paid DECIMAL(10,2),
    @payment_mode VARCHAR(50)
AS
BEGIN
    INSERT INTO payment_transactions (bill_id, amount_paid, payment_date, payment_mode)
    VALUES (@bill_id, @amount_paid, GETDATE(), @payment_mode);
    
    UPDATE bills
    SET payment_status = 'PAID', payment_mode = @payment_mode, payment_date = GETDATE()
    WHERE bill_id = @bill_id;
    
    SELECT SCOPE_IDENTITY() AS new_transaction_id;
END;
GO

CREATE PROCEDURE sp_update_payment_transaction
    @transaction_id INT,
    @amount_paid DECIMAL(10,2),
    @payment_mode VARCHAR(50)
AS
BEGIN
    UPDATE payment_transactions
    SET amount_paid = @amount_paid, payment_mode = @payment_mode
    WHERE transaction_id = @transaction_id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_payment_transaction
    @transaction_id INT
AS
BEGIN
    DELETE FROM payment_transactions WHERE transaction_id = @transaction_id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

-- =============================================
-- 9. SEARCH_MASTER PROCEDURES (3)
-- =============================================

CREATE PROCEDURE sp_insert_search_master
    @patient_id INT,
    @doctor_id INT,
    @bill_id INT
AS
BEGIN
    INSERT INTO search_master (patient_id, doctor_id, bill_id)
    VALUES (@patient_id, @doctor_id, @bill_id);
    SELECT SCOPE_IDENTITY() AS new_search_id;
END;
GO

CREATE PROCEDURE sp_update_search_master
    @id INT,
    @patient_id INT,
    @doctor_id INT,
    @bill_id INT
AS
BEGIN
    UPDATE search_master
    SET patient_id = @patient_id, doctor_id = @doctor_id, bill_id = @bill_id
    WHERE id = @id;
    SELECT @@ROWCOUNT AS rows_updated;
END;
GO

CREATE PROCEDURE sp_delete_search_master
    @id INT
AS
BEGIN
    DELETE FROM search_master WHERE id = @id;
    SELECT @@ROWCOUNT AS rows_deleted;
END;
GO

SELECT name AS procedure_name
FROM sys.procedures
ORDER BY name;
GO

-- Insert Specialties
EXEC sp_insert_specialty 'Cardiology';
EXEC sp_insert_specialty 'Neurology';
EXEC sp_insert_specialty 'Orthopedics';
EXEC sp_insert_specialty 'Pediatrics';
EXEC sp_insert_specialty 'Dermatology';

-- Insert Patients
EXEC sp_insert_patient 'Rahul Kumar', '1990-05-15', '9876543210', 'rahul@email.com', 'Delhi', 'O+';
EXEC sp_insert_patient 'Priya Sharma', '1985-08-20', '9876543211', 'priya@email.com', 'Mumbai', 'A+';
EXEC sp_insert_patient 'Amit Singh', '1992-12-10', '9876543212', 'amit@email.com', 'Bangalore', 'B+';

-- Insert Doctors
EXEC sp_insert_doctor 'Dr. Anil Gupta', 1, '9988776655', 500.00;
EXEC sp_insert_doctor 'Dr. Sunita Verma', 2, '9988776656', 600.00;
EXEC sp_insert_doctor 'Dr. Rajesh Kumar', 3, '9988776657', 550.00;

-- Insert Appointments
EXEC sp_insert_appointment 1, 1, '10:00:00';
EXEC sp_insert_appointment 2, 1, '10:30:00';
EXEC sp_insert_appointment 3, 2, '11:00:00';

-- Insert Visits
EXEC sp_insert_visit 1, 1, 1, 'Hypertension', 'Regular checkup needed';
EXEC sp_insert_visit 2, 2, 1, 'Heart palpitations', 'ECG recommended';
EXEC sp_insert_visit 3, 3, 2, 'Migraine', 'Avoid stress';

-- Insert Prescriptions
EXEC sp_insert_prescription 1, 'Amlodipine', '5mg once daily', '30 days';
EXEC sp_insert_prescription 1, 'Aspirin', '75mg once daily', '30 days';
EXEC sp_insert_prescription 2, 'Metoprolol', '25mg twice daily', '15 days';
EXEC sp_insert_prescription 3, 'Sumatriptan', '50mg as needed', '10 days';

-- Insert Bills
EXEC sp_insert_bill 1, 1, 1, 500.00;
EXEC sp_insert_bill 2, 2, 1, 500.00;
EXEC sp_insert_bill 3, 3, 2, 600.00;

-- Insert Payment Transactions
EXEC sp_insert_payment_transaction 2, 500.00, 'CASH';
EXEC sp_insert_payment_transaction 3, 600.00, 'UPI';

-- Insert Search Master
EXEC sp_insert_search_master 1, 1, 1;
EXEC sp_insert_search_master 2, 1, 2;
EXEC sp_insert_search_master 3, 2, 3;

-- Check Audit Log
SELECT * FROM audit_log;
GO
