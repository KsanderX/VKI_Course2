// Сворачивание/разворачивание окошек
const toggleButtons = document.querySelectorAll(".task-toggle");
toggleButtons.forEach(button => {
    button.addEventListener("click", () => {
        const content = button.nextElementSibling;
        content.style.display = content.style.display === "block" ? "none" : "block";
    });
});

// Задача 1
const array1 = [1, 2, 10, 4, 5]; //задача 1.1
const arrayWithDuplicates = [1, 2, 2, 3, 4, 4, 5]; // задача 1.2
const tasks = [
    { id: 1, idDone: true },
    { id: 2, idDone: false },
    { id: 3, idDone: true }
]; // задача 1.3

// Задача 2
const array2 = [1, 4, 6, 3, 2]; // задача 2.1
const nestedArray = [1, 4, [34, 1, 20], [6, [6, 12, 8], 6]]; //задача 2.2

//Задача 3 
const pairsTest1 = [-7, 12, 4, 6, -4, -12, 0];//  2
const pairsTest2 = [-1, 2, 4, 7, -4, 1, -2]; // 3
const tripletsTest = [-1, 0, 1, 2, -1, -4]; // 3

// 1.1) Максимальная разница
function findMaxDifference(arr) {
    if (arr.length === 0) return 0;
    const max = Math.max(...arr);
    const min = Math.min(...arr);
    return max - min;
}

document.getElementById("task1-1").textContent = `Максимальная разница: ${findMaxDifference(array1)}`;

// 1.2) Удаление дубликатов
function removeDuplicates(arr) {
    return [...new Set(arr)];
}

document.getElementById("task1-2").textContent = `Массив без дубликатов: ${JSON.stringify(removeDuplicates(arrayWithDuplicates))}`;

// 1.3) Фильтрация объектов
function filterDoneTasks(tasks) {
    return tasks.filter(task => task.idDone === true);
}

document.getElementById("task1-3").textContent = `Массив True: ${JSON.stringify(filterDoneTasks(tasks), null, 2)}`;



// 2.1) Элементы больше указанного числа
function filterGreaterThan(arr, num) {
    return arr.filter(item => item > num);
}

document.getElementById("task2-1").textContent = `Элементы больше 2: ${JSON.stringify(filterGreaterThan(array2, 2))}`;

// 2.2) Плоский массив
function flattenArray(arr) {
    return arr.reduce((acc, item) => {
        if (Array.isArray(item)) {
            return acc.concat(flattenArray(item));
        }
        return acc.concat(item);
    }, []);
}

document.getElementById("task2-2").textContent = `Плоский массив: ${JSON.stringify(flattenArray(nestedArray))}`;

// 3.1) Найти, сколько есть в массиве пар чисел, дающих в сумме 0:
function countZeroSumPairs(arr){ 
   let count = 0;
    for (let i = 0; i < arr.length; i++){
        for(let j = i + 1; j < arr.length; j++){
             if(arr[i] + arr[j] === 0){
                    count++;
            }           
        }
    }
    return count;
}

document.getElementById("task3-1").textContent = `Пары с суммой 0: ${countZeroSumPairs(pairsTest1)}`;

// 3.2) Найти, сколько есть в массиве три числа, дающих в сумме 0:
function countZeroSumTriples(arr){
    let count = 0;
    for (let i =0; i < arr.length; i++){
        for(let j = i + 1; j< arr.length; j++){
            for(let k = j + 1; k < arr.length; k++){
                if(arr[i] + arr[j] + arr[k] === 0){
                    count++;
                }
            }
        }
    }
    return count;
}

document.getElementById("task3-2").textContent = `Тройки с суммой 0: ${countZeroSumTriples(tripletsTest)}`;