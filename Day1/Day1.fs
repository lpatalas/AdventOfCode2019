module AdventOfCode.Day1

let getRequiredFuel mass =
    (mass / 3) - 2

let getTotalRequiredFuel masses =
    masses
    |> Seq.sumBy getRequiredFuel

let getInputMasses fileName =
    readInputFile "Day1"
    |> Seq.map parseInt

let run() =
    getInputMasses "Day1"
    |> getTotalRequiredFuel
    |> printfn "Day1: Total required fuel = %i"

