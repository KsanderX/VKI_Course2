import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.neural_network import MLPClassifier
from sklearn.metrics import accuracy_score
from sklearn.preprocessing import StandardScaler

# Загрузка данных MNIST
from sklearn.datasets import fetch_openml
mnist = fetch_openml('mnist_784', version=1)

# Разделение данных на признаки (X) и метки (y)
X = mnist.data
y = mnist.target

# Преобразование меток в целые числа
y = y.astype(int)

# Разделение данных на обучающую и тестовую выборки
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Стандартизация данных
scaler = StandardScaler()
X_train = scaler.fit_transform(X_train)
X_test = scaler.transform(X_test)

# Создание и обучение модели
mlp = MLPClassifier(hidden_layer_sizes=(100,), max_iter=200, solver='adam', random_state=42)
mlp.fit(X_train, y_train)

# Предсказание на тестовой выборке
y_pred = mlp.predict(X_test)

# Оценка точности
accuracy = accuracy_score(y_test, y_pred)
print(f'Точность на тестовой выборке: {accuracy:.4f}')