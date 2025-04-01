import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

# Сортировка по возрасту
titanic['age_child'] = (titanic['age'] < 18).astype(int)
titanic['age_adult'] = ((titanic['age'] >= 18)& (titanic['age']< 50)).astype(int)
titanic['age_elderly'] = (titanic['age'] >= 50).astype(int)
# Удаление старого столбца 'age'
titanic = titanic.drop('age', axis=1)

print (titanic.head(20))
