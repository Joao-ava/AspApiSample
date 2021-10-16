# API com asp.net

## Servidor Rest
```sh
/Server
|-> Api
 |-> Controllers # Endpoints da aplicação
|-> Domain
 |-> Commands # Commandos que alteram o banco de dados
 |-> Entities # Entidades da aplicação
 |-> Handler # Manipuladores para os commandos
 |-> Queries # Funçãos de consulta
 |-> Repositories # Interfaces de acesso aos dados
|-> Infra
 |-> Data # Configuração de armazenamento dos dados 
 |-> Repositories # Implementação dos Domain.Repositories
```

### **Rodar aplicação**
```sh
dotnet run
```


