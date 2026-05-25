wybor = input("Wybierz kierunek konwersji (C -> na Fahrenheity, F -> na Celsjusze): ").upper()
temp = float(input("Podaj wartość temperatury: "))

# Logika konwersji
if wybor == 'C':
    f = temp * 1.8 + 32
    print(f"{temp}°C = {f:.2f}°F")
elif wybor == 'F':
    c = (temp - 32) / 1.8
    print(f"{temp}°F = {c:.2f}°C")
else:
    print("Nieprawidłowy wybór kierunku konwersji.")
