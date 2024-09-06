using LoginSystem.Entities;

namespace LoginSystem.Models;

public class Interface
{
    const string file = @"C:\UserData\UserData.txt";

    public static void Menu()
    {
        User user = new();

        Console.Clear();

        Console.WriteLine("Olá! Para utilizar o app você precisa logar.\nCaso não tenha uma conta você pode se registrar.\n");
        Console.WriteLine("[1] Entrar com uma conta\n[2] Registrar uma nova conta\n[3] Fechar App\n");

        Console.Write("O que deseja? ");
        try
        {
            int option = int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    user.Login(file);
                    break;
                case 2:
                    user.Register(file);
                    Menu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("App Finalizado");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nUtilize somente números para a escolha de opções.");
            Thread.Sleep(1500);
            Menu();
        }
    }
}
