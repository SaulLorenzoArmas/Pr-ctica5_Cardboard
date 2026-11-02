# Práctica 5: Google Cardboard en Unity

En esta práctica se utiliza el paquete de Google Cardboard XR Plugin en Unity para desarrollar escenas de realidad virtual. La interacción se controla mediante la vista a través de `Raycast` y los mensajes del sistema de eventos (`OnPointerEnter`, `OnPointerExit` y `OnPointerClick`), programados mediante scripts en C#.

## 1. Escena de prueba

En esta primera parte se configura el proyecto con la escena de plantilla de Google Cardboard y se genera el archivo para poder usarlo en el movil. 

La escena incluye un objeto que reacciona a la vista del usuario: cuando el rayo de la cámara apunta hacia él (`OnPointerEnter`), cambia de material y color; al dejar de mirarlo (`OnPointerExit`), vuelve a su estado original; y al seleccionarlo (`OnPointerClick`), se teletransporta a una nueva posición aleatoria dentro de la escena.

![alt text](imagenes/Ejercicio_1.gif)

## 2. Escena de recolección
En este segundo ejercicio se ha desarrollado un minijuego en el que el jugador captura Pokémon utilizando la vista. El juego se ambienta en un bosque donde hay repartidos diferentes pokemon's que se van a capturar y guardar en un cofre. Cuando el jugador mira a un Pokémon, este desaparece de la escena, reproduce su sonido correspondiente y se actualiza el contador de pokemon's capturados.

Para la implementación, inicialmente se orientan los pokemon's hacia el jugador con `transform.LookAt`. Cuando el jugador mira a un Pokémon, se ejecuta la función `OnPointerEnter`, que desactiva tanto sus `Renderer` como su `SphereCollider` para ocultarlo y evitar capturas repetidas. En ese mismo instante, se reduce el volumen de la música ambiente, se reproduce el grito del Pokémon mediante `sonidoPokemon.Play()`, se incrementa el contador en `jugador.puntos` y se muestra en el canvas. Por último, se utiliza `Invoke` para esperar a que el audio del Pokémon se reproduzca antes de restaurar el volumen de la música ambiente a su nivel normal.

![alt text](imagenes/Ejercicio_2.gif)

## Ejercicio 3: Atracción y recuperación mediante el cofre

Partiendo del escenario anterior, se ha añadido un cofre que permite reunir a los Pokémon del mapa. Cuando el jugador fija la mirada sobre el cofre, todos los Pokémon salen de su escondite y comienzan a desplazarse hacia el jugador, deteniéndose a una distancia de él para poder observarlos a todos.

Para ello, se crea un evento personalizado  `OnEventoVista`. El cofre crea el evento, que se lanza al mirar el cofre dentro de su método `OnPointerEnter`. Por otra parte, cada Pokémon se responde a dicho evento moviéndose hacia el jugador. Cuando ya están considerablemente cerca se paran de acercar y quedan visibles delante del jugador.

![alt text](imagenes/Ejercicio_3.gif)