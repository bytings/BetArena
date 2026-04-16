# 🚀 GUÍA PASO A PASO - SUBIR A GITHUB

## ⚡ Resumen Rápido (5 minutos)

Si quieres empezar YA:

```bash
# 1. Abre PowerShell en C:\Users\danie\source\repos\Practicas\BetArena
cd C:\Users\danie\source\repos\Practicas\BetArena

# 2. Inicializa Git
git init

# 3. Agrega todos los archivos
git add .

# 4. Haz commit
git commit -m "Initial commit: BetArena - Complete application with 43 tests"

# 5. Crea rama main (si no existe)
git branch -M main

# 6. Agrega tu repositorio GitHub
git remote add origin https://github.com/tu-usuario/BetArena.git

# 7. Push a GitHub
git push -u origin main
```

---

## 📋 PASO A PASO DETALLADO

### PASO 1: Verifica que Git está instalado

Abre PowerShell y ejecuta:

```powershell
git --version
```

**Esperado**: Deberías ver algo como `git version 2.x.x`

Si no está instalado:
- Descarga desde: https://git-scm.com/download/win
- Instala y reinicia PowerShell

---

### PASO 2: Crea un Repositorio en GitHub

1. Abre: https://github.com/new
2. **Repository name**: `BetArena`
3. **Description**: "Mini aplicación fullstack para gestión de apuestas deportivas y juegos de casino online con ASP.NET Core 8, Razor Pages y 43 tests unitarios"
4. **Visibility**: Selecciona **Public** (así otros lo pueden ver)
5. **Initialize repository**: NO marques nada (ya tienes archivos locales)
6. Click en **Create repository**

**Resultado**: Se te mostrará algo como:
```
https://github.com/tu-usuario/BetArena
```

Copia esta URL.

---

### PASO 3: Abre PowerShell en tu Proyecto

```powershell
# Navega a la carpeta raíz del proyecto
cd C:\Users\danie\source\repos\Practicas\BetArena

# Verifica que ves los archivos
dir

# Deberías ver carpetas como: BetArena, BetArena.Tests, etc.
```

---

### PASO 4: Inicializa Git Localmente

```powershell
git init
```

**Esperado**: 
```
Initialized empty Git repository in C:\Users\danie\source\repos\Practicas\BetArena\.git\
```

---

### PASO 5: Configura tu Usuario de Git

```powershell
# Configura tu nombre
git config --global user.name "Tu Nombre"

# Configura tu email
git config --global user.email "tu-email@example.com"
```

**Nota**: Usa el mismo email que usaste en GitHub.

---

### PASO 6: Verifica el .gitignore

Asegúrate de que el archivo `.gitignore` está en la raíz:

```powershell
# Ver si existe
ls .gitignore

# Si no existe, crearé uno para ti
```

Debería contener:
```
bin/
obj/
*.exe
*.dll
.vs/
.vscode/
```

---

### PASO 7: Agrega todos los Archivos

```powershell
git add .
```

**Nota**: El `.` significa "agregar todo"

---

### PASO 8: Verifica qué se va a agregar

```powershell
git status
```

**Esperado**: Deberías ver:
```
On branch master

Initial commit

Changes to be committed:
  new file:   BetArena\Models\Bet.cs
  new file:   BetArena\Models\BetStats.cs
  ...
  (todos tus archivos)
```

---

### PASO 9: Haz el Primer Commit

```powershell
git commit -m "Initial commit: BetArena - Complete application with 43 tests"
```

**Esperado**:
```
[main (root-commit) abc1234] Initial commit...
 51 files changed, 10000+ insertions(+)
```

---

### PASO 10: Cambia a Rama Main

```powershell
git branch -M main
```

---

### PASO 11: Agrega el Repositorio Remoto

Usa la URL que copiaste en PASO 2:

```powershell
git remote add origin https://github.com/tu-usuario/BetArena.git
```

**Reemplaza `tu-usuario` con tu usuario de GitHub**

---

### PASO 12: Verifica la Conexión

