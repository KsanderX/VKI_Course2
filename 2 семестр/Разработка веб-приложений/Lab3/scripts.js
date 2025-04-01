

// Функция для сворачивания/разворачивания заданий
function toggleTask(taskNumber) {
    const content = document.getElementById(`task${taskNumber}`);
    if (content.style.display === "block") {
        content.style.display = "none";
    } else {
        content.style.display = "block";

        if(taskNumber === 2)
        {
            handleTask2()
        }

        if(taskNumber === 5)
        {
            handleTask5()
        }
    }
}

// Задание 1
let name = "Джон";
let admin = name;
document.getElementById("result1").innerText = admin;

// Задание 2
function handleTask2()
{
let a = +prompt("Первое число?", 1);
let b = +prompt("Второе число?", 2);
document.getElementById("result2").innerText = `${a} + ${b} = ${a + b}`;
}
// Задание 3
let evenNumbers = [];
for (let i = 2; i <= 10; i++) {
    if (i % 2 === 0) {
        evenNumbers.push(i);
    }
}
document.getElementById("result3").innerText = evenNumbers.join(", ");

// Задание 4
let task4Output = [];
let i = 0;
while (i < 3) {
    task4Output.push(`number ${i}!`);
    i++;
}
document.getElementById("result4").innerText = task4Output.join(" ");

// Задание 5
function handleTask5(){
let number;
do {
    number = prompt("Введите число больше 100:", "");
} while (number !== null && +number <= 100);
document.getElementById("result5").innerText = number;
}

// Задание 6
let n = 10;
let primes = [];
for (let i = 2; i <= n; i++) {
    let isPrime = true;
    for (let j = 2; j < i; j++) {
        if (i % j === 0) {
            isPrime = false;
            break;
        }
    }
    if (isPrime) {
        primes.push(i);
    }
}
document.getElementById("result6").innerText = primes.join(", ");
