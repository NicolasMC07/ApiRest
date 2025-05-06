# Coworking Space Booking API 🏢💻

![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)
![MySQL Version](https://img.shields.io/badge/MySQL-8.0-orange)
![JWT Authentication](https://img.shields.io/badge/JWT-Authentication-yellowgreen)

API REST para la gestión de reservas en espacios de coworking, con autenticación JWT y sistema de auditoría completo.

## Características principales ✨

- ✅ Autenticación JWT segura
- ✅ Gestión completa de salas y reservas
- ✅ Validación de disponibilidad en tiempo real
- ✅ Sistema de auditoría de acciones
- ✅ Seeders para datos iniciales
- ✅ Patrón Repository-Service

## Requisitos 📋

- .NET 8.0 SDK
- MySQL 8.0+
- Visual Studio Code (recomendado) o Visual Studio

## Configuración ⚙️

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/coworking-booking-api.git
   cd coworking-booking-api
   ```

2. **Configurar la base de datos**
   - Crear archivo `appsettings.json` basado en `appsettings.Example.json`
   - Configurar la cadena de conexión MySQL

3. **Aplicar migraciones**
   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

## Estructura del proyecto 🏗️

```
CoworkingBooking/
├── Controllers/      # Controladores API
├── Models/           # Modelos de datos
├── Interfaces/       # Interfaces de servicios y repositorios
├── Repositories/     # Implementación de repositorios
├── Services/         # Lógica de negocio
├── Data/             # Contexto de base de datos y seeders
├── DTOs/             # Objetos de transferencia de datos
└── Config/        # Utilities y clases auxiliares
```

## Endpoints principales 🌐

### Autenticación 🔐
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/users/register` - Registrar nuevo usuario

### Salas 🏢
- `GET /api/rooms/available` - Salas disponibles en rango de fechas
- `POST /api/rooms` - Crear nueva sala (Admin)

### Reservas 📅
- `POST /api/bookings` - Crear reserva
- `PUT /api/bookings/{id}/cancel` - Cancelar reserva
- `GET /api/bookings/users/{userId}` - Historial de reservas

### Auditoría 📝
- `GET /api/audits` - Todos los logs (Admin)
- `GET /api/audits/user/{userId}` - Logs por usuario (Admin)
- `GET /api/audits/entity/{entityName}` - Logs por entidad (Admin)

## Datos iniciales 🌱

El sistema incluye seeders con datos de prueba:

**Usuarios:**
- Admin: `admin@coworking.com` / `Admin123!`
- User1: `user1@test.com` / `User123!`
- User2: `user2@test.com` / `User123!`

**Tipos de sala:**
1. Sala de Reuniones Pequeña
2. Sala de Reuniones Grande
3. Oficina Privada
4. Espacio de Coworking

## Ejemplo de uso con cURL 🔄

**Login:**
```bash
curl -X POST "https://localhost:5110/api/auth/login" \
-H "Content-Type: application/json" \
-d '{"username":"admin", "password":"Admin123!"}'
```

**Crear reserva:**
```bash
curl -X POST "https://localhost:5110/api/bookings" \
-H "Authorization: Bearer {TU_TOKEN_JWT}" \
-H "Content-Type: application/json" \
-d '{"userId": 1, "roomId": 1, "startTime": "2023-12-01T09:00:00", "endTime": "2023-12-01T11:00:00"}'
```

## Tecnologías utilizadas 🛠️

- **Backend**: .NET 8.0
- **Base de datos**: MySQL
- **Autenticación**: JWT
- **ORM**: Entity Framework Core
- **Patrones**: Repository-Service, Dependency Injection

## Roadmap 🗺️

- [ ] Implementar paginación en endpoints
- [ ] Añadir sistema de notificaciones
- [ ] Integrar con sistema de pagos
- [ ] Desplegar en Docker

## Contribución 🤝

Las contribuciones son bienvenidas. Por favor abre un issue o pull request.

## Licencia 📄

MIT License - Ver archivo [LICENSE](LICENSE) para más detalles.
