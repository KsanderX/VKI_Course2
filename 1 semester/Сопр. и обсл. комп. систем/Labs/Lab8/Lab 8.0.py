import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

def plotCostHistory(cost_history):
    """Построение графика функции потерь по итерациям."""
    plt.plot(cost_history, color='blue')
    plt.xlabel("Number of Iterations")
    plt.ylabel("Cost (J)")
    plt.title("Cost Function Convergence")
    plt.show()

def plotPredictions(X, y, theta):
    """Построение графика для сравнения реальных и предсказанных значений, начиная от нуля по оси Y."""
    predictions = X.dot(theta)
    plt.scatter(range(len(y)), y, color='blue', label='Real values')
    plt.scatter(range(len(y)), predictions, color='red', label='Predicted values', marker='x')
    plt.xlabel("Training examples")
    plt.ylabel("Target variable")
    plt.title("Real vs Predicted Values")
    plt.ylim(bottom=0)  # Установка нижней границы Y в 0
    plt.legend()
    plt.show()

def computeCostMulti(X, y, theta):
    """Вычисление функции стоимости для линейной регрессии с несколькими переменными."""
    m = len(y)
    predictions = X.dot(theta)
    sq_errors = (predictions - y) ** 2
    return (1 / (2 * m)) * np.sum(sq_errors)

def computePredictionError(y, predictions):
    """Вычисление средней абсолютной ошибки предсказаний."""
    return np.mean(np.abs(predictions - y))

def gradientDescentMulti(X, y, theta, alpha, num_iters):
    """Градиентный спуск для линейной регрессии с несколькими переменными."""
    m = len(y)
    cost_history = []  # Для хранения значений функции стоимости на каждой итерации
    for i in range(num_iters):
        error = X.dot(theta) - y
        theta -= (alpha / m) * X.T.dot(error)
        cost_history.append(computeCostMulti(X, y, theta))  # Запись функции стоимости
    return theta, cost_history

# Основной код
data = pd.read_csv('data_multivar.txt', header=None)  # Загрузите данные с несколькими признаками
X = data.iloc[:, :-1]  # Все колонки, кроме последней, как признаки
y = data.iloc[:, -1]  # Последняя колонка как целевая переменная
m = len(y)

# Нормализация признаков
X = (X - X.mean()) / X.std()

# Добавляем столбец единиц для учета свободного члена theta0
X = np.hstack([np.ones((m, 1)), X])
theta = np.zeros(X.shape[1])

# Вычисление начальной стоимости
initial_cost = computeCostMulti(X, y, theta)
print(f"Initial cost: {initial_cost}")

# Настройка параметров для градиентного спуска
iterations = 1500
alpha = 0.01

# Запуск градиентного спуска
theta, cost_history = gradientDescentMulti(X, y, theta, alpha, iterations)
print(f"Theta: {theta}")

# Визуализация функции потерь
plotCostHistory(cost_history)

# Визуализация предсказаний и реальных значений
predictions = X.dot(theta)
plotPredictions(X, y, theta)

# Прогноз для новых данных (пример)
example = np.array([2104, 3])  # Пример новых данных (например, площадь и кол-во комнат)
example = (example - data.iloc[:, :-1].mean()) / data.iloc[:, :-1].std()  # Нормализация примера
example = np.hstack([1, example])  # Добавляем 1 для учета theta0
prediction = example.dot(theta)
print(f"Prediction for new example: {prediction}")
# Вычисление и вывод ошибки предсказания
error = computePredictionError(y, predictions)
print(f"Mean Absolute Error: {error}")