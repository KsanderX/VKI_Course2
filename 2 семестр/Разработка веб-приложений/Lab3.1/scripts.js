// Функция для сворачивания/разворачивания заданий
function toggleTask(taskNumber) {
    const content = document.getElementById(`task${taskNumber}`);
    if (content.style.display === "block") {
        content.style.display = "none";
    } else {
        content.style.display = "block";
    }
}

// Функция для сворачивания/разворачивания подзаданий
function toggleSubTask(subTaskNumber) {
    const subContent = document.getElementById(`subTask${subTaskNumber}`);
    if (subContent.style.display === "block") {
        subContent.style.display = "none";
    } else {
        subContent.style.display = "block";
    }
}

// Задача 1.1: Реверс числа
function reverseNumber(num) {
    return parseInt(num.toString().split('').reverse().join(''), 10);
}

function runTask1_1() {
    const input = document.getElementById('input1_1').value;
    const result = reverseNumber(input);
    document.getElementById('output1_1').innerText = `Результат: ${result}`;
}

// Задача 1.2: Удаление повторяющихся цифр
function removeDuplicateDigits(num) {
    const uniqueDigits = [...new Set(num.toString().split(''))];
    return parseInt(uniqueDigits.join(''), 10);
}

function runTask1_2() {
    const input = document.getElementById('input1_2').value;
    const result = removeDuplicateDigits(input);
    document.getElementById('output1_2').innerText = `Результат: ${result}`;
}

// Задача 1.3: Подсчёт цифр
function countDigitOccurrences(num, digit) {
    return num.toString().split('').filter(d => d === digit.toString()).length;
}

function runTask1_3() {
    const num = document.getElementById('input1_3_num').value;
    const digit = document.getElementById('input1_3_digit').value;
    const result = countDigitOccurrences(num, digit);
    document.getElementById('output1_3').innerText = `Результат: ${result}`;
}

// Задача 1.4: Самая длинная последовательность в двоичном числе
function longestBinarySequence(num) {
    const binary = num.toString(2);
    let maxZero = 0, maxOne = 0, currentZero = 0, currentOne = 0;
    for (let char of binary) {
        if (char === '0') {
            currentZero++;
            currentOne = 0;
            if (currentZero > maxZero) maxZero = currentZero;
        } else {
            currentOne++;
            currentZero = 0;
            if (currentOne > maxOne) maxOne = currentOne;
        }
    }
    return Math.max(maxZero, maxOne);
}

function runTask1_4() {
    const num = document.getElementById('input1_4_num').value;   
    const result = longestBinarySequence(num);
    document.getElementById('output1_4').innerText = `Результат: ${result}`;
}


// Задача 2.1: Первый неповторяющийся символ
function firstNonRepeatingCharacter(str) {
    const charCount = {};

    for (let char of str) {
        charCount[char] = (charCount[char] || 0) + 1;
    }

    for (let char of str) {
        if (charCount[char] === 1) {
            return char;
        }
    }

    return null;
}

function runTask2_1() {
    const input = document.getElementById('input2_1').value;
    const result = firstNonRepeatingCharacter(input);
    document.getElementById('output2_1').innerText = `Результат: ${result}`;
}

// Задача 2.2: Генерация случайной строки
function generateRandomString(length) {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';

    for (let i = 0; i < length; i++) {
        const randomIndex = Math.floor(Math.random() * chars.length);
        result += chars[randomIndex];
    }

    return result;
}

function runTask2_2() {
    const length = document.getElementById('input2_2').value;
    const result = generateRandomString(length);
    document.getElementById('output2_2').innerText = `Результат: ${result}`;
}

// Задача 2.3: Уникальные символы строки
function uniqueCharacters(str) {
    return [...new Set(str)].join('');
}

function runTask2_3() {
    const input = document.getElementById('input2_3').value;
    const result = uniqueCharacters(input);
    document.getElementById('output2_3').innerText = `Результат: ${result}`;
}