# The Ancient

[![The Ancient Video](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/ytThumbnail.png)](https://www.youtube.com/watch?v=rrtXn2t2kok)

En este proyecto se ha desarrollado un prototipo que contiene una gran parte de los elementos y técnicas estudiadas en clase para el desarrollo de videojuegos

## Descripción

The Ancient es un videojuego de plataformas metroidvania en donde el jugador tiene que entrar en distintos templos para absorver el poder de los "Ancients". Cada uno de estos poderes, localizados en templos diferentes, permiten al jugador avanzar progresivamente en su aventura y su lucha contra las fuerzas de la oscuridad.

Este prototipo, presenta al jugador la incursión del jugador en el primer templo y explora alguna de las mecánicas que podrían formar parte del videojuego final.

Durante el desarrollo del nivel, el jugador puede obtener orbes de energía que funcionan a forma de puntuación. Si el jugador muere es teletransportado a la posición más cercana y pierde un numero determinado de orbes de energía.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/gameplay.gif)]

## Cámara

Para la creación de la cámara se ha usado Cinemachine.

El juego usa una camara 2D con diferentes comportamientos. 
- En algunas áreas, la cámara se encuentra confinada para mostrar únicamente una parte del nivel (sub retos). Este confinamiento se mantiene activo hasta que el jugador entra una nueva área de confinamiento.
- En otras áreas, la cámara persigue al jugador de forma algo más libre, aunque siempre con un confinamiento para evitar enseñar áreas "off-limit" al jugador.

También se ha hecho uso de la extensión de impulsos de Cinemachine para hacer temblar la cámara cuando el jugador muere.

En el momento cinemático final se hace uso de una cámara secundaria que se activa y desactiva durante la secuencia para cambiar el zoom y foco de la escena.

## Nivel

El nivel del juego se ha dividido en 11 sub áreas con distintos retos que introducen las mecánicas al jugador de forma progresiva.

Para el diseño del nivel se ha hecho uso de las herramientas de diseño de niveles basados en Tiles ofrecidas por Unity.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/level.png)]

## Mecánicas

El prototipo presenta las siguientes mecánicas al jugador:

### Palancas

Permiten activar mecanismos como puertas o pinchos.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/lever.png)]

### Placas Presionables

Permiten activar mecanismos como puertas o pinchos pero mayormente se usan para spawnear cajas. A diferencia de las palancas, las placas vuelven a su estado original y pueden presionarse nuevamente.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/button.png)]

### Pinchos

Suponen una amenaza para el jugador y lo matan si este cae en ellos. Normalmente pueden aparecer o desaparecer al activar un mecanismo.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/spikes.png)]

### Plataformas Rompibles

Permiten al jugador saltar sobre ellas pero solo durante un periodo corto de tiempo, después del cual se rompen. Las plataformas reaparecen al pasar un tiempo.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/crumbling.png)]

### Puntos de respawn

El jugador los activa al pasar sobre ellos. Si el jugador muere es teletransportado al último punto de respawn activado.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/respawn.png)]

## Interfaz de Usuario

El prototipo muestra al jugador distintas UIs durante el menu principal y el gameplay.

#### Teleprompter

Tanto para el menú principal como para el sistema de dialogo se hace uso de un sistema de teleprompter que muestra un texto poco a poco. Esto se consigue haciendo uso de la clase AppearingText que permite acompañar el texto con un sonido de caracter.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/teleprompter.gif)]

#### Dialogo

Para la secuencia final, se ha creado un sistema de dialogo que hace uso de los ScriptableObjects de Unity. Para crear un dialogo, se ha de crear un Asset de tipo DialogData que permite definir distintas características del dialogo como lineas, nombre del personaje, sonido y eventos.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/dialog.png)]

El sistema de dialog (UIDialog) usa finalmente el sistema de teleprompter y los datos del dialog para mostrarlo al usuario, el cual puede avanzarlo rápidamente.

#### Puntuación

Durante el gameplay, se muestra una UI animada con las puntuación actual. Esta UI reproduce distintas animacíones cuando el jugador obtiene o pierde puntuación.

## Animaciones

#### Jugador

El jugador hace uso de distintas animaciones que se reproducen dependiendo de los parametros del Animator, como la velocidad del jugador o su estado de "Grounded".

