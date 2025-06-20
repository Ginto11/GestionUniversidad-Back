 ![Badge en Desarollo](https://img.shields.io/badge/STATUS-EN%20DESAROLLO-green)

# 🎓 Gestión Universidad-Back

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white) 
![C%23](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white) 
![SQL%20Server](https://img.shields.io/badge/SQL%20Server-2019-CC2927?logo=microsoftsqlserver&logoColor=white) 
![Entity%20Framework](https://img.shields.io/badge/Entity%20Framework-8.0-512BD4?logo=dotnet&logoColor=white)


Es una aplicación backend diseñada para facilitar la administración académica de una universidad. Permite registrar y gestionar estudiantes, docentes, materias, y realizar el proceso completo de matrícula de forma eficiente mediante una API RESTful robusta y segura.

## 🛠️ Tecnologías y Herramientas utilizadas

- ✅ [.NET 8 (ASP.NET Core)](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
- ✅ [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- ✅ [SQL Server](https://www.microsoft.com/sql-server/) Con procedimientos Almacenados
- ✅ Visual Studio 2022
- ✅ Swagger (documentación interactiva)
- ✅ Autenticación y autorización con JWT
- ✅ Encriptación de contraseñas.


## 🔥 Requisitos del sistema

- .NET 8 SDK
- Visual Studio 2022 o superior
- SQL Server 2019 o superior

## 🧩 Funcionalidades principales

- 🔹 **Gestión de Estudiantes**: crear, editar, consultar y eliminar estudiantes.
- 🔹 **Gestión de Docentes**: administración de datos de los docentes.
- 🔹 **Materias**: registrar nuevas materias, asociar docentes, definir créditos y valores.
- 🔹 **Matrículas**: generar matrículas con control de estado, fecha, costo y validaciones automáticas.
- 🔹 **Validaciones**: uso de anotaciones de datos y lógica de negocio para garantizar integridad.
- 🔹 **Procedimientos almacenados**: para operaciones críticas y cálculo de costos o promociones.
- 🔹 **Documentación Swagger UI**: explora todos los endpoints desde el navegador.

## 🚀 Instalación y ejecución local

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/GestionUniversidad.git
   ```
2. Abre el proyecto con Visual Studio 2022.
3. Configura la cadena de conexión en appsettings.Development.json (no subir al repo):
    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=Servidor;Database=BD;User Id=usuario;Password=Contraseña; TrustServerCertificate=true"
        }
    }
    ```
4. **Importante:** abrir Sql Server y ejecutar el script que va estar en la carpeta **Utilies**, ese script es el que contiene los procedimientos almacenados.
5. Ejecuta migraciones y actualiza la base de datos:
    ```bash
    dotnet ef database update
    ```
6. Ejecuta el proyecto (F5 en Visual Studio o dotnet run en terminal).

7. Abre tu navegador y visita:

 
    ```bash
    http://localhost:<puerto>/swagger/index.html
    ```
## 📁 Estructura del proyecto
```plaintext
📁 GestionUniversidad/
│
├── 📁 Authentication/       → Controlador de Autenticacion
├── 📁 Controllers/          → Controladores REST
├── 📁 Db/                   → Migraciones y contexto EF
├── 📁 Dtos/                 → Objetos de transferencia de datos
├── 📁 Interfaces            → Interfaz de servicio
├── 📁 Models/               → Modelos de entidad
├── 📁 Services/             → Lógica de negocio
├── 📁 Utilies/              → Acceso a datos y procedimientos almacenados
└── Program.cs               → Configuración de la app
```

## 🔁 Endpoints
Una tabla o lista de algunos recursos de la aplicación:

| Recurso     | Método | Ruta                         | Descripción                          |
|-------------|--------|------------------------------|--------------------------------------|
| Estudiantes | GET    | `/api/estudiantes`           | Lista todos los estudiantes          |
| Docente     | GET   | `/api/docentes`               | Lista todos los docentes             |
| Login    | POST    | `/api/login...`                | Dos metodos que permiten loguearse            |
| Materias    | GET   | `/api/materias`              | Lista todas las materias   |
| Matrículas  | POST   | `/api/matriculas`            | Genera una matrícula                 |


## 🔄 Migraciones EF

Una guía corta para crear nuevas migraciones:

Si agregas cambios al modelo, genera una nueva migración:

```bash
dotnet ef migrations add NombreMigracion
dotnet ef migrations remove NombreMigracion
dotnet ef database update
```

---
## 🔒 Seguridad

- Autenticación mediante JWT Bearer Tokens.

- Autorización por roles para limitar accesos (Administrador, Estudiante, Docente).

- Protección contra inyecciones SQL y validación de datos en todos los endpoints.
- Encriptación de contraseñas.

## 📌 Pruebas

- Usa Insomnia o Postman para probar los endpoints.

- Swagger UI te permite probar directamente desde el navegador.


## 💻 Proximas actualizacines
- [ ] Desarrollar el Front-End en Angular
- [ ] Terminar todos los endpoints
- [x] Implementar la logica para la generacion de matriculas mediante procedimientos almacenados.
- [x] Hacer mejoras de codigo.

