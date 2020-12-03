# Evaluación individual. 2 de diciembre

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/prueba1/game.gif)

Para la realización de la práctica se han utilizado los assets entregados.

## Jugador

Se ha desarrollado un nuevo controlador de jugador para la prueba que actualiza los parámetros del Animator del personaje.

El Animator del personaje usa dos blend trees para controlar los estado de movimiento y de parada.

Para la colisión del personaje se ha usado un CapsuleCollider2D que rodea los pies del personaje.

## Enemigos

La muerte hace spawn aleatoriamente usando puntos de spawn predefinidos y se mueve aleatoriamente por la escena.

Al tocar al jugador, este pierde las vidas y su poder, y es teletransportado al punto de partida.

Para simplificar el movimiento de la muerte se ha hecho que sea Kinematic y trigger por lo que no colisiona con los elementos del escenario.

## Gato

El gato da una cantidad predefinida de poder al jugador al colisionar con el.

## Colisiones

Para este proyecto hemos usado las capas Player y OnlyCollidesWithPlayer para optimizar las colisiones y no tener que detectar si el objeto que entra los triggers es el player, ya que es el único objeto que puede colisionar con esa capa.

La capa OnlyCollidesWithPlayer se usa para el gato, enemigos, la roca y las tumbas.

## Mapa

Para el mapa se ha usado un tilemap 2D, usando una paleta creada a partir de las imágenes disponibles.

## Eventos

Para los eventos se ha utilizado EventManager que funciona como buffer de eventos al que los objetos pueden registrarse.

Si el jugador entra el trigger de una tumba 3 veces se envia un evento que es capturado por el GameController y si esto se repite 3 veces el jugador obtiene una vida.

Si el jugador colisiona con el gato, el evento es capturado por el GameController y se incrementa el poder del jugador.

Si el jugador entra en el trigger de una roca, se lanza un evento que es capturado por los enemigos y el gato y actúa de forma diferente: el enemigo cambia su dirección y el gato mira para el lado contrario.

### Eventos de UI

Para actualizar la UI se han utilizado eventos de Unity (UnityEvent) por lo que en el inspector del GameController disponemos de OnPlayerLivesChanged y OnPlayerPowerChanged que llaman a funciones específicas de GameUI para actualizar los valores mostrados en la UI.

