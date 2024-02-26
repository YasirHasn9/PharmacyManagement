CREATE TABLE Drugs
(
    DrugId      UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name        NVARCHAR(100),
    Description NVARCHAR(255)
);

-- insert drugs
INSERT INTO Drugs (Name, Description)
VALUES
    ('Amoxicillin', 'Used to treat a wide variety of bacterial infections.'),
    ('Ibuprofen', 'Used to relieve pain from various conditions such as headache, dental pain, menstrual cramps, muscle aches, or arthritis.'),
    ('Lisinopril', 'Used to treat high blood pressure and heart failure.'),
    ('Metformin', 'Used to improve blood sugar control in people with type 2 diabetes.'),
    ('Amlodipine', 'Used to treat high blood pressure and chest pain.'),
    ('Simvastatin', 'Used to lower cholesterol and triglycerides in the blood.'),
    ('Omeprazole', 'Used to treat certain stomach and esophagus problems such as acid reflux.'),
    ('Losartan', 'Used to treat high blood pressure and to help protect the kidneys from damage due to diabetes.'),
    ('Aspirin', 'Used to reduce fever and relieve mild to moderate pain from conditions such as muscle aches, toothaches, common cold, and headaches.'),
    ('Cetirizine', 'An antihistamine used to relieve allergy symptoms such as watery eyes, runny nose, itching eyes/nose, sneezing, hives, and itching.');
