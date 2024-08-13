
-- TABLES
CREATE TABLE Sensors (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(255),
    Unit VARCHAR(10) NOT NULL
);


CREATE TABLE Readings (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SensorId UNIQUEIDENTIFIER NOT NULL,
    ReadingDate DATE NOT NULL,
    Value FLOAT NOT NULL,
    FOREIGN KEY (SensorId) REFERENCES Sensors(Id)
);


-- INSERTS
INSERT INTO Sensors (Name, Description, Unit)
VALUES ('Sensor Comedor', 'Sensor de temperatura para el comedor', 'CELSIUS');


INSERT INTO Readings (SensorId, ReadingDate, Value)
VALUES ('BC7B047A-EEA7-47D6-9DC1-6C371FCCC102', GETDATE(), 23.5);
