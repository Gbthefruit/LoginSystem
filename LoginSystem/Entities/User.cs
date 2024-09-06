using LoginSystem.Models;

namespace LoginSystem.Entities;

internal class User
{
    private string? _register;
    private string? _login;
    public string? Name { get;  set; } 
   
    public User() { }
    public User(string name) 
    {
        Name = name;
    }

    public void Register(string file) // Método responsável por criar e adicionar dados do usuário ao arquivo txt.
    {
        Console.Clear();

        try
        {
            using var data = File.AppendText(file);

            while (true)
            {
                Console.WriteLine("Sempre pode ser uma boa hora para começar!\n");

                Console.Write("Registre um nome: ");
                string? name = Console.ReadLine();

                if (name == null || name.Length < 4)
                {
                    Console.WriteLine("\nError! Digite um nome com mais de 4 carácteres.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.Write("Registre uma senha: ");
                    string? password = Console.ReadLine();

                    if (password == null || password.Length < 4)
                    {
                        Console.WriteLine("\nError! Digite uma senha com mais de 4 carácteres.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        User user = new User(name);

                        Console.Write("\nCadastrando dados");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(1000);
                            Console.Write(".");
                        }

                        _register = $"{name}{password}\n";
                        data.Write(_register);

                        break;
                    }
                }
            }
        }
        catch (Exception Error)
        {
            Console.WriteLine(Error.Message);
        }
        finally
        {
            Console.WriteLine("\n\nAgora você pode logar!");
            Thread.Sleep(2000);
        }
    }

    public void Login(string file) // Método responsável por verificar a existência do arquivo txt, e também verificar se á dados registrados pelo usuário.
    {
        Console.Clear();
        try
        {
            if (File.Exists(file))
            {
                var usersData = File.ReadAllText(file);

                if (usersData.Length != 0)
                {
                    while (true)
                    {
                        Console.WriteLine("Conecte-se e não fique para trás!\n");

                        Console.Write("Login: ");
                        string login = Console.ReadLine()!;

                        Console.Write("Senha: ");
                        string password = Console.ReadLine()!;

                        _login = $"{login}{password}";
                        if (usersData.Contains(_login) && login.Length > 1 && password.Length > 1)
                        {
                            Name = login;

                            Thread.Sleep(1000);
                            Console.WriteLine("\nLogado com Sucesso!");
                            Thread.Sleep(2000);
                            Console.Clear();

                            while (true)
                            {
                                Console.WriteLine($"Seja Bem Vindo ao Sistema {Name}\n");
                                Console.WriteLine($"Digite 'Desconectar' para desconectar.\n");

                                string option = Console.ReadLine()!.ToUpper();

                                if (option.Contains("DESCONECTAR"))
                                {
                                    Console.Write("\nDesconectando");
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Thread.Sleep(1000);
                                        Console.Write(".");
                                    }
                                    break;
                                }
                                else { Console.WriteLine("\nOpção Inválida."); Console.Clear(); }   
                            }
                            Interface.Menu();
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\nLogin ou Senha inválidos!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Banco de dados vazio. Crie uma conta!");
                    Thread.Sleep(1500);
                    Register(file);
                    Interface.Menu();
                }
            }
            else
            {
                Console.WriteLine("Banco de dados vazio. Crie uma conta!");
                Thread.Sleep(1500);
                Register(file);
                Interface.Menu();
            }
        }
        catch (Exception Error)
        {
            Console.WriteLine(Error.Message);
        }
    }
}
