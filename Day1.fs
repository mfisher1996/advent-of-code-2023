module AdventOfCode2023.Day1

open System

let get_digits line = 
    printfn "%s" line;
    let line = (String.filter (fun c -> Char.IsDigit c) line)
    printfn "%s" $"{line[0]}{line[line.Length - 1]}";
    int ($"{line[0]}{line[line.Length - 1]}") 

let part_1 file = 
    let aux stream = 
        stream |> 
        Seq.map get_digits |>
        Seq.sum
    aux (IO.File.ReadLines file) |> printfn "%d" ;;

let nums =["one";"two";"three";"four";"five";"six";"seven";"eight";"nine";]

let from_english (line:string) = 
    let rec aux acc line = 
        match line with 
            | 'o'::'n'::'e'::'i'::'g'::'h'::'t':: tl -> aux (acc @ ['1'; '8']) tl 
            | 'o'::'n'::'e':: tl -> aux (acc @ ['1']) tl 
            | 't'::'w'::'o'::'n'::'e':: tl -> aux (acc @ ['2';'1']) tl 
            | 't'::'w'::'o':: tl -> aux (acc @ ['2']) tl 
            | 't'::'h'::'r'::'e'::'e'::'i'::'g'::'h'::'t':: tl -> aux (acc @ ['3';'8']) tl 
            | 't'::'h'::'r'::'e'::'e':: tl -> aux (acc @ ['3']) tl 
            | 'f'::'o'::'u'::'r':: tl -> aux (acc @ ['4']) tl 
            | 'f'::'i'::'v'::'e'::'i'::'g'::'h'::'t':: tl -> aux (acc @ ['5';'8']) tl 
            | 'f'::'i'::'v'::'e':: tl -> aux (acc @ ['5']) tl 
            | 's'::'i'::'x':: tl -> aux (acc @ ['6']) tl 
            | 's'::'e'::'v'::'e'::'n'::'i'::'n'::'e':: tl -> aux (acc @ ['7';'9']) tl 
            | 's'::'e'::'v'::'e'::'n':: tl -> aux (acc @ ['7']) tl 
            | 'e'::'i'::'g'::'h'::'t'::'w'::'o':: tl -> aux (acc @ ['8';'2']) tl 
            | 'e'::'i'::'g'::'h'::'t':: tl -> aux (acc @ ['8']) tl 
            | 'n'::'i'::'n'::'e'::'i'::'g'::'h'::'t':: tl -> aux (acc @ ['9';'8']) tl 
            | 'n'::'i'::'n'::'e':: tl -> aux (acc @ ['9']) tl 
            | hd:: tl -> aux (acc @ [hd]) tl
            | [] -> acc
    printfn "%s" line;
    aux List.empty (List.ofArray( line.ToCharArray() ))

let part_2 file = 
    let aux stream = 
        stream |> 
        Seq.map from_english |>
        Seq.map (fun x -> x |> Array.ofList |> String.Concat) |>
        Seq.map get_digits |>
        Seq.sum
    aux (IO.File.ReadLines file) |> printfn "%d" ;;
