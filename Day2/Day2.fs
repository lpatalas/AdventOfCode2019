module AdventOfCode.Day2

let loadInput() =
    readInputFile "Day2"
    |> String.concat ""
    |> splitString ','
    |> Seq.map parseInt
    |> Seq.toArray

let sliceTriple index array =
    (Array.get array index, Array.get array (index + 1), Array.get array (index + 2))

type Instruction =
    | Add of (int * int * int)
    | Multiply of (int * int * int)
    | Halt

let runProgram program =
    let parseInstruction index =
        let opcode = Array.get program index
        match opcode with
        | 1 -> Add (sliceTriple (index + 1) program)
        | 2 -> Multiply (sliceTriple (index + 1) program)
        | 99 -> Halt
        | _ -> invalidOp (sprintf "Invalid opcode: %i" opcode)

    let executeOperation op (i1, i2, iResult) =
        let v1 = Array.get program i1
        let v2 = Array.get program i2
        let result = op v1 v2
        Array.set program iResult result

    let rec processInstruction index =
        let instruction = parseInstruction index
        match instruction with
        | Add parameters ->
            executeOperation (+) parameters
            processInstruction (index + 4)
        | Multiply parameters ->
            executeOperation (*) parameters
            processInstruction (index + 4)
        | Halt -> Array.get program 0

    processInstruction 0

let run() =
    let program = loadInput()

    Array.set program 1 12
    Array.set program 2 2

    program
    |> runProgram
    |> printfn "Day2: %i"
