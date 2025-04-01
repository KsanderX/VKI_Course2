import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

#  Максимальное значение ряда
max_row_number = titanic['row_number'].max()
titanic['row_number'] = titanic['row_number'].fillna(max_row_number)

print(titanic.head(20))