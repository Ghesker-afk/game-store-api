A API foi desenvolvida com:

.NET 8+
ASP.NET Core Minimal APIs
Entity Framework Core
DTOs (Data Transfer Objects)
Métodos de extensão para mapeamento entre entidades e DTOs

Os endpoints da aplicação estão organizados em dois grupos principais:
/games
/genres

Cada grupo contém operações específicas relacionadas ao domínio tratado.
Abaixo está uma documentação completa e centralizada desses recursos.


GET /games
Retorna uma lista contendo o resumo de todos os jogos cadastrados.
O resultado inclui dados essenciais, como nome, preço e gênero.

GET /games/{id}
Busca um jogo específico utilizando seu ID.
Caso o jogo exista, a API retorna o DTO de detalhes contendo todos os dados relevantes.
Se o jogo não for encontrado, é retornado 404 Not Found.

POST /games
Cria um novo registro de jogo no banco de dados.

PUT /games/{id}
Atualiza os dados de um jogo existente.
Primeiro, a API tenta localizar o jogo pelo ID.
Caso não exista, retorna 404 Not Found.

DELETE /games/{id}
Remove um jogo pelo ID.


GET /genres
Retorna todos os gêneros cadastrados na base.

Resumo Técnico da Arquitetura
A API foi projetada com boas práticas de organização, separação de responsabilidades e uso de padrões modernos da plataforma .NET.




Como Rodar o Projeto

Certifique-se de ter o .NET SDK instalado.

Clone o repositório:

git clone <repo-url>


Navegue até o projeto:

cd GameStore.Api


Execute as migrations, se houver:

dotnet ef database update


Rode o servidor:

dotnet run


A API estará disponível em:

https://localhost:<porta>/
