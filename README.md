
# TP .Net Week1

This project is an example of using *Restful API* principles.
In the project the main theme is Formula 1 (a.k.a F1 or Formula One) Motor Racing elements.

### What I have used so far:
- Asp.Net Core Web API with .Net5.0 framework.
- There is no Database used in this project.
- To be able to use Restful API's, dummy datas generated in Data Folder.


## Requirements
- This project must have Restful standarts.
- GET,POST,PUT,DELETE,PATCH methods must be used.
- Must be following Http staus code standarts.
- 200,201,400,404,500 Status codes must be showed.
- Required fields must be checked.
- Routing must be used.
- Model binding must be used both FromQuery and FromBody.
- Listing and Filtering can be used as Bonus.

## Installation and Usage

To get the project :
```
	git clone https://github.com/mhtaldmr/mhtaldmr.git
```
To reach the project folder :
```
	cd MuhammetAliDemir.TP.Week1.Homework
```
To run the project:
- If you are using the Visual Studio, just press **F5** or press **Start Debugging**.

- If you are using terminal : 
```
	dotnet run
```


## API Endpoints

* All the http mehtods and return types in requirements are represented in the project.

*  Examples of endpoints like:
<img height=100 src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/javascript/javascript.png" alt="endpoint" />

- Get a driver by Id example:
```c
        //.../Drivers/id
        [HttpGet("{id}")]
        public IActionResult GetDriverById([FromBody] int id)
        {
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (driver is null)
                return NotFound( $"There is no drivers in the list with id = {id}!");

            return Ok(driver); //http 200
        } 
```
- Filtering and sorting a team example:
```c
        //.../Teams/list?powerunit=
        [HttpGet("list")]
        public IActionResult GetTeamByPowerUnit([FromQuery] string powerUnit)
        {
            var teams = Teams.Where(r => r.PowerUnit == powerUnit)
                             .OrderByDescending(r => r.Championship)
                             .ToList();

            if (powerUnit is null)
                return NotFound("You didnt enter any input into the form!");

            //If there is NOT a team in the list, we will get : http 404 Not Found Error
            if (teams.Count == 0 )
                return NotFound($"There is no team in the list with input = {powerUnit}!");

            return Ok(teams); //http 200
        }
```

* In terms of 500 Internal Server Code, it defined by a StatusCode method.
```c
    public IActionResult InternalServiceError()
    {
        return StatusCode(500,"500 Internal Server Error Occured!"); //Http 500
    }
```


## Data Model

I have used 3 entity in this project to define Driver, Race and Team.
- All entities must have **required** fields such as Id and Name:
```c
    public class <EntityName>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
```
- Since these fields are common, these fields can be seperated by an BaseEntity and Inherited others.

- Drivers can have;
	* Team, Nationality, RaceEntered, Podiums, Championship

- Races can have;
	* Location, Length, NumberOfLaps, LapRecord, FirstRaceAt

- Teams can have;
	* PowerUnit, Country, TeamChief, Drivers, Championship

----