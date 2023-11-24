type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

//Create a list of 5 teams 
let teams : Team list = [
    { Name = "Houston Rockets"; Coach = { Name = "Ime Udoka"; FormerPlayer = true }; Stats = { Wins = 2328; Losses = 2196 } }
    { Name = "Milwaukee Bucks"; Coach = { Name = "Adrian Griffin"; FormerPlayer = false }; Stats = { Wins = 2340; Losses = 2103 } }
    { Name = "Los Angeles Lakers"; Coach = { Name = "Frank Vogel"; FormerPlayer = false }; Stats = { Wins = 2400; Losses = 2200 } }
    { Name = "Miami Heat"; Coach = { Name = "Erik Spoelstra"; FormerPlayer = true }; Stats = { Wins = 2400; Losses = 2000 } }
    { Name = "LA Clippers"; Coach = { Name = "Taylor Lue"; FormerPlayer = true }; Stats = { Wins = 1792; Losses = 2486 } }
]

//filtering the list
let goodTeamNames =
    teams
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)
    |> List.map (fun team -> team.Name)

printfn "Good Teams: %A" goodTeamNames

//Mapping the list
let calculateWinningPercentage team =
    float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0

let bestTeam =
    teams |> List.maxBy calculateWinningPercentage

printfn "Best Team by Winning Percentage: %s" bestTeam.Name
printfn "Winning Percentage: %.2f%%" (calculateWinningPercentage bestTeam)

//Discriminated Union
type Cuisine = 
| Korean
| Turkish

type MovieType =
| Regular
| IMAX
| DBOX
| RegularWithSnacks
| IMAXWithSnacks
| DBOXWithSnacks

type Activity =
| BoardGame
| Chill
| Movie of MovieType
| Restaurant of Cuisine
| LongDrive of int * float

// Calculate the Budget
let calculateBudget activity =
   match activity with 
   | BoardGame | Chill -> 0.0
   | Movie Regular -> 12.0
   | Movie IMAX -> 17.0
   | Movie DBOX -> 20.0
   | Movie RegularWithSnacks | Movie IMAXWithSnacks | Movie DBOXWithSnacks -> 12.0 + 5.0 // Other movie types with snacks
   | Restaurant Korean -> 70.0
   | Restaurant Turkish -> 65.0
   | LongDrive (kilometres, fuelcharge) -> float kilometres * fuelcharge

let eveningActivity = Restaurant Turkish
let budget = calculateBudget eveningActivity
printfn "Estimated Budget: %.2f CAD" budget