# Técnicas

En esta práctica hemos realizado un prototipo que se ajusta a los siguientes requerimientos
- Scroll con movimiento del fondo. El personaje salta sobre objetos que aparecen en la escena.
- Scroll con movimiento del personaje. El fondo se repite hasta que pare el juego.
- Fondo con efecto parallax. El efecto empieza cuando el jugador empieza a moverse, esto se debe comunicar mediante eventos.
- Utilizar la técnica de pool de objetos para ir creando elementos en el juego sobre los que debe saltar el jugador evitándolos o para adquirir puntos si salta sobre ellos.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega11/game.gif)

Para la realización de la práctica se han utilizado los siguientes assets:

https://ansimuz.itch.io/gothicvania-patreon-collection

https://rvros.itch.io/animated-pixel-hero

## Parallax

Para la implementación del parallax se han usado dos componentes. ParallaxEffect y ParallaxLayer.

ParallaxEffect se encarga de actualizar las capas. Aunque no es realmente necesario (ya que cada capa puede actualizarse a si misma), tener este controlador nos permitiría pasar un escalar para controllar la velocidad de todas las capas a la vez basándonos por ejemplo en la velocidad del jugador.

ParallaxLayer controla la recolocación de sprites que salen fuera de la pantalla por la izquierda, resposicionando estos sprites para su reaparición, fuera de pantalla a la derecha de la camara.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega11/parallax.gif)

## Eventos

Se ha creado un GameManager que envía dos eventos. Uno para la actualización de UI cuando la puntuación cambia y otro para el comienzo del juego.

Cuando se lanza el evento de comienzo de juego, el ObjectSpawner (que instancia enemigos), el ParallaxEffect y el PlayerController se activan para comenzar el juego.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega11/gm.png)

## Físicas

Al igual que en prácticas anteriores se han usado las capas Player y OnlyCollidesWithPlayer por motivos de optimización y simplificación de código.

El jugador usa un BoxCollider2D y se ha posicionado otro collider estático que actua como suelo.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega11/physics.png)

Para los enemigos se han utilizado dos colliders, uno sobre el enemigo para incrementar la puntuación cuando el jugador entra en el trigger y otro que cubre al enemigo y su parte inferior para matar al jugador. 

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega11/enemy.png)

Ambos colliders usan la capa OnlyCollidesWithPlayer y envían un evento en OnTriggerEnter usando el componente TriggerListener. Estos eventos son recogidos por el GameManager que actualiza los datos de juego y notifica a otros componentes (como la UI) de estos cambios.

## Pooling

Se ha usado el componente ObjectPool para crear un pool de enemigos que se inicializa con un número determinado de instancias.

El componente ObjectSpawner se encarga de obtener de esta pool las instancias disponibles.

Los enemigos son desactivados tras pasar un intervalo de tiempo usando el componente DisableAfterTime. Volviendo a estar disponibles en la pool.

## UI

Se ha implementado una UI simple que muestra la puntuación obtenida por el jugador. Esta UI se actualiza al recibir el evento de que la puntuación ha cambiado desde el GameManager.


