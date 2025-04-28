document.addEventListener('DOMContentLoaded', () => {
    const taskList = document.getElementById('task-list');
    const newTaskInput = document.getElementById('new-task');
    const addTaskButton = document.getElementById('add-task');
    const clearAllButton = document.getElementById('clear-all');
    const filterLinks = document.querySelectorAll('.filter-link');

    let tasks = [];
    let currentFilter = 'all'; // Текущий активный фильтр

    // Функция для отрисовки задач с учетом фильтра
    function renderTasks() {
        taskList.innerHTML = '';
        const filteredTasks = tasks.filter(task => {
            if (currentFilter === 'done') return task.done;
            if (currentFilter === 'not-done') return !task.done;
            return true; // 'all' — показываем все задачи
        });

        filteredTasks.forEach((task, index) => {
            const li = document.createElement('li');
            li.innerHTML = `
                <input type="checkbox" ${task.done ? 'checked' : ''} data-index="${index}">
                <span>${task.text}</span>
                <sub>от ${task.date}</sub>
                <button data-index="${index}">❌</button>
            `;
            taskList.appendChild(li);
        });
    }

    // Добавление новой задачи
    function addTask(text) {
        const task = {
            text,
            done: false,
            date: new Date().toLocaleDateString()
        };
        tasks.push(task);
        renderTasks();
    }

    // Удаление задачи
    function deleteTask(index) {
        tasks.splice(index, 1);
        renderTasks();
    }

    // Очистка всех задач
    function clearAllTasks() {
        tasks = [];
        renderTasks();
    }

    // Переключение статуса задачи (выполнено/не выполнено)
    function toggleTaskDone(index) {
        tasks[index].done = !tasks[index].done;
        renderTasks();
    }

    // Обработчик для добавления задачи
    addTaskButton.addEventListener('click', () => {
        const text = newTaskInput.value.trim();
        if (text) {
            addTask(text);
            newTaskInput.value = '';
        }
    });

    // Обработчик для очистки всех задач
    clearAllButton.addEventListener('click', clearAllTasks);

    // Обработчик для удаления задачи и переключения статуса
    taskList.addEventListener('click', (event) => {
        if (event.target.tagName === 'BUTTON') {
            const index = event.target.dataset.index;
            deleteTask(index);
        } else if (event.target.tagName === 'INPUT') {
            const index = event.target.dataset.index;
            toggleTaskDone(index);
        }
    });

    // Обработчик для фильтрации задач
    filterLinks.forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();
            currentFilter = event.target.dataset.filter; // Обновляем текущий фильтр
            filterLinks.forEach(link => link.classList.remove('active'));
            event.target.classList.add('active');
            renderTasks(); // Перерисовываем задачи с учетом нового фильтра
        });
    });

    // Первоначальная отрисовка задач
    renderTasks();
});