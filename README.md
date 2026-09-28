# Projeto Web Razor — Dragon Ball API

## 📖 Descrição

Este projeto consiste na implementação de novas funcionalidades num **Aplicativo Web Simples em Razor**, desenvolvido em **ASP.NET Core Razor Pages**.

Como parte do trabalho proposto, foi integrada a **Dragon Ball API**, uma API gratuita que disponibiliza informações sobre personagens do universo de Dragon Ball.

O objetivo principal é permitir que o utilizador:

* Aceda a uma nova opção **DragonBall** no menu;
* Consulte uma listagem de personagens;
* Visualize a imagem e o nome de cada personagem;
* Selecione uma personagem;
* Consulte os detalhes dessa personagem através do seu `id`.

---

## 🚀 Tecnologias utilizadas

* **C#**
* **ASP.NET Core**
* **Razor Pages**
* **HTML**
* **CSS**
* **Git / GitHub**
* **GitHub Codespaces**
* **Dragon Ball API**
* **HTTP / REST API**
* **JSON**

---

## 🌐 API utilizada

Para obter os dados das personagens foi utilizada a:

**Dragon Ball API**

---

# 📋 Funcionalidades

## 1. Novo item no menu

Foi adicionado um novo item no menu principal da aplicação com o nome:

**DragonBall**

Este item permite ao utilizador aceder à página de listagem das personagens.

---

## 2. Página Listdragonball

Foi criada uma nova Razor Page denominada:

**Listdragonball**

Esta página é responsável por apresentar a listagem das personagens obtidas através da Dragon Ball API.

Para cada personagem são apresentados:

| Informação | Descrição                   |
| ---------- | --------------------------- |
| `id`       | Identificador da personagem |
| `name`     | Nome da personagem          |
| `image`    | Imagem da personagem        |

A apresentação é feita de forma visual, utilizando a imagem e o nome da personagem.

Cada personagem funciona também como um link para a página de informação detalhada.
Ao clicar numa personagem, o respetivo `id` é enviado para a página de detalhes.

Por exemplo:

```text
/Infodragonball?id=2
```

---

# 🧩 Modelo de dados

Para representar os dados necessários da listagem foi criado um modelo de dados.

Exemplo:

```csharp
public class DragonBallCharacter
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Image { get; set; }
}
```

Este modelo permite representar as principais informações necessárias para a página de listagem.

---

# 🔎 3. Página Infodragonball

Foi criada uma segunda Razor Page denominada:

**Infodragonball**

Esta página apresenta as informações detalhadas da personagem selecionada.

A página recebe o `id` da personagem e utiliza esse identificador para consultar a API.

Endpoint utilizado:

```text
https://dragonball-api.com/api/characters/{id}
```

Por exemplo, para consultar a personagem com `id = 2`:

```text
https://dragonball-api.com/api/characters/2
```

---

## 📄 Informações apresentadas

Na página de detalhes são apresentadas as seguintes informações:

| Campo         | Descrição               |
| ------------- | ----------------------- |
| `name`        | Nome da personagem      |
| `description` | Descrição da personagem |
| `image`       | Imagem da personagem    |
| `affiliation` | Afiliação da personagem |

As informações recebidas da API são tratadas e apresentadas em HTML de forma organizada e legível.

---

# 📡 Consumo da API

A aplicação realiza pedidos HTTP à Dragon Ball API para obter os dados das personagens.

### Listagem

```http
GET https://dragonball-api.com/api/characters
```

### Personagem específica

```http
GET https://dragonball-api.com/api/characters/{id}
```

Os dados são recebidos no formato **JSON** e posteriormente convertidos para os modelos utilizados pela aplicação Razor.

---

# 🎯 Objetivos do trabalho

Com esta implementação pretende-se demonstrar conhecimentos de:

* Criação e utilização de **Razor Pages**;
* Criação de **modelos de dados em C#**;
* Consumo de uma **API REST**;
* Realização de pedidos HTTP;
* Tratamento de dados em formato JSON;
* Utilização de parâmetros através da URL;
* Criação de links entre páginas;
* Apresentação de dados dinamicamente em HTML;
* Organização de um projeto ASP.NET Core;
* Utilização de GitHub e GitHub Codespaces.

---

# 👨‍💻 Autor

**Nome:** *[Renan Straquicini]*

* [x] Documentação do projeto
