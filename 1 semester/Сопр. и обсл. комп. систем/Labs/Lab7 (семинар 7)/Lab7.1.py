import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression, Ridge  # Импортируем Ridge для L2-регуляризации
from sklearn.preprocessing import StandardScaler, PolynomialFeatures
from sklearn.model_selection import GridSearchCV

#Определение функций

def plotCostHistory(cost_history):
    """Построение графика функции потерь по итерациям."""
    plt.plot(cost_history, color='blue')
    plt.xlabel("Number of Iterations")
    plt.ylabel("Cost (J)")
    plt.title("Cost Function Convergence")
    plt.show()

def plotPredictions(y, y_pred):
    """Построение графика для сравнения реальных и предсказанных значений."""
    plt.scatter(range(len(y)), y, color='blue', label='Real values')
    plt.scatter(range(len(y_pred)), y_pred, color='red', label='Predicted values', marker='x')
    plt.xlabel("Training examples")
    plt.ylabel("Target variable")
    plt.title("Real vs Predicted Values")
    plt.ylim(bottom=0)  # Начало от нуля по оси Y
    plt.legend()
    plt.show()

def computePredictionError(y, y_pred): #между реальными и предсказанными значениями
    """Вычисление средней абсолютной ошибки предсказаний."""
    return np.mean(np.abs(y - y_pred))

#Загрузка и подготовка данных

data = pd.read_csv('data_multivar.txt', header=None)  # Загрузите данные с несколькими признаками
data = data.sample(frac=0.3, random_state=42)  #ИСПОЛЬЗУЕМ ТОЛЬКО 30% ДАННЫХ
X = data.iloc[:, :-1].values  # выбираем Все колонки, кроме последней, как признаки
y = data.iloc[:, -1].values  # выбираем Последняя колонка как целевая переменная

# Нормализация признаков

scaler = StandardScaler() #создаем объект для стандартизации данных
X = scaler.fit_transform(X) #нормализуем признаки X

#Генерация полиномиальных признаков

#Полиномиальные признаки — это признаки, которые получаются путем возведения исходных признаков в степень и их комбинаций
#создание объекта для Генерация полиномиальных признаков (степени 2)
poly = PolynomialFeatures(degree=2)  # Вы можете изменить степень на нужную вам
X_poly = poly.fit_transform(X) #Преобразуем исходные признаки X в полиномиальные признаки

# Инициализация и обучение модели с регуляризацией

alpha = 0.1  #ИЗМЕНЕНИЕ ШАГА ОБУЧЕНИЯ И ПАРАМТЕРОВ РЕГУЛИРЯЦИИ
#создание объекта модели
model = Ridge(alpha=alpha, max_iter=3000) #ИЗМЕНЕНИЕ ЧИСЛА ИТЕРАЦИЙ СХОДИМОСТИ ФУНКЦИИ ОШИБКИ
# Используем Ridge для L2-регуляризации
model.fit(X_poly, y)

#Получение параметров модели

#Переменная theta представляет собой параметры модели линейной регрессии, которые определяют, как модель соответствует данным
# Параметры модели
theta_0 = model.intercept_ #получаем значение свободного члена
theta_1 = model.coef_ #Получаем коэффициенты (веса) для каждого признака.
print(f"Theta 0 (intercept): {theta_0}")
print(f"Theta (slopes for each feature): {theta_1}")

# Прогнозируем значения y на основе модели

y_pred = model.predict(X_poly)

# Визуализация предсказанных и реальных значений

plotPredictions(y, y_pred)

# Прогноз для новых данных

new_example = np.array([1650, 3])  # Пример новых данных (площадь и количество комнат)
new_example_scaled = scaler.transform([new_example])  # Нормализация нового примера
new_example_poly = poly.transform(new_example_scaled)  # Преобразование в полиномиальные признаки
prediction = model.predict(new_example_poly) #Используем модель для предсказания значения для нового примера.
print(f"Prediction for new example: {prediction[0]}")

# Вычисление и вывод ошибки предсказания

error = computePredictionError(y, y_pred)
print(f"Mean Absolute Error: {error}")

# Выбор оптимальных параметров с использованием GridSearchCV

param_grid = { #Создаем словарь с параметрами, которые будут оптимизированы
    'alpha': [0.001, 0.01, 0.1, 1, 10, 100, 1000],
    'max_iter': [100, 500, 1000, 5000]
}

#Создаем объект GridSearchCV для поиска оптимальных параметров с использованием кросс-валидации и метрики neg_mean_absolute_error.
grid_search = GridSearchCV(Ridge(), param_grid, cv=5, scoring='neg_mean_absolute_error')
grid_search.fit(X_poly, y) #Обучаем GridSearchCV на полиномиальных признаках X_poly и целевой переменной y.

print(f"Best parameters: {grid_search.best_params_}")
print(f"Best score: {grid_search.best_score_}")