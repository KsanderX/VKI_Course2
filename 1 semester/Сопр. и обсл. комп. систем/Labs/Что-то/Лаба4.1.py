import numpy as np
import sys

def load_data(file_path):
    """Загрузка данных из файла и преобразование в массив NumPy."""
    return np.loadtxt(file_path, dtype=int)

def mix_data_method_1(real_data, synthetic_data, P):
    """Первый способ: выбираем синтетические данные с вероятностью P."""
    random_choice = np.random.rand(len(real_data)) < P
    mixed_data = np.where(random_choice, synthetic_data, real_data)
    return mixed_data

def mix_data_method_2(real_data, synthetic_data, P):
    """Второй способ: случайная выборка без изменения порядка."""
    indices = np.arange(len(real_data))
    # Выбираем случайные индексы для замены синтетическими данными
    swap_indices = np.random.choice(indices, size=int(P * len(real_data)), replace=False)
    mixed_data = np.copy(real_data)
    # Заменяем реальные данные на синтетические в выбранных индексах
    mixed_data[swap_indices] = synthetic_data[swap_indices]
    return mixed_data

if __name__ == "__main__":
    # Проверка корректности входных аргументов
    if len(sys.argv) != 4:
        print("Использование: python random_select.py <file_1> <file_2> <P>")
        sys.exit(1)

    file_1 = sys.argv[1]
    file_2 = sys.argv[2]
    P = float(sys.argv[3])

    # Загружаем данные
    real_data = load_data(file_1)
    synthetic_data = load_data(file_2)

    if len(real_data) != len(synthetic_data):
        print("Данные из файлов должны быть одинаковой длины.")
        sys.exit(1)

    # Перемешивание данных двумя разными способами
    mixed_data_1 = mix_data_method_1(real_data, synthetic_data, P)
    mixed_data_2 = mix_data_method_2(real_data, synthetic_data, P)

    # Вывод результата
    print("Результат первого метода:", mixed_data_1)
    print("Результат второго метода:", mixed_data_2)