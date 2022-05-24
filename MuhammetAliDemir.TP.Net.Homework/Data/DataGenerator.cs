using MuhammetAliDemir.TP.Net.Homework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuhammetAliDemir.TP.Net.Homework.Data
{
    public class DataGenerator
    {
        public static List<Driver> Drivers = new()
        {
            new Driver { Id=1, Name="Charles Leclerc", Team="Ferrari", Nationality="MON", RaceEntered=86, Podiums=17 , Championship=0 , PointsAtThisYear = 100}, 
            new Driver { Id=2, Name="Carlos Sainz",   Team="Ferrari", Nationality="ESP", RaceEntered=146, Podiums=9 , Championship=0  , PointsAtThisYear = 75}, 
            new Driver { Id=3, Name="Max Verstappen", Team="Redbull", Nationality="NED", RaceEntered=146, Podiums=63 , Championship=1  , PointsAtThisYear = 95}, 
            new Driver { Id=4, Name="Lewis Hamilton", Team="Mercedes", Nationality="GBR", RaceEntered=293, Podiums=183 , Championship=7  , PointsAtThisYear = 55}, 
            new Driver { Id=5, Name="Lando Norris", Team="Mclaren", Nationality="GBR", RaceEntered=65, Podiums=6 , Championship=0  , PointsAtThisYear = 12}, 
            new Driver { Id=6, Name="Daniel Ricardo", Team="Mclaren", Nationality="AUS", RaceEntered=215, Podiums=32 , Championship=0  , PointsAtThisYear = 58}, 
            new Driver { Id=7, Name="Valteri Bottas", Team="Alfa Romeo", Nationality="FIN", RaceEntered=183, Podiums=67 , Championship=0  , PointsAtThisYear = 95}, 
            new Driver { Id=8, Name="Fernando Alonso", Team="Renault", Nationality="ESP", RaceEntered=341, Podiums=98 , Championship=2  , PointsAtThisYear = 10}, 
            new Driver { Id=9, Name="Mick Schumacher", Team="Haas" ,Nationality="GER", RaceEntered=26, Podiums=0 , Championship=0  , PointsAtThisYear = 77}, 
            new Driver { Id=10, Name="Sebastian Vettel", Team="Aston Martin", Nationality="GER", RaceEntered=283, Podiums=122 , Championship=4, PointsAtThisYear= 99 }
        };

        public static List<Team> Teams = new()
        {
            new Team { Id=1, Name="Ferrari", PowerUnit="Ferrari",   Country="Italy",    TeamChief="Mattia Binotto", Championship=16,      Drivers= Drivers.Where(d => d.Team == "Ferrari").ToList()},
            new Team { Id=2,Name="Mercedes",  PowerUnit="Mercedes",   Country="Germany",  TeamChief="Toto Wolf",      Championship=8,     Drivers=  Drivers.Where(d => d.Team == "Mercedes").ToList() },
            new Team { Id=3,Name="Redbull",   PowerUnit="Honda",      Country="Austria",  TeamChief="Christian Horner",Championship=4,    Drivers=  Drivers.Where(d => d.Team == "Redbull").ToList() },
            new Team { Id=4,Name="Mclaren",   PowerUnit="Mercedes",   Country="England",  TeamChief="Andres Seidl",   Championship=8,     Drivers=  Drivers.Where(d => d.Team == "Mclaren").ToList() },
            new Team { Id=5,Name="AstonMartin",PowerUnit="Mercedes",  Country="England",  TeamChief="Mike Krack",     Championship=0,     Drivers=  Drivers.Where(d => d.Team == "Aston Martin").ToList() },
            new Team { Id=6,Name="Renault",   PowerUnit="Renault",    Country="France",   TeamChief="Otmar Saafnauer",Championship=2,     Drivers=  Drivers.Where(d => d.Team == "Renault").ToList() },
            new Team { Id=7,Name="AlfaRomeo", PowerUnit="Ferrari",    Country="Switzerland",TeamChief="Frederic Vasseur",Championship=0,  Drivers=  Drivers.Where(d => d.Team == "Alfa Romeo").ToList() },
            new Team { Id=8,Name="Haas",      PowerUnit="Ferrari",    Country="USA",      TeamChief="Guenther Steiner",Championship=0,    Drivers=  Drivers.Where(d => d.Team == "Haas").ToList() },
            new Team { Id=9,Name="Williams",  PowerUnit="Mercedes",   Country="England",  TeamChief="Jost Capito",    Championship=9,     Drivers=  Drivers.Where(d => d.Team == "Williams").ToList() },
            new Team { Id=10,Name="Alfa Tauri",PowerUnit="Honda",     Country="Italy",    TeamChief="Franz Tost",     Championship=0,     Drivers=  Drivers.Where(d => d.Team == "Alfa Tauri").ToList() }
        };

        public static List<Race> Races = new()
        {
            new Race { Id=1,Name="TurkishGp",  Location="Turkey",  Length=5.338, NumberOfLaps=58, LapRecord=1.22998, FirstRaceAt=DateTime.Parse("01-01-2005") },
            new Race { Id=2,Name="MonacoGP",   Location="Monaco",  Length=3.337, NumberOfLaps=78, LapRecord=1.12909, FirstRaceAt=DateTime.Parse("01-01-1950") },
            new Race { Id=3,Name="SilverstoneGp",Location="England",Length=5.891,NumberOfLaps=52, LapRecord=1.27097, FirstRaceAt=DateTime.Parse("01-01-1950") },
            new Race { Id=4,Name="SpaGp",      Location="Belgium", Length=7004,  NumberOfLaps=44, LapRecord=1.46286, FirstRaceAt=DateTime.Parse("01-01-1950") },
            new Race { Id=5,Name="MonzaGp",    Location="Italy",   Length=5.793, NumberOfLaps=53, LapRecord=1.21046, FirstRaceAt=DateTime.Parse("01-01-1950") },
            new Race { Id=6,Name="CatalunyaGp",Location="Spain",   Length=4.675, NumberOfLaps=66, LapRecord=1.18149, FirstRaceAt=DateTime.Parse("01-01-1991") },
            new Race { Id=7,Name="CanadaGp",   Location="Canada",  Length=4.361, NumberOfLaps=70, LapRecord=1.13078, FirstRaceAt=DateTime.Parse("01-01-1978") },
            new Race { Id=8,Name="SaoPauloGp", Location="Brazil",  Length=4.309, NumberOfLaps=71, LapRecord=1.10540, FirstRaceAt=DateTime.Parse("01-01-1973") },
            new Race { Id=9,Name="AustinGp",   Location="USA",     Length=5.513, NumberOfLaps=56, LapRecord=1.36169, FirstRaceAt=DateTime.Parse("01-01-2012") },
            new Race { Id=10,Name="MexicoGp",  Location="Mexico",  Length=4.304, NumberOfLaps=71, LapRecord=1.17774, FirstRaceAt=DateTime.Parse("01-01-1963") }
        };


    }
}
