# 📥 INSTALACIÓN Y CONFIGURACIÓN - BetArena

## Requisitos Previos (Importante ⚠️)

Antes de comenzar, asegúrate de tener instalado:

### 1. .NET 8 SDK

**Windows:**
```bash
# Descargar desde:
https://dotnet.microsoft.com/download/dotnet/8.0

# Verificar instalación:
dotnet --version
# Deberías ver: 8.0.x
```

**macOS:**
```bash
# Con Homebrew
brew install dotnet-sdk-8.0

# Verificar
dotnet --version
```

**Linux:**
```bash
# Ubuntu/Debian
wget https://dot.net/v1/dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --version 8.0

# Verificar
dotnet --version
```

### 2. Git

```bash
git --version
# Deberías ver: git version x.x.x
```

### 3. Editor (Uno de estos)

- **Visual Studio 2022** (Recomendado para Windows)
- **VS Code** + C# Extension
- **Rider** (JetBrains)

---

## 🔧 Instalación Paso a Paso

### Paso 1: Clonar el Repositorio

```bash
# Opción A: HTTPS (recomendado para usuarios nuevos)
git clone https://github.com/tu-usuario/BetArena.git

# Opción B: SSH (si tienes SSH configurado)
git clone git@github.com:tu-usuario/BetArena.git

# Navegar al directorio
cd BetArena
```

### Paso 2: Restaurar Paquetes NuGet

```bash
dotnet restore
```

**Esperado:**
```
Restoring packages...
Restored BetArena/BetArena.csproj
Restored BetArena.Tests/BetArena.Tests.csproj
```

### Paso 3: Compilar la Solución

```bash
dotnet build
```

**Esperado:**
```
Build succeeded with 0 warnings.
```

### Paso 4: Ejecutar Tests (Verificación)

```bash
dotnet test
```

**Esperado:**
```
43 test(s) passed, 0 failed.
```

### Paso 5: Ejecutar la Aplicación

```bash
cd BetArena
dotnet run
```

**Esperado:**
```
Now listening on: http://localhost:5157
```

---

## 🌐 Configuración de Puertos

### Puerto Predeterminado: 5157

Si el puerto ya está en uso, cámbialo en:

**Archivo**: `BetArena/Properties/launchSettings.json`

```json
"profiles": {
  "http": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "applicationUrl": "http://localhost:5158",  // Cambia aquí
    "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
    }
  }
}
```

---

## 📂 Estructura de Directorios

```
BetArena/
├── BetArena/                    # Proyecto principal
│   ├── Models/                  # Modelos de datos
│   ├── Services/                # Servicios de negocio
│   ├── Controllers/             # API Controllers
│   ├── Pages/                   # Razor Pages
│   ├── wwwroot/                 # Archivos estáticos
│   ├── Program.cs               # Configuración
│   └── BetArena.csproj         # Archivo de proyecto
│
├── BetArena.Tests/              # Tests unitarios
│   ├── UnitTests.cs             # Suite de tests (43 tests)
│   └── BetArena.Tests.csproj   # Archivo de proyecto
│
├── BetArena.sln                 # Solución
├── README.md                    # Documentación general
├── QUICK_START.md               # Inicio rápido
└── ... (otros documentos)
```

---

## ⚙️ Configuración de Visual Studio 2022

### Abrir el Proyecto

1. Abre **Visual Studio 2022**
2. Click en **"Open a project or solution"**
3. Navega a `BetArena.sln`
4. Click en **Open**

### Configurar como Proyecto de Inicio

1. En Solution Explorer, haz clic derecho en **BetArena**
2. Selecciona **"Set as Startup Project"**

### Ejecutar

- Presiona `F5` para Debug
- O presiona `Ctrl+F5` para Run sin Debug

---

## 📝 Configuración de VS Code

### Extensiones Recomendadas

1. **C# Dev Kit** (Microsoft)
2. **REST Client** (Huachao Mao) - Para probar API
3. **Thunder Client** - Alternativa a Postman

### Configurar Workspace

1. Abre la carpeta `BetArena` en VS Code
2. VS Code detectará los proyectos automáticamente
3. Presiona `F5` para iniciar debug

---

## 🧪 Verificación de Instalación

Ejecuta este script para verificar:

```bash
#!/bin/bash

echo "Verificando instalación..."
echo ""

# .NET SDK
echo "✓ Verificando .NET SDK"
dotnet --version

# Solución
echo "✓ Restaurando solución"
dotnet restore

# Compilación
echo "✓ Compilando"
dotnet build

# Tests
echo "✓ Ejecutando tests"
dotnet test --verbosity quiet

echo ""
echo "✅ Instalación verificada!"
```

**Copia este contenido en un archivo `verify.sh`:**

```bash
chmod +x verify.sh
./verify.sh
```

---

## 🔐 Configuración de Seguridad

### Certificados HTTPS

Para desarrollo local con HTTPS:

```bash
# Windows
dotnet dev-certs https --trust

# macOS/Linux
dotnet dev-certs https --trust
```

---

## 🚀 Primeros Pasos Después de Instalar

