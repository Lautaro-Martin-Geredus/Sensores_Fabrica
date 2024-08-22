-- TABLES
CREATE TABLE Sensors (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(255),
    Unit VARCHAR(10) CHECK (Unit IN ('CELSIUS', 'FAHRENHEIT')) NOT NULL
);

CREATE TABLE Readings (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SensorId UNIQUEIDENTIFIER NOT NULL,
    ReadingDate DATE NOT NULL,
    Value FLOAT NOT NULL,
    FOREIGN KEY (SensorId) REFERENCES Sensors(Id)
);

CREATE TABLE [User] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Description VARCHAR(255)
);


-- INSERTS

INSERT INTO [User] (Name, Email, Password, Description)
VALUES ('Lautaro Geredus', 'lautarogere@gmail.com', 'myPassword', 'Administrador del sistema');


INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_A1', 'Sensor de temperatura para la sala de control', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_B2', 'Sensor de temperatura para el área de ensamblaje', 'FAHRENHEIT');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_C3', 'Sensor de temperatura en el comedor de empleados', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_D4', 'Sensor de temperatura en el almacén', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_E5', 'Sensor de temperatura en la zona de carga y descarga', 'FAHRENHEIT');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_F6', 'Sensor de temperatura en la oficina principal', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_G7', 'Sensor de temperatura en la sala de servidores', 'FAHRENHEIT');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_H8', 'Sensor de temperatura en el laboratorio de pruebas', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_I9', 'Sensor de temperatura en el taller de mantenimiento', 'CELSIUS');
INSERT INTO Sensors (id, name, description, unit) VALUES (NEWID(), 'TempSensor_J10', 'Sensor de temperatura en la sala de reuniones', 'FAHRENHEIT');

