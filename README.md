# PT_SalesDatePrediction

Descripción
Este proyecto tiene como objetivo predecir tendencias de ventas a partir de datos históricos. Incluye una API desarrollada en .NET 8 y un frontend en Angular 19, junto con una base de datos en SQL Server.

Requisitos
Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

Backend: .NET 8, SQL Server
Frontend: Node.js, Angular CLI
Dependencias clave: Entity Framework, FluentValidation, Automapper, Material Angular
Instalación y Ejecución

1. Clonar el repositorio
git clone https://github.com/xDcf08/PT_SalesDatePrediction.git

3. Configurar el entorno
Si es necesario, copia el archivo de configuración de ejemplo:
cp .env.example .env
Modifica las variables de entorno según sea necesario.

5. Instalación de dependencias
Frontend
cd ./FrontEnd/SalesDatePrediction
npm install
Backend
cd ./Backend
dotnet restore

7. Ejecutar el proyecto
Backend
cd ./Backend/src/Codifico.SalesDatePrediction.Api
dotnet run
Frontend
cd ./FrontEnd/SalesDatePrediction
npm start

8. Acceso a la aplicación
API: Disponible en http://localhost:5115
Frontend: Disponible en http://localhost:4200
Consideraciones sobre la prueba
En el Frontend, se utilizó Material Angular para las tablas y formularios, optimizando el desarrollo y mejorando la experiencia de usuario.
En el Backend, se implementó Clean Architecture y buenas prácticas con los principios SOLID para garantizar mantenibilidad y legibilidad.
Ejecución de pruebas
El Backend cuenta con pruebas unitarias. Para ejecutarlas, usa:
dotnet test
Tecnologías utilizadas
Angular 19
.NET 8
Entity Framework
SQL Server
Material Angular

Autor
👨‍💻 Edwing Camilo Florez
📩 Contacto: LinkedIn
