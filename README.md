# 💰 Personal Finance API

Uma API RESTful desenvolvida em **.NET 8** com **SQL Server**, estruturada com o **Repository Pattern** e totalmente conteinerizada com **Docker**. Este projeto serve como um gerenciador de transações financeiras (Receitas e Despesas).

## 🚀 Tecnologias Utilizadas
* **.NET 8 (C#)**
* **Entity Framework Core**
* **SQL Server**
* **Docker & Docker Compose**
* **Swagger** para documentação da API

## 🏗️ Arquitetura e Padrões
* **Repository Pattern:** Isolamento da camada de acesso a dados.
* **Injeção de Dependência:** Desacoplamento e facilidade de testes.
* **Migrations Automáticas:** O banco de dados é criado e atualizado automaticamente ao subir os contêineres.

## ⚙️ Como executar o projeto

1. Certifique-se de ter o **Docker** e o **Docker Compose** instalados na sua máquina.
2. Clone este repositório:
   ```bash
   git clone [https://github.com/carloshenriquemorais/finance-api.git](https://github.com/carloshenriquemorais/finance-api.git)

## 🧪 Testes de Unidade

Este projeto inclui testes de unidade utilizando **xUnit** e **Moq** para garantir a confiabilidade da camada de Controllers e simular o comportamento do banco de dados de forma isolada.

Para rodar os testes localmente, execute na raiz do projeto:
```bash
dotnet test
