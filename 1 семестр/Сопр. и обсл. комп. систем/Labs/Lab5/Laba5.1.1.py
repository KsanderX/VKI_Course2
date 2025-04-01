import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

# Пол
titanic = titanic[titanic['sex'] != '-']
titanic = titanic[titanic['sex'] != "Не указан"]
titanic['sex'] = titanic['sex'].map({"m": 1, "M": 1, "м": 1, "М": 1, "ж": 0, "Ж": 0})

print(titanic.head(20))
