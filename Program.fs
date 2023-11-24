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

//Calculate the Budget
let calculateBudget activity =
   match activity with 
   |BoardGame | Chill -> 0.0
   |Movie Regular -> 12.0
   |Movie IMAX -> 17.0
   |Movie Dbox -> 20.0
   |Movie -> 12.0 + 5.0 // Other movie types with snacks
   |Restaurant Korean -> 70.0
   |Restaurant Turkish -> 65.0
   |LongDrive(kilometres, fuelcharge)-> float kilometres * fuelcharge

let eveningActivity = Restaurant Turkish
let budget = calculateBudget eveningActivity
printfn "Estimated Budget: %.2f CAD" budget