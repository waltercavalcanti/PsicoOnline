# PsicoOnline

PsicoOnline é uma aplicação para apoiar a rotina de atendimento de psicólogos. Fornece uma API REST para gerenciar dados clínicos e administrativos e uma interface web para interação com os recursos da aplicação.

## Objetivo

Permitir o cadastro e o gerenciamento de pacientes, responsáveis, registros de sessão e informações relacionadas (como grau de parentesco), facilitando o registro e a consulta de atendimentos psicológicos.

## Principais funcionalidades

- Cadastro e gerenciamento de `Paciente` (dados pessoais, histórico básico).
- Cadastro e gerenciamento de `Responsavel` (contatos ou responsáveis legais).
- Registro, listagem e consulta de `Sessao` (registros de atendimento, datas e observações).
- Gestão de `GrauParentesco` (tipos de vínculo entre paciente e responsável).
- API REST para consumo por clientes (UI, integrações externas).
- Interface web (Blazor) para uso pelos profissionais.

## Arquitetura do repositório

O projeto está organizado em camadas para separar responsabilidades:

- `PsicoOnline.Core` — modelos de domínio e regras de negócio.
- `PsicoOnline.Infrastructure` — implementação de persistência e integracões (banco de dados, repositórios).
- `PsicoOnline.WebApi` — API REST (controllers como `PacienteController`, `ResponsavelController`, `SessaoController`, `GrauParentescoController`).
- `PsicoOnline.UI` — aplicação cliente (Blazor) que consome a API.

## Tecnologias

- .NET 10
- C#
- ASP.NET Core Web API
- Blazor (UI)

## Como executar localmente

1. Restaurar dependências e compilar:

   ```
   dotnet restore
   dotnet build
   ```

2. Executar os projetos:

   - API: entre em `src/PsicoOnline.WebApi` e rode `dotnet run`.
   - UI: entre em `src/PsicoOnline.UI` e rode `dotnet run`.

3. Acesse a interface web no navegador usando a URL informada pelo comando `dotnet run`, ou consuma a API nas rotas expostas pelos controllers.

## Observações

- Verifique os arquivos de configuração (`appsettings.json`) em cada projeto para ajustar conexões e outras configurações.
- Para detalhes de implementação, explore os diretórios em `src/`.