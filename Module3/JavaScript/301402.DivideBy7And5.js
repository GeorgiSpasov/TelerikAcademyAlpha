function solve(args) {
    let num = +args[0];
    let result = num % 7 == 0 && num % 5 == 0;

    if (result) {
        console.log(`true ${num}`);
    }
    else {
        console.log(`false ${num}`);
    }
}