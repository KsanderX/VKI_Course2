import random

def виселица():  

    word = ["python", "javascript", "programming", "computer", "science","code" ]
    word = random.choice(word)
    list_letters = list(word)
    empty_word = ["_"] * len(word)
    attemp = 6

    print("Добро пожаловать в Виселицу!")

    while attemp > 0:
        print("Слово:", " ".join(empty_word))
        print("Оставшиеся попытки:", attemp)

        entered_letter = input("Введите букву: ").lower()

        if len(entered_letter) != 1 or not entered_letter.isalpha():
            print("Пожалуйста, введите одну букву.")
            continue

        if entered_letter in list_letters:
            print("Верно!")
            for i in range(len(list_letters)):
                if list_letters[i] == entered_letter:
                    empty_word[i] = entered_letter
        else:
            print("Неверно!")
            attemp -= 1

        if "_" not in empty_word:
            print("Поздравляем! Вы угадали слово:", word)
            break

    if "_" in empty_word:
        print("Вы проиграли! Слово было:", word)

виселица()

