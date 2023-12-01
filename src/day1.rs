pub fn part1() -> anyhow::Result<()> {
    let result: i32 = include_str!("../data/day1.prod")
        .lines()
        .map(|line| {
            let nums = line
            .chars()
            .filter(|c| c .is_numeric())
            .collect::<String>();
            format!("{}{}",nums.chars().take(1).collect::<String>(),nums.chars().rev().take(1).collect::<String>())
            .parse::<i32>()
            .unwrap_or(0)
        })
        .map(|n| if n < 10 { n*11 } else { n })
        .sum();
    println!("{}", result);
    
    Ok(())
}
