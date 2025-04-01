import pygame
import time
import random

# Инициализация Pygame
pygame.init()

# Определение цветов
black = (0, 0, 0)
red = (213, 50, 80)
green = (3, 153, 36)

# Размеры окна
dis_width = 600
dis_height = 400

# Создание окна
dis = pygame.display.set_mode((dis_width, dis_height))
pygame.display.set_caption('Snake Game')

# Время
clock = pygame.time.Clock()

# Размер блока змейки
snake_block = 10
# Скорость змейки
snake_speed = 15

# Функция для отображения счёта
def Your_score(score):
    font_style = pygame.font.SysFont(None, 30)
    value = font_style.render("Your Score: " + str(score), True, red)
    dis.blit(value, [0, 0])

# Функция для создания змейки
def our_snake(snake_block, snake_list):
    for x in snake_list:
        pygame.draw.rect(dis, black, [x[0], x[1], snake_block, snake_block])

# Основная игра
def gameLoop():
    game_over = False
    game_close = False

    x1 = dis_width / 2 # Начальная позиция змейки по оси x
    y1 = dis_height / 2 # Начальная позиция змейки по оси y
    x1_change = 0 # Изменение координаты x
    y1_change = 0 # Изменение координаты y

    snake_list = [] # Список блоков змейки
    snake_length = 1 # Длина змейки

    # Начальное положение еды
    foodx = round(random.randrange(0, dis_width - snake_block) / 10.0) * 10.0
    foody = round(random.randrange(0, dis_height - snake_block) / 10.0) * 10.0

    while not game_over:
        while game_close == True:
            dis.fill(green)
            message = "You Lost! Press Q-Quit or C-Play Again"
            pygame.display.set_caption(message)
            Your_score(snake_length - 1)
            pygame.display.update()

            # Обработка событий в режиме завершения игры
            for event in pygame.event.get():
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_q:
                        game_over = True
                        game_close = False
                    if event.key == pygame.K_c:
                        gameLoop() # Запуск новой игры

        # Обработка событий в режиме игры
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                game_over = True
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_LEFT:
                    x1_change = -snake_block
                    y1_change = 0
                elif event.key == pygame.K_RIGHT:
                    x1_change = snake_block
                    y1_change = 0
                elif event.key == pygame.K_UP:
                    y1_change = -snake_block
                    x1_change = 0
                elif event.key == pygame.K_DOWN:
                    y1_change = snake_block
                    x1_change = 0

        # Обновление позиции змейки
        if x1 >= dis_width or x1 < 0 or y1 >= dis_height or y1 < 0:
            game_close = True
        x1 += x1_change
        y1 += y1_change
        dis.fill(green)

        # Создание списка блоков змейки
        snake_head = [x1, y1]
        snake_list.append(snake_head)

        # Удаление хвоста, если змейка не съела еду
        if len(snake_list) > snake_length:
            del snake_list[0]

        # Проверка столкновения змейки с самой собой
        for x in snake_list[:-1]:
            if x == snake_head:
                game_close = True

        # Отрисовка еды
        our_snake(snake_block, snake_list)
        pygame.draw.rect(dis, red, [foodx, foody, snake_block, snake_block])
        Your_score(snake_length - 1)

        # Обновление экрана
        pygame.display.update()

        # Установка скорости игры
        clock.tick(snake_speed)

        # Создание новой еды, если змейка ее съела
        if x1 == foodx and y1 == foody:
            foodx = round(random.randrange(0, dis_width - snake_block) / 10.0) * 10.0
            foody = round(random.randrange(0, dis_height - snake_block) / 10.0) * 10.0
            snake_length += 1

    # Выход из игры
    pygame.quit()
    quit()

# Запуск игры
gameLoop()