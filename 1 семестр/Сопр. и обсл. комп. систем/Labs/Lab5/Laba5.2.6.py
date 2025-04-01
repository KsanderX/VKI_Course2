import numpy as np
import pandas as pd

sessions = pd.read_csv('cinema_sessions.csv', sep=' ')
titanic = pd.read_csv('titanic_with_labels.csv', sep=' ')

sessii = pd.merge(titanic, sessions, on='check_number', how='left')

sessii['morning'] = (pd.to_datetime(sessii['session_start']).dt.hour < 12).astype(int)
sessii['afternoon'] = ((pd.to_datetime(sessii['session_start']).dt.hour >= 12) & (pd.to_datetime(sessii['session_start']).dt.hour < 21)).astype(int)
sessii['evening'] = (pd.to_datetime(sessii['session_start']).dt.hour >= 21).astype(int)


print(sessii.head(5))

