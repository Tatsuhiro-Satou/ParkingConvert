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
    sign_type VARCHAR(50) NOT NULL,
    longitude DECIMAL(18, 15) NOT NULL,
    lattitude DECIMAL(18, 15) NOT NULL,
    CONSTRAINT pk_parkingspace
    PRIMARY KEY(id)
);
```
