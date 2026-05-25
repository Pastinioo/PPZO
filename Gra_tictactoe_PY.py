class Player:
    def __init__(self, name: str, symbol: str):
        self.name = name
        self.symbol = symbol

class Board:
    def __init__(self):
        # Inicjalizujemy planszę jako listę 9 pustych znaków
        self.grid = [' ' for _ in range(9)]

    def display(self):
        print("\n")
        print(f" {self.grid[0]} | {self.grid[1]} | {self.grid[2]} ")
        print("---+---+---")
        print(f" {self.grid[3]} | {self.grid[4]} | {self.grid[5]} ")
        print("---+---+---")
        print(f" {self.grid[6]} | {self.grid[7]} | {self.grid[8]} ")
        print("\n")

    def make_move(self, position: int, symbol: str) -> bool:
        # Sprawdzamy, czy pole mieści się w zakresie 0-8 i czy jest puste
        if 0 <= position <= 8 and self.grid[position] == ' ':
            self.grid[position] = symbol
            return True
        return False

    def check_winner(self, symbol: str) -> bool:
        # Możliwe wygrywające kombinacje
        win_conditions = [
            (0, 1, 2), (3, 4, 5), (6, 7, 8),  # Wiersze
            (0, 3, 6), (1, 4, 7), (2, 5, 8),  # Kolumny
            (0, 4, 8), (2, 4, 6)              # Przekątne
        ]
        for a, b, c in win_conditions:
            if self.grid[a] == self.grid[b] == self.grid[c] == symbol:
                return True
        return False

    def is_full(self) -> bool:
        return ' ' not in self.grid

class Game:
    def __init__(self, player1: Player, player2: Player):
        self.player1 = player1
        self.player2 = player2
        self.board = Board()
        self.current_turn = 0  # Licznik tur do określania, czyj jest ruch

    def play(self):
        print("Rozpoczynamy grę w Kółko i Krzyżyk!")
        print("Pola na planszy są ponumerowane od 1 do 9 (od lewej do prawej, z góry na dół).")
        self.board.display()

        while True:
            # Ustalenie, kto teraz wykonuje ruch
            current_player = self.player1 if self.current_turn % 2 == 0 else self.player2

            try:
                move_input = int(input(f"{current_player.name} ({current_player.symbol}), wybierz pole (1-9): "))
                position = move_input - 1  # Konwersja na indeks od 0 do 8

                if self.board.make_move(position, current_player.symbol):
                    self.board.display()

                    # Sprawdzenie wygranej
                    if self.board.check_winner(current_player.symbol):
                        print(f"Gratulacje! {current_player.name} wygrywa!")
                        break
                    
                    # Sprawdzenie remisu
                    if self.board.is_full():
                        print("Koniec gry! Mamy remis.")
                        break

                    # Zmiana tury
                    self.current_turn += 1
                else:
                    print("To pole jest zajęte lub nieprawidłowe. Spróbuj ponownie.")
            except ValueError:
                print("Błąd: Proszę podać liczbę od 1 do 9.")


# ---------- Test w bloku głównym ----------
if __name__ == "__main__":
    p1 = Player("Gracz 1", "X")
    p2 = Player("Gracz 2", "O")
    
    tic_tac_toe = Game(p1, p2)
    tic_tac_toe.play()