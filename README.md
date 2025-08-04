 ![Badge en Desarollo](https://img.shields.io/badge/STATUS-EN%20DESAROLLO-green)

# 🎓 Gestión Universidad-Back

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white) 
![C%23](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white) 
![SQL%20Server](https://img.shields.io/badge/SQL%20Server-2019-CC2927?logo=microsoftsqlserver&logoColor=white) 
![Entity%20Framework](https://img.shields.io/badge/Entity%20Framework-8.0-512BD4?logo=dotnet&logoColor=white)

Esta es la **API REST para la Gestión Universitaria de NovaUniversitas**.  
Se encarga de administrar estudiantes, docentes, materias, matrículas y otros elementos críticos para la operación de la universidad, utilizando procedimientos almacenados para garantizar eficiencia y seguridad en la administración de datos.


## 📋 Tabla de Contenido
- [🎓 Gestión Universidad-Back](#-gestión-universidad-back)
  - [📋 Tabla de Contenido](#-tabla-de-contenido)
  - [🗂️ Estructura del Proyecto](#️-estructura-del-proyecto)
  - [⚡️ Descripción General](#️-descripción-general)
  - [⚙️ Instalación y Ejecutable Local](#️-instalación-y-ejecutable-local)
      - [1️⃣ Clonar este repositorio](#1️⃣-clonar-este-repositorio)
      - [2️⃣ Configurar el `appsettings.json`](#2️⃣-configurar-el-appsettingsjson)
      - [3️⃣ Ejecutar Scripts para Procedimientos Almacenados](#3️⃣-ejecutar-scripts-para-procedimientos-almacenados)
      - [4️⃣ Ejecutar Migraciones EF](#4️⃣-ejecutar-migraciones-ef)
      - [5️⃣ Ejecutar el Proyecto](#5️⃣-ejecutar-el-proyecto)
      - [6️⃣ Acceder a la Documentación de la API](#6️⃣-acceder-a-la-documentación-de-la-api)
    - [🌐 Características principales](#-características-principales)
  - [📁 Scripts principales](#-scripts-principales)
  - [🔄 Endpoints principales](#-endpoints-principales)
  - [🔐 Seguridad](#-seguridad)
  - [💻 Próximas Actualizaciones](#-próximas-actualizaciones)
  - [👥 Contribución](#-contribución)
  - [✉️ Contacto](#️-contacto)


## 🗂️ Estructura del Proyecto

```plaintext
📁 GestionUniversidad-Back/
├─ 📁 Authentication/           → Controlador de Autenticación
├─ 📁 Controllers/              → Controladores REST
├─ 📁 Db/                       → Migraciones y Contexto EF
├─ 📁 Dtos/                     → Objetos de Transferencia de Datos
├─ 📁 Interfaces/               → Interfaces de servicios
├─ 📁 Models/                   → Modelos de entidad
├─ 📁 Services/                 → Lógica de negocio
├─ 📁 Utilies/                  → Scripts y procedimientos almacenados
└─ Program.cs                   → Configuración de la app
```

## ⚡️ Descripción General
✅ Framework: .NET 8 (ASP.NET Core)
✅ Lenguaje: C# 12.0
✅ ORM: Entity Framework 8.0 para mapeo de datos y migraciones.
✅ Base de Datos: SQL Server 2019
✅ Autenticación y autorización con JWT.
✅ Scripts para procedimientos críticos y generación de matrículas.
✅ Validaciones para garantizar integridad de datos.
✅ Endpoints REST para estudiantes, docentes, materias y matrículas.


## ⚙️ Instalación y Ejecutable Local
#### 1️⃣ Clonar este repositorio
```bash
git clone https://github.com/Ginto11/GestionUniversidad-Back.git
```

#### 2️⃣ Configurar el `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DATOS;User Id=TU_USER;Password=TU_PASSWORD;TrustServerCertificate=true"
  },
  "CONFIGURACION_EMAIL": {
    "HOST": "smtp.tu-servidor.com",
    "PUERTO": 587,
    "EMAIL": "tu-correo@dominio.com",
    "PASSWORD": "tu-contraseña-de-aplicacion"
  },
  "Encrypting": {
    "IV": "vector_inicializacion_16_caracteres",
    "Key": "clave_de_encriptacion_segura (recomendada de 32 caracteres)"
  },
  "Jwt": {
    "Issuer": "https://tudominio.com",
    "Audience": "https://tucliente.com",
    "Key": "clave_secreta_para_tokens"
  }
}
```
#### 3️⃣ Ejecutar Scripts para Procedimientos Almacenados
- Abre SQL Server e importa los procedimientos que encontrarás en la carpeta `Db/Script`.

#### 4️⃣ Ejecutar Migraciones EF
```bash
dotnet ef database update
```

#### 5️⃣ Ejecutar el Proyecto
- Ejecuta con Visual Studio 2022 (`F5`) o por CLI:
```bash
dotnet run
```

#### 6️⃣ Acceder a la Documentación de la API
```bash
http://localhost:<puerto>/swagger
```

### 🌐 Características principales
- 👥 Estudiantes: Crear, editar, consultar y eliminar estudiantes.

- 👔 Docentes: Gestión de datos de los docentes.

- 📚 Materias: Crear y administrar asignaturas, créditos y costos.

- 💳 Matrículas: Generación de matrículas basada en procedimientos almacenados.

- ✅ Validaciones de datos para garantizar integridad.

- 📄 Swagger UI para documentación y pruebas.

## 📁 Scripts principales
| Comando                                | Descripción                                                  |
| -------------------------------------- | ------------------------------------------------------------ |
| `dotnet build`                         | Compila la solución .NET.                                    |
| `dotnet run`                           | Ejecuta la aplicación en local.                              |
| `dotnet ef database update`            | Aplica todas las migraciones pendientes en la base de datos. |
| `dotnet ef migrations add <nombre>`    | Crea una nueva migración para reflejar cambios en el modelo. |
| `dotnet ef migrations remove <nombre>` | Elimina una migración no deseada.                            |

## 🔄 Endpoints principales
| Recurso     | Método | Ruta               | Descripción                              |
| ----------- | ------ | ------------------ | ---------------------------------------- |
| Estudiantes | GET    | `/api/estudiantes` | Lista todos los estudiantes.             |
| Docentes    | GET    | `/api/docentes`    | Lista todos los docentes.                |
| Login       | POST   | `/api/login`       | Autenticación de usuarios.               |
| Materias    | GET    | `/api/materias`    | Lista todas las materias.                |
| Matrículas  | POST   | `/api/matriculas`  | Genera una matrícula para un estudiante. |

## 🔐 Seguridad
- 🔑 Autenticación mediante JWT Bearer Tokens para todas las rutas privadas.

- ⚔️ Protección contra inyecciones SQL y validación de datos en todos los endpoints.

- 🔐 Encriptación de contraseñas para garantizar la seguridad de la información.


## 💻 Próximas Actualizaciones
- [ ] Integración con el Front‑End en Angular.

- [x] Finalización de todos los endpoints restantes.

- [x] Implementación de lógica para generación de matrículas mediante procedimientos.

- [x] Mejoras en la estructura de la lógica de servicios.

## 👥 Contribución
Si deseas contribuir al proyecto:
1. Realiza un fork del proyecto.
2. Crea una nueva rama para tu feature:
```bash
git checkout -b feature/nueva-funcionalidad
```
3. Agrega todos los cambios:
```bash
git add .
```
4. Haz commit de los cambios:
```bash
git commit -m "Agrega nueva funcionalidad"
```
5. Push al repositorio:
```bash
git push origin feature/nueva-funcionalidad
```

## ✉️ Contacto
Si deseas comunicarte para colaborar, obtener soporte o hacer consultas:

- 📧 Email: salinitosnelson@gmail.com
