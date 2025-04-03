import matplotlib.pyplot as plt
import cv2
import numpy as np


image = cv2.imread('ironman1.jpg')

# Преобразуем в черно-белое изображение
gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
plt.imshow(gray_image, cmap='gray')
plt.title('Чёрно-белое')
plt.axis('off')

# Отображаем все результаты
plt.show()
