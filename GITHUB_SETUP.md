# 🔄 GITHUB SETUP Y CI/CD - BetArena

## 📋 Configurar Repositorio en GitHub

### 1. Crear Repositorio en GitHub

1. Ve a https://github.com/new
2. **Repository name**: `BetArena`
3. **Description**: "Mini aplicación fullstack para gestión de apuestas deportivas y juegos de casino"
4. **Visibility**: Public (o Private según prefieras)
5. **Initialize**: NO necesitas README (ya tienes uno)
6. Click en **Create repository**

### 2. Conectar Repositorio Local

```bash
# Navega al proyecto
cd BetArena

# Agrega el origen remoto
git remote add origin https://github.com/tu-usuario/BetArena.git

# Rama principal
git branch -M main

# Push inicial
git push -u origin main
```

---

## 📝 Configurar .gitignore

Crea `.gitignore` en la raíz (si no existe):

```
# Binarios y objetos
bin/
obj/
*.exe
*.dll
*.pdb

# Archivos de usuario
*.user
*.userprefs

# Build
*.log
*.tlog

# Dependencias
packages/
NuGetFallbackFolder/

# VS Code
.vscode/
.vs/

# IDE
.idea/
*.sln.iml

# Temporales
temp/
tmp/

# OS
.DS_Store
Thumbs.db

# Resultado de tests
TestResults/
coverage/
*.trx
```

---

## 🚀 GitHub Actions - CI/CD

### 1. Crear Workflow de Compilación

Crea: `.github/workflows/build.yml`

```yaml
name: Build and Test

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main, develop ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '8.0.x'
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --no-restore --configuration Release
    
    - name: Run tests
      run: dotnet test --no-build --verbosity normal --logger "trx;LogFileName=test-results.trx"
    
    - name: Upload test results
      if: always()
      uses: actions/upload-artifact@v3
      with:
        name: test-results
        path: '**/test-results.trx'
```

### 2. Crear Workflow de Publish

Crea: `.github/workflows/publish.yml`

```yaml
name: Publish to NuGet

on:
  release:
    types: [created]

jobs:
  publish:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '8.0.x'
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --configuration Release --no-restore
    
    - name: Pack
      run: dotnet pack --configuration Release --no-build
    
    - name: Push to NuGet
      run: dotnet nuget push "**/*.nupkg" --api-key ${{ secrets.NUGET_API_KEY }} --source https://api.nuget.org/v3/index.json
```

### 3. Crear Workflow de Análisis de Código

Crea: `.github/workflows/codeql.yml`

```yaml
name: CodeQL

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main, develop ]

jobs:
  analyze:
    runs-on: ubuntu-latest
    
    steps:
    - name: Checkout repository
      uses: actions/checkout@v3
    
    - name: Initialize CodeQL
      uses: github/codeql-action/init@v2
      with:
        languages: 'csharp'
    
    - name: Autobuild
      uses: github/codeql-action/autobuild@v2
    
    - name: Perform CodeQL Analysis
      uses: github/codeql-action/analyze@v2
```

---

## 📚 Documentación en GitHub

### README.md principal

El `README.md` ya contiene:
- ✅ Descripción del proyecto
- ✅ Características
- ✅ Requisitos
- ✅ Instalación
- ✅ Guía de uso
- ✅ API REST
- ✅ Validaciones
- ✅ Arquitectura
- ✅ Tests

### Estructura de Documentación

```
📁 docs/
├── QUICK_START.md          # Inicio rápido
├── INSTALLATION_GUIDE.md   # Guía de instalación
├── TESTING_GUIDE.md        # Cómo ejecutar tests
├── TESTING_PLAN.md         # Plan de tests
└── API.md                  # Documentación API
```

Crea la carpeta `docs` y mueve los archivos:

```bash
mkdir docs
mv QUICK_START.md docs/
mv INSTALLATION_GUIDE.md docs/
```

---

## 🔐 Configurar Secrets en GitHub

