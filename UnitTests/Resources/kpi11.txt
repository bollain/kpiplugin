/*Truncate Tables*/

TRUNCATE TABLE unittest.patient;
TRUNCATE TABLE unittest.procedurelog;
TRUNCATE TABLE unittest.treatplan;
TRUNCATE TABLE unittest.treatplanattach;

/*Jannik Hansen*/

INSERT INTO unittest.patient (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ("Hansen", "Jannik", null , 20, 1, 2010-01-01, 103022, 1);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-20', 1, 20, 21, 404);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-23', 1, 20, 22, 404);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-10', 1, 20, 23, 404);
INSERT INTO unittest.treatplan (PatNum, TreatPlanNum) VALUES (20, 21);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (21,21, 0);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (22,21, 0);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (23,21, 0);

/* Henrik Sedin*/

INSERT INTO unittest.patient (LName, FName, MiddleI, PatNum, Gender, Birthdate, Zip, PriProv) VALUES ("Sedin", "Henrik", null, 21, 1, 2010-01-01, 103022, 1);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-23', 1, 21, 24, 404);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-24', 1, 21, 25, 404);
INSERT INTO unittest.procedurelog (ProcDate, ProcStatus, PatNum, ProcNum , CodeNum) VALUES ('2017-03-19', 1, 21, 26, 404);

INSERT INTO unittest.treatplan (PatNum, TreatPlanNum) VALUES (21, 22);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (24,22, 0);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (25,22, 0);
INSERT INTO unittest.treatplanattach (ProcNum, TreatPlanNum, Priority) VALUES (26,22, 0);
