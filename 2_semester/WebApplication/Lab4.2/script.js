 // Сворачивание/разворачивание окошек
const toggleButtons = document.querySelectorAll(".task-toggle");
toggleButtons.forEach(button => {
    button.addEventListener("click", () => {
        const content = button.nextElementSibling;
        content.style.display = content.style.display === "block" ? "none" : "block";
    });
});
 
 
 // 1.1) Генератор случайных чисел
 function generateRandom() {
    const min = parseInt(document.getElementById('min').value);
    const max = parseInt(document.getElementById('max').value);
    
    if (min >= max) {
        document.getElementById('randomResult').textContent = "Минимум должен быть меньше максимума";
        return;
    }
    
    const result = Math.floor(Math.random() * (max - min + 1)) + min;
    document.getElementById('randomResult').textContent = `Случайное число: ${result}`;
}

// 1.2) Последовательность Падована
function generatePadovan() {
    const count = parseInt(document.getElementById('padovanCount').value);
    let sequence = [];
    
    function padovan(n) {
        if (n === 0 || n === 1 || n === 2) return 1;
        return padovan(n-2) + padovan(n-3);
    }
    
    for (let i = 0; i < count; i++) {
        sequence.push(padovan(i));
    }
    
    document.getElementById('padovanResult').textContent = sequence.join(', ');
}

// 3. Генератор простых чисел
function generatePrimes() {
    const count = parseInt(document.getElementById('primeCount').value);
    let primes = [];
    let num = 2;
    
    function isPrime(n) {
        if (n < 2) return false;
        for (let i = 2, sqrt = Math.sqrt(n); i <= sqrt; i++) {
            if (n % i === 0) return false;
        }
        return true;
    }
    
    while (primes.length < count) {
        if (isPrime(num)) {
            primes.push(num);
        }
        num++;
    }
    
    document.getElementById('primeResult').textContent = primes.join(', ');
}

// 4. Подсчет букв в строке
function countLetters() {
    const text = document.getElementById('textInput').value.toLowerCase();
    const letterMap = new Map();
    
    for (const char of text) {
        if (/[a-zа-яё]/.test(char)) {
            letterMap.set(char, (letterMap.get(char) || 0) + 1);
        }
    }
    
    let result = "Количество букв:\n";
    const sortedLetters = [...letterMap.entries()].sort();
    
    for (const [letter, count] of sortedLetters) {
        result += `${letter}: ${count}\n`;
    }
    
    document.getElementById('letterCountResult').textContent = result;
}

// 5. N-ное простое число
function findNthPrime() {
    const n = parseInt(document.getElementById('nthPrime').value);
    let count = 0;
    let num = 2n;
    
    function isPrime(n) {
        if (n <= 1n) return false;
        if (n === 2n) return true;
        if (n % 2n === 0n) return false;
        
        for (let i = 3n; i * i <= n; i += 2n) {
            if (n % i === 0n) return false;
        }
        return true;
    }
    
    while (count < n) {
        if (isPrime(num)) {
            count++;
            if (count === n) {
                document.getElementById('nthPrimeResult').textContent = 
                    `${n}-е простое число: ${num}`;
                return;
            }
        }
        num++;
    }
}