# ParkingConvert

Dit zijn de queries voor de database.
1. Maak de DB aan
2. Maak de tables aan
3. Voeg de FK toe
``` 
IF DB_ID('parkingapp') IS NULL
     CREATE DATABASE parkingapp


USE parkingapp
CREATE TABLE parkingspace
(
    id SMALLINT NOT NULL,
    --bord_type_waarde VARCHAR(50) NOT NULL,
    sign_type VARCHAR(50) NOT NULL,
    longitude DECIMAL(18, 15) NOT NULL,
    lattitude DECIMAL(18, 15) NOT NULL,
    CONSTRAINT pk_parkingspace
    PRIMARY KEY(id)
);

USE parkingapp
CREATE TABLE roadworks
(
    id_roadworks SMALLINT NOT NULL, 
    description VARCHAR(320) NOT NULL,
    status VARCHAR(50) NOT NULL,
    CONSTRAINT pk_roadworks
    PRIMARY KEY(id_roadworks)
);

USE parkingapp
CREATE TABLE roadworks_location
(
    roadworks SMALLINT NOT NULL,
    longitude DECIMAL(18, 15) NOT NULL, 
    lattitude DECIMAL(18, 15) NOT NULL,
	CONSTRAINT pk_roadworks_location
    PRIMARY KEY(roadworks, longitude, lattitude)
);

-- ## Foreign keys ## --
-- ON DELETE CASCADE: Als de PK verwijderd wordt, worden ook de locations verwijderd.
-- ON UPDATE CASCADE: Als de PK gewijzigt wordt in roadworks, word hij hier ook gewijzigd	
USE parkingapp
ALTER TABLE roadworks_location
    ADD CONSTRAINT FK_roadworks_location_roadworks
    FOREIGN KEY(roadworks)
    REFERENCES roadworks(id_roadworks)
    ON DELETE CASCADE  
    ON UPDATE CASCADE    


```
