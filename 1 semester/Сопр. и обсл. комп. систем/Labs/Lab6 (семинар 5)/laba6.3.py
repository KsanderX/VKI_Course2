import cv2
import numpy as np

def count_contours(image_path):   

    # Загрузка изображения
    img = cv2.imread(image_path)

    # Преобразование в оттенки серого
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # Применение фильтра Кэнни для обнаружения границ
    edges = cv2.Canny(gray, 50, 150)

    # Нахождение контуров
    contours, hierarchy = cv2.findContours(edges, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

    # Подсчет количества контуров
    num_contours = len(contours)

    # Отображение контуров на исходном изображении
    cv2.drawContours(img, contours, -1, (0, 0, 255), 2)

    # Вывод количества контуров
    print(f"Количество найденных контуров: {num_contours}")

    # Отображение результатов  
    cv2.imshow("Исходное изображение", img)
    cv2.imshow("Границы (Canny)", edges)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

if __name__ == "__main__":
    image_path = "ironman1.jpg"
    count_contours(image_path)