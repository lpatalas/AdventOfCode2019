module AdventOfCode.Day1

let getRequiredFuel mass =
    (mass / 3) - 2

let rec getTotalRequiredFuel mass =
    let requiredFuel = getRequiredFuel mass
    if requiredFuel <= 0 then
        0
    else
        requiredFuel + getTotalRequiredFuel requiredFuel

let getInputMasses fileName =
    readInputFile "Day1"
    |> Seq.map parseInt

let calculateFuel calculator =
    getInputMasses "Day1"
    |> Seq.sumBy calculator

let run() =
    let fuelBasedOnMass = calculateFuel getRequiredFuel
    let fuelBasedOnMassAndFuel = calculateFuel getTotalRequiredFuel
    printfn "Day1: Fuel based on mass = %i; including fuel = %i" fuelBasedOnMass fuelBasedOnMassAndFuel

