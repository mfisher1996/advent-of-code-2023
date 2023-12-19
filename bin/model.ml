type rune = { 
    digit: char;
    surrounding: char list;
}

    let rune_from_str value =
        let aux_rune value = 
