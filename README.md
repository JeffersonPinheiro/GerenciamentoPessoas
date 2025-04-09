# 👥 Gerenciamento de Pessoas

Sistema web simples para **cadastrar, listar, editar e excluir pessoas**, utilizando ASP.NET Core com Entity Framework e SQL Server. Ideal para aprendizado ou como base para sistemas administrativos mais completos.

---

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 6**
- **Entity Framework Core**
- **Razor Pages / MVC**
- **SQL Server**
- **Bootstrap 5**
- **C#**

---

## ✨ Funcionalidades

- ✅ Cadastro de novas pessoas
- ✅ Listagem com paginação
- ✅ Edição de dados
- ✅ Exclusão com confirmação
- ✅ Validação de campos (ex: nome obrigatório)
- ✅ Interface simples e responsiva

---

## 🛠️ Como executar

1. Clone o projeto:
   ```bash
   git clone https://github.com/JeffersonPinheiro/GerenciamentoPessoas.git
2.Abra com o Visual Studio 2022 ou superior.

3.Configure o banco de dados no arquivo appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=GerenciamentoPessoas;Trusted_Connection=True;"
}

4.Execute as migrations (via Package Manager Console):
Update-Database


5.Rode a aplicação (F5).

