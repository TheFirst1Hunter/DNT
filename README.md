.
├── DotNetTemplate.Application
│   ├── Auth
│   │   ├── Polices.Auth
│   │   │   ├── Common
│   │   │   │   └── Base.Policy.cs
│   │   │   └── Todo.Policy.cs
│   │   └── Role.Auth.cs
│   ├── DTOs
│   │   └── User
│   │   ├── Login.User.Response.cs
│   │   └── Register.User.Response.cs
│   ├── Extensions
│   │   ├── AuthConfig.Extension.cs
│   │   ├── AuthPolicy.Extension.cs
│   │   └── ServiceInjection.Extension.cs
│   └── Services
│   ├── Auth.Service
│   │   ├── Auth.Service.cs
│   │   └── IAuth.Service.cs
│   ├── Base.Service
│   │   └── IBase.Service.cs
│   ├── Hash.Service
│   │   ├── Hash.Service.cs
│   │   └── IHash.Service.cs
│   ├── Todo.Service
│   │   └── ITodo.Service.cs
│   └── Token.Service
│   ├── IToken.Service.cs
│   └── Token.Service.cs
├── DotNetTemplate.Core
│   ├── Entities
│   │   ├── Common.Entity
│   │   │   └── Base.Entity.cs
│   │   ├── Todo.Entity
│   │   │   ├── Todo.Entity.cs
│   │   │   └── TodoTypes.cs
│   │   └── User.Entity
│   │   └── User.Entity.cs
│   └── Exceptions
│   ├── Common.Exceptions
│   │   ├── Base.Exceptions.cs
│   │   └── EntityNotFound.Exception.cs
│   └── User.Exceptions
│   ├── InvalidCredentials.Exceptions.cs
│   └── InvalidRefreshToken.Exceptions.cs
├── DotNetTemplate.Data
│   ├── DBContext
│   │   └── DotNetTemplateDbContext.cs
│   ├── DTOs
│   │   ├── Common.Dto
│   │   │   ├── List.Base.Dto.cs
│   │   │   ├── List.Wrapper.cs
│   │   │   ├── Query.Base.Dto.cs
│   │   │   └── Single.Base.Dto.cs
│   │   └── Todo.Dto
│   │   ├── List.Todo.Dto.cs
│   │   ├── Query.Todo.Dto.cs
│   │   └── Single.Todo.Dto.cs
│   ├── Extensions
│   │   └── RepositoryInjection.cs
│   ├── ModelConfigurations
│   │   ├── Base.Configuration.cs
│   │   ├── Todo.Configuration.cs
│   │   └── User.Configuration.cs
│   └── Repositories
│   ├── Common.Repository
│   │   ├── Base.Read.Repository.cs
│   │   ├── Base.Write.Repository.cs
│   │   ├── IBase.Read.Repository.cs
│   │   └── IBase.Write.Repository.cs
│   ├── Todo.Repository
│   │   ├── ITodo.Read.Repository.cs
│   │   ├── ITodo.Write.Repository.cs
│   │   ├── Todo.Read.Repository.cs
│   │   └── Todo.Write.Repository.cs
│   └── User.Repository
│   ├── IUser.ReadRepository.cs
│   ├── IUser.WriteRepository.cs
│   ├── User.Read.Repository.cs
│   └── User.Write.Repository.cs
├── DotNetTemplate.Infrastructure
│   ├── DTOs
│   │   └── Error.dto.cs
│   ├── Log
│   │   ├── LogStructure.Log.cs
│   │   ├── Logs
│   │   │   └── Logs20240414.txt
│   │   └── SerilogConfig.Log.cs
│   ├── Logging
│   │   └── Logs
│   │   └── Logs20240417.txt
│   └── Middleware
│   ├── ExceptionHandler.Middleware.cs
│   └── LogMiddleware.Middleware.cs
├── DotNetTemplate.Presentation
│   ├── Controllers
│   │   ├── Auth.Controller.cs
│   │   ├── Common.Controller
│   │   │   └── Base.Controller.cs
│   │   └── Todo.Controller.cs
│   ├── DTOs
│   │   ├── Common.Dto
│   │   │   ├── Create.Base.Dto.cs
│   │   │   ├── Query.Base.Dto.cs
│   │   │   ├── Update.Base.Dto.cs
│   │   │   └── Wrappers
│   │   │   ├── PaginatedResponse.Wrapper.cs
│   │   │   └── SingleResponse.Wapper.cs
│   │   ├── Todo.Dto
│   │   │   ├── Create.Todo.Dto.cs
│   │   │   ├── Query.Todo.Dto.cs
│   │   │   └── Update.Todo.Dto.cs
│   │   └── User.Dto
│   │   ├── Login.User.Dto.cs
│   │   ├── RefreshToken.User.Dto.cs
│   │   ├── Register.User.Dto.cs
│   │   └── Update.UserPermission.Dto.cs
│   ├── Extensions
│   │   └── Swagger.Extension.cs
│   └── Mappings
│   ├── Base.Mapper.cs
│   └── Todo.Mapper.cs
├── DotNetTemplate.csproj
├── DotNetTemplate.http
├── DotNetTemplate.sln
├── Program.cs
├── README.md
├── appsettings.Development.json
└── appsettings.json
