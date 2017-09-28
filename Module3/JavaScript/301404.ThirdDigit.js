function solve(args) {
    let thirdDigit = args[0][args[0].length - 3]
    console.log(thirdDigit)
    console.log(thirdDigit == '7' ? true : `false ${thirdDigit || 0}`)
}

solve(['877'])