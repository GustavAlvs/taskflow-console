# TaskFlow Console

Aplicação de console desenvolvida em C# com .NET 10 para gerenciamento de tarefas em memória.

## Funcionalidades

- Adicionar tarefas com ID automático.
- Listar todas as tarefas cadastradas.
- Marcar tarefas como concluídas.
- Remover tarefas pelo ID.
- Tratar buscas por IDs inexistentes.
- Executar testes unitários com xUnit.

## Requisitos

- .NET SDK 10.0 ou superior.
- Terminal ou PowerShell.

## Como compilar

Na pasta raiz do projeto, execute:

```bash
dotnet build
```

## Como executar

Execute o comando:

```bash
dotnet run --project TaskFlow.Console
```

## Como executar os testes

Para rodar os testes unitários:

```bash
dotnet test
```

## Estrutura do projeto

- `TaskFlow.Console`: aplicação principal.
- `TaskFlow.Console/Domain`: entidade `TaskItem`.
- `TaskFlow.Console/Services`: gerenciamento das tarefas com `TaskManager`.
- `TaskFlow.Tests`: testes unitários com xUnit.

## Observação

As tarefas são armazenadas em memória e não são persistidas após o encerramento da aplicação.