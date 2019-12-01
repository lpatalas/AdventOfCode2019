module AdventOfCode.Day1

let getRequiredFuel mass =
    (mass / 3) - 2

let getTotalRequiredFuel mass =
    let rec iter total mass =
        let requiredFuel = getRequiredFuel mass
        if requiredFuel <= 0 then
            total
        else
            iter (total + requiredFuel) requiredFuel

    iter 0 mass

let getInputMasses fileName =
    readInputFile fileName
    |> Seq.map parseInt

let calculateFuel calculator =
    getInputMasses "Day1"
    |> Seq.sumBy calculator

let run() =
    let fuelBasedOnMass = calculateFuel getRequiredFuel
    let fuelBasedOnMassAndFuel = calculateFuel getTotalRequiredFuel
    printfn "Day1: Fuel based on mass = %i; including fuel = %i" fuelBasedOnMass fuelBasedOnMassAndFuel

