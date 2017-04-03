TRUNCATE TABLE unittest.appointment;
TRUNCATE TABLE unittest.procedurelog;
TRUNCATE TABLE unittest.patient;
TRUNCATE TABLE unittest.treatplan;
TRUNCATE TABLE unittest.treatplanattach;

// Honey Booboo
// "100%"
INSERT INTO 'unittest'.'patient' (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ('Booboo', 'Honey', '', '22', '1', '2010-01-01', '103022', '1');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum, PlannedAptNum) VALUES ('2017-03-20', 1, 22, 30, '30', 2);
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum, PlannedAptNum) VALUES ('2017-03-23', 1, 22, 31, '31', 2);
INSERT INTO 'unittest'.'treatplan' (PatNum, TreatPlanNum) VALUES (22, 24);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (30,24, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (31,24, 0);
INSERT INTO 'unittest'.'appointment' (AptNum, PatNum, AptStatus, NextAptNum) VALUES (20,22, 6, 0);


// Nono Badbadnotgood
// "No Procedures"
INSERT INTO 'unittest'.'patient' (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ('Badbadnotgood', 'Nono', '', '23', '1', '2010-01-01', '103022', '1');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum, PlannedAptNum) VALUES ('2017-03-20', 1, 23, 32, '30', 2);
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum, PlannedAptNum) VALUES ('2017-03-23', 1, 23, 33, '31', 2);
INSERT INTO 'unittest'.'treatplan' (PatNum, TreatPlanNum) VALUES (23, 25);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (32,25, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (33,25, 0);
