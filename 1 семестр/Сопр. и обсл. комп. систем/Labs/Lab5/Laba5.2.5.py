import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

# titanic['is_alcoholic'] = ((titanic['drink'] != "Cola") & (titanic['drink'] != "Fanta") & (titanic['drink'] != "Water").astype(int))

titanic['drink'] = titanic['drink'].map({'Cola': 1, 'Fanta' : 1, 'Water': 1,  'Beerbeer': 0, 'Bugbeer': 0, '"Strong beer"': 0})
print(titanic.head(20))  