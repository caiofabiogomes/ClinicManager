# Clinic Manager

Este é o projeto Clinic manager, um sistema de clínica que permite cadastrar médicos, pacientes e consultas.
Ao marcar a consulta é enviado um agendamento para o google calander do paciente e do médioc

## Tecnologias Utilizadas

- **.NET 8.0**
- **Clean Architecture**: Padrão arquitetural que enfatiza a separação de preocupações e a escalabilidade da aplicação.
- **CQRS (Command Query Responsibility Segregation)**: Padrão de design que separa as operações de leitura e escrita em comandos e consultas distintos.
- **JWT (JSON Web Tokens)**: Método para autenticação e autorização de usuários na aplicação.
- **xUnit**: Framework de testes unitários para .NET.
- **Fluent Validation**: Biblioteca para validação de objetos de forma fluente e fácil de ler.
- **Entity Framework**: Framework ORM para acesso a banco de dados em .NET.
- **Unit Of Work**: Padrão que permite gerenciar transações de banco de dados.
- **Auto Mapper**: Mapeamento de objetos.
- **Hosted Service**: Permite executar tarefas em background.


## Configuração e Execução

1. **Clonar o Repositório**: Clone este repositório em sua máquina local.

    ```bash
    git clone https://github.com/caiogomesxx/ClinicManager.git
    ```

2. **Instalar Dependências**: Certifique-se de ter o .NET 8.0 SDK instalado em sua máquina. Em seguida, instale as dependências do projeto.


3. **Configurar o Google Calendar API**: Obtenha suas credenciais de teste do Google Calendar e configure-as na classe SendNotificationGoogleCalander.
    ![image](https://github.com/caiogomesxx/ClinicManager/assets/72234988/fee326c4-6edd-40c0-9548-ad6557b4c889)



4. **Configurar Banco de Dados**: Configure a connection string com o banco de dados no arquivo de configuração correspondente (ClinicManager.API/appsettings.json).
    ![image](https://github.com/caiogomesxx/Library/assets/72234988/ae9c7166-f884-4ea4-b2b5-b0d32e373ac3)

5. **Executar Migrações**: Execute as migrações do Entity Framework para criar o banco de dados.

    ```bash
    dotnet ef database update
    ```

6. **Executar Projeto**: Execute o projeto ClinicManage.API.
 

7. **Executar Testes**: Para executar os testes unitários, utilize o seguinte comando:

    ```bash
    dotnet test
    ```