```powershell
git remote -v
```

**Esperado**:
```
origin  https://github.com/tu-usuario/BetArena.git (fetch)
origin  https://github.com/tu-usuario/BetArena.git (push)
```

---

### PASO 13: Push a GitHub

```powershell
git push -u origin main
```

**Esperado**:
```
Enumerating objects: 51, done.
Counting objects: 100% (51/51), done.
...
To https://github.com/tu-usuario/BetArena.git
 * [new branch]      main -> main
Branch 'main' set up to track remote branch 'main' from 'origin'.
```

---

### PASO 14: Verifica en GitHub

1. Abre: https://github.com/tu-usuario/BetArena
2. Deberías ver todos tus archivos y carpetas
3. ¡Felicidades! 🎉

---

## ✅ VERIFICACIÓN FINAL

Para verificar que todo funcionó:

```powershell
# Ver el estado
git status

# Ver logs
git log --oneline

# Ver remoto
git remote -v
```

Todo debería verse limpio sin cambios pendientes.

---

## 🐛 TROUBLESHOOTING

### Error: "fatal: Could not read Username"

**Solución**: Necesitas autenticarse en GitHub

```powershell
# Opción 1: Usar token personal (recomendado)
# 1. Ve a GitHub → Settings → Developer settings → Personal access tokens
# 2. Crea un token con permisos "repo"
# 3. Copia el token
# 4. Cuando pida contraseña, pega el token

# Opción 2: Configurar SSH (más avanzado)
# https://docs.github.com/en/authentication/connecting-to-github-with-ssh
```

---

### Error: "fatal: remote origin already exists"

**Solución**:
```powershell
# Si ya existe un origen, reemplázalo
git remote remove origin

# Luego agrega el nuevo
git remote add origin https://github.com/tu-usuario/BetArena.git
```

---

### Error: "Everything up-to-date"

Significa que ya lo subiste. ¡Todo bien! ✅

---

### Los archivos no aparecen en GitHub

**Soluciones**:
1. Espera 30 segundos y recarga la página
2. Verifica que el push fue exitoso: `git log`
3. Verifica la rama: `git branch` (debe estar en `main`)

---

## 📊 Comandos Útiles

```powershell
# Ver estado
git status

# Ver cambios
git diff

# Ver logs
git log --oneline

# Ver ramas
git branch -a

# Ver remoto
git remote -v

# Agregar cambios futuros
git add .

# Hacer commit
git commit -m "Tu mensaje"

# Hacer push
git push origin main

# Actualizar desde GitHub
git pull origin main
```

---

## 🎯 AHORA QUE ESTÁ EN GITHUB

### Próximos pasos:

1. **Agrega Descripción** (en la página principal del repo):
   - Settings → Edit description
   - Agrega: "Mini aplicación fullstack ASP.NET Core 8 con 43 tests"

2. **Agrega Topics** (tags):
   - Settings → Topic
   - Agrega: `csharp`, `dotnet`, `aspnet-core`, `testing`

3. **Habilita Wiki** (opcional):
   - Settings → Features → Wiki

4. **Configura Branch Protection** (opcional):
   - Settings → Branches → Add rule
   - Branch: `main`
   - Require pull request reviews

---

## 🎉 ¡ÉXITO!

```
╔═══════════════════════════════════════════════════════╗
║                                                       ║
║   ✅ BetArena en GitHub - ¡PUBLICADO!               ║
║                                                       ║
║   URL: https://github.com/tu-usuario/BetArena       ║
║                                                       ║
║   Ahora puedes:                                       ║
║   ✓ Compartir el link                                ║
║   ✓ Invitar colaboradores                            ║
║   ✓ Recibir pull requests                            ║
║   ✓ Publicar releases                                ║
║   ✓ Usar GitHub Pages para documentación             ║
║                                                       ║
╚═══════════════════════════════════════════════════════╝
```

---

**Última actualización**: 16 de Abril de 2026  
**Versión**: 1.0  
**Estado**: ✅ LISTO PARA PUBLICAR
