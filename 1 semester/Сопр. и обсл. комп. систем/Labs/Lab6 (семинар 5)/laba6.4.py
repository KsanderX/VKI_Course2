import cv2
import numpy as np

def load_images(main_image_path, ghost_image_path):
    main_image = cv2.imread(main_image_path, cv2.IMREAD_COLOR)
    ghost_image = cv2.imread(ghost_image_path, cv2.IMREAD_COLOR)
    return main_image, ghost_image

def find_ghosts(main_image, ghost_image):
    orb = cv2.ORB_create()

    # Обнаружение ключевых точек и вычисление дескрипторов
    kp1, des1 = orb.detectAndCompute(main_image, None)
    kp2, des2 = orb.detectAndCompute(ghost_image, None)

    # Сопоставление с использованием Brute-Force
    bf = cv2.BFMatcher(cv2.NORM_HAMMING, crossCheck=True)
    matches = bf.match(des1, des2)

    # Сортировка совпадений
    matches = sorted(matches, key=lambda x: x.distance)

    # Найдите, по крайней мере, 10 лучших совпадений
    if len(matches) >= 10:
        src_pts = np.float32([kp1[m.queryIdx].pt for m in matches]).reshape(-1, 1, 2)
        dst_pts = np.float32([kp2[m.trainIdx].pt for m in matches]).reshape(-1, 1, 2)

        # Найти гомографию
        M, mask = cv2.findHomography(dst_pts, src_pts, cv2.RANSAC, 5.0)

        # Рисуем рамку вокруг найденного призрака
        h, w, _ = ghost_image.shape
        pts = np.float32([[0, 0], [0, h - 1], [w - 1, h - 1], [w - 1, 0]]).reshape(-1, 1, 2)
        dst = cv2.perspectiveTransform(pts, M)
        main_image = cv2.polylines(main_image, [np.int32(dst)], True, (255, 0, 0), 3, cv2.LINE_AA)

    return main_image

def main():
    # Загрузите основное изображение и изображения призраков
    main_image_path = 'house.png'  # Замените на ваше основное изображение
    ghost_image_paths = ['candy_ghost.png', 'pampkin_ghost.png', 'scary_ghost.png']

    main_image = cv2.imread(main_image_path, cv2.IMREAD_COLOR)

    for ghost_image_path in ghost_image_paths:
        ghost_image = cv2.imread(ghost_image_path, cv2.IMREAD_COLOR)
        main_image = find_ghosts(main_image, ghost_image)

    # Отобразить результат
    cv2.imshow('Ghosts Found', main_image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()