### 1. Familiarizarse con la Estructura

```bash
# Ver archivos del proyecto
ls -la BetArena/

# Ver archivos de tests
ls -la BetArena.Tests/
```

### 2. Leer la Documentación

```bash
# Documentación general
cat README.md

# Guía rápida
cat QUICK_START.md

# Plan de tests
cat TESTING_PLAN.md
```

### 3. Ejecutar Tests

```bash
dotnet test
```

### 4. Ejecutar la Aplicación

```bash
cd BetArena
dotnet run
```

---

## 🐛 Problemas Comunes y Soluciones

### Error: "dotnet: command not found"

**Causa**: .NET SDK no está instalado o no está en PATH

**Solución**:
1. Instala .NET 8 SDK desde https://dotnet.microsoft.com/download
2. Reinicia la terminal
3. Verifica con `dotnet --version`

---

### Error: "Project not found"

**Causa**: Estás en el directorio incorrecto

**Solución**:
```bash
# Asegúrate de estar en la carpeta BetArena
cd BetArena

# Verifica que ves BetArena.csproj
ls -la

# Ahora ejecuta
dotnet restore
```

---

### Error: "Port 5157 already in use"

**Causa**: El puerto está ocupado por otro proceso

**Soluciones**:

**Opción 1**: Encontrar y matar el proceso
```bash
# Windows
netstat -ano | findstr :5157
taskkill /PID <PID> /F

# macOS/Linux
lsof -i :5157
kill -9 <PID>
```

**Opción 2**: Cambiar el puerto (ver sección anterior)

---

### Error: "Tests not found"

**Causa**: Tests no se compilaron correctamente

**Solución**:
```bash
# Limpia
dotnet clean

# Restaura
dotnet restore

# Reconstruye
dotnet build

# Intenta tests nuevamente
dotnet test
```

---

### Error: "NuGet packages not restoring"

**Causa**: Problemas con NuGet

**Solución**:
```bash
# Limpia la caché de NuGet
dotnet nuget locals all --clear

# Restaura
dotnet restore

# Construye
dotnet build
```

---

## 📊 Verificar Instalación

Después de instalar, verifica que todo funciona:

```bash
# 1. Verifica .NET
dotnet --version

# 2. Restaura dependencias
dotnet restore

# 3. Compila
dotnet build

# 4. Ejecuta tests
dotnet test

# 5. Ejecuta la aplicación
cd BetArena
dotnet run

# 6. Abre en navegador
# http://localhost:5157
```

---

## 🔄 Actualizar Dependencias

Para actualizar paquetes NuGet:

```bash
# Ver actualizaciones disponibles
dotnet list package --outdated

# Actualizar todo
dotnet package update
```

---

## 🌍 Variables de Entorno

### Desarrollo

```bash
# Windows
set ASPNETCORE_ENVIRONMENT=Development

# macOS/Linux
export ASPNETCORE_ENVIRONMENT=Development
```

### Producción

```bash
# Windows
set ASPNETCORE_ENVIRONMENT=Production

# macOS/Linux
export ASPNETCORE_ENVIRONMENT=Production
```

---

## 📚 Comando Útiles

| Comando | Propósito |
|---------|----------|
| `dotnet restore` | Restaurar paquetes NuGet |
| `dotnet build` | Compilar solución |
| `dotnet run` | Ejecutar aplicación |
| `dotnet test` | Ejecutar tests |
| `dotnet clean` | Limpiar artefactos de compilación |
| `dotnet add package [nombre]` | Agregar paquete NuGet |
| `dotnet remove package [nombre]` | Remover paquete NuGet |

---

## ✅ Checklist de Instalación

```
[ ] .NET 8 SDK instalado
[ ] Git instalado
[ ] Repositorio clonado
[ ] dotnet restore ejecutado
[ ] dotnet build exitoso
[ ] dotnet test (43 tests pasando)
[ ] dotnet run sin errores
[ ] Navegador abre http://localhost:5157
[ ] Tests ejecutados correctamente
[ ] Documentación leída
```

---

## 🎉 ¡Instalación Completada!

```
╔════════════════════════════════════════════╗
║   ✅ BetArena instalado correctamente    ║
║                                            ║
║   Próximos pasos:                          ║
║   1. Ejecutar: dotnet run                  ║
║   2. Abrir: http://localhost:5157          ║
║   3. Leer: README.md                       ║
║                                            ║
║   ¡A disfrutar! 🚀                        ║
╚════════════════════════════════════════════╝
```

---

## 📞 Soporte

Si encuentras problemas:

1. **Verifica los requisitos**: .NET 8 SDK, Git
2. **Ejecuta `dotnet --version`**: Debe ser 8.0 o superior
3. **Limpia y reconstruye**: `dotnet clean && dotnet build`
4. **Lee la documentación**: `README.md`, `QUICK_START.md`
5. **Revisa troubleshooting**: Ver sección de problemas comunes

---

**Última actualización**: 16 de Abril de 2026  
**Versión**: 1.0  
**Estado**: ✅ LISTO PARA INSTALAR
