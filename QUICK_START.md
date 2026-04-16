# 🚀 QUICK START - BetArena

## Inicio Rápido en 5 minutos

### Requisitos Previos

- **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** instalado
- **Visual Studio 2022** o **VS Code**
- **Git** (para clonar el repositorio)

---

## 📦 Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/BetArena.git
cd BetArena
```

### 2. Restaurar Dependencias

```bash
dotnet restore
```

### 3. Compilar la Solución

```bash
dotnet build
```

---

## ▶️ Ejecutar la Aplicación

### Opción 1: Desde Línea de Comandos

```bash
cd BetArena
dotnet run
```

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5157
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### Opción 2: Desde Visual Studio

1. Abre `BetArena.sln`
2. Presiona `F5` o click en el botón **Run**
3. Se abrirá automáticamente en `http://localhost:5157`

### Opción 3: Desde VS Code

```bash
cd BetArena
code .
# Luego presiona F5
```

---

## 🌐 Acceder a la Aplicación

Una vez ejecutada, abre tu navegador en:

```
http://localhost:5157
```

---

## 🧪 Ejecutar Tests

### Todos los Tests

```bash
cd BetArena
dotnet test
```

**Resultado esperado:**
```
43 test(s) passed, 0 failed.
```

### Tests Específicos

```bash
# Solo validaciones
dotnet test --filter "ClassName=BetServiceValidationTests"

# Solo RTP
dotnet test --filter "ClassName=StatsCalculatorRTPTests"

# Solo API
dotnet test --filter "ClassName=BetsControllerIntegrationTests"

# Con detalle
dotnet test --verbosity detailed
```

---

## 📝 Usar la Aplicación

### Registrar una Apuesta

1. Completa el formulario:
   - **ID Usuario**: Número único (ej: 1, 2, 3)
   - **Juego**: Selecciona de la lista (Roulette, Blackjack, Slots, etc.)
   - **Stake**: Monto apostado (ej: 100)
   - **Win Amount**: Monto ganado (ej: 250)

2. Click en **"Registrar Apuesta"**

3. Verás un mensaje de confirmación

### Ver Estadísticas

- Las tablas se actualizan automáticamente
- **Tabla de Juegos**: Muestra RTP (%) por juego
- **Tabla de Usuarios**: Muestra totales por usuario
- Click en **"Actualizar Estadísticas"** para refrescar

---

## 🧾 Probar con cURL

### Registrar Apuesta

```bash
curl -X POST http://localhost:5157/api/bets \
  -H "Content-Type: application/json" \
  -d '{"userId":1,"game":"Roulette","stake":100,"winAmount":50}'
```

**Respuesta esperada:**
```json
{"message":"Apuesta registrada exitosamente."}
```

### Obtener Estadísticas

```bash
curl http://localhost:5157/api/bets/stats
```

**Respuesta esperada:**
```json
{
  "games": [
    {"game": "Roulette", "rtp": 50.0}
  ],
  "users": [
    {"userId": 1, "totalStake": 100, "totalWin": 50}
  ]
}
```

---

## 📊 Probar con Postman

### 1. Descargar Postman

Descarga desde: https://www.postman.com/downloads/

### 2. Crear Solicitud POST

**URL**: `http://localhost:5157/api/bets`

**Método**: POST

**Headers**:
```
Content-Type: application/json
```

**Body** (raw, JSON):
```json
{
  "userId": 1,
  "game": "Roulette",
  "stake": 100,
  "winAmount": 50
}
```

Click en **Send**

### 3. Crear Solicitud GET

**URL**: `http://localhost:5157/api/bets/stats`

**Método**: GET

Click en **Send**

---

## 🐛 Troubleshooting

### Error: "dotnet command not found"

**Solución**: Instala .NET 8 SDK desde https://dotnet.microsoft.com/download

### Error: "Port 5157 is already in use"

**Solución**: Cambia el puerto en `launchSettings.json`:
```json
"applicationUrl": "http://localhost:5158"
```

### Los tests no se encuentran

**Solución**:
```bash
dotnet clean
dotnet restore
dotnet build
dotnet test
```

### La aplicación no inicia

**Solución**:
```bash
# Limpia y reconstruye
dotnet clean
dotnet build

# Intenta ejecutar de nuevo
dotnet run
```

---

## 📚 Documentación Completa

| Documento | Propósito |
|-----------|----------|
| `README.md` | Documentación general del proyecto |
| `TESTING_PLAN.md` | Plan de testing detallado |
| `TESTING_GUIDE.md` | Cómo ejecutar tests |
| `TESTING_SUMMARY.md` | Resumen de resultados |
| `TESTING_VISUAL_MAP.md` | Estructura visual de tests |
| `PROJECT_COMPLETION.md` | Resumen del proyecto |
| `QUICK_START.md` | Este documento - inicio rápido |

---

## 🎯 Casos de Prueba Recomendados

### Caso 1: Apuesta Ganadora

```
UserId: 1
Game: Roulette
Stake: 100
Win Amount: 250
```

Resultado esperado: ✅ Registrado, RTP = 250%

### Caso 2: Apuesta Perdida

```
UserId: 2
Game: Blackjack
Stake: 50
Win Amount: 0
```

Resultado esperado: ✅ Registrado, RTP = 0%

### Caso 3: Múltiples Apuestas

Registra varias con los mismos usuarios pero diferentes juegos.

Resultado esperado: ✅ Estadísticas agregadas correctamente

### Caso 4: Datos Inválidos

```
UserId: 0
Stake: -50
Game: (vacío)
WinAmount: -100
```

Resultado esperado: ❌ Error 400 Bad Request

---

## ✅ Verificación Rápida

Ejecuta esto para verificar que todo funciona:

```bash
# 1. Limpia
dotnet clean

# 2. Restaura
dotnet restore

# 3. Compila
dotnet build

# 4. Prueba
dotnet test

# 5. Ejecuta
dotnet run
```

Si todo sale verde ✅, ¡está listo para usar!

---

## 🔍 Ver Logs

### Modo Verbose

```bash
dotnet run --verbose
```

### Tests con Detalle

```bash
dotnet test --verbosity detailed
```

---

## 💻 Requisitos del Sistema

| Componente | Versión Mínima |
|-----------|-----------------|
| .NET SDK | 8.0 |
| Windows | 10/11 |
| Memoria RAM | 2 GB |
| Espacio Disco | 500 MB |

---

## 🎓 Próximos Pasos

1. **Ejecuta** la aplicación
2. **Registra** algunas apuestas
3. **Prueba** la API con curl o Postman
4. **Ejecuta** los tests
5. **Lee** la documentación completa

---

## 📞 Ayuda

Si encuentras problemas:

1. Verifica los requisitos previos
2. Lee el archivo `README.md`
3. Revisa la sección de Troubleshooting arriba
4. Ejecuta `dotnet --version` para confirmar .NET 8

---

## 🎉 ¡Listo!

```
╔════════════════════════════════════════╗
║   ✅ BetArena está listo para usar    ║
║                                        ║
║   1. dotnet run     (Ejecutar)        ║
║   2. dotnet test    (Probar)          ║
║   3. Abre el navegador                ║
║                                        ║
║   ¡Que disfrutes! 🚀                 ║
╚════════════════════════════════════════╝
```

---

**Última actualización**: 16 de Abril de 2026  
**Versión**: 1.0  
**Estado**: ✅ LISTO PARA USAR
