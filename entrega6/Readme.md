
# Programación de Scrips en C#

En esta práctica hemos realizado un pequeño videojuego que se ajusta a los siguientes requerimientos:

* Los objetos se distribuyen por la escena y se catalogan en dos tipos, en movimiento rectilíneo y estáticos.
* Los objetos estáticos actualizan su posición cada cierto tiempo intercambian sus posiciones.
* Cada objeto proporciona una puntuación diferente.
* El jugador incrementa su puntuación siempre que esté a una distancia menor que un umbral del objeto.
* Cuando el jugador suma puntos, las dimensiones del objeto disminuyen y se atenúa su color, cuando se llega a un umbral desaparece el objeto.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega6/screen1.gif)

## PowerUps

### PowerUpController

Los PowerUps son instanciados y distribuidos por el nivel aleatoriamente por el PowerUpController.

Los PowerUps estáticos son distribuidos por el nivel usando puntos preestablecidos de aparición (o spawn). 

Los PowerUps dinámicos son distribuidos por el nivel usando puntos preestablecidos como su ruta de movimiento. Haciendo uso del componente LinearPathFollower.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega6/screen1.png)

Después de un intervalo preestablecido de tiempo los objetos estáticos intercambian su posición.

### PowerUp

La clase PowerUp nos permite establecer puntuaciones y ratios de consumición diferentes para cada objeto.

La clase actualiza el estado del objeto si este es consumido, cambiando su color, reduciendo el tamaño del elemento visual (permaneciendo el trigger del mismo tamaño) y adicionalmente, aumentando su velocidad de rotación.

La consumición del objeto es realizado por el componente PowerUpCollector que puede estar adjuntado a uno o varios jugadores.

### PowerUpCollector

Éste componente controla los PowerUps que entran o salen de su trigger y los registra en una lista para su consumición. 

Durante el update, se consumen progresivamente los PowerUps que están dentro del trigger.

Para optimizar el sistema. Ambos componentes, los colliders que hacen uso de PowerUps y PowerUpCollector están en una capa física propia, llamada PowerUpSystem. Evitando de esta forma que otros objetos estén registrando las colisiones con estos triggers. 

Adicionalmente, el component se deshabilita a si mismo para evitar llamadas innecesarias al método Update cuando no tiene PowerUps que consumir.  

Para simplificar la práctica, el componente también lleva el seguimiento de los puntos obtenidos por el jugador aunque esto podría moverse a una clase de información general del estado de la partida.

## Movimiento del jugador

Para esta práctica se ha utilizado un personaje del AssetStore y se ha adaptado, simplificado y optimizado uno de los componentes de movimiento para integrarlo en el proyecto. El movimiento, rotación y actualización del Animator del personaje principal se realiza en el componente PlayerMovement.

La clase PlayerMovement utiliza el sistema de input tradicional de Unity, obteniendo los ejes de movimiento vertical y horizontal. Estos valores son transformados a direcciones relativas a la cámara y finalmente se aplican al Transform del jugador, adicionalmente, se realizan varias interpolaciones para suavizar su movimiento y rotación.

También se actualiza el parámetro \_Speed en el Animator que es usado para controlar la animación del personaje. 

## UI y Eventos

Para mostrar los puntos en la interfaz del usuario hemos creado un sistema de eventos global que permite a los componentes comunicarse de forma desacoplada.

Cuando el PowerUpCollector consume alguno de los PowerUps y aumenta la puntuación, éste envía un evento global para avisar a otros sistemas de que la puntuación ha cambiado (usando la clase OnScoreUpdatedEvent en PowerUpCollector).

La clase UIScore se registra al evento al comenzar la aplicación y actualiza el texto al recibir el evento.



