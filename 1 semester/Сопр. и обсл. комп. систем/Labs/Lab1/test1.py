import random

def number_guessing_game():
  

  secret_number = random.randint(1, 100)
  attempts = 0

  print("Угадай число от 1 до 100 ^_^")

  while True:
    try:
      number = int(input("Введите число: "))
      attempts += 1

      if number < secret_number:
        print(f"Это не {number} ! Введите число побольше.")
      elif number > secret_number:
        print(f"Это не {number} ! Введите число поменьше.")
      else:
        print(f"Поздравляю! Ты угадал число {secret_number} за {attempts} попыток!")
        break 
    except ValueError:
      print("Некорректный ввод. Пожалуйста, введите целое число.")

if __name__ == "__main__":
  number_guessing_game() 
  