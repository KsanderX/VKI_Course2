// Общие функции для управления интерфейсом
function toggleTheme() {
    document.body.classList.toggle('dark-theme');
    if (document.body.classList.contains('dark-theme')) {
        createRain();
    }
}
function createRain() {
    const rainfield = document.getElementById('rainfield');
    rainfield.innerHTML = '';
    const numDrops = 120;

    for (let i = 0; i < numDrops; i++) {
        const drop = document.createElement('div');
        drop.className = 'drop';
        drop.style.left = Math.random() * 100 + 'vw';
        drop.style.animationDuration = (0.5 + Math.random() * 1.5) + 's';
        drop.style.animationDelay = Math.random() * 2 + 's';
        rainfield.appendChild(drop);
    }
}

function toggleSection(header) {
    const content = header.nextElementSibling;
    content.style.display = content.style.display === 'block' ? 'none' : 'block';
}

// Задача 1. Таймеры

// Простой счетчик
let simpleCounterTimeout = null;
function runSimpleCounter() {
    const n = parseInt(document.getElementById('simpleCounterInput').value);
    const resultDiv = document.getElementById('simpleCounterResult');
    // Останавливаем предыдущий счетчик, если он был запущен
    if (simpleCounterTimeout) {
        clearTimeout(simpleCounterTimeout);
        simpleCounterTimeout = null;
    }
    resultDiv.textContent = '';
    
    counter(n, (num) => {
        resultDiv.textContent += num + ' ';
    });
}

function counter(n, callback) {
    callback(n);
    if (n > 0) {
        simpleCounterTimeout = setTimeout(() => counter(n - 1, callback), 1000);
    } else {
        simpleCounterTimeout = null;
    }
}

// Управляемый счетчик
let managedCounter = null;
let counterInterval = null;
let currentCount = 0;

function createManagedCounter() {
    const n = parseInt(document.getElementById('managedCounterInput').value);
    currentCount = n;
    
    managedCounter = {
        start() {
            if (counterInterval) return;
            
            document.getElementById('managedCounterDisplay').textContent = currentCount;
            counterInterval = setInterval(() => {
                currentCount--;
                document.getElementById('managedCounterDisplay').textContent = currentCount;
                if (currentCount <= 0) {
                    clearInterval(counterInterval);
                    counterInterval = null;
                }
            }, 1000);
        },
        pause() {
            clearInterval(counterInterval);
            counterInterval = null;
        },
        stop() {
            clearInterval(counterInterval);
            counterInterval = null;
            currentCount = 0;
            document.getElementById('managedCounterDisplay').textContent = 'Счетчик остановлен';
        }
    };
    
    document.getElementById('startBtn').disabled = false;
    document.getElementById('pauseBtn').disabled = false;
    document.getElementById('stopBtn').disabled = false;
    document.getElementById('managedCounterDisplay').textContent = 'Готов к запуску';
}

function startManagedCounter() {
    if (managedCounter) managedCounter.start();
}

function pauseManagedCounter() {
    if (managedCounter) managedCounter.pause();
}

function stopManagedCounter() {
    if (managedCounter) managedCounter.stop();
}

// Задача 2. Промисы
//Задержка с промисами
function runDelay() {
    const n = parseInt(document.getElementById('delayInput').value);
    const resultDiv = document.getElementById('delayResult');
    
    resultDiv.textContent = `Задержка ${n} сек...`;
    
    delay(n).then(() => {
        resultDiv.textContent = `Задержка ${n} сек завершена!`;
    });
}

function delay(N) {
    return new Promise(resolve => {
        setTimeout(resolve, N * 1000);
    });
}

//Счетчик через промисы
let promiseCounterActive = false;

function runPromiseCounter() {
    const n = parseInt(document.getElementById('promiseCounterInput').value);
    const resultDiv = document.getElementById('promiseCounterResult');
    
    // Если счетчик уже работает, не запускаем новый
    if (promiseCounterActive) {
        return;
    }
    
    resultDiv.textContent = '';
    promiseCounterActive = true;
    
    promiseCounter(n, (num) => {
        resultDiv.textContent += num + ' ';
    }).finally(() => {
        promiseCounterActive = false;
    });
}

function promiseCounter(n, callback) {
    return new Promise((resolve) => {
        callback(n);
        if (n > 0) {
            delay(1).then(() => promiseCounter(n - 1, callback).then(resolve));
        } else {
            resolve();
        }
    });
}

//Первый репозиторий GitHub
function getFirstRepo() {
    const username = document.getElementById('githubUserInput').value.trim();
    const resultDiv = document.getElementById('githubRepoResult');
    
    if (!username) {
        resultDiv.textContent = 'Введите имя пользователя';
        return;
    }
    
    resultDiv.textContent = 'Загрузка данных...';
    
    fetch(`https://api.github.com/users/${username}`)
        .then(response => {
            if (!response.ok) throw new Error('Пользователь не найден');
            return response.json();
        })
        .then(user => {
            return fetch(user.repos_url);
        })
        .then(response => response.json())
        .then(repos => {
            if (repos.length > 0) {
                resultDiv.textContent = `Первый репозиторий: ${repos[0].name}`;
            } else {
                resultDiv.textContent = 'У пользователя нет репозиториев';
            }
        })
        .catch(error => {
            resultDiv.textContent = `Ошибка: ${error.message}`;
        });
}

// Задача 3. Async/await
class HttpError extends Error {
    constructor(response) {
        super(`${response.status} for ${response.url}`);
        this.name = 'HttpError';
        this.response = response;
    }
}

async function loadJsonAsync(url) {
    const response = await fetch(url);
    if (response.status == 200) {
        return await response.json();
    } else {
        throw new HttpError(response);
    }
}

async function getGithubUserAsync() {
    const resultDiv = document.getElementById('githubUserResult');
    resultDiv.textContent = 'Введите логин в диалоговом окне...';
    
    let name;
    let user;
    
    while (true) {
        name = prompt("Введите логин?", "KsanderX");
        if (name === null) {
            resultDiv.textContent = 'Отменено пользователем';
            return;
        }
        
        try {
            user = await loadJsonAsync(`https://api.github.com/users/${name}`);
            break;
        } catch (err) {
            if (err instanceof HttpError && err.response.status == 404) {
                alert("Такого пользователя не существует, пожалуйста, повторите ввод.");
            } else {
                resultDiv.textContent = `Ошибка: ${err.message}`;
                throw err;
            }
        }
    }
    
    const userInfo = `Полное имя: ${user.name || 'не указано'}\nЛогин: ${user.login}\nРепозитории: ${user.public_repos}`;
    resultDiv.textContent = userInfo;
    alert(userInfo);
    return user;
}
