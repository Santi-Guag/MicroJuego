
# Game Design Document (GDD)

## 1. Resumen del Juego
- **Título del Juego**: MicroJuego
- **Género**: Disparos de vista cenital
- **Plataforma(s)**: Windows
- **Descripción General**: El jugador controla una nave espacial y debe disparar para destruir la mayor cantidad de asteroides posibles.

## 3. Mecánicas del Juego
- **Objetivos**: Conseguir la mayor cantidad de puntos posibles antes de que se reinicie la partida. Los puntos se consiguen rompiendo asteroides, la partida se reinicia cuando la nave impacta con un enemigo.
- **Mecánicas Principales**: La nave se mueve con movimientos de tanque (adelante, atrás y giro). Los movimientos se controlan con WASD o las flechas. Otra mecánica es la de disparar, que se hace cada vez que se da al espacio.
- **Progresión del Juego**: Los puntos se consiguen cada vez que disparas y destruyes un enemigo, y se reinicia cuando la nave es impactada por un enemigo.

## 4. Diseño de Niveles
- **Número de Niveles/Escenarios**: Solo hay un nivel, el jugador inicia en el centro de la pantalla y los asteroides caen de la parte superior de la pantalla de un lugar aleatorio.
- **Dificultad**: El tiempo de spawn de los asteroides se va disminuyendo cada vez que destruyes un enemigo.

## 5. Diseño Visual
- **Estilo Artístico**: El estilo visual del juego es píxel-art.
- **Personajes**: El personaje principal es una nave espacial.
- **Entornos**: El juego está ambientado en el espacio.
- **Interfaz de Usuario (UI)**: El sistema de puntos se muestra por pantalla con un texto en la parte inferior central de la pantalla que va aumentando cada vez que se destruye un enemigo.

## 8. Requisitos Técnicos
- **Motor de Juego**: Unity.
- **Lenguajes de Programación**: C#.
- **Repositorio software**: [MicroJuego](https://github.com/Santi-Guag/MicroJuego).
