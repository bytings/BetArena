# 🧪 GUÍA DE TESTING - BetArena

## Cómo Ejecutar los Tests

### 1. Ejecutar Todos los Tests

```bash
cd BetArena
dotnet test
```

**Resultado esperado:**
```
✅ 43 tests passed
❌ 0 tests failed
⏭️  0 tests skipped
```

---

## 2. Ejecutar Tests Específicos

### Por Clase de Test

```bash
# Solo validaciones
dotnet test --filter "FullyQualifiedName~BetServiceValidationTests"

# Solo funcionalidad
dotnet test --filter "FullyQualifiedName~BetServiceFunctionalityTests"

# Solo cálculos RTP
dotnet test --filter "FullyQualifiedName~StatsCalculatorRTPTests"

# Solo estadísticas
dotnet test --filter "FullyQualifiedName~StatsCalculatorAggregationTests"

# Solo API
dotnet test --filter "FullyQualifiedName~BetsControllerIntegrationTests"

# Solo edge cases
dotnet test --filter "FullyQualifiedName~EdgeCaseTests"
```

### Por Nombre de Test

```bash
# Test específico
dotnet test --filter "DisplayName~VS-001"

# Todos los tests de Stake
dotnet test --filter "DisplayName~Stake"

# Todos los tests de RTP
dotnet test --filter "DisplayName~RTP"
```

---

## 3. Opciones Útiles

### Modo Verboso
```bash
dotnet test --verbosity detailed
```

### Con Salida en Paralelo Deshabilitada
```bash
dotnet test -p:ParallelizeTestCollections=false
```

### Con Logger Personalizado
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Guardar Resultados en XML
```bash
dotnet test --logger "trx;LogFileName=results.trx"
```

---

## 4. Categorías de Tests

### 🎯 Validaciones (13 tests)

**Propósito**: Validar que se rechazan entradas inválidas

```bash
dotnet test --filter "FullyQualifiedName~BetServiceValidationTests"
```

Cubre:
- Stake > 0
- UserId > 0
- Game != vacío
- WinAmount >= 0

---

### 📦 Funcionalidad (3 tests)

**Propósito**: Validar almacenamiento y recuperación

```bash
dotnet test --filter "FullyQualifiedName~BetServiceFunctionalityTests"
```

Cubre:
- Registro exitoso
- Recuperación de datos
- Múltiples registros

---

### 📊 RTP (5 tests)

**Propósito**: Validar cálculo del Return To Player

```bash
dotnet test --filter "FullyQualifiedName~StatsCalculatorRTPTests"
```

Cubre:
- RTP simple
- RTP múltiples apuestas
- RTP > 100%
- RTP sin datos
- Precisión de decimales

---

### 📈 Estadísticas (8 tests)

**Propósito**: Validar agrupación y agregación

```bash
dotnet test --filter "FullyQualifiedName~StatsCalculatorAggregationTests"
```

Cubre:
- Stats por usuario
- Stats por juego
- Múltiples usuarios
- Múltiples juegos

---

### 🌐 API (8 tests)

**Propósito**: Validar endpoints REST

```bash
dotnet test --filter "FullyQualifiedName~BetsControllerIntegrationTests"
```

Cubre:
- POST /api/bets (validaciones)
- GET /api/bets/stats (respuestas)

---

### 🔧 Edge Cases (6 tests)

**Propósito**: Validar casos extremos

```bash
dotnet test --filter "FullyQualifiedName~EdgeCaseTests"
```

Cubre:
- Decimales muy pequeños
- Decimales muy grandes
- Caracteres especiales
- Múltiples juegos por usuario
- RTP > 100%
- Apuestas perdidas

---

## 5. Interpretación de Resultados

### ✅ Test Exitoso
```
PASS [0.015s] BetArena.Tests.BetServiceValidationTests.RegisterBet_WithValidPositiveStake_ReturnsTrue
```

### ❌ Test Fallido
```
FAIL [0.015s] BetArena.Tests.BetServiceValidationTests.RegisterBet_WithZeroStake_ReturnsFalseAndError
Assert.False() Failure
Expected: false
Actual:   true
```

---

## 6. Debugging de Tests

### Ejecutar un Test Específico en Debug

```bash
dotnet test --filter "DisplayName~VS-001" --logger "console;verbosity=detailed"
```

### Filtrar por DisplayName

```bash
dotnet test --filter "DisplayName~Stake" --verbosity detailed
```

---

## 7. Checklist de Calidad

Antes de hacer commit, verifica:

- [ ] `dotnet test` pasa 100%
- [ ] Cobertura > 90%
- [ ] No hay warnings
- [ ] Tests documentados
- [ ] Tests independientes
- [ ] No hay datos compartidos entre tests

```bash
# Script de verificación completa
dotnet clean
dotnet restore
dotnet build
dotnet test --verbosity detailed
```

---

## 8. Casos de Uso Comunes

### Verificar Que Todo Funciona
```bash
dotnet test
```

### Verificar Solo Validaciones
```bash
dotnet test --filter "FullyQualifiedName~BetServiceValidationTests"
```

### Verificar Solo API
```bash
dotnet test --filter "FullyQualifiedName~BetsControllerIntegrationTests"
```

### Verificar Cálculos
```bash
dotnet test --filter "ClassName~Calculator"
```

### Verificar Casos Específicos
```bash
dotnet test --filter "DisplayName~RTP|Name~Edge"
```

---

## 9. Troubleshooting

### Tests no se encuentran
```bash
# Asegúrate de estar en la carpeta correcta
cd BetArena

# Limpia y restaura
dotnet clean
dotnet restore
```

### Tests fallan aleatoriamente
```bash
# Desactiva paralelismo
dotnet test -p:ParallelizeTestCollections=false
```

### Error: "No test is available"
```bash
# Verifica que tienes el SDK .NET 8
dotnet --version

# Reconstruye la solución
dotnet build --force
```

---

## 10. Métricas de Calidad

| Métrica | Target | Estado |
|---------|--------|--------|
| Tests | 43 | ✅ |
| Pass Rate | 100% | ✅ |
| Cobertura | > 90% | ✅ |
| Validaciones | 13 | ✅ |
| Funcionalidad | 3 | ✅ |
| RTP | 5 | ✅ |
| Estadísticas | 8 | ✅ |
| API | 8 | ✅ |
| Edge Cases | 6 | ✅ |

---

## 11. Integración Continua

Para CI/CD (GitHub Actions, Azure Pipelines, etc.):

```yaml
- name: Run Tests
  run: dotnet test --verbosity detailed --logger "trx;LogFileName=results.trx"

- name: Upload Results
  uses: actions/upload-artifact@v2
  if: always()
  with:
    name: test-results
    path: results.trx
```

---

## 12. Información de Contacto

**Para reportar problemas en los tests:**

1. Ejecuta: `dotnet test --verbosity detailed`
2. Guarda la salida
3. Revisa el archivo de tests
4. Verifica la lógica del código bajo test

---

**Última actualización**: 16/04/2026  
**Estado**: ✅ LISTO PARA USAR
