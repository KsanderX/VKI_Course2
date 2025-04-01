import cv2
import numpy as np
from matplotlib import pyplot as plt

# Загружаем изображение
image = cv2.imread('ironman1.jpg')

# Отображаем оригинальное изображение
plt.subplot(2, 3, 1)
plt.imshow(cv2.cvtColor(image, cv2.COLOR_BGR2RGB))
plt.title('Оригинал')
plt.axis('off')

# Применяем Gaussian Blur
gaussian_blur = cv2.GaussianBlur(image, (5, 5), 0)
plt.subplot(2, 3, 2)
plt.imshow(cv2.cvtColor(gaussian_blur, cv2.COLOR_BGR2RGB))
plt.title('Gaussian Blur')
plt.axis('off')

# Применяем Median Blur
median_blur = cv2.medianBlur(image, 5)
plt.subplot(2, 3, 3)
plt.imshow(cv2.cvtColor(median_blur, cv2.COLOR_BGR2RGB))
plt.title('Median Blur')
plt.axis('off')

# Применяем фильтр резкости
sharpen_filter = np.array([[0, -1, 0],
                            [-1, 5, -1],
                            [0, -1, 0]])
sharpened_image = cv2.filter2D(image, -1, sharpen_filter)
plt.subplot(2, 3, 4)
plt.imshow(cv2.cvtColor(sharpened_image, cv2.COLOR_BGR2RGB))
plt.title('Sharpen')
plt.axis('off')

# Преобразуем в черно-белое изображение
gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
plt.subplot(2, 3, 5)
plt.imshow(gray_image, cmap='gray')
plt.title('Чёрно-белое')
plt.axis('off')

# Отображаем все результаты
plt.tight_layout()
plt.show()
