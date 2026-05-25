n = int(input("Podaj liczbę ocen: "))

suma_ocen = 0

for i in range(n):
    ocena = float(input(f"Podaj ocenę nr {i+1}: "))
    suma_ocen += ocena

if n > 0:
    srednia = suma_ocen / n
    print(f"\nŚrednia: {srednia:.2f}")
    
    if srednia >= 3.0:
        print("Uczeń zdał.")
    else:
        print("Uczeń nie zdał.")
else:
    print("Brak wprowadzonych ocen.")