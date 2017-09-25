function solve(args) {
    let num = +args[0];

    if (num % 2 == 0) {
        console.log(`even ${num}`);
    }
    else {
        console.log(`odd ${num}`);
    }
}