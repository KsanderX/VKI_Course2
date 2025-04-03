import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

# Количество выпитого в литрах
titanic ['liters_drunk'] = titanic['liters_drunk'].clip(lower=0, upper=titanic['liters_drunk'].quantile(0.99))
titanic['liters_drunk'] = titanic['liters_drunk'].fillna(titanic['liters_drunk'].mean())

print(titanic.head(20))


