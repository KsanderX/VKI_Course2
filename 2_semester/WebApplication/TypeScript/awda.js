// Функции, соответствующие правым частям дифференциальных уравнений
function f1(x) {
    return Math.sin(x);
}

function f2(x) {
    return 2 - Math.cos(x);
}

// Решение задачи Коши методом Эйлера
function solveEuler() {
    let x = 0;
    let y = 1;
    const n = 12;
    const h = Math.PI / 12;
    
    console.log(" i    x      прибл.решение   точное решение   погрешность");
    
    for (let i = 0; i <= n; i++) {
        const exact = f2(x);
        const error = Math.abs(exact - y);
        
        // Форматируем вывод для лучшей читаемости
        console.log(
            `${i.toString().padStart(2)} ${x.toFixed(4).padStart(6)} ` +
            `${y.toFixed(8).padStart(15)} ${exact.toFixed(8).padStart(15)} ` +
            `${error.toFixed(8).padStart(15)}`
        );
        
        // Вычисляем следующее значение по методу Эйлера
        y = y + f1(x) * h;
        x = x + h;
    }
}

// Запускаем решение
solveEuler();