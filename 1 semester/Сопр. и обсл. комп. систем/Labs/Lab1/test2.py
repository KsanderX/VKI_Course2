import random 

def multi_task():   
    print("Игра в задачи!")
    print("Реши 4 задачи")
    score = 0 
    for i in range(4):
        num1 = random.randint(1, 10) 
        num2 = random.randint(1, 10) 
        answer = num1 * num2
        user_answer = int(input(f"Сколько будет {num1} * {num2}= "))
        if user_answer == answer:
            print("Правильно! Ты молодец!")
            score += 1
        else:
            print(f"Неправильно! Правильный ответ {answer}")
    print(f"Верно решил {score} из 4.") 

multi_task()
