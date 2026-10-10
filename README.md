# Eventos Costa Rica - Sistema de Gestión y Venta de Entradas

**Universidad Fidélitas**  
**Carrera:** Ingeniería en Sistemas de Computación  
**Curso:** Programación Avanzada (SC-701)  
**Profesor:** Richard Arce Vargas  

---

## 1. Integrantes del Grupo

| Nombre Completo | Correo Institucional |
| :--- | :--- |
| Erick Alejandro Barrientos Montes] | ebarrientos80448@ufide.ac.cr |
| Clark Delenny Samuels Gonzalez | csamuels00989@ufide.ac.cr |
| Edwin Camilo Pardo Garcia |epardo32120@ufide.ac.cr |
| Steven Mauricio Fonseca Herrera | sfonseca10995@ufide.ac.cr |

---

## 2. Repositorio del Proyecto

- **Enlace de GitHub:** [https://github.com/tu-usuario/eventos-costa-rica](https://github.com/tu-usuario/eventos-costa-rica](https://github.com/erickbm2002/eventos-costa-rica-G2.git))
- **Profesor invitado:** `Richard.arce.vargas@gmail.com`

---

## 3. Especificación Técnica y Arquitectura

### 3.1. Arquitectura del Proyecto (.NET)
El sistema está estructurado bajo una arquitectura multicapas / modular orientada a la separación de responsabilidades:

- **Capa de Presentación / UI (`EventosCostaRica.UI`):**  
  Interfaz de usuario desarrollada en .NET (Blazor / ASP.NET Core MVC / WPF / WinForms según corresponda). Gestiona vistas, validaciones de formularios y experiencia del usuario (catálogo, selección interactiva de asientos y paneles de administración).
- **Capa de Negocio / Core (`EventosCostaRica.Core` o `EventosCostaRica.Services`):**  
  Implementa las reglas de negocio, validación de inventario de asientos (matriz 10x10), control de roles/permisos y flujos de reserva.
- **Capa de Datos / Acceso a Datos (`EventosCostaRica.Data` o `Infrastructure`):**  
  Manejo del almacenamiento, persistencia y consultas hacia la base de datos mediante ORM o ADO.NET.
- **Modelos / Entidades (`EventosCostaRica.Models`):**  
  Definición de entidades de dominio: `Usuario`, `Rol`, `Evento`, `Boleto`, `Asiento`.

### 3.2. Paquetes NuGet y Librerías Utilizadas
- `Microsoft.EntityFrameworkCore` *(o proveedor correspondiente, ej. SqlServer / Sqlite)*: Persistencia y mapeo objeto-relacional.
- `Microsoft.EntityFrameworkCore.Tools`: Manejo de migraciones y scripts de base de datos.
- `BCrypt.Net-Next`: Encriptación y almacenamiento seguro de contraseñas de usuarios.
- `FluentValidation` *(opcional)*: Reglas de validación desacopladas para formularios y entidades.

### 3.3. Principios SOLID Implementados
- **Single Responsibility Principle (SRP):** Cada clase y servicio responde a un único propósito (ej. `AuthService` para sesiones, `SeatAllocationService` para la gestión de matriz de asientos, `EventRepository` para persistencia de eventos).
- **Open/Closed Principle (OCP):** El diseño permite extender funcionalidades (nuevos métodos de filtrado o reportes) sin modificar las clases base consolidadas.
- **Liskov Substitution Principle (LSP):** Abstracciones e interfaces reutilizables que permiten intercambiar implementaciones de repositorios o servicios sin romper el flujo.
- **Interface Segregation Principle (ISP):** Interfaces pequeñas y cohesivas (ej. `IEventReader`, `IEventManager`, `ITicketService`) en lugar de interfaces monolíticas.
- **Dependency Inversion Principle (DIP):** Inyección de dependencias en los controladores/servicios mediante interfaces abstractas, desacoplando la capa de negocio del acceso directo a la infraestructura.

### 3.4. Patrones de Diseño Utilizados
- **Repository Pattern:** Desacopla la lógica de negocio del acceso y persistencia de datos.
- **Dependency Injection (DI):** Registro de servicios en el contenedor nativo de .NET para promover bajo acoplamiento y facilitar pruebas.
- **Factory / Builder (o DTO / ViewModel Pattern):** Construcción estructurada de respuestas de visualización y armado del mapa de 100 asientos ($10 \times 10$).

---

## 4. Módulos y Funcionalidades del Sistema

1. **Autenticación (Log In):**
   - Control de acceso por credenciales y asignación de sesiones según rol (`Administrador` o `Cliente`).
2. **Administración de Usuarios (Rol: Administrador):**
   - CRUD completo (Crear, Consultar, Actualizar, Eliminar) de usuarios con validaciones de unicidad de identificaciones/correos.
3. **Administración de Eventos (Rol: Administrador):**
   - CRUD de eventos: definición de nombre, fecha, lugar, banner/imagen descriptiva y estado general.
4. **Página de Inicio / Catálogo (Roles: Administrador y Cliente):**
   - Visualización de la cartelera de próximos eventos disponibles.
5. **Detalle de Evento:**
   - Información exhaustiva: fecha, recinto, banner visual, disponibilidad de entradas y acceso a la compra.
6. **Compra y Selección de Asientos:**
   - Distribución gráfica de capacidad para 100 personas (matriz de $10 \text{ filas} \times 10 \text{ asientos}$).
   - Selección dinámica de asientos disponibles y confirmación de reserva (sin pasarela de pago real según especificación).
7. **Mis Boletos (Roles: Administrador y Cliente):**
   - Panel de consulta de compras realizadas: nombre del evento, fecha, lugar y desglose de asientos asignados.

---

## 5. Instrucciones de Ejecución

1. **Requisitos previos:**
   - .NET SDK (versión utilizada, ej. .NET 8.0 o superior).
   - Motor de Base de Datos (SQL Server LocalDB / SQLite / MySQL).
   - Visual Studio 2022 o Visual Studio Code con extensiones de C#.

2. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/eventos-costa-rica.git
   cd eventos-costa-rica
   ```

3. **Restaurar dependencias y paquetes:**
   ```bash
   dotnet restore
   ```

4. **Aplicar migraciones de base de datos:**
   ```bash
   dotnet ef database update
   ```

5. **Compilar y ejecutar:**
   ```bash
   dotnet run --project EventosCostaRica.UI
   ```
