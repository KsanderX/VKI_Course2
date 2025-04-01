import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.neural_network import MLPClassifier
from sklearn.metrics import accuracy_score, confusion_matrix, classification_report
from sklearn.preprocessing import StandardScaler

def display_data(X, example_width=None, example_height=None):
    """
    Display examples from the dataset.
    """
    if X.ndim == 1:
        X = X[np.newaxis, :]  # Приводим массив к размеру (1, n_features)
    # Automatically calculate width and height if not provided
    if example_width is None or example_height is None:
        example_width = int(np.sqrt(X.shape[1]))
        example_height = X.shape[1] // example_width

    display_rows = int(np.sqrt(X.shape[0]))
    display_cols = (X.shape[0] + display_rows - 1) // display_rows  # Ceiling division

    fig, ax_array = plt.subplots(display_rows, display_cols, figsize=(4, 4))
    # Ensure ax_array is always 1D array, even if we have just one plot
    if display_rows == 1 and display_cols == 1:
        ax_array = np.array([ax_array])  # Single plot
    else:
        ax_array = ax_array.ravel()  # Flatten to 1D array if needed

    for i, ax in enumerate(ax_array[:X.shape[0]]):  # Avoid indexing out of bounds
        ax.imshow(X[i].reshape(example_width, example_height).T, cmap='gray')
        ax.axis('off')
    plt.show()

# =========== Load Data ============
print('Loading Data ...')
# Load Training Data from Excel
df = pd.read_excel('mnist.xlsx')
# Extract X and y from the dataframe
X = df.drop(columns='Label').values  # All columns except 'Label' are the features
y = df['Label'].values  # 'Label' column is the target variable
print('Ready')

# Visualize data (we select random samples for display)
sel = np.random.choice(X.shape[0], size=100, replace=False)
display_data(X[sel, :])

# =========== Split Data ============
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# =========== Standardize Data ============
scaler = StandardScaler()
X_train = scaler.fit_transform(X_train)
X_test = scaler.transform(X_test)

# =========== Train Model ============
mlp = MLPClassifier(hidden_layer_sizes=(100,50), max_iter=200, solver='adam', random_state=42)
mlp.fit(X_train, y_train)

# =========== Visualize Training Results ============
plt.figure(figsize=(12, 4))

# График потерь
plt.subplot(1, 2, 1)
plt.plot(mlp.loss_curve_, label='Training Loss')
plt.xlabel('Iterations')
plt.ylabel('Loss')
plt.title('Training Loss Curve')
plt.legend()

# График точности
plt.subplot(1, 2, 2)
plt.plot(mlp.validation_scores_, label='Validation Accuracy')
plt.xlabel('Iterations')
plt.ylabel('Accuracy')
plt.title('Validation Accuracy Curve')
plt.legend()

plt.show()

# =========== Evaluate Model ============
y_pred = mlp.predict(X_test)

# Точность
accuracy = accuracy_score(y_test, y_pred)
print(f'Точность на тестовой выборке: {accuracy:.4f}')

# Матрица ошибок
conf_matrix = confusion_matrix(y_test, y_pred)
print('Матрица ошибок:')
print(conf_matrix)

# Отчет о классификации
class_report = classification_report(y_test, y_pred)
print('Отчет о классификации:')
print(class_report)
