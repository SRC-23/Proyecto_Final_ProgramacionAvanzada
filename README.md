Integrantes:
Adrián Cordero Abarca
Rodrigez Cruz Sebastian

SISTEMA DE GESTIÓN DE TAREAS
Este proyecto es una aplicación web desarrollada con ASP.NET Core MVC que permite la gestión de tareas, mostrando una cola priorizada donde las tareas se ordenan según su prioridad (Alta, Media, Baja). Permite crear, editar, eliminar y visualizar tareas.

Especificación de la arquitectura:
QueueSystem/
│
├── QueueSystem.sln                 
│
├── QueueSystem.ML/                
│   ├── Models/
│   │   └── Tarea.cs 
|   |   └── LogTarea.cs
|   |   └── Notificacion.cs
|   |   └── Usuario.cs
│   └── Interfaces/
│       └── ITareaRepositorio.cs  
│
├── QueueSystem.DAL/                
│   ├── DbContexts/
│   │   └── AppDbContext.cs        
│   └── Repositorios/
│       └── TareaRepositorio.cs     
│
├── QueueSystem.BL/                
│   ├── Services/
│   │   └── TareaServicio.cs         
│
├── QueueSystem.UI/                
│   ├── Controllers/
│   │   └── TareaController.cs   
│   ├── Views/
│   │   └── Tarea/
│   │       ├── Index.cshtml        
│   │       ├── Crear.cshtml        
│   │       ├── Editar.cshtml       
│   │       ├── Eliminar.cshtml  
|   |       └── Cola.cshtml            
│
├── appsettings.json              
├── Program.cs                     
└── README.md                      



Listado de librerías/paquetes NuGet utilizados:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 


https://github.com/SRC-23/Proyecto_Final_ProgramacionAvanzada.git
