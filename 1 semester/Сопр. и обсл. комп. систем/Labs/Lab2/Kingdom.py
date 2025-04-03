import random

class Hero:
    def __init__(self, name, level=1, health=100, power=10):
        self.name = name
        self.level = level
        self.health = health
        self.power = power

    def go_on_scouting(self):
        success = random.choice([True, False])  # 50% шанс на успех
        return success


class Warrior(Hero):
    def __init__(self, name, level=1, health=120, power=15):
        super().__init__(name, level, health, power)

    def attack(self, enemy_level):
        # Логика атаки воина
        if self.level >= enemy_level:
            print(f"{self.name} победил противника!")
            return True  # Победа
        return False  # Поражение


class Mage(Hero):
    def __init__(self, name, level=1, health=80, power=10, mana=50):
        super().__init__(name, level, health, power)
        self.mana = mana

    def cast_spell(self, enemy_level):
        # Логика магической атаки
        if self.mana >= 10 and self.level >= enemy_level:
            self.mana -= 10  # Расход маны
            print(f"{self.name} использовал заклинание и победил противника!")
            return True  # Победа
        print(f"{self.name} не смог победить противника...")
        return False  # Поражение


class Kingdom:
    def __init__(self):
        self.food = 100
        self.territory = 50
        self.heroes = []

    def add_hero(self, hero):
        self.heroes.append(hero)

    def feed_people(self):
        if self.food > 0:
            self.food -= len(self.heroes) * 2  # Расход пищи на героев
            print(f"Королевство накормлено! Осталось продовольствия: {self.food}")
        else:
            print("Нехватка продовольствия! Жители могут поднять бунт!")

    def manage_resources(self, success):
        if success:
            gained_food = random.randint(10, 30)
            gained_territory = random.randint(5, 15)
            self.food += gained_food
            self.territory += gained_territory
            print(f"Успешная разведка! Получено {gained_food} продовольствия и {gained_territory} территорий!")
        else:
            lost_food = random.randint(5, 20)
            lost_territory = random.randint(3, 10)
            self.food -= lost_food
            self.territory -= lost_territory
            print(f"Неудачная разведка! Потеряно {lost_food} продовольствия и {lost_territory} территорий!")

        if self.food < 0 or self.territory < 0:
            self.rebellion()

    def rebellion(self):
        print("Бунт в королевстве! Игра окончена.")
        exit()

    def scouting(self):
        for hero in self.heroes:
            success = hero.go_on_scouting()
            self.manage_resources(success)

            if success:
                enemy_level = random.randint(1, 3)  # Уровень противника
                print(f"{hero.name} встретил противника уровня {enemy_level}!")
                action = input("Хотите сразиться или избежать боя? (fight/run): ").strip().lower()

                if action == "fight":
                    if isinstance(hero, Warrior):
                        if hero.attack(enemy_level):
                            self.manage_resources(True)
                        else:
                            self.manage_resources(False)
                    elif isinstance(hero, Mage):
                        if hero.cast_spell(enemy_level):
                            self.manage_resources(True)
                        else:
                            self.manage_resources(False)
                else:
                    print(f"{hero.name} избежал боя.")
            else:
                print(f"{hero.name} не удалось выполнить разведку.")


# Пример игрового процесса:
kingdom = Kingdom()
hero1 = Warrior("Рыцарь Артур")
hero2 = Mage("Маг Гэндальф")

kingdom.add_hero(hero1)
kingdom.add_hero(hero2)

while True:
    kingdom.feed_people()
    kingdom.scouting()