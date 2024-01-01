create database PersonasDB; 

create table if not exists public."Persona"
(
    "Id" uuid not null,
    "Rut" varchar(8) not null, 
    "Nombre" varchar(200) not null, 
    "ApellidoPaterno" varchar(100) , 
    "ApellidoMaterno" varchar(100)  not null, 
    "FechaNacimiento" timestamp  not null, 
    "Genero" varchar(10) not null, 
    constraint persona_pk primary key ("Id")
); 

create table if not exists public."Direccion"
(
    "Id" uuid not null,
    "IdPersona" uuid not null, 
    "Calle" varchar(200), 
    "Numero" varchar(10) , 
    "NumeroCasaDepartamento" varchar(10), 
    "Comuna" timestamp  not null, 
    constraint Direccion_pk primary key ("Id")
); 

create table if not exists public."Contacto"
(
    "Id" uuid not null,
    "IdPersona" uuid not null, 
    "Celular" varchar(13), 
    "Email" varchar(200) , 
    "TipoContacto" varchar(20), 
    constraint Contacto_pk primary key ("Id")
); 

create table public."History" (
	"Id" uuid NULL,
	"AggregateId" uuid NULL,
	"Data" text NOT NULL,
	"Action" varchar(100) NULL,
	"Date" timestamp NULL,
	"User" text NOT NULL,
	CONSTRAINT History_pk PRIMARY KEY ("Id")
);
