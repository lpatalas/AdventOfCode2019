[<AutoOpen>]
module AdventOfCode.Utils

open System
open System.IO
open System.Reflection

let parseInt input =
    Int32.Parse input

let readAllLines (stream: Stream) =
    seq {
        use reader = new StreamReader(stream)
        let mutable line = reader.ReadLine()
        while not (isNull line) do
            yield line
            line <- reader.ReadLine()
    }

let readInputFile name =
    let assembly = Assembly.GetExecutingAssembly()
    use inputStream = assembly.GetManifestResourceStream name
    if isNull inputStream then invalidOp "Can't find resource"
    readAllLines inputStream |> Seq.toArray
