import pandas as pd
import matplotlib.pyplot as plt
import seaborn  as sns
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression, Ridge
from sklearn.metrics import mean_squared_error, r2_score
from sklearn.linear_model import Ridge

data = pd.read_csv('Student_Performance.csv')

print(data.describe)



#Распределение индекса успеваемости
plt.figure(figsize = (8,5))
sns.histplot(data['Performance Index'], kde = True, bins = 30, color = 'blue')
plt.title("Распределение индекса успеваемости", fontsize = 14)
plt.xlabel("Performanse Index", fontsize = 12)
plt.ylabel("Frequency", fontsize = 12)
plt.show

#Зависимость успеваемости от часов учебы
plt.figure(figsize = (8,5))
sns.scatterplot(x=data['Hours Studied'], y=data['Performance Index'], color = 'green', alpha=0.6)
plt.title("Зависимость успеваемости от часов учебы", fontsize = 14)
plt.xlabel("Hours Studied", fontsize = 12)
plt.ylabel("Performance Index", fontsize = 12)
plt.show

# Зависимость успеваемости от предыдущих баллов
plt.figure(figsize = (8,5))
sns.scatterplot(x=data['Previous Scores'], y=data['Performance Index'], color = 'orange', alpha=0.6)
plt.title("Зависимость успеваемости от предыдущих баллов", fontsize = 14)
plt.xlabel("Previous Scores", fontsize = 12)
plt.ylabel("Performanse Index", fontsize = 12)
plt.show

# Зависимость успеваемости от количесва часов сна
plt.figure(figsize = (8,5))
sns.boxplot(x=data['Sleep Hours'], y=data['Performance Index'],palette="coolwarm")
plt.title("Зависимость успеваемости от количесва часов сна", fontsize = 14)
plt.xlabel("Sleep Hours", fontsize = 12)
plt.ylabel("Performanse Index", fontsize = 12)
plt.show

# Линейная регрессия

X = data[['Hours Studied', 'Previous Scores', 'Sleep Hours']]
y = data['Performance Index']

#Разделение данных на обущающую и тестовую выборки
X_train, X_test, y_train, y_test = train_test_split(X, y,test_size=0.2, random_state=42)

# Создание и обучение модели
lr_model = LinearRegression()
lr_model.fit(X_train, y_train)

#Предсказание и оценка
y_pred = lr_model.predict(X_test)
mse_lr = mean_squared_error(y_test, y_pred)
r2_lr= r2_score(y_test, y_pred)

print("Линейная регрессия:")
print(f"Коэффициенты: {lr_model.coef_}")
print(f"Свободный член: {lr_model.intercept_}")
print(f"MSE: {mse_lr}")
print(f"R^2: {r2_lr}")

# Регуляризация (Ridge)

# Применение Ridge-регрессии
ridge_model = Ridge(alpha=1.0)
ridge_model.fit(X_train, y_train)

# Предсказание и оценка
y_pred_ridge = ridge_model.predict(X_test)
mse_ridge = mean_squared_error(y_test, y_pred_ridge)
r2_ridge = r2_score(y_test, y_pred_ridge)

print("\nRidge-регрессия:")
print(f"Коэффициенты: {ridge_model.coef_}")
print(f"Свободный член: {ridge_model.intercept_}")
print(f"MSE: {mse_ridge}")
print(f"R^2: {r2_ridge}")

# Сравнение
print("\nСравнение моделей:")
print(f"Разница в MSE: {mse_lr - mse_ridge}")
print(f"Разница в R^2: {r2_ridge - r2_lr}")
