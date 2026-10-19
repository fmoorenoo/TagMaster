<div align="center">

# TagMaster

### Videojuego educativo para aprender el orden de las etiquetas HTML

**Unity · C# · Juego de lógica · Demo WebGL**

![Unity](https://img.shields.io/badge/Unity-1A1B26?style=for-the-badge&logo=unity&logoColor=E46B79)
![C%23](https://img.shields.io/badge/C%23-1A1B26?style=for-the-badge&logo=csharp&logoColor=E46B79)
![HTML](https://img.shields.io/badge/HTML-1A1B26?style=for-the-badge&logo=html5&logoColor=E46B79)
![WebGL](https://img.shields.io/badge/WebGL-1A1B26?style=for-the-badge&logo=webgl&logoColor=E46B79)

[![Estado](https://img.shields.io/badge/ESTADO-Proyecto_académico-712B39?style=flat-square)](#estado-del-proyecto)
[![Demo](https://img.shields.io/badge/DEMO-Jugar_online-712B39?style=flat-square)](https://fmoorenoo.github.io/TagMasterPage/)
[![Código](https://img.shields.io/badge/REPOSITORIO-Código_fuente-22252C?style=flat-square)](https://github.com/fmoorenoo/TagMaster)

**[Jugar a TagMaster](https://fmoorenoo.github.io/TagMasterPage/)** · **[Ver el repositorio de la versión web](https://github.com/fmoorenoo/TagMasterPage)**

</div>

---

## Sobre el proyecto

**TagMaster** es un videojuego educativo desarrollado en **Unity con C#**, inspirado en *Super Markup Man*. El desafío consiste en **colocar etiquetas HTML en el orden correcto** para completar líneas de código y avanzar por distintos niveles.

El personaje es una mano que se desplaza por el escenario para recoger y colocar etiquetas. El juego combina movimiento lateral, resolución de problemas y un límite de tiempo.

## Mecánicas y funcionalidades

- **Aprendizaje mediante juego:** ordenar etiquetas HTML para completar secuencias.
- **Seis niveles:** progresión a través de ejercicios representados como líneas de código.
- **Movimiento del personaje:** desplazamiento lateral con las teclas `A` y `D`, con animación de salto.
- **Interacción con etiquetas:** el jugador puede recoger y soltar objetos para reorganizarlos.
- **Validación de respuestas:** un gestor comprueba el orden de las etiquetas antes de avanzar.
- **Cuenta atrás:** tiempo limitado para completar la partida y estados de victoria o derrota.
- **Demo en navegador:** versión WebGL publicada a través de GitHub Pages.

Las mecánicas se han contrastado con los scripts y el README original. No se ha realizado una ejecución completa del videojuego durante esta revisión.

## Tecnologías

| Área | Tecnologías |
| --- | --- |
| **Motor** | Unity 2022.3.55f1 |
| **Programación** | C# |
| **Interfaz** | Unity UI · TextMesh Pro |
| **Lógica de juego** | MonoBehaviour · Coroutines · gestión de escenas |
| **Contenido educativo** | HTML |
| **Distribución web** | Unity WebGL · GitHub Pages |

## Arquitectura

```text
TagMaster/
├── Assets/
│   ├── Scenes/
│   │   ├── Main.unity            # Menú principal
│   │   └── Game.unity            # Escenario de juego
│   ├── Scripts/
│   │   ├── PlayerMovement.cs     # Desplazamiento del personaje
│   │   ├── HTMLTag.cs            # Recoger y soltar etiquetas
│   │   ├── LevelManager1.cs      # Progresión entre niveles
│   │   ├── LevelData.cs          # Información de cada nivel
│   │   ├── LevelUtilities.cs     # Utilidades de validación y movimiento
│   │   ├── Timer.cs              # Cuenta atrás
│   │   └── ...                   # Cámara, escenas y utilidades
│   └── ...                       # Modelos, materiales y recursos
├── Packages/                      # Dependencias de Unity
└── ProjectSettings/               # Configuración del proyecto
```

Los scripts gestionan el movimiento, la interacción con las etiquetas, la comprobación del orden y el cambio de niveles. Las escenas se organizan en menú principal y partida.

## Cómo jugar

| Control | Acción |
| --- | --- |
| `A` | Desplazamiento a la izquierda |
| `D` | Desplazamiento a la derecha |
| `Espacio` | Interactuar y agarrar etiquetas, según la documentación original |

**Objetivo:** colocar las etiquetas HTML correctamente y superar los **seis niveles** antes de que finalice el tiempo disponible. El README original indica una partida de aproximadamente **50 segundos**; el script `Timer.cs` inicia la cuenta en 51 segundos.

### Demo web

**[Abrir TagMaster y jugar en el navegador →](https://fmoorenoo.github.io/TagMasterPage/)**

La versión web se distribuye desde el repositorio independiente [TagMasterPage](https://github.com/fmoorenoo/TagMasterPage). La URL está documentada en el proyecto original; su funcionamiento en cada navegador no se ha probado durante esta revisión.

## Capturas del juego

Se conservan las capturas originales del menú y de la partida.

| Menú principal | Escenario de juego |
| :---: | :---: |
| <img src="https://github.com/user-attachments/assets/b1e7fc72-6fbd-4087-b0f3-f9989acb7ca8" alt="Menú principal de TagMaster" width="100%"> | <img src="https://github.com/user-attachments/assets/d76e2698-fef5-45cd-8959-b92ce5e85d72" alt="Partida de TagMaster con etiquetas HTML" width="100%"> |

## Instalación y ejecución

1. Clona el repositorio:
   ```bash
   git clone https://github.com/fmoorenoo/TagMaster.git
   ```
2. Instala **Unity Hub** y una versión compatible de **Unity 2022.3.55f1**.
3. Abre la carpeta del repositorio como proyecto de Unity.
4. Espera a que Unity importe los assets y las dependencias.
5. Abre `Assets/Scenes/Main.unity` y ejecuta la escena desde el editor.

La apertura, compilación y exportación del proyecto no se han verificado en esta revisión.

## Estado del proyecto

**Proyecto académico con código fuente y versión web publicada.**

El repositorio contiene recursos propios del editor de Unity y dependencias de terceros. Para redistribuir o ampliar el proyecto conviene revisar las licencias de los assets utilizados y la configuración de compilación WebGL.

## Autor

**Fernando Montelongo Moreno** · Full Stack Developer · DAM + DAW

[![GitHub](https://img.shields.io/badge/GitHub-fmoorenoo-22252C?style=flat-square&logo=github)](https://github.com/fmoorenoo)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Perfil_profesional-712B39?style=flat-square&logo=linkedin)](https://www.linkedin.com/in/fernando-montelongo/)

---

<div align="center">
  <sub>TagMaster · Aprender HTML jugando · Unity y C#</sub>
</div>
