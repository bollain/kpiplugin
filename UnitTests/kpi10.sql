// Truncate Tables

TRUNCATE TABLE unittest.patient;
TRUNCATE TABLE unittest.procedurelog;
TRUNCATE TABLE unittest.treatplan;
TRUNCATE TABLE unittest.treatplanattach;

// Kevin Bieksa

INSERT INTO 'unittest'.'patient' (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ('Bieksa', 'Kevin', 'F', 1, 1, '2010-01-01', '1');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-20', 1, 1, 1, 'T3541');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-23', 1, 1, 2, 'T1254');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-24', 1, 1, 3, 'T6531');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-21', 1, 1, 4,'T2345');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-10', 1, 1, 5, 'T7966');
INSERT INTO 'unittest'.'treatplan' (PatNum, TreatPlanNum) VALUES (1, 1);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (1,1, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (2,1, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (3,1, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (4,1, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (5,1, 0);


// Henrik Sedin

INSERT INTO 'unittest'.'patient' (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ('Sedin', 'Henrik', '', 2, 1, '2010-01-01', '1');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-23', 1, 2, 6, 'T3541');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-24', 1, 2, 7, 'T1254');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-19', 1, 2, 8, 'T6531');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-13', 1, 2, 9,'T2345');
INSERT INTO 'unittest'.'procedurelog' (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-13', 1, 2, 10, 'T7966');
INSERT INTO 'unittest'.'treatplan' (PatNum, TreatPlanNum) VALUES (2, 2);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (6,2, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (7,2, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (8,2, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (9,2, 0);
INSERT INTO 'unittest'.'treatplanattach' (ProcNum, TreatPlanNum, Priority) VALUES (10,2, 0);
