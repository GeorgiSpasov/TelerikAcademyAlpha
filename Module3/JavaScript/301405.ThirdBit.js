function solve(args) {
    let result = +((args[0] & 1 << 3) == 1 << 3)
    console.log(result)
}