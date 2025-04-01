import random

class Hero:
    def __init__(self, name, level=2, health=999, power=999):
        self.name = name
        self.level = level
        self.health = health
        self.power = power
    def go_on_scouting(self):
        # Разведка имеет случайный шанс успеха
        success = random.choice([True, False])
        return success

    def take_damage(self, damage):
        self.health -= damage
        if self.health <= 0:
            print(f"{self.name} Герой погиб!")
            return False  # Герой погиб
        return True

class Warrior(Hero):
    def __init__(self, name, level=2, health=999, power=999):
        super().__init__(name, level, health, power)

    def attack(self, enemy_level):
        # Логика атаки воина
        print(f"{self.name} атакует противника уровня {enemy_level}.")
        if self.level >= enemy_level:
            print(f"{self.name} побеждает!")
            return True  # Победа
        print(f"{self.name} проигрывает!")
        return False  # Поражение

class Mage(Hero):
    def __init__(self, name, level=1, health=999, power=999, mana=999):
        super().__init__(name, level, health, power)
        self.mana = mana

    def cast_spell(self, enemy_level):
        # Логика магической атаки
        print(f"{self.name} использует заклинание против противника уровня {enemy_level}.")
        if self.mana >= 10 and self.level >= enemy_level:
            self.mana -= 10  # Расход маны
            print(f"{self.name} побеждает!")
            return True  # Победа
        print(f"{self.name} не хватает маны или силы.")
        return False  # Поражение

class Enemy:
    def __init__(self, level):
        self.level = level
        self.health = level * 20
        self.power = level * 5

class Kingdom:
    def __init__(self):
        self.food = 100
        self.territory = 50
        self.heroes = []

    def add_hero(self, hero):
        self.heroes.append(hero)

    def feed_people(self):
        self.food -= 10
        if self.food <= 0:
            print("Не хватает продовольствия для населения!")
            return False  # Бунт
        return True

    def manage_resources(self, success, enemy_level=0):
        if success:
            self.food += enemy_level * 5
            self.territory += enemy_level * 2
            print(f"Королевство увеличило свои ресурсы: +{enemy_level * 5} еды и +{enemy_level * 4} территорий.")
        else:
            self.food -= enemy_level * 3
            self.territory -= enemy_level * 2
            print(f"Королевство потеряло ресурсы: -{enemy_level * 3} еды и -{enemy_level * 2} территорий.")

    def random_enemy_encounter(self):
        # Случайный уровень противника
        enemy_level = random.randint(1, 5)
        return Enemy(enemy_level)

    def check_resources(self):
        if self.food <= 0 or self.territory <= 0:
            print("Королевство в упадке! Бунт жителей завершает игру.")
            return False
        return True

    def play_turn(self):
        hero = random.choice(self.heroes)  # Случайный выбор героя
        print(f"Герой {hero.name} отправляется на разведку.")
        if hero.go_on_scouting():
            print(f"Разведка {hero.name} прошла успешно!")
            if random.choice([True, False]):
                enemy = self.random_enemy_encounter()
                print(f"Герой встречает противника уровня {enemy.level}.")
                action = input(f"Сражаться или убежать? (fight/run): ").strip().lower()
                if action == "fight":
                    success = False
                    if isinstance(hero, Warrior):
                        success = hero.attack(enemy.level)
                    elif isinstance(hero, Mage):
                        success = hero.cast_spell(enemy.level)

                    self.manage_resources(success, enemy.level)
                else:
                    print(f"{hero.name} решает избежать боя.")
            else:
                print(f"Разведка {hero.name} не принесла результатов.")
        self.check_resources()

# Пример игрового процесса:
kingdom = Kingdom()
hero1 = Warrior("Рыцарь Александр")
hero2 = Mage("Маг Гарри Поттер")

kingdom.add_hero(hero1)
kingdom.add_hero(hero2)




# Главный игровой цикл
while True:
    if not kingdom.feed_people():
        break  # Если не хватает продовольствия, игра прекращается
    kingdom.play_turn()