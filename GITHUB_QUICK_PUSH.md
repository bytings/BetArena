# 📌 RESUMEN - PASOS PARA GITHUB

## ⚡ VERSIÓN ULTRA RÁPIDA (2 minutos)

```powershell
# Abre PowerShell en: C:\Users\danie\source\repos\Practicas\BetArena

cd C:\Users\danie\source\repos\Practicas\BetArena

# Inicializa Git
git init

# Configura usuario (reemplaza con tus datos)
git config --global user.name "Tu Nombre"
git config --global user.email "tu-email@example.com"

# Agrega todos los archivos
git add .

# Primer commit
git commit -m "Initial commit: BetArena - Complete application with 43 tests"

# Cambia a main
git branch -M main

# Agrega repositorio remoto (reemplaza tu-usuario)
git remote add origin https://github.com/tu-usuario/BetArena.git

# Push a GitHub
git push -u origin main
```

## 📝 INSTRUCCIONES PASO A PASO

### 1️⃣ Antes de empezar

- Crea cuenta en GitHub (si no tienes): https://github.com
- Crea un repositorio vacío en GitHub llamado "BetArena"
- Ten git instalado (descarga desde https://git-scm.com si no tienes)

### 2️⃣ Abre PowerShell

Presiona: **Windows + R**

Escribe: `powershell`

Presiona: **Enter**

### 3️⃣ Navega a tu proyecto

```powershell
cd C:\Users\danie\source\repos\Practicas\BetArena
```

Verifica que ves tus carpetas:

```powershell
dir
```

### 4️⃣ Inicializa Git

```powershell
git init
```

### 5️⃣ Configura Git (una sola vez)

```powershell
git config --global user.name "Tu Nombre"
git config --global user.email "tu-email@gmail.com"
```

**Importante**: Usa el mismo email que en GitHub

### 6️⃣ Agrega archivos

```powershell
git add .
```

### 7️⃣ Commit inicial

```powershell
git commit -m "Initial commit: BetArena - Complete application with 43 tests"
```

### 8️⃣ Rama main

```powershell
git branch -M main
```

### 9️⃣ Conecta con GitHub

```powershell
git remote add origin https://github.com/tu-usuario/BetArena.git
```

**Reemplaza `tu-usuario` con tu usuario de GitHub**

### 🔟 Push a GitHub

```powershell
git push -u origin main
```

---

## ✅ ¡LISTO!

Abre tu navegador:

```
https://github.com/tu-usuario/BetArena
```

¡Deberías ver todos tus archivos en GitHub! 🎉

---

## 📚 Para más detalles

Lee: `GITHUB_PUSH_STEP_BY_STEP.md`

---

**¡Felicidades! Tu BetArena está en GitHub! 🚀**
