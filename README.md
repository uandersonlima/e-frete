# e-frete


Prova técnica composta por 3 testes.

1- FizzBuzz
2- Números Romanos
3- Aplicação CEP


Existem 2 pastas dentro do projeto, a primeira source contém a aplicação e suas camadas. a segunda tests, possuem as provas técnicas FizzBuzz e Números Romanos.


1 - Rodando a aplicação.
    Para rodar a aplicação, é necessário instalar a SDK .NET 7.0 da microsoft, uma vez instalada em seu computador, basta dar um dotnet restore, ou em caso de visual studio community, esperar que as dependências sejam resolvidas.
    O coração da aplicação é efrete.WebApp.MVC, para executá-lo basta rodar esse projeto.

    A aplicação possui ao todo 5 telas, 1 tela de apresentação, 2 telas de consultas e 2 telas de respostas, uma para cada tela de consulta.

    o comando via CLI para rodar a aplicação é o dotnet run.


2. Tests

    Apenas teste do automapper realizado na camada de aplicação, para executar é simples, bastar restaurar a dependencias e utilizar o dotnet test.
    Demais camadas funcionamento simples, modelo sem comportamentos expressivos.