También se ha usado la clase AnimationEventHandler que se usa para definir callbacks a eventos de la animación, por ejemplo, los sonidos y efectos de las pisadas del personaje.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/animevent1.png)]

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/animevent2.png)]

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/animevent3.png)]

#### Objetos rompibles

Los objetos rompibles tienen una animación básica de ruptura y desaparición

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/breakable.gif)]

#### UI

Como se ha descrito, la UI tiene diversas animaciónes para cuando el jugador obtiene o pierte energía al morir.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/score1.gif)]
[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/score2.gif)]

#### Secuencia final

Para la secuencia final se ha hecho uso de una animación para reproducir los distintos sonidos y efectos.

## Físicas

Con el fin de optimizar al máximo las colisíones del juego se han creado capas físicas para funcionalidades específicas del juego.

Las más generales, usadas para triggers y elementos únicamente centrados en el jugador, son Player y OnlyCollidesWithPlayer.

Para las interaccioes, como palancas y cajas, se han usado Interactor y Interactable. De forma que las cajas también pueden accionar placas y palancas.

Para los sistemas de vida, se han utilizado Damageable y Hazard. Podriamos usar estas mismas capas si se añadieran otros enemigos en el futuro aunque por norma general se requiere un sistema de daño más complejo.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/physics.png)]

Los únicos elementos dinámicos del juego son el jugador y las cajas, el resto son estáticos o cinemáticos.

## Eventos

Al igual que en prácticas anteriores se han utilizado UnityEvents, buffer de mensajes y adicionalmente para este prototipo, eventos de diseño :

### UnityEvents

Los UnityEvents actuan prácticamente como delegates pero tienen la ventaja que se exponen adecuadamente en el inspector de Unity. 

Los eventos más utilizados han sido OnTriggerEnter y OnTriggerExit (de la clase TriggerListener) que se usan para palancas, placas y otros elementos del juego y permite el prototipado rápido de reacciones al entrar en contacto el jugador con un collider al usar las capas adecuadas.

Los UnityEvents son usados también para muchas otras acciones. Por ejemplo, AppearingText expone los eventos OnStartShowing y OnShowAll. Estos eventos son utilizados por el sistema de dialog para mostrar una imagen al jugador que indica que puede pulsar para continuar.

### Buffer de eventos

El buffer de eventos, nos permite enviar eventos de forma global que son recogidos por las clases subscritas. Internamente, el buffer de eventos usa UnityEvents.

Este sistema se usa normalmente para conectar sistemas de forma desacoplada, sin necesidad de establer relaciones en la escene o el editor.

### Eventos de diseño

Los eventos de diseño se han implementado para permitir, durante la fase de diseño (es decir, sin requerir la edición de código), definir eventos que son lanzados y recogidos por distintos elementos del juego.

Estos eventos son ScriptableObjects y por lo tanto son assets del proyecto, de forma que pueden arrastrarse en el inspector.

Por ejemplo, un fichero de datos de dialogo, permite lanzar eventos de diseño al comezar y terminar el dialogo.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/designevent.png)]

Tanto el dialogo, como el evento, son assets que pueden ser creados por diseñadores en el editor y por lo tanto no requieren código.

Al comenzar y finalizar el dialogo, el sistema de dialogo enviará, usando el buffer de eventos, un evento de tipo DesignEvent que contiene el asset de evento incorporado. 

Otros elementos del juego podrán escuchar y actuar a este evento usando el componente DesignEventListener que usa UnityEvent para definir en el inspector lo que sucederá cuando el evento sea recibido.

Por ejemplo, al terminar el dialogo final, se activa la animación que finaliza el prototipo, se desactiva al jugador principal (ya que la animación tiene un sprite propio que representa al personaje) y se desactiva una cámara secundaria.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/designeventlistener.png)]

## Técnicas

Adicionalmente se han hecho uso de otrás técnicas estudiadas en clase como Pooling y Parallax:

#### Pooling

El sistema de pooling se ha utilizado para la creación de los distintos efectos del jugador, como huellas, explosión de muerte, aterrizaje, etc...

También se ha utilizado para la instanciación de cajas.

#### Parallax

Debido al diseño del nivel no había necesidad de hacer un parallax continuo, pero se han creado paqueñas áreas exteriores que hacen uso de la técnica parallax dependiendo de la posición de la camara.

[![](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entregaFinal/parallax.gif)]