
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
  
## 9. Scripts
- **Player**: Este script controla el comportamiento del jugador en un juego. Gestiona el movimiento de una nave espacial utilizando una fuerza de empuje y rotación basada en la entrada del usuario. Además, controla la creación de balas cuando el jugador dispara y reinicia la escena al colisionar con un enemigo, restableciendo la puntuación a cero
- **Bullet**: Este script controla el comportamiento de las balas en el juego. Las balas se mueven en la dirección indicada y se destruyen después de un tiempo o al colisionar con un enemigo. Al impactar un enemigo, aumenta la puntuación del jugador y se actualiza el texto de la interfaz de usuario para reflejar los puntos obtenidos
- **EnemySpawner**: Este script controla la generación de asteroides en el juego. Los asteroides se crean a intervalos que se ajustan dinámicamente, aumentando la frecuencia de aparición con el tiempo. Los asteroides se generan en posiciones aleatorias dentro de los límites definidos y se destruyen automáticamente después de un tiempo determinado

## 10. Prefabs
- **Bullet**: prefab para las balas que dispara la nave
- **Meteor**: prefab para los enemigos en forma de asteroide