### 1. Agrega Secrets

Ve a: **Settings → Secrets and variables → Actions**

Click en **New repository secret**

### Secrets Recomendados

| Secret | Valor | Uso |
|--------|-------|-----|
| `NUGET_API_KEY` | Tu API key de NuGet | Publicar paquetes |
| `GITHUB_TOKEN` | Automático | CI/CD básico |

---

## 📊 Status Badge

Agrega a tu `README.md`:

```markdown
[![Build and Test](https://github.com/tu-usuario/BetArena/workflows/Build%20and%20Test/badge.svg)](https://github.com/tu-usuario/BetArena/actions)
```

---

## 🎯 Pull Request Template

Crea: `.github/pull_request_template.md`

```markdown
## Descripción
<!-- Describe los cambios que hace este PR -->

## Tipo de Cambio
- [ ] Bug fix
- [ ] Nuevo feature
- [ ] Breaking change
- [ ] Cambio en documentación

## Cómo se Probó
<!-- Describe cómo probaste estos cambios -->

## Checklist
- [ ] El código sigue los estilos del proyecto
- [ ] Los tests locales pasan
- [ ] Se agregaron tests para el nuevo código
- [ ] La documentación fue actualizada

## Screenshots (si aplica)
<!-- Agrega screenshots si es relevante -->
```

---

## 🐛 Issue Template

Crea: `.github/ISSUE_TEMPLATE/bug_report.md`

```markdown
---
name: Bug report
about: Reportar un bug
title: "[BUG] "
labels: bug
assignees: ''
---

## Descripción del Bug
<!-- Describe el bug claramente -->

## Pasos para Reproducir
1. 
2. 
3. 

## Comportamiento Esperado
<!-- Qué debería pasar -->

## Comportamiento Actual
<!-- Qué pasó realmente -->

## Logs/Screenshots
<!-- Agrega logs o screenshots si es posible -->

## Información del Sistema
- OS: 
- .NET Version: 
- Browser: 
```

---

## 📋 Checklist de GitHub Setup

```
[ ] Repositorio creado en GitHub
[ ] Local repository conectado
[ ] .gitignore configurado
[ ] Primer push a main exitoso
[ ] Build workflow creado
[ ] Tests workflow creado
[ ] README.md revisado
[ ] Documentación actualizada
[ ] Secrets configurados
[ ] Branch protection rules establecidas
```

---

## 🔐 Branch Protection Rules

### Configurar Main Branch

1. Ve a **Settings → Branches**
2. Click en **Add rule**
3. **Branch name pattern**: `main`
4. Habilita:
   - ✅ Require a pull request before merging
   - ✅ Require status checks to pass before merging
   - ✅ Require branches to be up to date
   - ✅ Dismiss stale pull request approvals when new commits are pushed

---

## 📦 Releases

### Crear Release

1. Ve a **Releases**
2. Click en **Draft a new release**
3. **Tag version**: `v1.0.0`
4. **Release title**: `BetArena v1.0.0`
5. **Description**: Cambios principales
6. Click en **Publish release**

### Versionado Semántico

```
v[MAJOR].[MINOR].[PATCH]

Ejemplo: v1.0.0
- MAJOR: Cambios incompatibles
- MINOR: Nuevas features compatibles
- PATCH: Bug fixes
```

---

## 📞 Configurar Colaboradores

### Invitar Colaboradores

1. Ve a **Settings → Collaborators and teams**
2. Click en **Add people**
3. Busca el usuario
4. Selecciona permiso:
   - **Pull**: Solo lectura
   - **Triage**: Lectura + gestionar issues
   - **Push**: Lectura + escritura
   - **Maintain**: Acceso a settings
   - **Admin**: Control total

---

## 🎯 Código de Conducta

Crea: `CODE_OF_CONDUCT.md`

