import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
from sklearn.datasets import load_sample_image
from PIL import Image

# Загрузка изображения
china = load_sample_image("china.png")

# Отображение исходного изображения
plt.figure(figsize=(10, 5))
ax = plt.axes(xticks=[], yticks=[])
ax.imshow(china)
plt.title('Original Image')
plt.show()

# Преобразование изображения в массив numpy
image_array = np.array(china)

# Преобразование массива в формат, подходящий для кластеризации
pixels = image_array.reshape(-1, 3)

# Применение K-Means для кластеризации цветов
n_colors = 16  # Количество цветов после сжатия
kmeans = KMeans(n_clusters=n_colors, random_state=0)
kmeans.fit(pixels)

# Замена цветов пикселей на центроиды кластеров
compressed_pixels = kmeans.cluster_centers_[kmeans.labels_]

# Восстановление изображения
compressed_image_array = compressed_pixels.reshape(image_array.shape)
compressed_image = Image.fromarray(np.uint8(compressed_image_array))

# Отображение сжатого изображения
plt.figure(figsize=(10, 5))
ax = plt.axes(xticks=[], yticks=[])
ax.imshow(compressed_image)
plt.title(f'Compressed Image ({n_colors} colors)')
plt.show()