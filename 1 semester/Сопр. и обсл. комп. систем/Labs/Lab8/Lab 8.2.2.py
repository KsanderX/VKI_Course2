import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression, Ridge
from sklearn.preprocessing import StandardScaler, PolynomialFeatures
from sklearn.model_selection import GridSearchCV

# Функция для построения графика функции потерь по итерациям
def plotCostHistory(cost_history):
    plt.plot(cost_history, color='blue')
    plt.xlabel("Number of Iterations")
    plt.ylabel("Cost (J)")
    plt.title("Cost Function Convergence")
    plt.show()

# Функция для построения графика сравнения реальных и предсказанных значений
def plotPredictions(y, y_pred):
    plt.scatter(range(len(y)), y, color='blue', label='Real values')
    plt.scatter(range(len(y_pred)), y_pred, color='red', label='Predicted values', marker='x')
    plt.xlabel("Training examples")
    plt.ylabel("Target variable")
    plt.title("Реальные и прогнозируемые значения")
    plt.ylim(bottom=0)  # Начало от нуля по оси Y
    plt.legend()
    plt.show()

# Функция для вычисления средней абсолютной ошибки предсказаний
def computePredictionError(y, y_pred):
    return np.mean(np.abs(y - y_pred))

# Загрузка данных

data = pd.read_csv('Student_Performance.csv')

# Выбор признаков и целевой переменной

X = data[['Hours Studied', 'Previous Scores', 'Sleep Hours']]  # Признаки
y = data['Performance Index']  # Целевая переменная

# Нормализация признаков

scaler = StandardScaler()  # Создаем объект для стандартизации данных
X = scaler.fit_transform(X)  # Нормализуем признаки X

# Генерация полиномиальных признаков (степени 2)

poly = PolynomialFeatures(degree=2)  # Создаем объект для генерации полиномиальных признаков
X_poly = poly.fit_transform(X)  # Преобразуем исходные признаки X в полиномиальные признаки

# Построение графиков

plt.figure(figsize=(15, 10))

# Распределение индекса успеваемости

plt.subplot(2, 2, 1)
plt.hist(y, bins=20, color='blue')
plt.xlabel("Performance Score")
plt.ylabel("Frequency")
plt.title("Распределение индекса успеваемости")

# Зависимость успеваемости от часов учебы

plt.subplot(2, 2, 2)
plt.scatter(data['Hours Studied'], y, color='green')
plt.xlabel("Hours Studied")
plt.ylabel("Performance Score")
plt.title("Зависимость успеваемости от часов учебы")

# Зависимость успеваемости от предыдущих баллов
plt.subplot(2, 2, 3)
plt.scatter(data['Previous Scores'], y, color='red')
plt.xlabel("Previous Scores")
plt.ylabel("Performance Score")
plt.title("Зависимость успеваемости от предыдущих баллов")

# Зависимость успеваемости от количества часов сна

plt.subplot(2, 2, 4)
plt.scatter(data['Sleep Hours'], y, color='purple')
plt.xlabel("Sleep Hours")
plt.ylabel("Performance Score")
plt.title("Зависимость успеваемости от количества часов сна")

plt.tight_layout()
plt.show()

# Обучение модели линейной регрессии без регуляризации

model_linear = LinearRegression()  # Создаем объект модели линейной регрессии
model_linear.fit(X_poly, y)  # Обучаем модель на полиномиальных признаках X_poly и целевой переменной y

# Прогнозируем значения y на основе модели

y_pred_linear = model_linear.predict(X_poly)  # Предсказываем значения целевой переменной

# Визуализация предсказанных и реальных значений

plotPredictions(y, y_pred_linear)  # Строим график сравнения реальных и предсказанных значений

# Вычисление и вывод ошибки предсказания

error_linear = computePredictionError(y, y_pred_linear)  # Вычисляем среднюю абсолютную ошибку
print(f"Mean Absolute Error (Linear Regression): {error_linear}")  # Выводим ошибку на экран

# Обучение модели с регуляризацией (Ridge)

param_grid = {
    'alpha': [0.001, 0.01, 0.1, 1, 10, 100, 1000]  # Создаем словарь с параметрами, которые будут оптимизированы
}

grid_search = GridSearchCV(Ridge(), param_grid, cv=5, scoring='neg_mean_absolute_error')  # Создаем объект GridSearchCV
grid_search.fit(X_poly, y)  # Обучаем GridSearchCV на полиномиальных признаках X_poly и целевой переменной y

# Лучшие параметры и модель

best_alpha = grid_search.best_params_['alpha']  # Получаем лучшее значение параметра alpha
best_model = grid_search.best_estimator_  # Получаем лучшую модель

# Прогнозируем значения y на основе лучшей модели

y_pred_ridge = best_model.predict(X_poly)  # Предсказываем значения целевой переменной

# Визуализация предсказанных и реальных значений

plotPredictions(y[::20], y_pred_ridge[::20])  # Строим график сравнения реальных и предсказанных значений

# Вычисление и вывод ошибки предсказания

error_ridge = computePredictionError(y, y_pred_ridge)  # Вычисляем среднюю абсолютную ошибку
print(f"Mean Absolute Error (Ridge Regression with alpha={best_alpha}): {error_ridge}")  # Выводим ошибку на экран

# Сравнение точности обучения
print(f"Improvement with Ridge Regression: {error_linear - error_ridge}")  # Выводим улучшение точности обучения