```markdown
# Código de Conducta

## Nuestro Compromiso
Nosotros como miembros, colaboradores y líderes nos comprometemos a hacer que 
la participación en nuestra comunidad sea una experiencia libre de acoso para todos.

## Nuestros Estándares
- Ser respetuoso y profesional
- Aceptar crítica constructiva
- Enfocarse en lo mejor para la comunidad

## Aplicación
Las instancias de comportamiento abusivo, de acoso o inaceptable pueden ser 
reportadas a los mantenedores del proyecto.

## Atribución
Este Código de Conducta es adaptado de [Contributor Covenant][homepage].
```

---

## 📄 CONTRIBUTING.md

Crea: `CONTRIBUTING.md`

```markdown
# Contribuyendo a BetArena

¡Gracias por tu interés en contribuir! Aquí está cómo hacerlo:

## Comenzar

1. Fork el repositorio
2. Clone tu fork: `git clone https://github.com/tu-usuario/BetArena.git`
3. Crea una rama: `git checkout -b feature/mi-feature`

## Desarrollar

1. Realiza tus cambios
2. Asegúrate de que los tests pasen: `dotnet test`
3. Sigue el estilo de código existente

## Hacer Commit

```bash
git add .
git commit -m "feat: descripción de tu feature"
```

## Push y Pull Request

1. Push a tu fork: `git push origin feature/mi-feature`
2. Abre un Pull Request
3. Describe los cambios
4. Espera la revisión

## Convenciones de Commit

- `feat`: Nueva feature
- `fix`: Bug fix
- `docs`: Cambios en documentación
- `style`: Cambios en estilo (sin lógica)
- `refactor`: Refactorización
- `test`: Agregar/modificar tests

## Reportar Bugs

1. Usa el template de bug report
2. Incluye pasos para reproducir
3. Agrega logs/screenshots
4. Describe el comportamiento esperado
```

---

## 🔄 GitHub Pages (Documentación)

### Habilitar GitHub Pages

1. Ve a **Settings**
2. Desplaza a **GitHub Pages**
3. **Source**: `main` branch, `docs` folder
4. Tu documentación estará en: `https://tu-usuario.github.io/BetArena`

### Agregar Índice en docs

Crea: `docs/index.md`

```markdown
# BetArena - Documentación

Bienvenido a la documentación de BetArena.

## Comenzar

- [Quick Start](QUICK_START.md)
- [Instalación](INSTALLATION_GUIDE.md)

## Desarrollo

- [Guía de Testing](../TESTING_GUIDE.md)
- [Plan de Testing](../TESTING_PLAN.md)

## API

- [Documentación API](API.md)

## Contribuir

- [Guía de Contribución](../CONTRIBUTING.md)
```

---

## 📊 GitHub Analytics

Monitorea:

1. **Insights → Traffic**: Clones y visitantes
2. **Insights → Network**: Grafo de commits
3. **Insights → Pulse**: Actividad general
4. **Insights → Code frequency**: Actividad de código

---

## 🎉 Checklist Final

```
Antes de publicar en GitHub:

[ ] Repositorio creado
[ ] Local conectado y pusheado
[ ] .gitignore configurado
[ ] README.md completo
[ ] Documentación agregada
[ ] Workflows de CI/CD creados
[ ] Secrets configurados
[ ] Branch rules establecidas
[ ] CODE_OF_CONDUCT.md agregado
[ ] CONTRIBUTING.md agregado
[ ] Primera release publicada
[ ] GitHub Pages habilitado
```

---

## 📞 Comandos Git Útiles

```bash
# Clonar
git clone https://github.com/tu-usuario/BetArena.git

# Crear rama
git checkout -b feature/mi-feature

# Ver cambios
git status

# Agregar cambios
git add .

# Commit
git commit -m "feat: descripción"

# Push
git push origin feature/mi-feature

# Actualizar desde main
git fetch origin
git merge origin/main

# Ver log
git log --oneline

# Revertir cambios
git reset --hard
```

---

**Última actualización**: 16 de Abril de 2026  
**Versión**: 1.0  
**Estado**: ✅ LISTO PARA GITHUB
