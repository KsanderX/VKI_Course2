import cv2
import numpy as np
import random

def augment_image(image):
    # Поворот на случайный угол
    angle = random.uniform(-30, 30)
    h, w = image.shape[:2]
    M = cv2.getRotationMatrix2D((w // 2, h // 2), angle, 1.0)
    rotated_image = cv2.warpAffine(image, M, (w, h))

    # Отражение по вертикали и горизонтали
    if random.choice([True, False]):
        rotated_image = cv2.flip(rotated_image, 0)  # вертикальное отражение
    if random.choice([True, False]):
        rotated_image = cv2.flip(rotated_image, 1)  # горизонтальное отражение

    # Вырезание части изображения
    h, w = rotated_image.shape[:2]
    x = random.randint(0, w // 4)
    y = random.randint(0, h // 4)
    cropped_image = rotated_image[y:h-y, x:w-x]

    # Размытие
    if random.choice([True, False]):
        cropped_image = cv2.GaussianBlur(cropped_image, (5, 5), 0)

    # Приведение к одному размеру (например, 224x224)
    resized_image = cv2.resize(cropped_image, (224, 224))

    return resized_image

def image_generator(images):
    while True:
        for image in images:
            yield augment_image(image)

# Пример использования генератора
if __name__ == "__main__":
    # Загрузка списка изображений
    image_paths = ['ironman1.jpg', 'robert1.jpg', 'tom1.jpg']
    images = [cv2.imread(path) for path in image_paths]
    
    gen = image_generator(images)
    
    # Генерация и отображение 5 примеров
    for _ in range(5):
        augmented_image = next(gen)
        cv2.imshow('Augmented Image', augmented_image)
        cv2.waitKey(2000)  # Отображение в течение 3000 мс
    cv2.destroyAllWindows()