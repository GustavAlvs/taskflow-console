
using TaskFlow.Console.Services;

var manager = new TaskManager();
var executando = true;

while (executando)
{
    System.Console.WriteLine("\n=== TaskFlow ===");
    System.Console.WriteLine("1 - Adicionar tarefa");
    System.Console.WriteLine("2 - Listar tarefas");
    System.Console.WriteLine("3 - Concluir tarefa");
    System.Console.WriteLine("4 - Remover tarefa");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("Escolha uma opção: ");

    var opcao = System.Console.ReadLine();

    switch (opcao)
    {
        case "1":
            System.Console.Write("Digite o título da tarefa: ");
            var titulo = System.Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                var tarefa = manager.AddTask(titulo);
                System.Console.WriteLine(
                    $"Tarefa adicionada com ID {tarefa.Id}.");
            }
            else
            {
                System.Console.WriteLine("O título não pode ficar vazio.");
            }

            break;

        case "2":
            var tarefas = manager.GetAllTasks();

            if (tarefas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma tarefa cadastrada.");
                break;
            }

            foreach (var tarefa in tarefas)
            {
                var status = tarefa.IsCompleted
                    ? "Concluída"
                    : "Pendente";

                System.Console.WriteLine(
                    $"{tarefa.Id} - {tarefa.Title} [{status}]");
            }

            break;

        case "3":
            System.Console.Write("Digite o ID da tarefa: ");

            if (int.TryParse(System.Console.ReadLine(), out var idConcluir))
            {
                if (manager.CompleteTask(idConcluir))
                    System.Console.WriteLine("Tarefa concluída!");
                else
                    System.Console.WriteLine("Tarefa não encontrada.");
            }
            else
            {
                System.Console.WriteLine("Digite um ID numérico válido.");
            }

            break;

        case "4":
            System.Console.Write("Digite o ID da tarefa: ");

            if (int.TryParse(System.Console.ReadLine(), out var idRemover))
            {
                if (manager.RemoveTask(idRemover))
                    System.Console.WriteLine("Tarefa removida!");
                else
                    System.Console.WriteLine("Tarefa não encontrada.");
            }
            else
            {
                System.Console.WriteLine("Digite um ID numérico válido.");
            }

            break;

        case "0":
            executando = false;
            System.Console.WriteLine("Encerrando o TaskFlow...");
            break;

        default:
            System.Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
