num1 = float(input("Podaj pierwszą liczbę: "))
num2 = float(input("Podaj drugą liczbę: "))
op = input("Wybierz operację (+, -, *, /): ")

if op == '+':
    print(f"Wynik: {num1 + num2}")
elif op == '-':
    print(f"Wynik: {num1 - num2}")
elif op == '*':
    print(f"Wynik: {num1 * num2}")
elif op == '/':
    if num2 != 0:
        print(f"Wynik: {num1 / num2}")
    else:
        print("Błąd: Nie można dzielić przez zero!")
else:
    print("Nieznana operacja.")
