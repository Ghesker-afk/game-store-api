# 🎮 Game Store API

A **Game Store API** é uma aplicação desenvolvida com **.NET 8+, ASP.NET Core Minimal APIs** e **Entity Framework Core**, oferecendo endpoints para gerenciamento de jogos, gêneros e demais recursos relacionados a uma loja de jogos. 

---

## 🚀 Tecnologias Utilizadas

- .NET 8+
- ASP.NET Core Minimal APIs
- Entity Framework Core
- DTOs (Data Transfer Objects)
- Métodos de extensão para mapeamento (`ToEntity()`, `ToDto()`, `ToGameSummaryDto()`, etc.)
- Agrupamento de rotas com `MapGroup`

---

## 📁 Estrutura Geral do Projeto (exemplo)

GameStore.Api/    
├─ Data/   
│ └─ Migrations    
├─ Data/DataExtension.cs  
├─ Data/GameStoreContext.cs  
├─ Endpoints/  
│ ├─ GamesEndpoints.cs  
│ └─ GenresEndpoints.cs  
├─ Entities/  
│ ├─ Game.cs  
│ └─ Genre.cs  
├─ Dtos/  
│ ├─ CreateGameDto.cs  
│ ├─ GenreDto.cs   
│ ├─ UpdateGameDto.cs  
│ ├─ GameSummaryDto.cs  
│ └─ GameDetailsDto.cs  
├─ Mapping/   
│ ├─ GameMapping.cs   
│ └─ GenreMapping.cs   
├─ Program.cs    
├─ games.http  
├─ genres.http    
└─ appsettings.json  

# 📌 Endpoints da API

A Game Store API é dividida em dois grupos principais de endpoints:  
  
/games  
/genres  



  
## 🎮 Endpoints de Games (`/games`)

##  GET /games
Retorna uma lista resumida de todos os jogos cadastrados.

### ✔ Exemplo de resposta (200 OK)
```json
[
  {
    "id": 1,
    "name": "Hades",
    "genre": "Action",
    "price": 79.9
  },
  {
    "id": 2,
    "name": "The Witcher 3",
    "genre": "RPG",
    "price": 199.9
  }
]
```

##  GET /games/{id}
Retorna os detalhes completos de um jogo.

### ✔ Exemplo de resposta (200 OK)
```json
{
  "id": 7,
  "name": "Hollow Knight",
  "description": "Metroidvania atmosférico",
  "genre": {
    "id": 3,
    "name": "Metroidvania"
  },
  "price": 49.9,
  "releaseDate": "2017-02-24"
}
```

## POST /games
Cria um novo jogo no sistema.

### ✔ Exemplo de resposta (201 CREATED)
```json
{
  "name": "Hollow Knight",
  "description": "Metroidvania atmosférico",
  "genreId": 3,
  "price": 49.9,
  "releaseDate": "2017-02-24"
}
```

## PUT /games/{id}
Atualiza totalmente um jogo existente.

## ✔ Exemplo de resposta (204 NO CONTENT)
```json
{
  "name": "Hollow Knight (Updated)",
  "description": "Descrição atualizada",
  "genreId": 3,
  "price": 59.9,
  "releaseDate": "2017-02-24"
}
```

## DELETE /games/{id}
Remove um jogo pelo ID.


## GET /genres
Retorna todos os gêneros cadastrados.
```json
[
  { "id": 1, "name": "Fighting" },
  { "id": 2, "name": "Roleplaying" },
  { "id": 3, "name": "Sports" }
...
]
```
