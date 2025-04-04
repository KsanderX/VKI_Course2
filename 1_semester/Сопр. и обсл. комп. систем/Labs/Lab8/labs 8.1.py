import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.linear_model import LogisticRegression
from sklearn.preprocessing import StandardScaler
from sklearn.metrics import accuracy_score  # Используем метрику точности для классификации

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

# Основной код
data = pd.read_csv('data_multivar.txt', header=None, delim_whitespace=True, dtype=float)
X = data.iloc[:, :-1].values  # Все колонки, кроме последней, как признаки
y = data.iloc[:, -1].values  # Последняя колонка как целевая переменная
# Нормализация признаков
scaler = StandardScaler()
X = scaler.fit_transform(X)

# Инициализация и обучение модели с регуляризацией
model = LogisticRegression(solver='lbfgs', penalty='l2', C=1.0)  # Добавлена регуляризация L2 с параметром C
model.fit(X, y)

# Параметры модели
theta_0 = model.intercept_
theta_1 = model.coef_
print(f"Theta 0 (intercept): {theta_0}")
print(f"Theta (coefficients for each feature): {theta_1}")
# Прогнозируем значения y на основе модели
y_pred = model.predict(X)
# Визуализация предсказанных и реальных значений
# Вычисление точности (accuracy)
accuracy = accuracy_score(y, y_pred)
print(f"Accuracy: {accuracy}")
plotPredictions(y, y_pred)

# Прогноз для новых данных
new_example = np.array([0.4, 0.1])  # Пример новых данных
new_example_scaled = scaler.transform([new_example])  # Нормализация нового примера
prediction = model.predict(new_example_scaled)
print(f"Prediction for new example: {prediction[0]}")