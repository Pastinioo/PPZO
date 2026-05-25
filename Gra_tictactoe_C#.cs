using System;

public class Player
{
    public string Name { get; }
    public char Symbol { get; }

    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}

public class Board
{
    private readonly char[] grid;

    public Board()
    {
        // Inicjalizujemy planszę jako tablicę 9 pustych znaków
        grid = new char[9];
        for (int i = 0; i < 9; i++)
        {
            grid[i] = ' ';
        }
    }

    public void Display()
    {
        Console.WriteLine("\n");
        Console.WriteLine($" {grid[0]} | {grid[1]} | {grid[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {grid[3]} | {grid[4]} | {grid[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {grid[6]} | {grid[7]} | {grid[8]} ");
        Console.WriteLine("\n");
    }

    public bool MakeMove(int position, char symbol)
    {
        // Sprawdzamy, czy pole mieści się w zakresie 0-8 i czy jest puste
        if (position >= 0 && position < 9 && grid[position] == ' ')
        {
            grid[position] = symbol;
            return true;
        }
        return false;
    }

    public bool CheckWinner(char symbol)
    {
        // Możliwe wygrywające kombinacje
        int[,] winConditions = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Wiersze
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Kolumny
            {0, 4, 8}, {2, 4, 6}             // Przekątne
        };

        for (int i = 0; i < 8; i++)
        {
            if (grid[winConditions[i, 0]] == symbol &&
                grid[winConditions[i, 1]] == symbol &&
                grid[winConditions[i, 2]] == symbol)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        foreach (char c in grid)
        {
            if (c == ' ') return false;
        }
        return true;
    }
}

public class Game
{
    private readonly Board board;
    private readonly Player player1;
    private readonly Player player2;
    private int currentTurn;

    public Game(Player p1, Player p2)
    {
        player1 = p1;
        player2 = p2;
        board = new Board();
        currentTurn = 0;
    }

    public void Play()
    {
        Console.WriteLine("Rozpoczynamy grę w Kółko i Krzyżyk!");
        Console.WriteLine("Pola na planszy są ponumerowane od 1 do 9 (od lewej do prawej, z góry na dół).");
        board.Display();

        while (true)
        {
            // Ustalenie, kto teraz wykonuje ruch
            Player currentPlayer = (currentTurn % 2 == 0) ? player1 : player2;

            Console.Write($"{currentPlayer.Name} ({currentPlayer.Symbol}), wybierz pole (1-9): ");

            // Wczytanie i sprawdzenie poprawności wejścia
            if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9)
            {
                int position = move - 1; // Konwersja na indeks od 0 do 8

                if (board.MakeMove(position, currentPlayer.Symbol))
                {
                    board.Display();

                    // Sprawdzenie wygranej
                    if (board.CheckWinner(currentPlayer.Symbol))
                    {
                        Console.WriteLine($"Gratulacje! {currentPlayer.Name} wygrywa!");
                        break;
                    }

                    // Sprawdzenie remisu
                    if (board.IsFull())
                    {
                        Console.WriteLine("Koniec gry! Mamy remis.");
                        break;
                    }

                    // Zmiana tury
                    currentTurn++;
                }
                else
                {
                    Console.WriteLine("To pole jest zajęte lub nieprawidłowe. Spróbuj ponownie.");
                }
            }
            else
            {
                Console.WriteLine("Błąd: Proszę podać liczbę od 1 do 9.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Player p1 = new Player("Gracz 1", 'X');
        Player p2 = new Player("Gracz 2", 'O');

        Game ticTacToe = new Game(p1, p2);
        ticTacToe.Play();
    }
}
