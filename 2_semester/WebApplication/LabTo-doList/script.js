document.addEventListener('DOMContentLoaded', () => {
    const taskList = document.getElementById('task-list');
    const newTaskInput = document.getElementById('new-task');
    const addTaskButton = document.getElementById('add-task');
    const clearAllButton = document.getElementById('clear-all');
    const filterLinks = document.querySelectorAll('.filter-link');
    const sortSelect = document.getElementById('sort-tasks');

    let tasks = JSON.parse(localStorage.getItem('tasks')) || [];
    let currentFilter = 'all';
    let currentSort = 'default';

    function saveTasks() {
        localStorage.setItem('tasks', JSON.stringify(tasks));
    }

    function renderTasks() {
        taskList.innerHTML = '';
        let filtered = tasks.filter(task => {
            if (currentFilter === 'done') return task.done;
            if (currentFilter === 'not-done') return !task.done;
            return true;
        });

        if (currentSort === 'name') {
            filtered.sort((a, b) => a.text.localeCompare(b.text));
        } else if (currentSort === 'date') {
            filtered.sort((a, b) => new Date(a.date) - new Date(b.date));
        }

        filtered.forEach((task, index) => {
            const li = document.createElement('li');
            li.innerHTML = `
                <input type="checkbox" ${task.done ? 'checked' : ''} data-index="${index}">
                <span contenteditable="true" class="editable" data-index="${index}">${task.text}</span>
                <sub>от ${task.date}</sub>
                <button class="edit-btn" data-index="${index}">💾</button>
                <button data-index="${index}">❌</button>
            `;
            taskList.appendChild(li);
        });
    }

    function addTask(text) {
        const task = {
            text,
            done: false,
            date: new Date().toLocaleDateString()
        };
        tasks.push(task);
        saveTasks();
        renderTasks();
    }

    function deleteTask(index) {
        tasks.splice(index, 1);
        saveTasks();
        renderTasks();
    }

    function clearAllTasks() {
        tasks = [];
        saveTasks();
        renderTasks();
    }

    function toggleTaskDone(index) {
        tasks[index].done = !tasks[index].done;
        saveTasks();
        renderTasks();
    }

    function updateTaskText(index, newText) {
        tasks[index].text = newText;
        saveTasks();
    }

    addTaskButton.addEventListener('click', () => {
        const text = newTaskInput.value.trim();
        if (text) {
            addTask(text);
            newTaskInput.value = '';
        }
    });

    clearAllButton.addEventListener('click', clearAllTasks);

    taskList.addEventListener('click', (e) => {
        const index = e.target.dataset.index;
        if (e.target.tagName === 'BUTTON' && e.target.textContent === '❌') {
            deleteTask(index);
        } else if (e.target.tagName === 'INPUT') {
            toggleTaskDone(index);
        } else if (e.target.classList.contains('edit-btn')) {
            const span = document.querySelector(`span[data-index="${index}"]`);
            updateTaskText(index, span.textContent.trim());
        }
    });

    filterLinks.forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            currentFilter = e.target.dataset.filter;
            filterLinks.forEach(l => l.classList.remove('active'));
            e.target.classList.add('active');
            renderTasks();
        });
    });

    sortSelect.addEventListener('change', (e) => {
        currentSort = e.target.value;
        renderTasks();
    });

    renderTasks();
});