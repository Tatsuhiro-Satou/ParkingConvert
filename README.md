# ParkingConvert

Dit zijn de queries voor de database.
1. Maak de DB aan
2. Maak de tables aan
3. Voeg de FK toe
``` 
-- ## Database maken ## --
IF DB_ID('parkingapp') IS NULL
     CREATE DATABASE parkingapp

-- ## Tables maken ## --
USE parkingapp
CREATE TABLE parkingspace
(
    id SMALLINT NOT NULL,
    bord_type_waarde VARCHAR(50) NOT NULL,
    sign_type VARCHAR(50) NOT NULL,
    longitude DECIMAL(18, 15) NOT NULL,
    lattitude DECIMAL(18, 15) NOT NULL,
    CONSTRAINT pk_parkingspace
    PRIMARY KEY(id)
);

USE parkingapp
CREATE TABLE roadworks
(
    id_roadworks SMALLINT NOT NULL, -- Might not suffice for later.. objectid might be replaced
    description VARCHAR(320) NOT NULL, -- TITEL
    status VARCHAR(50) NOT NULL,
    CONSTRAINT pk_roadworks
    PRIMARY KEY(id_roadworks)
);

USE parkingapp
CREATE TABLE roadworks_location
(
    id_roadworks_location SMALLINT IDENTITY(1,1) PRIMARY KEY,
    roadworks SMALLINT NOT NULL,
    longitude DECIMAL(18, 15) NOT NULL, -- 4.308
    lattitude DECIMAL(18, 15) NOT NULL, -- 52.098
);

-- ## Foreign keys ## --
USE parkingapp
ALTER TABLE roadworks_location
    ADD CONSTRAINT FK_roadworks_location_roadworks
    FOREIGN KEY(roadworks)
    REFERENCES roadworks(id_roadworks)
    ON DELETE CASCADE  
    ON UPDATE CASCADE    
```
