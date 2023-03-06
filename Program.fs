open System
open System.IO;

let rec findDirs (endsWith : string seq) directory =
    let rest, matches =
        directory |>
        Directory.GetDirectories |>
        Array.map Path.GetFullPath |>
        Array.partition (fun x -> endsWith |> Seq.where x.EndsWith |> Seq.isEmpty)

    rest |>
        seq |>
        Seq.map (findDirs endsWith) |>
        Seq.concat |>
        Seq.append (matches |> seq)

match
    Environment.GetCommandLineArgs() |>
    Array.skip 1
with
| [| path |] -> path
| _ -> Environment.CurrentDirectory
|>
findDirs (seq { "/bin"; "/obj" ; "\\bin" ; "\\obj" }) |>
Seq.iter (fun p ->
     p |> printfn "Purging '%s'"
     Directory.Delete(p, true)
)
