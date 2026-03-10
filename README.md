# CondoManager — Backend

API REST para gerenciamento de condomínios, desenvolvida com **ASP.NET Core 8**, seguindo os princípios de **Clean Architecture**.

---

## Tecnologias

- **ASP.NET Core 10** — framework web
- **Entity Framework Core** — ORM para acesso ao banco de dados
- **SQL Server** — banco de dados relacional
- **BCrypt.Net** — hash de senhas
- **JWT Bearer** — autenticação via token
- **Scalar** — documentação interativa da API
- **Docker** — containerização do banco de dados

---

## Arquitetura

O projeto segue a **Clean Architecture**, organizado em quatro camadas:

```
CondoManager.Domain          → Entidades e interfaces (contratos)
CondoManager.Application     → DTOs e Use Cases (lógica de negócio)
CondoManager.Infrastructure  → Repositórios e DbContext (acesso ao banco)
CondoManager.API             → Controllers e configuração da API
```

### Fluxo de uma requisição

```
HTTP Request
    ↓
Controller (API)
    ↓
Use Case (Application)
    ↓
Repository Interface (Domain)
    ↓
Repository Implementation (Infrastructure)
    ↓
SQL Server
```

---

## Entidades

- **User** — usuário do sistema (dono do condomínio)
- **Condominium** — condomínio gerenciado
- **Member** — morador (Resident ou Syndic)
- **Employee** — funcionário do condomínio
- **Visitor** — visitante com aprovação
- **AccessLog** — registro de entrada e saída

---

## Autenticação

A API usa **JWT via cookies HttpOnly**. O fluxo é:

1. O usuário faz login em `POST /api/user/login`
2. A API gera um JWT assinado com HMAC-SHA256
3. O token é armazenado num cookie `HttpOnly` — JavaScript não consegue acessá-lo
4. Nas próximas requisições, o browser envia o cookie automaticamente
5. A API valida o token e autoriza o acesso

---

## Endpoints

### User
| Método | Rota | Autenticação | Descrição |
|--------|------|-------------|-----------|
| `POST` | `/api/user/register` | Público | Criar conta |
| `POST` | `/api/user/login` | Público | Fazer login |
| `GET` | `/api/user/{id}` | Requerida | Buscar usuário |

### Condominium
| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/condominium` | Criar condomínio |
| `GET` | `/api/condominium/{id}` | Buscar por id |
| `GET` | `/api/condominium` | Listar todos |
| `PUT` | `/api/condominium/{id}` | Atualizar |
| `DELETE` | `/api/condominium/{id}` | Deletar |

### Member
| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/member/resident` | Criar morador |
| `POST` | `/api/member/syndic` | Criar síndico |
| `GET` | `/api/member/{id}` | Buscar por id |
| `GET` | `/api/member/condominium/{condominiumId}` | Listar por condomínio |
| `PUT` | `/api/member/resident/{id}` | Atualizar morador |
| `PUT` | `/api/member/syndic/{id}` | Atualizar síndico |
| `DELETE` | `/api/member/{id}` | Deletar |

### Employee
| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/employee` | Criar funcionário |
| `GET` | `/api/employee/{id}` | Buscar por id |
| `GET` | `/api/employee/condominium/{condominiumId}` | Listar por condomínio |
| `PUT` | `/api/employee/{id}` | Atualizar |
| `DELETE` | `/api/employee/{id}` | Deletar |

### Visitor
| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/visitor` | Registrar visitante |
| `GET` | `/api/visitor/condominium/{condominiumId}` | Listar por condomínio |

### AccessLog
| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/accesslog` | Registrar entrada |
| `GET` | `/api/accesslog/{id}` | Buscar por id |
| `GET` | `/api/accesslog/condominium/{condominiumId}` | Listar por condomínio |
| `PATCH` | `/api/accesslog/{id}/checkout` | Registrar saída |

---

## Como rodar localmente

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)

### 1. Suba o banco de dados

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SuaSenha123!" \
  -p 1433:1433 --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Configure as credenciais

Crie o arquivo `CondoManager.API/appsettings.Development.json`:

```json
{
  "JwtSettings": {
    "SecretKey": "sua-chave-secreta-com-32-caracteres-minimo"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=CondoManager;User Id=sa;Password=SuaSenha123!;TrustServerCertificate=True;"
  }
}
```

### 3. Execute as migrations

```bash
dotnet ef database update --project CondoManager.Infrastructure --startup-project CondoManager.API
```

### 4. Rode a API

```bash
dotnet run --project CondoManager.API
```

### 5. Acesse a documentação

```
http://localhost:5151/scalar/v1
```

---

## Estrutura de pastas

```
backend/
├── CondoManager.API/
│   ├── Controllers/
│   └── Program.cs
├── CondoManager.Application/
│   ├── DTOs/
│   │   ├── Condominiums/
│   │   ├── Members/
│   │   ├── Employees/
│   │   ├── Visitors/
│   │   ├── AccessLogs/
│   │   └── Users/
│   └── UseCases/
│       ├── Condominiums/
│       ├── Members/
│       ├── Employees/
│       ├── Visitors/
│       ├── AccessLogs/
│       └── Users/
├── CondoManager.Domain/
│   ├── Entities/
│   └── Interfaces/
└── CondoManager.Infrastructure/
    ├── Data/
    ├── Migrations/
    └── Repositories/
```

