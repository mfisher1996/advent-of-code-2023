module AdventOfCode2023.Day2

open System

type Cubes = {
    red : int
    blue : int
    green : int
}

let set_red (cubes : Cubes) red = if cubes.red < red then {red=red; blue=cubes.blue; green=cubes.green} else cubes
let set_blue (cubes : Cubes) blue = if cubes.blue < blue then {red=cubes.red; blue=blue; green=cubes.green} else cubes
let set_green (cubes : Cubes) green = if cubes.green < green then {red=cubes.red; blue=cubes.blue; green=green} else cubes

let compare max_cubes cube  = 
    cube.red > max_cubes.red || cube.blue > max_cubes.blue || cube.green > max_cubes.green

let parse_colors (line:string) = 
    let rec aux acc words = 
        match words with 
            | "Game" :: some :: rest -> aux acc rest
            | some :: "red;" :: rest | some :: "red," :: rest | some :: "red" :: rest -> aux (set_red acc (int some)) rest
            | some :: "blue;" :: rest | some :: "blue," :: rest | some :: "blue" :: rest -> aux (set_blue acc (int some)) rest
            | some :: "green;" :: rest | some :: "green," :: rest | some :: "green" :: rest -> aux (set_green acc (int some)) rest
            | some :: rest -> printfn "some: %s" some ; aux acc rest
            | [] -> acc
    aux {red=0; blue=0; green=0} (List.ofArray (line.Split(' ')))

let find_games colors games = 
    let rec games_aux num acc games = 
        match games with 
            | game :: rest -> games_aux (num + 1) (acc + if compare colors (parse_colors game) then 0 else num) rest
            | [] -> acc
    games_aux 1 0 games

let part_1 file = 
    let find_games_max = find_games {red=12; blue=14; green=13} ;
    let aux stream = 
        stream |>  
        Seq.toList |>
        find_games_max 
    aux (IO.File.ReadLines file) |> printfn "%d" ;;

let get_powers stream = 
    let aux stream = 
        stream |> 
        Seq.map parse_colors |>
        Seq.map (fun x -> x.red * x.blue * x.green) |>
        Seq.sum
    aux stream

let part_2 file = 
    let aux stream =
        stream |>
        get_powers
    aux (IO.File.ReadLines file) |> printfn "%d" ;;


