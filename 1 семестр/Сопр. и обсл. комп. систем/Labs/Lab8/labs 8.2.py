import pandas as pd  
import numpy as np  
import matplotlib.pyplot as plt  
import seaborn as sns  
from sklearn.model_selection import train_test_split  
from sklearn.linear_model import LogisticRegression  
from sklearn.preprocessing import StandardScaler  
from sklearn.metrics import accuracy_score  
from sklearn.linear_model import LogisticRegressionCV  

# Шаг 1: Чтение данных  
data = pd.read_csv('car_data.csv')  

# Удаление пробелов из названий столбцов, если они есть  
data.columns = data.columns.str.strip()  

# Вывод первых строк для проверки данных и названий столбцов  
print("Первые строки данных:")  
print(data.head())  

print("\nНазвания столбцов:")  
print(data.columns)  

# Шаг 2: Преобразование данных  
# Кодируем пол клиентов (Male = 0, Female = 1)  
data['Gender'] = data['Gender'].map({'Male': 0, 'Female': 1})  

# Определяем признаки (X) и целевую переменную (y)  
X = data[['Gender', 'Age', 'AnnualSalary']]  
y = data['Purchased']  

# Шаг 3: Разделение данных на обучающую и тестовую выборки  
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)  

# Нормализация данных  
scaler = StandardScaler()  
X_train_scaled = scaler.fit_transform(X_train)  
X_test_scaled = scaler.transform(X_test)  

# Шаг 4: Обучение модели логистической регрессии  
model = LogisticRegression()  
model.fit(X_train_scaled, y_train)  

# Шаг 5: Предсказание и оценка точности  
predictions = model.predict(X_test_scaled)  
accuracy = accuracy_score(y_test, predictions)  
print(f"\nТочность модели: {accuracy:.2f}")  

# Шаг 6: Построение графиков  
plt.figure(figsize=(14, 10))  

# График зависимости покупки от годового дохода  
plt.subplot(2, 2, 1)  
sns.scatterplot(data=data, x='AnnualSalary', y='Purchased', hue='Gender', alpha=0.8)  
plt.title('График зависимости покупок автомобилей от годового дохода пользователей')  

# График зависимости покупки от возраста  
plt.subplot(2, 2, 2)  
sns.scatterplot(data=data, x='Age', y='Purchased', hue='Gender', alpha=0.8)  
plt.title('График зависимости решения о покупке от возраста клиентов')  

# График зависимости решения о покупке от пола  
plt.subplot(2, 2, 3)  
sns.countplot(data=data, x='Gender', hue='Purchased')  
plt.title('График зависимости решения о покупке от пола клиентов')  

# График зависимости решения о покупке от годового дохода  
plt.subplot(2, 2, 4)  
sns.boxplot(data=data, x='Purchased', y='AnnualSalary')  
plt.title('График зависимости решения о покупке от годового дохода')  

plt.tight_layout()  
plt.show()  

# Шаг 7: Регуляризация
# Используем LogisticRegressionCV для подбора параметра C  
model_cv = LogisticRegressionCV(Cs=10, cv=5, random_state=42, penalty='l2')  
model_cv.fit(X_train_scaled, y_train)  
print(f"\nЛучший параметр C: {model_cv.C_}")  

# Проверка точности модели с регуляризацией  
predictions_cv = model_cv.predict(X_test_scaled)  
accuracy_cv = accuracy_score(y_test, predictions_cv)  
print(f"Точность модели с регуляризацией: {accuracy_cv:.2f}")