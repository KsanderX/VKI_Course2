function signCount(arr) {
    let count = 0;
    let prevSign = 0;
    
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === 0) continue;
        
        const currentSign = Math.sign(arr[i]);
        
        if (prevSign !== 0 && currentSign !== prevSign) {
            count++;
        }
        
        prevSign = currentSign;
    }
    
    return count;
}


function createAsc(arr) {
    if (arr.length === 0) return [];

    const tails = [];
    const prevIndices = new Array(arr.length).fill(-1);

    for (let i = 0; i < arr.length; i++) {
        const num = arr[i];

        let left = 0, right = tails.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[tails[mid]] < num) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }

        if (left < tails.length) {
            tails[left] = i;
        } else {
            tails.push(i);
        }

        if (left > 0) {
            prevIndices[i] = tails[left - 1];
        }
    }

    const result = [];
    let current = tails[tails.length - 1];
    while (current !== -1) {
        result.push(arr[current]);
        current = prevIndices[current];
    }

    return result.reverse();
}


document.getElementById('task1Result').textContent = 
    `Результат: ${signCount([1, 0, -1, -3, -5, 5, -1])}`;

document.getElementById('task2Result').textContent = 
    `Результат: [${createAsc([6, 2, 5, 4, 2, 5, 6]).join(', ')}]`;